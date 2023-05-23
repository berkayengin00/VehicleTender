using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTender.DAL.Hashing
{
	public class MyHash
	{
		public string HashPassword(string password)
		{
			using (var sha512 = SHA512.Create())
			{
				var hashedBytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(password));
				var hash = Convert.ToBase64String(hashedBytes);

				return hash;
			}
		}
	}
}
