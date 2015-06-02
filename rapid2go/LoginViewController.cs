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

namespace com.rapidtogo.rapid2go
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
			string salt = sha.ComputeHash (bytes).ToString();

			finalurl = baseURL + "?usern=" + WebUtility.UrlEncode (txtEmail.Text) + "&pwd=" + salt;
			UIAlertView view = new UIAlertView ("salthash", salt, null, "ok", null);


			return finalurl;

		}


	}
}
