using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CentrumStorage
{
    public class RecipeManager
    {
        public const string AnyCopper = "CentrumStorage:AnyCopper";
        public const string AnySilver = "CentrumStorage:AnySilver";
        public const string AnyGold   = "CentrumStorage:AnyGold";

        public Mod Mod;

        public RecipeManager(Mod mod)
        {
            Mod = mod;
        }

        public void AddRecipeGroups()
        {
            RecipeGroup group = QuickDuoRecipeGroup(ItemID.CopperBar, ItemID.TinBar);
            RecipeGroup.RegisterGroup(AnyCopper, group);

            group = QuickDuoRecipeGroup(ItemID.SilverBar, ItemID.TungstenBar);
            RecipeGroup.RegisterGroup(AnySilver, group);

            group = QuickDuoRecipeGroup(ItemID.GoldBar, ItemID.PlatinumBar);
            RecipeGroup.RegisterGroup(AnyGold, group);
        }

        public RecipeGroup QuickDuoRecipeGroup(int item1, int item2)
        {
            RecipeGroup group = new RecipeGroup(() => Lang.GetItemName(item1) + "/" + Lang.GetItemName(item2), item1, item2);
            return group;
        }
    }
}
