using System.Collections.Generic;
using System.Linq;
using OpenRA.Support;
using OpenRA.Widgets;

namespace OpenRA.Mods.Common.Widgets.Logic
{
	class StatusBarLabelLogic : ChromeLogic
	{

		readonly LabelWidget widget;
		readonly World world;
		Actor[] actors;

		[ObjectCreator.UseCtor]
		public StatusBarLabelLogic(LabelWidget widget, World world)
		{
			this.widget = widget;
			this.world = world;
		}

		public override void Tick()
		{
			var actors = world.Selection.Actors.Where(a => a.Owner == world.LocalPlayer && a.IsInWorld && !a.IsDead).ToArray();
			var map = new Dictionary<string, int>();
			var text = "";

			foreach (var a in actors)
			{
				var name = a.Info.Name;
				map.TryAdd(name, 0);
				map[name]++;
			}

			foreach (var key in map.Keys)
			{
				text += $"{key} : {map[key]}\n";
			}

			widget.GetText = () => text;
			base.Tick();
		}
	}
}
