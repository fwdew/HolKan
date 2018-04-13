using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace Settings
{
   // TODO:
   public static class SQLiteHelper
   {
      // TODO:
      public static string MakeConnectionString(string indexPath)
      {
         return $"Data Source={indexPath};Version=3;PRAGMA journal_mode=WAL;";
      }

      // TODO:
      public static void ExecuteDdl(SQLiteSession session, string ddl)
      {
         using (var command = session.CreateCommand(ddl)) {
            command.ExecuteNonQuery();
         }
      }

      // TODO:
      public static bool ColumnExists(SQLiteSession session, string tableName, string columnName)
      {
         using (var command = session.CreateCommand($"PRAGMA TABLE_INFO({tableName})")) {
            using (var reader = command.ExecuteReader()) {
               while (reader.Read()) {
                  var name = reader.GetString(1);
                  if (String.Equals(name, columnName, StringComparison.OrdinalIgnoreCase)) {
                     return true;
                  }
               }
            }
         }
         return false;
      }

      // TODO:
      /// <summary>
      /// Gets the user-defined file version of the sqlite db.
      /// </summary>
      public static int GetFileVersion(SQLiteSession session)
      {
         using (var command = session.CreateCommand("PRAGMA user_version")) {
            return Convert.ToInt32(command.ExecuteScalar());
         }
      }

      // TODO:
      /// <summary>
      /// Sets the user-defined file version of the sqlite db.
      /// You may need to commit afterward.
      /// </summary>
      public static void SetFileVersion(SQLiteSession session, int version)
      {
         using (var command = session.CreateCommand($@"PRAGMA user_version = {version}")) {
            command.ExecuteNonQuery();
         }
      }

      // TODO:
      public static void SetFileVersion(SQLiteConnection db, SQLiteTransaction txn, int version)
      {
         using (var command = new SQLiteCommand($@"PRAGMA user_version = {version}", db, txn)) {
            command.ExecuteNonQuery();
         }
      }
   }

   /// <summary>
   /// Keeps track of a single SQLite DB file; ensures that there is only one writer to the 
   /// file at any given time.
   /// </summary>
   public class SQLiteDatabase
   {
      private readonly string filePath;
      private readonly string connString;

      /// <summary>
      /// Prepares to access the database with the given file name.
      /// Make sure to call CreateDataFile before using the DB.
      /// </summary>
      public SQLiteDatabase(string fileName)
      {
         connString = SQLiteHelper.MakeConnectionString(
            Path.Combine(
               Path.GetTempPath(),
               fileName));
      }

      /// <summary>
      /// Creates the database file if it is missing.
      /// </summary>
      /// <returns>true if a new file was created, false if an existing one was used</returns>
      public bool CreateDataFile()
      {
         if (!File.Exists(filePath)) {
            SQLiteConnection.CreateFile(filePath);
            return true;
         }
         return false;
      }

      /// <summary>
      /// Checks if a database file is present, without creating it.
      /// </summary>
      public bool IsDatabasePresent()
      {
         return File.Exists(filePath);
      }

      /// <summary>
      /// Opens a new session, which contains a SQLite connection and a transaction.
      /// </summary>
      public SQLiteSession OpenSession()
      {
         if (!File.Exists(filePath)) {
            throw new Exception($"No file for SQLite: {filePath}");
         }

         return new SQLiteSession(connString);
      }
   }

   /// <summary>
   /// Represents an active SQLite connection, including the connection object and the 
   /// transaction, if any.
   /// </summary>
   public class SQLiteSession : IDisposable
   {
      public readonly SQLiteConnection Db;
      public SQLiteTransaction Txn;

      internal SQLiteSession(string connString)
      {
         Db = new SQLiteConnection(connString);
         Db.Open();
         Txn = Db.BeginTransaction();
      }

      /// <summary>
      /// The whole purpose of this class; creates a command from the give SQL text with the
      /// correct SQLiteConnection and transaction.
      /// </summary>
      public SQLiteCommand CreateCommand(string sql)
      {
         return new SQLiteCommand(sql, Db, Txn);
      }

      public void Rollback()
      {
         Txn?.Rollback();
      }

      public void Commit()
      {
         if (Txn == null) {
            throw new InvalidOperationException("Transaction is not open");
         }
         Txn.Commit();
         Txn.Dispose();
         Txn = null;
      }

      public void CommitAndBegin()
      {
         if (Txn == null) {
            throw new InvalidOperationException("Transaction is not open");
         }
         Txn.Commit();
         Txn.Dispose();
         Txn = Db.BeginTransaction();
      }

      public void Dispose()
      {
         try {
            Txn?.Dispose();
            Txn = null;
            Db.Dispose();
         }
         catch { } // ignore
      }
   }

   public static class HolKanDao
   {
      private static readonly string dbPath = Path.GetTempPath();
      private const string DB_NAME = @"HolKanDB.sqlite";

      private static SQLiteDatabase SQLiteDatabase;

      public static bool CheckDatabasePresent(bool createTables)
      {
         if (SQLiteDatabase == null) {
            SQLiteDatabase = new SQLiteDatabase(DB_NAME);
         }
         if (!SQLiteDatabase.IsDatabasePresent()) {
            if (createTables) {
               SQLiteDatabase.CreateDataFile();
               using (var session = SQLiteDatabase.OpenSession()) {
                  CreateTables(session.Db, session.Txn);
               }
               return true;
            } else {
               return false;
            }
         }
         return true;
      }

      // DEBUG
      public static void TestRun()
      {
         SQLiteConnection.CreateFile("MyDatabase.sqlite");

         SQLiteConnection m_dbConnection;
         m_dbConnection =
               new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
         m_dbConnection.Open();
         string sql = "CREATE TABLE highscores (name VARCHAR(20), score INT)";
         SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
         command.ExecuteNonQuery();
         sql = "insert into highscores (name, score) values ('Me', 9001)";
         command = new SQLiteCommand(sql, m_dbConnection);
         command.ExecuteNonQuery();
         sql = "insert into highscores (name, score) values ('Myself', 6000)";
         command = new SQLiteCommand(sql, m_dbConnection);
         command.ExecuteNonQuery();
         sql = "insert into highscores (name, score) values ('And I', 9001)";
         command = new SQLiteCommand(sql, m_dbConnection);
         command.ExecuteNonQuery();

         sql = "select * from highscores order by score desc";
         command = new SQLiteCommand(sql, m_dbConnection);
         SQLiteDataReader reader = command.ExecuteReader();
         while (reader.Read())
            Console.WriteLine("Name: " + reader["name"] + "\tScore: " + reader["score"]);
         //Console.ReadKey();
      }

      #region Create TODO
      // TODO:
      public static bool CreateDB(bool rewrite = false)
      {
         SQLiteConnection.CreateFile("MyDatabase.sqlite");

         SQLiteConnection m_dbConnection;
         m_dbConnection =
               new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
         m_dbConnection.Open();
         //string sql = "CREATE TABLE highscores (name VARCHAR(20), score INT)";

         return true;
      }

      // TODO:
      public static bool CreateTables()
      {
         return true;
      }
      #endregion

      #region Users TODO maybe not need in db
      // TODO: Not implemented yet
      public static bool SaveUser()
      {
         using (var session = SQLiteDatabase.OpenSession()) {
            //HolKanDao.SaveUser(session.Db, session.Txn);
         }
         return true;
      }

      // TODO: Not implemented yet
      public static bool SaveUsers()
      {
         return true;
      }

      // TODO: Not implemented yet
      public static bool UpdateUser()
      {
         return true;
      }

      // TODO:
      public static User GetUserById(long id)
      {
         return new User(new byte[0]);
      }

      // TODO:
      public static string[] LoadUsers()
      {
         return new string[] { "", "" };
      }
      #endregion

      #region Messages TODO
      public static bool SaveMessage()
      {
         return true;
      }

      public static bool SaveMessages()
      {
         return true;
      }

      public static bool UpdateMessage()
      {
         return true;
      }

      public static bool UpdateMessageStatus()
      {
         return true;
      }

      public static bool UpdateMessageStatusHistory()
      {
         return true;
      }

      public static string LoadMessage()
      {
         return "Message";
      }

      public static string LoadMessages()
      {
         return "Message";
      }

      public static void CreateTables(SQLiteConnection db, SQLiteTransaction txn)
      {
         throw new NotImplementedException();
      }
      #endregion
   }
}
