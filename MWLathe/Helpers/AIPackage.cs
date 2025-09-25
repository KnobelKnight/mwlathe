namespace MWLathe.Helpers
{
    public abstract class AIPackage
    {
        public abstract uint GetByteSize();
        public abstract void ReplaceID(string oldID, string newID);
        public abstract void Write(FileStream ts);
    }
}
