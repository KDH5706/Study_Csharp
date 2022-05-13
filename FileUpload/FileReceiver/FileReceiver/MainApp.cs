using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using FUP;

namespace FileReceiver
{
    class MainApp
    {
        static void Main(string[] args)
        {
            if(args.Length < 1)
            {
                Console.WriteLine("사용법 : {0} <Directory>",
                    Process.GetCurrentProcess().ProcessName);
                return;
            }
            uint msgId = 0;

            string dir = args[0];
            // args[0] 이름의 디렉터리가 존재하지 않을 경우 CreateDirectory메소드를 이용하여 디렉터리 생성
            if (Directory.Exists(dir) == false)
                Directory.CreateDirectory(dir);

            const int bindPort = 5425;      //서버포트 : 5425
            TcpListener server = null;
            try
            {
                //localAddress : 127.0.0.1:5425 (0으로 입력하면 해당 OS의 주소로도 서버에 접속이 가능)
                IPEndPoint localAddress =
                    new IPEndPoint(0, bindPort);

                server = new TcpListener(localAddress);

                //연결 요청 수신 대기 상태로 진입
                server.Start();

                Console.WriteLine("파일 업로드 서버 시작...");

                while (true)
                {
                    //클라이언트의 연결 요청을 수락한다. 리턴 값은 TcpClient 객체를 반환한다.
                    TcpClient client = server.AcceptTcpClient();

                    //클라이언트의 주소를 cmd창에 출력한다.
                    Console.WriteLine("클라이언트 접속 : {0}",
                        ((IPEndPoint)client.Client.RemoteEndPoint).ToString());

                    //데이터를 주고받는 데 사용하는 매개체인 NetworkStream을 가져온다.
                    NetworkStream stream = client.GetStream();

                    //클라이언트로부터 받아온 메세지를 reqMsg 객체에 정의
                    Message reqMsg = MessageUtil.Receive(stream);

                    //메세지 reqMsg의 헤더에 있는 MSGTYPE이 0x01이 아닐 경우(파일 전송 요청을 한 경우가 아닌 경우)
                    if (reqMsg.Header.MSGTYPE != CONSTANTS.REQ_FILE_SEND)
                    {
                        stream.Close();
                        client.Close();
                        continue;
                    }

                    /*파일 전송 요청을 한 경우(Header.MSGTYPE == 1) 아래의 코드를 실행*/
                    /*-- 서버측에서 클라이언트 측으로 보내는 파일 전송 요청에 대한 응답 코드 시작 지점 --*/

                    BodyRequest reqBody = (BodyRequest)reqMsg.Body;

                    Console.WriteLine(
                        "파일 업로드 요청이 왔습니다. 수락하시겠습니까? yes/no");
                    string answer = Console.ReadLine();

                    //요청에 대한 응답(rspMsg)에 필요한 Message 정의
                    Message rspMsg = new Message();

                    rspMsg.Body = new BodyResponse()
                    {
                        //클라이언트 측에서 보낸 파일 전송 요청 메시지의 메세지 식별 번호
                        MSGID = reqMsg.Header.MSGID,
                        //파일 전송 승인을 하였기 때문에 0x1로 정의
                        RESPONSE = CONSTANTS.ACCEPTED
                    };
                    rspMsg.Header = new Header()
                    {
                        //요청에 대한 응답 Message이므로 
                        MSGID = msgId++,    //MSGID : 1 (왜 msgId++가 1이 되는지... 몰루)
                        MSGTYPE = CONSTANTS.REP_FILE_SEND,  //MSGTYPE : 0x02
                        BODYLEN = (uint)rspMsg.Body.GetSize(),  //BODYLEN : 5 (sizeof(uint) + sizeof(byte))
                        FRAGMENTED = CONSTANTS.NOT_FRAGMENTED,  //FRAGMENTED : 0x00
                        LASTMSG = CONSTANTS.LASTMSG,    //LASTMSG : 0x01
                        SEQ = 0
                    };

                    //응답 거부 할 경우
                    if (answer != "yes")
                    {
                        rspMsg.Body = new BodyResponse()
                        {
                            MSGID = reqMsg.Header.MSGID,
                            //파일 전송 승인 거부 하였기 때문에 0x0으로 정의
                            RESPONSE = CONSTANTS.DENIED
                        };
                        MessageUtil.Send(stream, rspMsg);
                        stream.Close();
                        client.Close();

                        continue;
                    }
                    else
                        MessageUtil.Send(stream, rspMsg);
                    /*-- 서버측에서 클라이언트 측으로 보내는 파일 전송 요청에 대한 응답 코드 끝 지점 --*/

                    Console.WriteLine("파일 전송을 시작합니다...");

                    /*--- 클라이언트 측으로 부터 받은 파일을 복사하는 코드 시작 지점 ---*/

                    //클라이언트 측에서 보내는 파일의 크기를 확인
                    long fileSize = reqBody.FILESIZE;

                    //읽어온 바이트 배열을(reqBody.FILENAME) 문자열로(fileName) 디코딩한다.
                    string fileName = Encoding.Default.GetString(reqBody.FILENAME);

                    //디렉터리(args[0])\\fileName으로 파일을 생성한다.
                    FileStream file =
                        new FileStream(dir + "\\" + fileName, FileMode.Create);

                    /* Value Type(정수, 부동자릿수, 구조체 등)은 NULL 값을 가질 수 없지만, Type 뒤에 ?를 붙이면
                     * 해당 타입이 Nullable 타입이 되면서 NULL 값이 허용 됨 */
                    
                    uint? dataMsgId = null;
                    ushort prevSeq = 0;

                    //클라이언트 측에서 보낸 Message가 NULL이 아닐 때 까지 반복
                    while ((reqMsg = MessageUtil.Receive(stream)) != null)
                    {
                        //Console.Write("#");

                        //메세지 reqMsg의 헤더에 있는 MSGTYPE이 0x03이 아닐 경우(파일 전송 데이터가 아닌 경우)
                        if (reqMsg.Header.MSGTYPE != CONSTANTS.FILE_SEND_DATA)
                            break;

                        // 이하 코드는 reqMsg의 헤더에 있는 MSGTYPE이 0x03인 경우(파일 전송 데이터인 경우)

                        // data의 메시지 식별 번호를 통해 메시지들을 식별??
                        if (dataMsgId == null)
                            dataMsgId = reqMsg.Header.MSGID;
                        else
                        {
                            if (dataMsgId != reqMsg.Header.MSGID)
                                break;
                        }

                        //메시지 파편 번호를 통해 분할된 메시지 유무 확인??
                        if(prevSeq++ != reqMsg.Header.SEQ)
                        {
                            Console.WriteLine("{0}, {1}", prevSeq, reqMsg.Header.SEQ);
                            break;
                        }

                        //지정된 디렉토리에 파일 작성
                        file.Write(reqMsg.Body.GetBytes(), 0, reqMsg.Body.GetSize());

                        //클라이언트 측에서 보낸 메시지가 분할된 메시지가 아니면 종료
                        if (reqMsg.Header.FRAGMENTED == CONSTANTS.NOT_FRAGMENTED)
                            break;
                        //클라이언트 측에서 보낸 분할된 메시지가 마지막 파편이면 종료
                        if (reqMsg.Header.LASTMSG == CONSTANTS.LASTMSG)
                            break;
                    }

                    long recvFileSize = file.Length;
                    file.Close();

                    Console.WriteLine();
                    Console.WriteLine("수신 파일 크기 : {0} bytes", recvFileSize);

                    /*--- 클라이언트 측으로 부터 받은 파일을 복사하는 코드 끝 지점 ---*/

                    /*--- 파일 수신 결과 메시지를 클라이언트 측에 보내는 코드 시작 지점 ---*/

                    Message rstMsg = new Message();
                    rstMsg.Body = new BodyResult()
                    {
                        MSGID = reqMsg.Header.MSGID,
                        RESULT = CONSTANTS.SUCCESS
                    };
                    rstMsg.Header = new Header()
                    {
                        // 수신 결과를 클라이언트에 보내는 Message이므로
                        MSGID = msgId++,    //MSGID : 3 (왜 msgId++가 3이 되는지... 몰루)
                        MSGTYPE = CONSTANTS.FILE_SEND_RES,  //MSGTYPE : 0x04
                        BODYLEN = (uint)rstMsg.Body.GetSize(),  //BODYLEN : 5 (sizeof(uint) + sizeof(byte))
                        FRAGMENTED = CONSTANTS.NOT_FRAGMENTED,  //FRAGMENTED : 0x00
                        LASTMSG = CONSTANTS.LASTMSG,    //LASTMSG : 0x01
                        SEQ = 0
                    };

                    //클라이언트 측에서 보낸 파일의 크기와(fileSize) 서버측에서 복사한 파일의 크기(recvFileSize) 비교
                    if (fileSize == recvFileSize)
                        MessageUtil.Send(stream, rstMsg);   //클라이언트 측으로 성공 수신 메시지 전송
                    else
                    {
                        rstMsg.Body = new BodyResult()
                        {
                            MSGID = reqMsg.Header.MSGID,
                            RESULT = CONSTANTS.FAIL
                        };

                        MessageUtil.Send(stream, rstMsg);   //클라이언트 측으로 실패 수신 메시지 전송
                    }
                    Console.WriteLine("파일 전송을 마쳤습니다.");

                    stream.Close();
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                server.Stop();
            }

            Console.WriteLine("서버를 종료합니다.");
        }
    }
}
