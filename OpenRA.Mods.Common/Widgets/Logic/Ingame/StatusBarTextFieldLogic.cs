using System.Linq;
using OpenRA;
using OpenRA.Primitives;
using OpenRA.Traits;
using OpenRA.Widgets;

namespace OpenRA.Mods.Common.Widgets.Logic.Ingame
{
	class StatusBarTextFieldLogic : ChromeLogic
	{

		readonly TextFieldWidget widget;
		readonly World world;

		[ObjectCreator.UseCtor]
		public StatusBarTextFieldLogic(TextFieldWidget widget, World world)
		{
			this.widget = widget;
			widget.Disabled = true;
			widget.TextColorDisabled = Color.White;
			this.world = world;
		}

		public override void Tick()
		{
			var actors = world.Selection.Actors.Where(a => a.Owner == world.LocalPlayer && a.IsInWorld && !a.IsDead).ToArray();
			var text = "";

			if (actors.Length == 1)
			{
				var actor = actors.FirstOrDefault();

				if (actor != null)
				{
					var name = actor.Info.Name;
					var health = actor.TraitOrDefault<IHealth>();
					text = $"{name} : {health.HP / 100} / {health.MaxHP / 100}";
				}
			}
			else
			{
				var count = 0;
				foreach (var actor in actors)
				{
					var name = actor.Info.Name;
					var health = actor.TraitOrDefault<IHealth>();
					text += $"{name} : {health.HP / 100} / {health.MaxHP / 100} | ";
					count++;
					if (count % 3 == 0) text += "\n";
					if (count > 24) break;
				}
			}

			widget.Text = text;
			base.Tick();
		}
	}
}
