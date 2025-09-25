using MWLathe.Records;
using System.Text;

namespace MWLathe.Helpers
{
    public class AI_A : AIPackage
    {
        public string ID { get; set; }

        public override uint GetByteSize()
        {
            return 8 + 33;
        }

        public override void ReplaceID(string oldID, string newID)
        {
            if (ID.Equals(oldID, StringComparison.OrdinalIgnoreCase))
            {
                ID = newID;
            }
        }

        public override void Write(FileStream ts)
        {
            ts.Write(Encoding.GetEncoding("Windows-1252").GetBytes("AI_A"));
            ts.Write(BitConverter.GetBytes(33));
            ts.Write(Record.EncodeChar32(ID));
            ts.WriteByte(0); // Junk value
        }
    }
}
