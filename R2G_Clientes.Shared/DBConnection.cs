using SQLite;
using System;
using System.IO;

namespace R2G_Clientes.Shared
{
	public class DataConnect{
		
		[Table("User")]
		public class Stock {
			[PrimaryKey, AutoIncrement, Column("_id")]
			public int Id { get; set; }
			[MaxLength(8)]
			public int userID { get; set; }
		}


		public static void dataAccess (int iD) {
			Console.WriteLine ("Creating database, if it doesn't already exist");
			string dbPath = Path.Combine (
				Environment.GetFolderPath (Environment.SpecialFolder.Personal),
				"userdata.db3");
			var db = new SQLiteConnection (dbPath);
			db.CreateTable<Stock> ();
			if (db.Table<Stock> ().Count() == 0) {
				// only insert the data if it doesn't already exist
				var newUser = new Stock ();
				newUser.userID = iD;
				db.Insert (newUser);
			}
			Console.WriteLine("Reading data");
			var table = db.Table<Stock> ();
			foreach (var s in table) {
				Console.WriteLine (s.Id + " " + s.userID);
			}
		}

		public static int getUserID(){
			int userid;
			string dbPath = Path.Combine (
				Environment.GetFolderPath (Environment.SpecialFolder.Personal),
				"userdata.db3");
			var db = new SQLiteConnection (dbPath);
			var userid2 = db.Get<Stock> (1);
			//userid = userid2.userID.ToString ();	
			return userid2.userID;
		}

		public static string deleteUser(){
			string dbPath = Path.Combine (
				Environment.GetFolderPath (Environment.SpecialFolder.Personal),
				"userdata.db3");
			var db = new SQLiteConnection (dbPath);
			db.DeleteAll<Stock>();
			if (db.Table<Stock>().Count () == 0) {
				return "Logout Exitoso";
				Console.WriteLine("Reading data");
				var table = db.Table<Stock> ();
				foreach (var s in table) {
					Console.WriteLine (s.Id + " " + s.userID);
				}
			} else {
				return null;
				Console.WriteLine("Reading data");
				var table = db.Table<Stock> ();
				foreach (var s in table) {
					Console.WriteLine (s.Id + " " + s.userID);
				}
			}
		}
			

	}
}

