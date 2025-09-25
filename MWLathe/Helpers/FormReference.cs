﻿using MWLathe.Records;
using System.Text;

namespace MWLathe.Helpers
{
    public class FormReference
    {
        public uint ReferenceID { get; set; }
        public string ObjectID { get; set; }
        public byte? Blocked { get; set; }
        public float? Scale { get; set; }
        public string? NPCID { get; set; }
        public string? OwnershipGlobal { get; set; }
        public string? FactionID { get; set; }
        public uint? FactionRank { get; set; }
        public string? Soul { get; set; }
        public float? EnchantCharge { get; set; }
        // Can be float or uint
        public byte[]? RemainingUsage { get; set; }
        public uint? Value { get; set; }
        public List<TravelDestination> Destinations { get; set; } = new List<TravelDestination>();
        public uint? LockDifficulty { get; set; }
        public string? KeyName { get; set; }
        public string? TrapName { get; set; }
        public byte? Disabled { get; set; }
        public DODT? ReferencePosition { get; set; }
        public uint? Deleted { get; set; }

        public void ReplaceID(string oldID, string newID)
        {
            if (ObjectID.Equals(oldID, StringComparison.OrdinalIgnoreCase))
            {
                ObjectID = newID;
            }
            if (NPCID is not null && NPCID.Equals(oldID, StringComparison.OrdinalIgnoreCase))
            {
                NPCID = newID;
            }
            if (OwnershipGlobal is not null && OwnershipGlobal.Equals(oldID, StringComparison.OrdinalIgnoreCase))
            {
                OwnershipGlobal = newID;
            }
            if (FactionID is not null && FactionID.Equals(oldID, StringComparison.OrdinalIgnoreCase))
            {
                FactionID = newID;
            }
            if (Soul is not null && Soul.Equals(oldID, StringComparison.OrdinalIgnoreCase))
            {
                Soul = newID;
            }
            if (KeyName is not null && KeyName.Equals(oldID, StringComparison.OrdinalIgnoreCase))
            {
                KeyName = newID;
            }
            if (TrapName is not null && TrapName.Equals(oldID, StringComparison.OrdinalIgnoreCase))
            {
                TrapName = newID;
            }
        }

        public uint GetByteSize()
        {
            uint byteSize = 8 + 4 + 8 + (uint)ObjectID.Length + 1;
            if (Blocked.HasValue)
            {
                byteSize += 9;
            }
            if (Scale.HasValue)
            {
                byteSize += 12;
            }
            if (NPCID is not null)
            {
                byteSize += 8 + (uint)NPCID.Length + 1;
            }
            if (OwnershipGlobal is not null)
            {
                byteSize += 8 + (uint)OwnershipGlobal.Length + 1;
            }
            if (FactionID is not null)
            {
                byteSize += 8 + (uint)FactionID.Length + 1;
            }
            if (FactionRank.HasValue)
            {
                byteSize += 12;
            }
            if (Soul is not null)
            {
                byteSize += 8 + (uint)Soul.Length + 1;
            }
            if (EnchantCharge.HasValue)
            {
                byteSize += 12;
            }
            if (RemainingUsage is not null)
            {
                byteSize += 12;
            }
            if (Value.HasValue)
            {
                byteSize += 12;
            }
            byteSize += (uint)Destinations.Sum(x => x.GetByteSize());
            if (LockDifficulty.HasValue)
            {
                byteSize += 12;
            }
            if (KeyName is not null)
            {
                byteSize += 8 + (uint)KeyName.Length + 1;
            }
            if (TrapName is not null)
            {
                byteSize += 8 + (uint)TrapName.Length + 1;
            }
            if (Disabled.HasValue)
            {
                byteSize += 9;
            }
            if (ReferencePosition is not null)
            {
                byteSize += 8 + DODT.StructSize;
            }
            if (Deleted.HasValue)
            {
                byteSize += 12;
            }
            return byteSize;
        }

