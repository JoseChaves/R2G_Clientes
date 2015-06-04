using System;
using System.Security.Cryptography;
using System.Text;

namespace R2G_Clientes.Shared
{
	public class HashBrown
	{

		public static string hasher(string pwd){

			SHA1 sha = SHA1.Create ();
			string hash = pwd;
			UTF8Encoding encode = new UTF8Encoding ();
			byte[] bytes = encode.GetBytes (hash);
			byte[] result = sha.ComputeHash (bytes);
			StringBuilder salt = new StringBuilder ();

			for (int i = 0; i < result.Length; i++) {
				salt.Append (result [i].ToString ("x2"));
			}

			return salt.ToString ();

		}


	}
}

