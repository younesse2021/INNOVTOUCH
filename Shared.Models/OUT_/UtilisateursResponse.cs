using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models.OUT_
{
	internal class UtilisateursResponse
	{
		//invnetory
		public class Utilisateur
		{
			public string Username { get; set; }
			public string Password { get; set; }
			public string Domain { get; set; }
			public string MethodName { get; set; }
		}
		//inventories
		public class Utilisateurs
		{
			public List<Utilisateur> Utilisateur { get; set; }
		}


	}
}
