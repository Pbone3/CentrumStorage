using Terraria.ID;
using Terraria.ModLoader;

namespace CentrumStorage.Items.Drives
{
    public class BasicDrive : AbstractDrive
    {
        public override long MaxStorage => 100;

        public override void AddRecipes()
        {
            base.AddRecipes();
            ModRecipe recipe = new ModRecipe(mod);
            // 6 Iron
            // 1 Diamond
            // 2 Gold
            // 1 Circuit board (Copper + glass)
        }
    }
}
