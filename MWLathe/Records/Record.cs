﻿using System.Text;

namespace MWLathe.Records
{
    public abstract class Record
    {
        public uint RecordSize { get; set; }
        public uint RecordFlags { get; set; }
        public uint? Deleted { get; set; }

        public virtual void Populate(BufferedStream bs)
        {
            byte[] buffer = new byte[4];
            bs.Read(buffer, 0, 4);
            RecordSize = BitConverter.ToUInt32(buffer);
            // Junk bytes
            bs.Read(buffer, 0, 4);
            bs.Read(buffer, 0, 4);
            RecordFlags = BitConverter.ToUInt32(buffer);
        }

        public abstract void ReplaceID(string oldID, string newID);

        public virtual void CalculateRecordSize()
        {
            RecordSize = 0;
            if (Deleted.HasValue)
            {
                RecordSize += 12; // Field + size + data
            }
        }

        public virtual void Write(FileStream ts)
        {
            CalculateRecordSize();
            ts.Write(Encoding.GetEncoding("Windows-1252").GetBytes(GetType().Name));
            ts.Write(BitConverter.GetBytes(RecordSize));
            ts.Write(BitConverter.GetBytes(0));
            ts.Write(BitConverter.GetBytes(RecordFlags));
        }

        public static string ReadZString(BufferedStream bs)
        {
            List<byte> byteList = new List<byte>();
            int readByte;
            while ((readByte = bs.ReadByte()) > 0)
            {
                byteList.Add((byte)readByte);
            }
            return Encoding.GetEncoding("Windows-1252").GetString(byteList.ToArray());
        }

        public static string ReadStringField(BufferedStream bs, uint fieldSize)
        {
            uint fieldBytes = 0;
            var sb = new StringBuilder();
            byte[] buffer = new byte[256];
            while (fieldBytes < fieldSize)
            {
                int difference = (int)(fieldSize - fieldBytes);
                if (difference > 256)
                {
                    bs.Read(buffer, 0, 256);
                    sb.Append(Encoding.GetEncoding("Windows-1252").GetString(buffer, 0, 256));
                    fieldBytes += 256;
                }
                else
                {
                    bs.Read(buffer, 0, difference);
                    sb.Append(Encoding.GetEncoding("Windows-1252").GetString(buffer, 0, difference));
                    fieldBytes = fieldSize;
                }
            }
            return sb.ToString().TrimEnd('\0');
        }

        public static byte[] EncodeZString(string zString)
        {
            return Encoding.GetEncoding("Windows-1252").GetBytes(zString + '\0');
        }

        public static byte[] EncodeChar32(string inputString)
        {
            return Encoding.GetEncoding("Windows-1252").GetBytes(inputString.PadRight(32, '\0'));
        }
    }
}
