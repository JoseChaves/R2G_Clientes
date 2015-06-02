using Foundation;
using System;
using System.Json;
using System.Net;
using Newtonsoft.Json;
using System.Security.Cryptography;

using R2G_Clientes.Shared;
using System.Text;
using UIKit;




namespace R2G_Clients.iOS
{
	partial class RegisterViewController : UIViewController
	{

		UserLogin ul;

		public RegisterViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();


			btnRegister.TouchUpInside += async (object sender, EventArgs e) => {
				string uri = urlBuilder();
				try{
					JsonValue json = await RequestHandler.FetchAsync(uri);
					parse(json);
					if(ul.success){
						DataConnect.dataAccess(ul.userID);
						NavigationController.PopToRootViewController(false);
					}else{
						UIAlertView alert = new UIAlertView("Error", "Ha habido un error en el Registro, Intenta de Nuevo", null, "Ok", null);
						alert.Show();
					}

				}catch{}


			};

			//BuyPackbtn.TouchUpInside += (object sender, EventArgs e) => {

			//};

			// Perform any additional setup after loading the view, typically from a nib.
		}

		public string urlBuilder(){

			string baseurl = "http://ps413027.dreamhost.com:8080/rapidtoREST/service/user/add";

			SHA1 sha = SHA1.Create ();
			string hash = txtPassword.Text;
			UTF8Encoding encode = new UTF8Encoding ();
			byte[] bytes = encode.GetBytes (hash);
			string salt = sha.ComputeHash (bytes).ToString();

			string finalurl = baseurl + "?usern=" + WebUtility.UrlEncode (txtName.Text) + "&email=" + WebUtility.UrlEncode (txtEmail.Text) + "&password=" +
				WebUtility.UrlEncode (salt) + "&uaddr=" + WebUtility.UrlEncode (txtAddress.Text) + "&wphone=" + txtWPhone + "&phone=" + 
				txtPhone.Text + "&waddr=" + WebUtility.UrlEncode (txtWAddress.Text) + "&wemail=" + WebUtility.UrlEncode (txtWEmail.Text);

			return finalurl;

		}

		public void parse(JsonValue json){
			ul = JsonConvert.DeserializeObject<UserLogin> (json.ToString ());
		}

	}


	public class UserLogin{
		public bool success { get; set; }
		public int userID { get; set; }
	}


}
