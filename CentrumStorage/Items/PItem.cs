using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CentrumStorage.Items
{
    public abstract class PItem : ModItem
    {
        public virtual bool Autosize => true;

        public override void SetDefaults()
        {
            base.SetDefaults();

            if (Autosize && Main.itemTexture[item.type] != null)
            {
                Vector2 texSize = Main.itemTexture[item.type].Size();
                Vector2 correctedSize = texSize;

                if (Main.itemAnimations[item.type] is DrawAnimationVertical animation) // If it has a DrawAnimationVertical registered
                    correctedSize = new Vector2(texSize.X, (texSize.Y / animation.FrameCount) - animation.FrameCount * 2); // Account for the amount of frames and buffer between frames

                item.Size = correctedSize;
            }
        }
    }
}
