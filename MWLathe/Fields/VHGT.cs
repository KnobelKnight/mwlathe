namespace MWLathe.Helpers
{
    public class VHGT
    {
        public static readonly uint StructSize = 4232;
        public float Offset { get; set; }
        // 65 x 65
        public List<List<sbyte>> Data { get; set; } = new List<List<sbyte>>();
    }
}