        public void Write(FileStream ts)
        {
            ts.Write(Encoding.GetEncoding("Windows-1252").GetBytes("FRMR"));
            ts.Write(BitConverter.GetBytes(4));
            ts.Write(BitConverter.GetBytes(ReferenceID));
            ts.Write(Encoding.GetEncoding("Windows-1252").GetBytes("NAME"));
            ts.Write(BitConverter.GetBytes(ObjectID.Length + 1));
            ts.Write(Record.EncodeZString(ObjectID));
            if (Blocked.HasValue)
            {
                ts.Write(Encoding.GetEncoding("Windows-1252").GetBytes("UNAM"));
                ts.Write(BitConverter.GetBytes(1));
                ts.WriteByte(Blocked.Value);
            }
            if (Scale.HasValue)
            {
                ts.Write(Encoding.GetEncoding("Windows-1252").GetBytes("XSCL"));
                ts.Write(BitConverter.GetBytes(4));
                ts.Write(BitConverter.GetBytes(Scale.Value));
            }
            if (NPCID is not null)
            {
                ts.Write(Encoding.GetEncoding("Windows-1252").GetBytes("ANAM"));
                ts.Write(BitConverter.GetBytes(NPCID.Length + 1));
                ts.Write(Record.EncodeZString(NPCID));
            }
            if (OwnershipGlobal is not null)
            {
                ts.Write(Encoding.GetEncoding("Windows-1252").GetBytes("BNAM"));
                ts.Write(BitConverter.GetBytes(OwnershipGlobal.Length + 1));
                ts.Write(Record.EncodeZString(OwnershipGlobal));
            }
            if (FactionID is not null)
            {
                ts.Write(Encoding.GetEncoding("Windows-1252").GetBytes("CNAM"));
                ts.Write(BitConverter.GetBytes(FactionID.Length + 1));
                ts.Write(Record.EncodeZString(FactionID));
            }
            if (FactionRank.HasValue)
            {
                ts.Write(Encoding.GetEncoding("Windows-1252").GetBytes("INDX"));
                ts.Write(BitConverter.GetBytes(4));
                ts.Write(BitConverter.GetBytes(FactionRank.Value));
            }
            if (Soul is not null)
            {
                ts.Write(Encoding.GetEncoding("Windows-1252").GetBytes("XSOL"));
                ts.Write(BitConverter.GetBytes(Soul.Length + 1));
                ts.Write(Record.EncodeZString(Soul));
            }
            if (EnchantCharge.HasValue)
            {
                ts.Write(Encoding.GetEncoding("Windows-1252").GetBytes("XCHG"));
                ts.Write(BitConverter.GetBytes(4));
                ts.Write(BitConverter.GetBytes(EnchantCharge.Value));
            }
            if (RemainingUsage is not null)
            {
                ts.Write(Encoding.GetEncoding("Windows-1252").GetBytes("INTV"));
                ts.Write(BitConverter.GetBytes(4));
                ts.Write(RemainingUsage.AsSpan()[..4]); // Should never be more than 4 bytes anyway, but just in case...
            }
            if (Value.HasValue)
            {
                ts.Write(Encoding.GetEncoding("Windows-1252").GetBytes("NAM9"));
                ts.Write(BitConverter.GetBytes(4));
                ts.Write(BitConverter.GetBytes(Value.Value));
            }
            foreach (var destination in Destinations)
            {
                destination.Write(ts);
            }
            if (LockDifficulty.HasValue)
            {
                ts.Write(Encoding.GetEncoding("Windows-1252").GetBytes("FLTV"));
                ts.Write(BitConverter.GetBytes(4));
                ts.Write(BitConverter.GetBytes(LockDifficulty.Value));
            }
            if (KeyName is not null)
            {
                ts.Write(Encoding.GetEncoding("Windows-1252").GetBytes("KNAM"));
                ts.Write(BitConverter.GetBytes(KeyName.Length + 1));
                ts.Write(Record.EncodeZString(KeyName));
            }
            if (TrapName is not null)
            {
                ts.Write(Encoding.GetEncoding("Windows-1252").GetBytes("TNAM"));
                ts.Write(BitConverter.GetBytes(TrapName.Length + 1));
                ts.Write(Record.EncodeZString(TrapName));
            }
            if (Disabled.HasValue)
            {
                ts.Write(Encoding.GetEncoding("Windows-1252").GetBytes("ZNAM"));
                ts.Write(BitConverter.GetBytes(1));
                ts.WriteByte(Disabled.Value);
            }
            if (ReferencePosition is not null)
            {
                ts.Write(Encoding.GetEncoding("Windows-1252").GetBytes("DATA"));
                ts.Write(BitConverter.GetBytes(24));
                ts.Write(BitConverter.GetBytes(ReferencePosition.PositionX));
                ts.Write(BitConverter.GetBytes(ReferencePosition.PositionY));
                ts.Write(BitConverter.GetBytes(ReferencePosition.PositionZ));
                ts.Write(BitConverter.GetBytes(ReferencePosition.RotationX));
                ts.Write(BitConverter.GetBytes(ReferencePosition.RotationY));
                ts.Write(BitConverter.GetBytes(ReferencePosition.RotationZ));
            }
            if (Deleted.HasValue)
            {
                ts.Write(Encoding.GetEncoding("Windows-1252").GetBytes("DELE"));
                ts.Write(BitConverter.GetBytes(4));
                ts.Write(BitConverter.GetBytes(Deleted.Value));
            }
        }
    }
}
