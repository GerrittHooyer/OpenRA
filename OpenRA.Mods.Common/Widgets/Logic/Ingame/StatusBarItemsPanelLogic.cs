using System.Linq;
using OpenRA.Graphics;
using OpenRA.Traits;
using OpenRA.Widgets;

namespace OpenRA.Mods.Common.Widgets.Logic
{
	class StatusBarItemsPanelLogic : ChromeLogic
	{

		readonly Widget widget;
		readonly World world;
		readonly WorldRenderer worldRenderer;

		[ObjectCreator.UseCtor]
		public StatusBarItemsPanelLogic(Widget widget, World world, WorldRenderer worldRenderer)
		{
			this.widget = widget;
			this.world = world;
			this.worldRenderer = worldRenderer;

			var armyIconsWidth = new PlayerSelectedUnitsIconsWidget(world, worldRenderer)
			{
				GetPlayer = () => world.LocalPlayer,
				IconWidth = 30,
				IconHeight = 24,
				IconSpacing = 1
			};

			widget.AddChild(armyIconsWidth);
		}
	}
}
