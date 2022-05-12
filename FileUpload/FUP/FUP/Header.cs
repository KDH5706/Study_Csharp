﻿using System;

namespace FUP
{
    public class Header : ISerializable
    {
        public uint MSGID { get; set; }
        public uint MSGTYPE { get; set; }
        public uint BODYLEN { get; set; }
        public byte FRAGMENTED { get; set; }
        public byte LASTMSG { get; set; }
        public ushort SEQ { get; set; }

        public Header() { }
        public Header(byte[] bytes)
        {
            MSGID = BitConverter.ToUInt32(bytes, 0);    //bytes[0] ~ bytes[3]   : 4바이트
            MSGTYPE = BitConverter.ToUInt32(bytes, 4);  //bytes[4] ~ bytes[7]   : 4바이트
            BODYLEN = BitConverter.ToUInt32(bytes, 8);  //bytes[8] ~ bytes[11]  : 4바이트
            FRAGMENTED = bytes[12];
            LASTMSG = bytes[13];
            SEQ = BitConverter.ToUInt16(bytes, 14);     //bytes[14] ~ bytes[15] : 2바이트
        }

        public byte[] GetBytes()
        {
            byte[] bytes = new byte[16];

            byte[] temp = BitConverter.GetBytes(MSGID);
            Array.Copy(temp, 0, bytes, 0, temp.Length);

            temp = BitConverter.GetBytes(MSGTYPE);
            Array.Copy(temp, 0, bytes, 4, temp.Length);

            temp = BitConverter.GetBytes(BODYLEN);
            Array.Copy(temp, 0, bytes, 8, temp.Length);

            bytes[12] = FRAGMENTED;
            bytes[13] = LASTMSG;

            temp = BitConverter.GetBytes(SEQ);
            Array.Copy(temp, 0, bytes, 14, temp.Length);

            return bytes;
        }

        public int GetSize()
        {
            return 16;
        }
    }
}
