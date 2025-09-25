﻿namespace MWLathe.Helpers
{
    public abstract class AILocationPackage : AIPackage
    {
        public float DestX { get; set; }
        public float DestY { get; set; }
        public float DestZ { get; set; }
        public ushort Duration { get; set; }
        public string ID { get; set; }
        public string? Cell { get; set; }

        public override void ReplaceID(string oldID, string newID)
        {
            if (ID.Equals(oldID, StringComparison.OrdinalIgnoreCase))
            {
                ID = newID;
            }
        }

        public override uint GetByteSize()
        {
            return Cell is null ? 8 + 48 : 8 + 48 + 8 + (uint)Cell.Length + 1;
        }
    }
}
