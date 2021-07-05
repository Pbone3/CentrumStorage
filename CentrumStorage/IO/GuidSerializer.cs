using System;
using Terraria.ModLoader.IO;

namespace CentrumStorage.IO
{
    public class GuidSerializer : TagSerializer<Guid, TagCompound>
    {
        public override TagCompound Serialize(Guid value) => new TagCompound() {
            ["Raw"] = value.ToByteArray()
        };

        public override Guid Deserialize(TagCompound tag) => new Guid(tag.Get<byte[]>("Raw"));
    }
}
