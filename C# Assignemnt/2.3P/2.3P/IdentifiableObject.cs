using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure2
{
	public class IdentifiableObject
	{
		private List<string> _identifiers;

		public IdentifiableObject(string[] idents)
		{
			_identifiers = new List<string>();
			_identifiers.AddRange(idents);


		}
		
		public Boolean AreYou(string id)
		{
		
			for (int i = 0; i < _identifiers.Count; i++)
			{
				if (_identifiers[i] == id.ToLower())
				{
					return true;
				}
			}
			return false; 
		}

		public string FirstID 
		{
			get 
			{

				if (_identifiers.Count > 0)
				{

					return _identifiers[0];
				}
				else 
				{
					return "";
				}

			}
		}

		public void AddIdentifier(string id)
		{
			_identifiers.Add(id);
		}

	}
}
