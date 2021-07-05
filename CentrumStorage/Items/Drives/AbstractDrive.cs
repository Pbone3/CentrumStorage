using System;
using System.IO;
using Terraria.ModLoader.IO;

namespace CentrumStorage.Items.Drives
{
    public abstract class AbstractDrive : PItem
    {
        public abstract long MaxStorage { get; }
        public Guid Identifier;

        public override void SetDefaults()
        {
            base.SetDefaults();
            Identifier = Guid.NewGuid();
        }

        public override TagCompound Save() => new TagCompound() {
            ["Identifier"] = Identifier
        };

        public override void Load(TagCompound tag) => Identifier = tag.Get<Guid>("Identifier");

        public override void NetSend(BinaryWriter writer)
        {
            base.NetSend(writer);
            byte[] raw = Identifier.ToByteArray();

            writer.Write(raw.Length);
            writer.Write(raw);
        }

        public override void NetRecieve(BinaryReader reader)
        {
            base.NetRecieve(reader);
            byte[] raw = new byte[reader.ReadInt32()];
            raw = reader.ReadBytes(raw.Length);

            Identifier = new Guid(raw);
        }
    }
}
