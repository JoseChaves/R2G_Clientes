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

namespace Rapid2Go_iOS
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
		UITextField txtPhone { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtPwd { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtWAddress { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtWEmail { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtwPhone { get; set; }

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
			if (txtPhone != null) {
				txtPhone.Dispose ();
				txtPhone = null;
			}
			if (txtPwd != null) {
				txtPwd.Dispose ();
				txtPwd = null;
			}
			if (txtWAddress != null) {
				txtWAddress.Dispose ();
				txtWAddress = null;
			}
			if (txtWEmail != null) {
				txtWEmail.Dispose ();
				txtWEmail = null;
			}
			if (txtwPhone != null) {
				txtwPhone.Dispose ();
				txtwPhone = null;
			}
		}
	}
}
