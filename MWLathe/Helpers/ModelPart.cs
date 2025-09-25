using System.Text;

namespace MWLathe.Helpers
{
    public class ModelPart
    {
        public byte BipedObject { get; set; }
        public string? MaleModel { get; set; }
        public string? FemaleModel { get; set; }

        public uint GetByteSize()
        {
            uint byteSize = 9; // BipedObject + field + size
            if (MaleModel is not null)
            {
                byteSize += (uint)(8 + MaleModel.Length);
            }
            if (FemaleModel is not null)
            {
                byteSize += (uint)(8 + FemaleModel.Length);
            }
            return byteSize;
        }

        public void Write(FileStream ts)
        {
            ts.Write(Encoding.GetEncoding("Windows-1252").GetBytes("INDX"));
            ts.Write(BitConverter.GetBytes(1));
            ts.WriteByte(BipedObject);
            if (MaleModel != null)
            {
                ts.Write(Encoding.GetEncoding("Windows-1252").GetBytes("BNAM"));
                ts.Write(BitConverter.GetBytes(MaleModel.Length));
                ts.Write(Encoding.GetEncoding("Windows-1252").GetBytes(MaleModel));
            }
            if (FemaleModel != null)
            {
                ts.Write(Encoding.GetEncoding("Windows-1252").GetBytes("CNAM"));
                ts.Write(BitConverter.GetBytes(FemaleModel.Length));
                ts.Write(Encoding.GetEncoding("Windows-1252").GetBytes(FemaleModel));
            }
        }
    }
}
