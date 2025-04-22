using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure2
{
	public abstract class Command : IdentifiableObject
	{
		public Command(string[] ids) : base(ids) { }


		public virtual string Execute(Player p, string[] text) { return null; }
	}
}
