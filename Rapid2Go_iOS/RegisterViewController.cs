using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using R2G_Clientes.Shared;
using System.Net;
using System.Web;
using System.Json;
using Newtonsoft.Json;

namespace Rapid2Go_iOS
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

			btnRegister.TouchUpInside += async (sender, e) => {
				string url = urlbuilder();
				try{
					JsonValue json = await RequestHandler.FetchAsync(url);
					parser(json);
					if (ul.success.Equals ("true")) {
						DataConnect.dataAccess (ul.userID);
						NavigationController.PopToRootViewController(false);
					}else{
						UIAlertView aler = new UIAlertView("Error de Registro", "Parece que ha habido un error de Registro, revisa tus datos e intenta de nuevo.", null, "Ok", null);
						aler.Show();
					}

				}catch{
					UIAlertView aler = new UIAlertView("Error de Registro", "Parece que ha ocurrido un error al intentar contactar al servidor, Intenta de nuevo más tarde. Si el problema persiste, contacta a nuestras oficinas.", null, "Ok", null);
					aler.Show();
				}
			};

		
		}


		public string urlbuilder(){
			string baseurl = "http://ps413027.dreamhost.com:8080/rapidtoREST/service/user/add";
			string finalurl;
			string pwd = HashBrown.hasher (txtPwd.Text);

			finalurl= baseurl + "?usern=" + WebUtility.UrlEncode (txtName.Text) + "&email=" + WebUtility.UrlEncode (txtEmail.Text) + "&password=" +
				WebUtility.UrlEncode (pwd) + "&uaddr=" + WebUtility.UrlEncode (txtAddress.Text) + "&wphone=" + WebUtility.UrlEncode(txtwPhone.Text) + "&phone=" + 
				WebUtility.UrlEncode(txtPhone.Text) + "&waddr=" + WebUtility.UrlEncode (txtWAddress.Text) + "&wemail=" + WebUtility.UrlEncode (txtWEmail.Text);

			return finalurl;
		}

		public void parser(JsonValue json){
			ul = JsonConvert.DeserializeObject<UserLogin> (json.ToString ());

		}

	}

	public class UserLogin{
		public string success { get; set; }
		public int userID { get; set; }
	}
}
