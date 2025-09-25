using System.Text;

namespace MWLathe.Helpers
{
    public class SOUN_DATA
    {
        public static readonly uint StructSize = 3;
        public byte Volume { get; set; }
        public byte MinRange { get; set; }
        public byte MaxRange { get; set; }

        public void Write(FileStream ts)
        {
            ts.Write(Encoding.GetEncoding("Windows-1252").GetBytes("DATA"));
            ts.Write(BitConverter.GetBytes(StructSize));
            ts.WriteByte(Volume);
            ts.WriteByte(MinRange);
            ts.WriteByte(MaxRange);
        }
    }
}
