using System;
//using System.Data;
//using Devart.Data.MySql;
using RestSharp;

namespace R2G_Clientes.Shared
{
	public class DBConnection
	{
		//	MySqlConnection connect = new MySqlConnection("server=mysql.readytogo.com, database= rapidto_db, Uid=rapidtosql, pwd=webmasterserra552015");
		//	connect.Open();

		public static void registerUser(string username, string email, int phone, int wphone, string addr, string waddr, string password, string wemail){
			var cliente = new RestClient ("htttp://192.168.1.107:8080/rapidtoREST/service/user");
			var request = new RestRequest("add", Method.GET);
			request.AddParameter ("usern", username);
			request.AddParameter ("email", email);
			request.AddParameter ("password", password);
			request.AddParameter ("uaddr", addr);
			request.AddParameter ("wphone", wphone);
			request.AddParameter ("phone", phone);
			request.AddParameter ("waddr", waddr);
			request.AddParameter ("wemail", wemail);
			cliente.ExecuteAsGet (request, "GET");


		} 
	}
}

