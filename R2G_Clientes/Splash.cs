using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace R2G_Clientes
{
	[Activity (Label = "Ready2Go", NoHistory=true, Theme="@android:style/Theme.Holo.Light.NoActionBar.TranslucentDecor")]			
	public class Splash : Activity
	{
		public class SplashActivity : Activity
		{
			protected override void OnCreate(Bundle bundle)
			{
				base.OnCreate(bundle);
				SetContentView (Resource.Layout.activity_splash);
				Thread.Sleep(100); // Simulate a long loading process on app startup.
				StartActivity(typeof(MainActivity));
			}
		}
	}
}

