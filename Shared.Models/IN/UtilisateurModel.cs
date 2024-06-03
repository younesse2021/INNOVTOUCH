using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.IN
{
	internal class UtilisateurModel
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string Type { get; set; }
		public string TypeId { get; set; }
		= Guid.NewGuid().ToString();
		public string TypeName { get; set; }
		= string.Empty;
		public string TypeDescription { get; set; }
		= string.Empty;
			

	}
}
