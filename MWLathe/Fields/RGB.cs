namespace MWLathe.Helpers
{
    public class RGB
    {
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }

        public void Write(FileStream ts, bool includeAlpha)
        {
            ts.WriteByte(Red);
            ts.WriteByte(Green);
            ts.WriteByte(Blue);
            if (includeAlpha)
            {
                ts.WriteByte(0);
            }
        }
    }
}
