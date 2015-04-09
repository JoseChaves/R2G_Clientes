using System;
//using System.Threading.Tasks;

//using Android.OS;
//using Auth0.SDK;
//using Xamarin.Auth;
//using Android.App;
//using Android.Widget;
//using Android.Content;
using Newtonsoft.Json;

namespace R2G_Clientes.Shared
{
	public class LoginAuth
	{
		string access_token;

		/*public void LoginByGoogle ()
		{
			var auth = new OAuth2Authenticator (
				clientId: "1011842775122-kmjq0ap02qhrsv7jc54uec2p6gupomja.apps.googleusercontent.com",
				scope: "https://www.googleapis.com/auth/userinfo.email", 
				authorizeUrl: new Uri ("https://accounts.google.com/o/oauth2/auth"),
				//redirectUrl: new Uri ("https://www.googleapis.com/plus/v1/people/me"), 
				redirectUrl: new Uri ("http://localhost"),  
				getUsernameAsync: null);  

			string access_token;
			auth.Completed += (sender , e ) =>
			{  
				Console.WriteLine ( e.IsAuthenticated );
				e.Account.Properties.TryGetValue ( "access_token" , out access_token ); 
				//get user full information
				getInfo();

			} ; 
			//var intent = auth.GetUI(this);
			//StartActivity (intent);
		}



		async void getInfo()
		{   
			//do RESP request,by appending token
			string userInfo = await GetDataFromGoogle (access_token ); 
			Console.WriteLine (  userInfo);
			if ( userInfo != "Exception" )
			{
				//Deserialize  to objet
				GoogleUserInfo googleIngo = JsonConvert.DeserializeObject<GoogleUserInfo> ( userInfo );  
			}
			else
			{  

				Console.WriteLine("exception");
			}
		}

		async   Task<string> GetDataFromGoogle(string accessTokenValue)
		{    
			string strResult;
			string  strURL =   /* "https://www.googleapis.com/oauth2/v1/userinfo?access_token=" + accessTokenValue + "" "https://accounts.google.com/o/oauth2/token";   
			//WebClient client = new WebClient (); 
			try
			{
				//strResult=await client.DownloadStringTaskAsync (new Uri(strURL));
				Console.WriteLine("downloaded");
			}
			catch
			{
				strResult="Exception";
			}
			finally
			{
			//	client.Dispose ();
			//	client = null; 
			}
			return "";//strResult;
		}

		public class GoogleUserInfo
		{
			public string id { get; set; }
			public string email { get; set; }
			public bool verified_email { get; set; }
			public string name { get; set; }
			public string given_name { get; set; }
			public string family_name { get; set; }
			public string link { get; set; }
			public string picture { get; set; }
			public string gender { get; set; }
		}*/
	}
}

