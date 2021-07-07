using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CentrumStorage.Items.Materials
{
    public class CircuitBoard : PItem
    {
        public override void SetDefaults()
        {
            base.SetDefaults();

            item.value = Item.sellPrice(0, 0, 1, 0);
            item.rare = ItemRarityID.Blue;
        }

        public override void AddRecipes()
        {
            base.AddRecipes();
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Glass, 8);
            recipe.AddRecipeGroup(RecipeManager.AnyCopper, 4);
            recipe.AddRecipeGroup(ItemID.Diamond);
            recipe.AddTile(TileID.Anvils);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Glass, 8);
            recipe.AddRecipeGroup(RecipeManager.AnyCopper, 4);
            recipe.AddRecipeGroup(ItemID.Ruby, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Glass, 8);
            recipe.AddRecipeGroup(RecipeManager.AnyCopper, 4);
            recipe.AddRecipeGroup(ItemID.Emerald, 3);
            recipe.AddTile(TileID.Anvils);
            recipe.AddRecipe();
        }
    }
}
