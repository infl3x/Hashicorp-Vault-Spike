using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HashicopVaultTest.Models
{
	public class HomeModel
	{
		public IEnumerable<KeyValuePair<string, string>> VaultStartupConfiguration { get; set; }
		public IEnumerable<KeyValuePair<string, string>> VaultConfiguration { get; set; }
	}
}
