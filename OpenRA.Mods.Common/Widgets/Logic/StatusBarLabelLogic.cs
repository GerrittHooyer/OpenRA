using OpenRA.Widgets;

namespace OpenRA.Mods.Common.Widgets.Logic
{
	class StatusBarLabelLogic : ChromeLogic
	{
		[ObjectCreator.UseCtor]
		public StatusBarLabelLogic(LabelWidget widget, World world)
		{
			var players = "";
			var i = 1;

			foreach (var player in world.Players)
			{
				players += $"{i++}. {player.PlayerName} \n";
			}

			widget.GetText = () => players;
		}
	}
}
