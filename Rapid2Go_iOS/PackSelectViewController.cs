using System;
using System.Collections.Generic;
using R2G_Clientes.Shared;
using MonoTouch;
using UIKit;

namespace Rapid2Go_iOS
{
	partial class PackSelectViewController : UIViewController
	{

		int carID;
		string carsize;
		string selectedCar;
		int pack;

		public PackSelectViewController (IntPtr handle) : base (handle)
		{
		}

		public async override void ViewDidLoad ()
		{
			
			base.ViewDidLoad ();


			try{
				carID = CarConnect.getCarID ();
				carsize=CarConnect.getCarSize();

				UIAlertView alert = new UIAlertView("FOR TESTING PURPOSES", carID.ToString(), null, "OK", null);
				//alert.Show();
			}catch{	
				UIAlertView aler = new UIAlertView ("ERROR!", "Ha ocurrido un error, no encontramos tu carro. \n Asegurate de haber iniciado sesión y de haber registrado tu carro.", null, "Ok", null);
				aler.Show ();
			}

			switch (carsize) {
			case "Small":
				btnFour.SetTitle("Cuatro Servicios - $37.00", UIControlState.Normal);
				btnSix.SetTitle("Seis Servicios - $52.50", UIControlState.Normal);
				btnTen.SetTitle ( "Diez Servicios - $82.50",UIControlState.Normal);
				btnTwelve.SetTitle ( "Doce Servicios - $96.00", UIControlState.Normal);
				break;
			case "Medium":
				btnFour.SetTitle ( "Cuatro Servicios - $39.00", UIControlState.Normal);
				btnSix.SetTitle ( "Seis Servicios   - $55.50", UIControlState.Normal);
				btnTen.SetTitle ( "Diez Servicios  - $87.50", UIControlState.Normal);
				btnTwelve.SetTitle("Doce Servicios  - $102.00", UIControlState.Normal);
				break;
			case "Large":
				btnFour.SetTitle("Cuatro Servicios - $44.00", UIControlState.Normal);
				btnSix.SetTitle("Seis Servicios   - $63.00", UIControlState.Normal);
				btnTen.SetTitle("Diez Servicios  - $100.00", UIControlState.Normal);
				btnTwelve.SetTitle("Doce Servicios  - $117.00", UIControlState.Normal);
				break;
			}


			btnFour.TouchUpInside += (sender, e) => {
				pack = 4;
			};

			btnSix.TouchUpInside += (sender, e) => {
				pack = 6;
			};

			btnTen.TouchUpInside += (sender, e) => {
				pack = 10;
			};

			btnTwelve.TouchUpInside += (sender, e) => {
				pack = 12;
			};

		}

	public override void PrepareForSegue (UIStoryboardSegue segue, Foundation.NSObject sender)
		{
//	DataClass dt = new DataClass ();

			base.PrepareForSegue (segue, sender);

//			var cash = segue.DestinationViewController as CashViewController;
//			var detailsViewController = segue.DestinationViewController as DetailsViewController;
//			detailsViewController.pack = pack;
//			detailsViewController.size = carsize;
			DataClass.pack=pack;
			DataClass.size = carsize;
		
			UIAlertView alert = new UIAlertView ("SHFDUF", DataClass.pack + pack.ToString(), null, "sdfj", null);
			alert.Show ();

	}



	}
		
}
