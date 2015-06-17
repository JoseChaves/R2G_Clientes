using Foundation;
using System;
using System.CodeDom.Compiler;
using System.Net;
using System.Web;
using Newtonsoft.Json;
using System.Json;
using R2G_Clientes.Shared;

using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using UIKit;

namespace Rapid2Go_iOS
{
	partial class LoginViewController : UIViewController
	{

		LoginData lg;
		CarData cd;
		List<orderData> od;
		string verif = "true";

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
					string parser = parse(json);
					if ( verif.Equals(parser)){
						string caruray = "http://ps413027.dreamhost.com:8080/rapidtoREST/service/cars/onLogin/" + lg.userID;
						json = await RequestHandler.FetchAsync(caruray);
						parsemycar(json);
						DataConnect.dataAccess(lg.userID);
						CarConnect.dataAccess(cd.carid, cd.carsize);
						string orderurl = "http://ps413027.dreamhost.com:8080/rapidtoREST/service/orders/onLogin/" + lg.userID;
						json = await RequestHandler.FetchAsync(orderurl);
						orderparse(json);
						foreach(var s in od){
							Console.WriteLine(s.id);
							OrderConnect.dataAccess(s.id);
						}

						NavigationController.PopToRootViewController(false);

					}else {
						UIAlertView alert = new UIAlertView("Error en los Datos", "La Combinación de Email y contraseña es incorrecta, Revisala e intenta de nuevo", null, "Ok", null);
						alert.Show();
					}
				}catch{}
			};

			//BuyPackbtn.TouchUpInside += (object sender, EventArgs e) => {

			//};

			// Perform any additional setup after loading the view, typically from a nib.
		}

		public string urlbuilder(){
			string baseURL = "http://ps413027.dreamhost.com:8080/rapidtoREST/service/users/login";
			string finalurl;


			finalurl = baseURL + "?usern=" + WebUtility.UrlEncode (txtEmail.Text) + "&pwd=" + HashBrown.hasher(txtPwd.Text);;
			//UIAlertView view = new UIAlertView ("salthash", salt.ToString(), null, "ok", null);
		//	view.Show ();

			return finalurl;

		}


		private string parse(JsonValue json){
			lg = JsonConvert.DeserializeObject<LoginData> (json.ToString ());
			//	Toast.MakeText (this, "Bienvenido", ToastLength.Long).Show ();
			return lg.login;
		}

		private void parsemycar(JsonValue jval){
			cd = JsonConvert.DeserializeObject<CarData> (jval.ToString ());
		}

		public void orderparse(JsonValue jval){
			od= JsonConvert.DeserializeObject<List<orderData>>(jval.ToString());
		}
	}

	public class LoginData{

		public int userID { get; set; }
		public string login { get; set; }

	}

	public class CarData{
		public int carid{ get; set; }
		public string success{ get; set; }
		public string carsize{ get; set; }
	}

	public class orderData{
		public int id{ get; set; }
		public string success{ get; set; }
	}
}
