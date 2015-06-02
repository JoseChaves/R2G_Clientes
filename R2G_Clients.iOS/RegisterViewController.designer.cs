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
	[Register ("RegisterViewController")]
	partial class RegisterViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnRegister { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtAddress { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtEmail { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtName { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtPassword { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtPhone { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtWAddress { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtWEmail { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtWPhone { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (btnRegister != null) {
				btnRegister.Dispose ();
				btnRegister = null;
			}
			if (txtAddress != null) {
				txtAddress.Dispose ();
				txtAddress = null;
			}
			if (txtEmail != null) {
				txtEmail.Dispose ();
				txtEmail = null;
			}
			if (txtName != null) {
				txtName.Dispose ();
				txtName = null;
			}
			if (txtPassword != null) {
				txtPassword.Dispose ();
				txtPassword = null;
			}
			if (txtPhone != null) {
				txtPhone.Dispose ();
				txtPhone = null;
			}
			if (txtWAddress != null) {
				txtWAddress.Dispose ();
				txtWAddress = null;
			}
			if (txtWEmail != null) {
				txtWEmail.Dispose ();
				txtWEmail = null;
			}
			if (txtWPhone != null) {
				txtWPhone.Dispose ();
				txtWPhone = null;
			}
		}
	}
}
