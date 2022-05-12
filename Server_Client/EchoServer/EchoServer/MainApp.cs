using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace EchoServer
{
    class MainApp
    {
        static void Main(string[] args)
        {
            if(args.Length < 1)
            {
                Console.WriteLine("사용법 : {0} <Bind IP>",
                    Process.GetCurrentProcess().ProcessName);
                return;
            }

            string bindIp = args[0];
            const int bindPort = 5425;
            TcpListener server = null;

            try
            {
                //localAddress : 127.0.0.1:5425
                IPEndPoint localAddress =
                    new IPEndPoint(IPAddress.Parse(bindIp), bindPort);

                server = new TcpListener(localAddress);

                //연결 요청 수신 대기 상태로 진입
                server.Start();

                Console.WriteLine("메아리 서버 시작...");

                while (true)
                {
                    //클라이언트의 연결 요청을 수락한다. 리턴 값은 TcpClient 객체를 반환한다.
                    TcpClient client = server.AcceptTcpClient();

                    //클라이언트의 주소를 cmd창에 출력한다.
                    Console.WriteLine("클라이언트 접속 : {0}",
                        ((IPEndPoint)client.Client.RemoteEndPoint).ToString());

                    //데이터를 주고받는 데 사용하는 매개체인 NetworkStream을 가져온다.
                    NetworkStream stream = client.GetStream();

                    int length;
                    string data = null;
                    byte[] bytes = new byte[256];

                    //NetworkStream에서 데이터를 읽고 바이트 배열에(bytes) 저장. 읽은 바이트의 수 만큼 리턴 받아서 length에 저장
                    while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        //읽어온 바이트 시퀀스를(bytes) 문자열로(data) 디코딩한다.
                        data = Encoding.Default.GetString(bytes, 0, length);
                        Console.WriteLine(String.Format("수신 : {0}", data));

                        //디코딩한 문자열을(data) 바이트 시퀀스로(msg) 인코딩한다.
                        byte[] msg = Encoding.Default.GetBytes(data);
                        //바이트 시퀀스로(msg) 인코딩 된 바이트 배열에서 NetworkStream에 데이터를 작성한다.
                        stream.Write(msg, 0, msg.Length);
                        Console.WriteLine(String.Format("송신 : {0}", data));
                    }

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
