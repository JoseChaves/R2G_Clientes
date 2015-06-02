using System;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using Newtonsoft.Json;
using System.IO;
using System.Json;

namespace R2G_Clientes.Shared
{
	public class RequestHandler
	{
		HttpWebRequest wreq;

		public static async Task<JsonValue> FetchAsync(string url){

			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create (new Uri (url));

			request.ContentType = "application/json";
			request.Method = "GET";

			using (WebResponse response = await request.GetResponseAsync ()) {

				using (Stream stream = response.GetResponseStream ()) {

					JsonValue jsondoc = await Task.Run (() => System.Json.JsonArray.Load (stream));
					Console.Out.Write ("Response, {0} ", jsondoc.ToString ());
					//Toast.MakeText (this, "Conexion Establecida" + jsondoc.ToString(), ToastLength.Long).Show ();

					return jsondoc;
				}
			}
		}

	}
}

