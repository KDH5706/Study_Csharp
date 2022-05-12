using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace EchoClient
{
    class MainApp
    {
        static void Main(string[] args)
        {
            if(args.Length < 4)
            {
                Console.WriteLine(
                    "사용법 : {0} <Bind IP> <Bind Port> <Server IP> <Message>",
                    Process.GetCurrentProcess().ProcessName);
                return;
            }

            string bindIp = args[0];
            int bindPort = Convert.ToInt32(args[1]);
            string serverIp = args[2];
            const int serverPort = 5425;
            string message = args[3];

            try
            {
                //clientAddress : 127.0.0.1:10000
                IPEndPoint clientAddress =
                    new IPEndPoint(IPAddress.Parse(bindIp), bindPort);
                //serverAddress : 127.0.0.1:5425
                IPEndPoint serverAddress =
                    new IPEndPoint(IPAddress.Parse(serverIp), serverPort);

                //클라이언트 주소와 서버 주소를 cmd창에 출력
                Console.WriteLine("클라이언트: {0}, 서버: {1}",
                    clientAddress.ToString(), serverAddress.ToString());

                //clientAddress를 이용하여 client 객체 생성
                TcpClient client = new TcpClient(clientAddress);

                //서버에 연결을 요청한다.
                client.Connect(serverAddress);

                //cmd 창에서 입력한 message를 바이트 시퀀스로 인코딩한다.
                byte[] data = Encoding.Default.GetBytes(message);

                //데이터를 주고받는 데 사용하는 매개체인 NetworkStream을 가져온다.
                NetworkStream stream = client.GetStream();

                //바이트 시퀀스로 인코딩 된 바이트 배열에서 NetworkStream에 데이터를 작성한다.
                stream.Write(data, 0, data.Length);

                //cmd창에서 입력한 message를 cmd창에 출력
                Console.WriteLine("송신: {0}", message);

                //바이트 배열 초기화
                data = new byte[256];

                string responseData = "";

                //NetworkStream에서 데이터를 읽고 바이트 배열에(data) 저장한다. 읽은 바이트의 수 만큼 리턴 받아서 bytes에 저장
                int bytes = stream.Read(data, 0, data.Length);

                //읽어온 바이트 시퀀스를(data) 문자열로(responseData) 디코딩한다.
                responseData = Encoding.Default.GetString(data, 0, bytes);

                //cmd창에 수신한 문자열을 출력
                Console.WriteLine("수신: {0}", responseData);

                //NetworkStream을 닫는다.
                stream.Close();
                //TcpClient 인스턴스를 삭제하고 내부 TCP 연결을 닫는다.
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
