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

		private UIManager ui;

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
        }

        #region UI
        public override void UpdateUI(GameTime gameTime) => ui.UpdateUI(gameTime);
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers) => ui.ModifyInterfaceLayers(layers);
        #endregion
    }
}