using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure2
{
	public abstract class GameObject : IdentifiableObject
	{
		private string _description, _name;

		public GameObject(string[] ids, string name, string desc) : base(ids)
		{
			_name = name;
			_description = desc;
		}

		public string Name
		{
			get
			{
				return _name;
			}
		}


		public string ShortDescription
		{
			get
			{
				return $"{Name} {FirstID}";
			}
		}
		public virtual string FullDescription 
		{
			get
			{
				return _description;
			}
		}
		public string Description
		{
			get
			{
				return _description;
			}
			set
			{
				_description = value;

			}
		}
	}
}
