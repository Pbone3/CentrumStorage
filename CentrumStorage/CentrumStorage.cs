using CentrumStorage.IO;
using CentrumStorage.UI.States;
using Microsoft.Xna.Framework;
using PboneLib.Core.UI;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.UI;

namespace CentrumStorage
{
	public class CentrumStorage : Mod
	{
        public static CentrumStorage Instance => ModContent.GetInstance<CentrumStorage>();

        public static UIManager UI => Instance.ui;
        public static RecipeManager Recipes => Instance.recipes;

		private UIManager ui;
        private RecipeManager recipes;

        public Guid StorageInterface;

        public override void Load()
        {
            base.Load();

            TagSerializer.AddSerializer(new GuidSerializer());

            ui = new UIManager(this);
            if (!Main.dedServ)
            {
                StorageInterface = ui.QuickCreateInterface("Vanilla: Mouse Text");
                ui.RegisterUI<StorageUI>(StorageInterface);
            }

            recipes = new RecipeManager(this);
        }

        #region UI
        public override void UpdateUI(GameTime gameTime) => ui.UpdateUI(gameTime);
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers) => ui.ModifyInterfaceLayers(layers);
        #endregion

        #region Recipes
        public override void AddRecipeGroups() => recipes.AddRecipeGroups();
        #endregion
    }
}