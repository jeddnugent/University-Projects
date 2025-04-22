using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure2
{
	public class LookCommand : Command
	{
		public LookCommand() : base(new string[] {"look_command"}) { }

		public override string Execute(Player p, string[] text) 
		{
			if (text.Length == 5 || text.Length == 3)
			{
				if (text[0] == "look")
				{
					if (text[1] == "at")
					{
						IHaveInventory Container;
						if (text.Length == 5) //Look in container which is the 5th word
						{
							Container = FetchContainer(p, text[4]);
							if (Container == null) return $"I cannot find the {text[4]}";
							else return LookAtLn(text[2], Container);

						} 
						else // look in player
						{
							Container = FetchContainer(p, "me");
							if (Container == null) return $"I cannot find the player";
							else return LookAtLn(text[2], Container);
						}
					}
					else return "What do you want to look at?";
				}
				else return "Error in look input";
			}
			else return "I don’t know how to look like that";
		}




		private IHaveInventory FetchContainer(Player p, string containerId) { return p.Locate(containerId) as IHaveInventory; }


		private string LookAtLn(string thingId, IHaveInventory container) 
		{
			if (container.Locate(thingId) != null) return $"You can see {container.Locate(thingId).Description}";
			else return $"{thingId} cannot be found";
		}

	}
}
