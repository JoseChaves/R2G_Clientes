using System;
using System.IO;
using System.Collections.Generic;
using SQLite;

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
			string filename = "userdata.db3";
			#if __IOS__
			string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder
			var dbPath = Path.Combine(libraryPath, filename);
			#else

			#if __ANDROID__
			Console.WriteLine ("Creating database, if it doesn't already exist");
			string dbPath = Path.Combine (
				Environment.GetFolderPath (Environment.SpecialFolder.Personal),
				filename);
			#endif
			#endif

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
			string filename = "userdata.db3";
			#if __IOS__
			string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder
			var dbPath = Path.Combine(libraryPath, filename);
			#else

			#if __ANDROID__
			Console.WriteLine ("Creating database, if it doesn't already exist");
			string dbPath = Path.Combine (
			Environment.GetFolderPath (Environment.SpecialFolder.Personal),
			"userdata.db3");
			#endif
			#endif

			var db = new SQLiteConnection (dbPath);
			var userid2 = db.Get<Stock> (1);
			//userid = userid2.userID.ToString ();	
			return userid2.userID;
		}

		public static string deleteUser(){
			string filename = "userdata.db3";
			#if __IOS__
			string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder
			var dbPath = Path.Combine(libraryPath, filename);
			#else

			#if __ANDROID__
			Console.WriteLine ("Creating database, if it doesn't already exist");
			string dbPath = Path.Combine (
			Environment.GetFolderPath (Environment.SpecialFolder.Personal),
			filename);
			#endif
			#endif
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
			string filename = "cardata.db3";
			#if __IOS__
			string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder
			var dbPath = Path.Combine(libraryPath, filename);
			#else

			#if __ANDROID__
			Console.WriteLine ("Creating database, if it doesn't already exist");
			string dbPath = Path.Combine (
			Environment.GetFolderPath (Environment.SpecialFolder.Personal),
			filename);
			#endif
			#endif
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

		public static int getCarID(){
			string dbPath = Path.Combine (
				Environment.GetFolderPath (Environment.SpecialFolder.Personal),
				"cardata.db3");
			var db = new SQLiteConnection (dbPath);
			var userid2 = db.Get<CarStock> (1);
			//userid = userid2.userID.ToString ();	
			return userid2.carID;

		}

	}

	public static class OrderConnect{

		[Table("Orders")]
		public class OrderStock {
			[PrimaryKey, AutoIncrement, Column("_id")]
			public int Id { get; set; }
			[MaxLength(8)]
			public int orderID { get; set; }

		}

		public static void dataAccess (int iD) {
			string filename = "orderdata.db3";
			#if __IOS__
			string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder
			var dbPath = Path.Combine(libraryPath, filename);
			#else

			#if __ANDROID__
			Console.WriteLine ("Creating database, if it doesn't already exist");
			string dbPath = Path.Combine (
			Environment.GetFolderPath (Environment.SpecialFolder.Personal),
			filename);
			#endif
			#endif
			var db = new SQLiteConnection (dbPath);
			db.CreateTable<OrderStock> ();
			//if (db.Table<OrderStock> ().Count () == 0) {
				// only insert the data if it doesn't already exist
				var newCar = new OrderStock ();
				newCar.orderID = iD;
				db.Insert (newCar);
			Console.WriteLine("Reading data");
			var table = db.Table<OrderStock> ();
			foreach (var s in table) {
				Console.WriteLine (s.Id + " " + s.orderID);
			}
		}

		public static int getCarID(){
			string filename = "orderdata.db3";
			#if __IOS__
			string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder
			var dbPath = Path.Combine(libraryPath, filename);
			#else

			#if __ANDROID__
			Console.WriteLine ("Creating database, if it doesn't already exist");
			string dbPath = Path.Combine (
			Environment.GetFolderPath (Environment.SpecialFolder.Personal),
			filename);
			#endif
			#endif
			var db = new SQLiteConnection (dbPath);
			var userid2 = db.Get<OrderStock> (1);
			//userid = userid2.userID.ToString ();	
			return userid2.orderID;

		}

		public static List<int> getAllOrders(){
			List<int> ids= new List<int>();
			string filename = "orderdata.db3";
			#if __IOS__
			string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder
			var dbPath = Path.Combine(libraryPath, filename);
			#else

			#if __ANDROID__
			Console.WriteLine ("Creating database, if it doesn't already exist");
			string dbPath = Path.Combine (
			Environment.GetFolderPath (Environment.SpecialFolder.Personal),
			filename);
			#endif
			#endif
			var db = new SQLiteConnection (dbPath);

			foreach (var s in db.Table<OrderStock>()) {
				ids.Add (s.orderID);
			}

			return ids;
		}

		public static string deleteOrders(){
			string filename = "orderdata.db3";
			#if __IOS__
			string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder
			var dbPath = Path.Combine(libraryPath, filename);
			#else
			#if __ANDROID__
			Console.WriteLine ("Creating database, if it doesn't already exist");
			string dbPath = Path.Combine (
			Environment.GetFolderPath (Environment.SpecialFolder.Personal),
			filename);
			#endif
			#endif
			var db = new SQLiteConnection (dbPath);
			db.DropTable<OrderStock>();
			return "Logout Exitoso";

		}

	}
}

