namespace MWLathe.Helpers
{
    public class RankData
    {
        public uint Attribute1Modifier { get; set; }
        public uint Attribute2Modifier { get; set; }
        public uint PrimarySkill { get; set; }
        public uint FavoredSkill { get; set; }
        public uint FactionReaction { get; set; }

        public void Write(FileStream ts)
        {
            ts.Write(BitConverter.GetBytes(Attribute1Modifier));
            ts.Write(BitConverter.GetBytes(Attribute2Modifier));
            ts.Write(BitConverter.GetBytes(PrimarySkill));
            ts.Write(BitConverter.GetBytes(FavoredSkill));
            ts.Write(BitConverter.GetBytes(FactionReaction));
        }
    }
}
