using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using FUP;

namespace FileSender
{
    class MainApp
    {
        const int CHUNK_SIZE = 4096;

        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine(
                    "사용법 : {0} <Server IP> <File Path>",
                    Process.GetCurrentProcess().ProcessName);
                return;
            }

            string serverIp = args[0];  //서버측의 IP
            const int serverPort = 5425;
            string filepath = args[1];  //클라이언트에서 서버로 보낼 파일명(확장자 포함)

            try
            {
                //clientAddress : OS에서 할당한 IP주소와 포트로 바인딩
                IPEndPoint clientAddress = new IPEndPoint(0, 0);
                //serverAddress : 127.0.0.1:5425
                IPEndPoint serverAddress =
                    new IPEndPoint(IPAddress.Parse(serverIp), serverPort);

                Console.WriteLine("클라이언트: {0}, 서버:{1}",
                    clientAddress.ToString(), serverAddress.ToString());

                uint msgId = 0;

                //서버에게 파일 전송을 요청(reqMsg)하기 위한 Message 정의
                Message reqMsg = new Message();

                reqMsg.Body = new BodyRequest()
                {
                    FILESIZE = new FileInfo(filepath).Length,
                    //문자열을(filepath) 바이트 시퀀스로(FILENAME) 인코딩한다.
                    FILENAME = System.Text.Encoding.Default.GetBytes(filepath)
                };
                reqMsg.Header = new Header()
                {
                    //요청에 대한 응답 Message이므로 
                    MSGID = msgId++,    //MSGID : 0 (왜 msgId++가 0이 되는지... 몰루)
                    MSGTYPE = CONSTANTS.REQ_FILE_SEND,  //MSGTYPE : 0x01
                    BODYLEN = (uint)reqMsg.Body.GetSize(),  //BODYLEN : sizeof(long) + FILENAME.Length
                    FRAGMENTED = CONSTANTS.NOT_FRAGMENTED,  //FRAGMENTED : 0x00
                    LASTMSG = CONSTANTS.LASTMSG,    //LASTMSG : 0x01
                    SEQ = 0
                };

                TcpClient client = new TcpClient(clientAddress);
                //서버에 연결을 요청한다.
                client.Connect(serverAddress);

                //데이터를 주고받는 데 사용하는 매개체인 NetworkStream을 가져온다.
                NetworkStream stream = client.GetStream();

                //클라이언트는 서버에 접속을 하자마자 파일 전송 요청 메세지를 보낸다
                MessageUtil.Send(stream, reqMsg);

                //서버로부터 응답을 받는다.
                Message rspMsg = MessageUtil.Receive(stream);

                //메세지 rspMsg의 헤더에 있는 MSGTYPE이 0x02가 아닐 경우(파일 전송 요청에 대한 응답을 한 경우가 아닌 경우)
                if (rspMsg.Header.MSGTYPE != CONSTANTS.REP_FILE_SEND)
                {
                    Console.WriteLine("정상적인 서버 응답이 아닙니다. {0}",
                        rspMsg.Header.MSGTYPE);
                    return;
                }

                /*파일 전송 요청에 대한 응답을 한 경우(Header.MSGTYPE == 2) 아래의 코드를 실행*/

                //서버로부터 응답 받은 Message의 Body의 RESPONSE가 0 인 경우 (서버가 파일 전송 승인을 거절 한 경우)
                if (((BodyResponse)rspMsg.Body).RESPONSE == CONSTANTS.DENIED)
                {
                    Console.WriteLine("서버에게 파일 전송을 거부했습니다.");
                    return;
                }

                /*서버가 파일 전송 승인을 승인 한 경우(rspMsg.Body.RESPONSE == 1) 아래의 코드를 실행*/

                /*-- 클라이언트 측에서 서버 측으로 파일을 전송하는 코드 시작 지점 --*/

                //클라이언트에서 서버로 보낼 파일을 Open 한다.
                using (Stream fileStream = new FileStream(filepath, FileMode.Open))
                {

                    //CHUNK_SIZE(4096) 크기의 바이트 배열(rbytes) 선언
                    byte[] rbytes = new byte[CHUNK_SIZE];

                    //왜 사용하는지 몰루
                    long readValue = BitConverter.ToInt64(rbytes, 0);

                    int totalRead = 0;
                    ushort msgSeq = 0;

                    //보낼 파일의 길이가(fileStream.Length) CHUNK_SIZE(4096)보다 작으면 0, 크면 1 (메시지 분할 여부 정의)
                    byte fragmented =
                        (fileStream.Length < CHUNK_SIZE) ?
                        CONSTANTS.NOT_FRAGMENTED : CONSTANTS.FRAGMENTED;

                    while (totalRead < fileStream.Length)
                    {
                        //데이터를 읽고 바이트 배열에(rbytes) 저장한다. 읽은 바이트의 수 만큼 리턴 받아서 read에 저장
                        int read = fileStream.Read(rbytes, 0, CHUNK_SIZE);
                        //totalRead 갱신
                        totalRead += read;

                        Message fileMsg = new Message();

                        //read크기 만큼의 바이트 배열 생성
                        byte[] sendBytes = new byte[read];

                        //파일에서 읽어들인 데이터 배열을(rbytes) 보낼 데이터 배열에(sendBytes) 복사
                        //실제로 보낼 데이터의 크기가 CHUNK_SIZE보다 작을수도 있기 때문에 해당 연산이 필요함(추측)
                        Array.Copy(rbytes, 0, sendBytes, 0, read);

                        //sendBytes를 이용하여 Body 구성
                        fileMsg.Body = new BodyData(sendBytes);
                        fileMsg.Header = new Header()
                        {
                            //파일 전송 데이터 Message이므로
                            MSGID = msgId,  // MSGID : 2(왜 2가 되는지... 몰루)
                            MSGTYPE = CONSTANTS.FILE_SEND_DATA,  //MSGTYPE : 0x03
                            BODYLEN = (uint)fileMsg.Body.GetSize(),  //BODYLEN : 0 ~ CHUNK_SIZE
                            FRAGMENTED = fragmented,  //메시지 분할 여부(미분할 : 0x0 / 분할 : 0x1)
                            LASTMSG = (totalRead < fileStream.Length) ? //갱신한 totalRead가 전체 크기보다
                                       CONSTANTS.NOT_LASTMSG :          //작으면 0(분할된 메시지가 마지막이 아님을 의미)
                                       CONSTANTS.LASTMSG,               //같으면 1(분할된 메시지가 마지막임을 의미)
                            SEQ = msgSeq++      //메시지의 파편 번호 지정
                        };

                        //정의된 Header와 Body를 서버측으로 전송
                        MessageUtil.Send(stream, fileMsg);
                    }

                    Console.WriteLine();
                    /*-- 클라이언트 측에서 서버 측으로 파일을 전송하는 코드 끝 지점 --*/

                    /*-- 파일을 보낸 후 서버측으로부터 결과를 리턴 받는 코드 시작 지점 --*/

                    //서버측으로부터 파일 전송 결과 Message를 받아서 rstMsg로 정의
                    Message rstMsg = MessageUtil.Receive(stream);

                    //서버로부터 받은 Message의 Body를 result로 정의
                    BodyResult result = ((BodyResult)rstMsg.Body);

                    //서버로부터 받은 Message의 Body(result)에 있는 RESULT 값이 1이면 TRUE
                    Console.WriteLine("파일 전송 성공 : {0}",
                        result.RESULT == CONSTANTS.SUCCESS);
                    /*-- 파일을 보낸 후 서버측으로부터 결과를 리턴 받는 코드 끝 지점 --*/
                }

                stream.Close();
                client.Close();
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("클라이언트를 종료합니다.");
        }
    }
}
