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


		public static void DoSomeDataAccess (int iD) {
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



	}
}

