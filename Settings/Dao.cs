using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace Settings
{
   // TODO:
   public static class SQLiteHelper
   {
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
         filePath = fileName;
         connString = SQLiteHelper.MakeConnectionString(filePath);
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

      public void DeleteDataFile()
      {
         if (File.Exists(filePath)) {
            File.Delete(filePath);
         }
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
      private static readonly string db_folder_path = Path.GetTempPath();
      private const string DB_NAME = @"HolKanDB.sqlite";
      private static readonly string DB_PATH = Path.Combine(db_folder_path, DB_NAME);

      private static SQLiteDatabase SQLiteDatabase;

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

      #region Create DB with tables
      #region DB
      public static void ConnectToDB(bool rewriteDb = false)
      {
         if (SQLiteDatabase == null) {
            SQLiteDatabase = new SQLiteDatabase(DB_PATH);
         }
         if (rewriteDb) {
            SQLiteDatabase.DeleteDataFile();
         }
         if (SQLiteDatabase.CreateDataFile()) {
            using (var session = SQLiteDatabase.OpenSession()) {
               CreateTables(session.Db, session.Txn);
            }
         }
      }

      // TODO: maybe needless
      public static bool CheckDatabasePresent(bool createTables)
      {
         if (SQLiteDatabase == null) {
            SQLiteDatabase = new SQLiteDatabase(DB_NAME);
         }

         return SQLiteDatabase.IsDatabasePresent();
      }
      #endregion

      #region Tables
      public static void CreateTables(SQLiteConnection db, SQLiteTransaction txn)
      {
         CreateUserTable(db, txn);
         CreateMessageTable(db, txn);
      }

      private static void CreateUserTable(SQLiteConnection db, SQLiteTransaction txn)
      {
         const string CREATE_USER_TABLE = @"
CREATE TABLE users (
   id INT
   , ip VARCHAR(20)
   , name VARCHAR(20)
)";

         using (var command = new SQLiteCommand(CREATE_USER_TABLE, db, txn)) {
            command.ExecuteNonQuery();
         }
      }

      private static void CreateMessageTable(SQLiteConnection db, SQLiteTransaction txn)
      {
         const string CREATE_MESSAGE_TABLE = @"
CREATE TABLE messages (
   localId INT
   , serverId INT
   , creationTime INT
   , showTime INT
   , message VARCHAR(20)
   , systemMessage BLOB
   , alert INT
   , senderId INT
   , recipientId INT
   , status VARCHAR(20)
)";

         using (var command = new SQLiteCommand(CREATE_MESSAGE_TABLE, db, txn)) {
            command.ExecuteNonQuery();
         }
      }
      #endregion
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

      #region Messages
      // TODO:
      public static void SaveMessage(long id,
         long serverId,
         double creationTimeSeconds,
         double showTimeSeconds,
         string message,
         byte[] systemMessage,
         bool alertOnConfirm,
         byte senderId,
         int RecipientId,
         Type Type)
      {
         var messageSql = $@"
insert into messages (localId
   , severId
   , creationTime
   , showTime
   , message
   , systemMessage
   , alert
   , senderId
   , recipientId
   , status)
values ({id}
   , {serverId}
   , {creationTimeSeconds}
   , {showTimeSeconds}
   , {message}
   , {systemMessage}
   , {alertOnConfirm}
   , senderId INT
   , recipientId INT
   , status VARCHAR(20)
)";

         using (var session = SQLiteDatabase.OpenSession()) {
            using (var command = new SQLiteCommand(message, session.Db, session.Txn)) {
               command.ExecuteNonQuery();
            }
         }
         
      }

      public static void SaveMessages(IEnumerable<Datagram> datagrams)
      {
         foreach (var datagram in datagrams) {
            SaveMessage(datagram);
         }
      }

      // TODO:
      public static bool UpdateMessage()
      {
         return true;
      }

      // TODO:
      public static bool UpdateMessageStatus()
      {
         return true;
      }

      // TODO:
      public static bool UpdateMessageStatusHistory()
      {
         return true;
      }

      // TODO:
      public static string LoadMessage()
      {
         return "Message";
      }

      // TODO:
      public static string LoadMessages()
      {
         
         return "Message";
      }
      #endregion
   }
}
