using Terraria.ModLoader.IO;

namespace CentrumStorage
{
    public interface ISaveAndLoadable
    {
        TagCompound Save();
        void Load(TagCompound tag);
    }
}
