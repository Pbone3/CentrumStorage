using System;
using Terraria.ModLoader.IO;

namespace CentrumStorage.IO
{
    public class GuidSerializer : TagSerializer<Guid, TagCompound>
    {
        public override TagCompound Serialize(Guid value) => new TagCompound() {
            ["Raw"] = value.ToByteArray()
        };

        public override Guid Deserialize(TagCompound tag)
        {
            byte[] b = tag.Get<byte[]>("Raw");
            if (b.Length != 16) // Fail-safe I added while doing testing
                return default;

            return new Guid(b);
        }
    }
}
