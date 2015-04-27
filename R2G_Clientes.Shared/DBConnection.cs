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
			db.DropTable<Stock>();
					return "Logout Exitoso";
				
		}
			

	}

	public class CarConnect{

		[Table("Car")]
		public class CarStock {
			[PrimaryKey, AutoIncrement, Column("_id")]
			public int Id { get; set; }
			[MaxLength(8)]
			public int carID { get; set; }
			[MaxLength(12)]
			public string size{ get; set;}

		}

		public static void dataAccess (int iD, string size) {
			Console.WriteLine ("Creating database, if it doesn't already exist");
			string dbPath = Path.Combine (
				Environment.GetFolderPath (Environment.SpecialFolder.Personal),
				"cardata.db3");
			var db = new SQLiteConnection (dbPath);
			db.CreateTable<CarStock> ();
			if (db.Table<CarStock> ().Count() == 0) {
				// only insert the data if it doesn't already exist
				var newCar = new CarStock ();
				newCar.carID = iD;
				newCar.size = size;
				db.Insert (newCar);
			}
			Console.WriteLine("Reading data");
			var table = db.Table<CarStock> ();
			foreach (var s in table) {
				Console.WriteLine (s.Id + " " + s.carID + " " + s.size);
			}
		}

		public static string getCarSize(){
			int userid;
			string dbPath = Path.Combine (
				                Environment.GetFolderPath (Environment.SpecialFolder.Personal),
				                "cardata.db3");
			var db = new SQLiteConnection (dbPath);
			var userid2 = db.Get<CarStock> (1);
			//userid = userid2.userID.ToString ();	
			return userid2.size;
		}

		public static string deleteCar(){
			string dbPath = Path.Combine (
				Environment.GetFolderPath (Environment.SpecialFolder.Personal),
				"cardata.db3");
			var db = new SQLiteConnection (dbPath);
			db.DropTable<CarStock>();
			return "Logout Exitoso";

		}

	}
}

