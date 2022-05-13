using System;
using System.IO;

namespace FUP
{
    public class MessageUtil
    {
        public static void Send(Stream writer, Message msg)
        {
            writer.Write(msg.GetBytes(), 0, msg.GetSize());
        }

        public static Message Receive(Stream reader)
        {
            int totalRecv = 0;
            int sizeToRead = 16;    //Header부터 읽어오기 때문에 16으로 초기화
            //16바이트 크기의 바이트 배열 hBuffer 정의
            byte[] hBuffer = new byte[sizeToRead];

            //**** Header ****//    //참고 P.771 ~ P.772
            while (sizeToRead > 0)
            {
                byte[] buffer = new byte[sizeToRead];
                //sizeToRead 만큼 데이터를 읽고 바이트 배열에(buffer) 저장. 읽은 바이트의 수 만큼 리턴 받아서 recv에 저장
                int recv = reader.Read(buffer, 0, sizeToRead);
                if (recv == 0)
                    return null;

                //바이트 배열(buffer)에 존재 하는 데이터를 hBuffer에 Copy한다.
                buffer.CopyTo(hBuffer, totalRecv);
                //Header를 정상적으로 읽었을 경우 totalRecv = 16
                totalRecv += recv;
                //Header를 정상적으로 읽었을 경우 sizeToRead = 0
                sizeToRead -= recv;
            }

            //while문을 통해서 정의된 hBuffer를 이용하여 header 객체 생성
            Header header = new Header(hBuffer);

            //totalRecv 초기화
            totalRecv = 0;

            //header에 존재하는 BODYLEN 정보를 이용하여 바이트 배열(bBuffer) 생성
            byte[] bBuffer = new byte[header.BODYLEN];
            //읽어올 데이터의 사이즈 sizeToRead를 정의
            sizeToRead = (int)header.BODYLEN;

            //**** Body ****//    //참고 P.771 ~ P.772
            while (sizeToRead > 0)
            {
                byte[] buffer = new byte[sizeToRead];
                //sizeToRead 만큼 데이터를 읽고 바이트 배열에(buffer) 저장. 읽은 바이트의 수 만큼 리턴 받아서 recv에 저장
                int recv = reader.Read(buffer, 0, sizeToRead);
                if (recv == 0)
                    return null;

                //바이트 배열(buffer)에 존재하는 데이터를 bBuffer에 Copy한다.
                buffer.CopyTo(bBuffer, totalRecv);
                //Body를 정상적으로 읽었을 경우 totalRecv는 Body의 사이즈[(int)header.BODYLEN]와 동일
                totalRecv += recv;
                //Body를 정상적으로 읽었을 경우 sizeToRead = 0
                sizeToRead -= recv;
            }


            /*--------------- 리펙토링 대상 : Factory Method 형식으로 ---------------*/
            //header.MSGTYPE에 따라서 Body를 정의함
            ISerializable body = null;      //의문점: 인터페이스로 객체 생성이 되나...? 안되서 NULL한거겠지?
            switch (header.MSGTYPE)
            {
                case CONSTANTS.REQ_FILE_SEND:
                    body = new BodyRequest(bBuffer);
                    break;
                case CONSTANTS.REP_FILE_SEND:
                    body = new BodyResponse(bBuffer);
                    break;
                case CONSTANTS.FILE_SEND_DATA:
                    body = new BodyData(bBuffer);
                    break;
                case CONSTANTS.FILE_SEND_RES:
                    body = new BodyResult(bBuffer);
                    break;
                default:
                    throw new Exception(
                        String.Format(
                            "Unknown MSGTYPE : {0}", header.MSGTYPE));
            }

            //Message 클래스를 통해 header와 body를 이용하여 객체를 생성 후 리턴
            return new Message() { Header = header, Body = body };
        }
    }
}
