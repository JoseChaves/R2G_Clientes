//using System.Data;
//using Devart.Data.MySql;
//using RestSharp;

namespace R2G_Clientes.Shared
{
	public class DBConnection
	{
		//	MySqlConnection connect = new MySqlConnection("server=mysql.readytogo.com, database= rapidto_db, Uid=rapidtosql, pwd=webmasterserra552015");
		//	connect.Open();
		//public RestClient cliente;
		public static void registerUser(string username, string email, int phone, int wphone, string addr, string waddr, string password, string wemail){
			//cliente = new RestClient ("http://192.168.1.107:8080/rapidtoREST/service/user");
			/*var request = new RestRequest("add{usern}{email}{password}{uaddr}{wphone}{phone}{waddr}{wemail}", Method.GET);
			request.RequestFormat = DataFormat.Json;
			request.AddParameter ("usern", username);
			request.AddParameter ("email", email);
			request.AddParameter ("password", password);
			request.AddParameter ("uaddr", addr);
			request.AddParameter ("wphone", wphone);
			request.AddParameter ("phone", phone);
			request.AddParameter ("waddr", waddr);
			request.AddParameter ("wemail", wemail);
			cliente.ExecuteAsGet (request, "GET");*/
			UserRegister usuarios = new UserRegister ();

			usuarios.Nombre = username;
			usuarios.password = password;
			usuarios.waddrs = waddr;
			usuarios.phone = phone;
			usuarios.Email = email;
			usuarios.Direccion = addr;
			usuarios.wphone = wphone;
			//hacemos el request del metodo que POST para guardar los datos
			//var request = new RestRequest("users/add", Method.POST);
			////asignamos el valor de nuestros datos puede ser en XML O JSON en nuestro caso usaremos json
			//request.RequestFormat = DataFormat.Json;
			//agregamos la entidad con los valores asignado anteriormente
			//request.AddBody(usuarios);
			//ejecutamos el request
			//cliente.Execute (request);

			/*AlertDialog.Builder dialogo = new AlertDialog.Builder (this);
			AlertDialog men = dialogo.Create();
			men.SetTitle ("Metodo Post");
			men.SetMessage ("Guardado Correctamente");
			men.Show ();*/


		} 

		//public viewOrder{}


	//	public 
	}
}

