using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Net;
using System.Web;
using Newtonsoft.Json;
using System.Json;
using R2G_Clientes.Shared;

using System.Security.Cryptography;
using System.Text;

namespace Rapid2Go_iOS
{
	partial class LoginViewController : UIViewController
	{
		public LoginViewController (IntPtr handle) : base (handle)
		{
		}


		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();


			btnLogin.TouchUpInside += async (sender, e) => {
				string url = urlbuilder();
				try{
					JsonValue json = await RequestHandler.FetchAsync(url);

				}catch{}
			};

			//BuyPackbtn.TouchUpInside += (object sender, EventArgs e) => {

			//};

			// Perform any additional setup after loading the view, typically from a nib.
		}

		public string urlbuilder(){
			string baseURL = "http://ps413027.dreamhost.com:8080/rapidtoREST/service/users/login";
			string finalurl;

			SHA1 sha = SHA1.Create ();
			string hash = txtPwd.Text;
			UTF8Encoding encode = new UTF8Encoding ();
			byte[] bytes = encode.GetBytes (hash);
			byte[] result = sha.ComputeHash (bytes);
			StringBuilder salt = new StringBuilder ();

			for (int i = 0; i < result.Length; i++) {
				salt.Append (result [i].ToString ("x2"));
			}


			finalurl = baseURL + "?usern=" + WebUtility.UrlEncode (txtEmail.Text) + "&pwd=" + salt.ToString ();;
			UIAlertView view = new UIAlertView ("salthash", salt.ToString(), null, "ok", null);
			view.Show ();

			return finalurl;

		}


	}
}
