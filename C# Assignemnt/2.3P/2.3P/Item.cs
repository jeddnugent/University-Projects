using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure2
{
	public class Item : GameObject
	{
		public Item(string[] indents, string name, string desc) : base(indents, name, desc) { }
	}
}
