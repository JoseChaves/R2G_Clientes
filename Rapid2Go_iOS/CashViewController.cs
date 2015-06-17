using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Net;
using System.Web;
using R2G_Clientes.Shared;

namespace Rapid2Go_iOS
{



	partial class CashViewController : UIViewController
	{
		

		int pack2;
		string size2;
		string address2;
		string start2;
		string end2;
		string comments2;
		string days2;

		public CashViewController (IntPtr handle) : base (handle)
		{
		}

//		public override void ViewWillAppear (bool animated)
//		{
//			base.ViewWillAppear (animated);
//			pack2 = pack;
//			size2 = size;
//			address2 = address;
//			start2 = start;
//			end2 = end;
//			comments2 = comments;
//			days2 = days;
//		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			switch (DataClass.days) {
			case "Mon ":
				days2 = "Lunes";
				break;
			case "Tue ":
				days2= "Martes";
				break;
			case "Wed ":
				days2 = "Miércoles";
				break;
			case "Thur ":
				days2 = "Jueves";
				break;
			case "Fri ":
				days2 = "Viernes";
				break;
			case "Sat ":
				days2 = "Sábado";
				break;
			case "Sun ":
				days2 = "Domingo";
				break;
			}

			switch (DataClass.size) {
			case "Small":
				size2 = "Pequeño";
				break;
			case "Medium":
				size2 = "Mediano";
				break;
			case "Large":
				size2 = "Grande";
				break;
			}

			lblOrderDetails.Text = "Paquete Contratado: " + DataClass.pack + " Servicios para Auto " + size2 + ".\n" +
				"Direccion para el Servicio: " + DataClass.address + "\n" +
				"Horas para el Servicio: de " + DataClass.start + " a " + DataClass.end + "\n" +
			"DIas Para el Servicio: " + days2 + "\n" +
				"Comentarios adicionales: " + DataClass.comments;

			btnListo.TouchUpInside+= (sender, e) => {
				string url=urlbuilder();
				UIAlertView alert = new UIAlertView("alert", url, null, "ok", null);
				alert.Show();
			};

		}

		public string urlbuilder(){
			string baseurl = "http://ps413027.dreamhost.com:8080/rapidtoREST/service/orders/new?";
			string finalurl;

			finalurl = baseurl + "orderAddr=" + WebUtility.UrlEncode (DataClass.address) + "&startH=" + WebUtility.UrlEncode (DataClass.start) + "&endH=" + WebUtility.UrlEncode (DataClass.end) +
				"&orderComm=" + WebUtility.UrlEncode (DataClass.comments) + "&userID=" + WebUtility.UrlEncode(DataConnect.getUserID().ToString()) + "&carID=" + WebUtility.UrlEncode (CarConnect.getCarID().ToString()) + "&days=" + WebUtility.UrlEncode(days2) + 
				"&orderedPack=" + DataClass.pack; 
			return finalurl;
		}

	}
}
