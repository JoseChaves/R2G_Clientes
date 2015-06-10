using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using R2G_Clientes.Shared;

namespace Rapid2Go_iOS
{
	partial class SettingsViewController : UIViewController
	{
		public SettingsViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			btnSignOut.TouchUpInside += (sender, e) => {
				DataConnect.deleteUser();
				CarConnect.deleteCar();
				OrderConnect.deleteOrders();
				UIAlertView alert = new UIAlertView("Cierre de Sesión", "El cierre de sesion ha sido exitoso", null, "Ok", null);
				alert.Show();
			};

		}
	}
}
