using System.Text;

namespace MWLathe.Helpers
{
    public class BYDT
    {
        public static readonly uint StructSize = 4;
        public byte Part { get; set; }
        public byte Vampiric { get; set; }
        public byte Flags { get; set; }
        public byte Type { get; set; }

        public void Write(FileStream ts)
        {
            ts.Write(Encoding.GetEncoding("Windows-1252").GetBytes("BYDT"));
            ts.Write(BitConverter.GetBytes(StructSize));
            ts.WriteByte(Part);
            ts.WriteByte(Vampiric);
            ts.WriteByte(Flags);
            ts.WriteByte(Type);
        }
    }
}
