using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityMongo.Model
{
	public class TwoFactorRecoveryCode
	{
		public string Code { get; set; }

		public bool Redeemed { get; set; }
	}
}
