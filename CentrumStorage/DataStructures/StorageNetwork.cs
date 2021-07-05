using Terraria.ModLoader.IO;

namespace CentrumStorage.DataStructures
{
    public class StorageNetwork : ISaveAndLoadable
    {
        public TagCompound Save()
        {
            TagCompound tag = new TagCompound();

            return tag;
        }

        public void Load(TagCompound tag)
        {
        }
    }
}
