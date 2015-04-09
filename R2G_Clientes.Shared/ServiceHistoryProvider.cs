using System;
using System.Net;
using System.Threading.Tasks;
using System.Json;
using System.IO;

namespace R2G_Clientes.Shared
{
	public class ServiceHistoryProvider
	{

			public async Task<JsonValue> FetchAsync(string url){

			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create (new Uri (url));
				
			request.ContentType = "application/json";
			request.Method = "GET";

			using (WebResponse response = await request.GetResponseAsync ()) {
				
				using (Stream stream = response.GetResponseStream ()) {
					
					JsonValue jsondoc = await Task.Run (() => System.Json.JsonObject.Load (stream));
					Console.Out.Write ("Response, {0} ", jsondoc.ToString ());
					//Toast.MakeText (this, "Conexion Establecida" + jsondoc.ToString(), ToastLength.Long).Show ();
					return jsondoc;
				}
			}
		}
			}

		}
