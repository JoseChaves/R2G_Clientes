// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace R2G_Clients.iOS
{
	[Register ("MainMenuViewController")]
	partial class MainMenuViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UINavigationItem navMainMenu { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView viewMainMenu { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (navMainMenu != null) {
				navMainMenu.Dispose ();
				navMainMenu = null;
			}
			if (viewMainMenu != null) {
				viewMainMenu.Dispose ();
				viewMainMenu = null;
			}
		}
	}
}
