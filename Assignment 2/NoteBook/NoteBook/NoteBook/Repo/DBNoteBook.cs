using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using NoteBook.Models;

namespace NoteBook.Repo
{
    public static class DBNoteBook
    {
        //Local Database Connection
        public static SqliteConnection dBConnection = new SqliteConnection("Filename=NoteBook.db");

        /// <summary>
        /// Initiate database
        /// </summary>
        public static void CreateDB()
        {
            string createStatement = "CREATE TABLE if not exists NoteBook " 
                                    + "(NoteName VARCHAR(50),"
                                    + "NoteText VARCHAR(255))";
            try
            {
                using (dBConnection) 
                {
                    dBConnection.Open();
                    SqliteCommand create = new SqliteCommand(createStatement, dBConnection);
                    create.ExecuteReader();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Could not create Table!" + ex.Message);
            }
        }

        /// <summary>
        /// Insert Note to NootBook table
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="fileContent"></param>
        public static void InsertNote(string fileName, string fileContent)
        {
            string insertStatement = "INSERT INTO NoteBook (NoteName, NoteText) " +
                        "VALUES (@NName, @NText);";
            try
            {
                using (dBConnection)
                {
                    dBConnection.Open();
                    SqliteCommand insertCommand = new SqliteCommand();
                    insertCommand.Connection = dBConnection;

                    insertCommand.CommandText = insertStatement;
                    insertCommand.Parameters.AddWithValue("@NName", fileName);
                    insertCommand.Parameters.AddWithValue("@NText", fileContent);
                    insertCommand.ExecuteReader();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Could not insert value to Table" + ex.Message);
            }
        }

        /// <summary>
        /// Update Note in Table
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="fileContent"></param>
        public static void UpdateNote(string fileName, string fileContent)
        {
            string updateStatemnt = "UPDATE NoteBook SET NoteText = @NText WHERE NoteName = @NName;";
            try
            {
                using (dBConnection)
                {
                    dBConnection.Open();
                    SqliteCommand updateCommand = new SqliteCommand();
                    updateCommand.Connection = dBConnection;

                    updateCommand.CommandText = updateStatemnt;
                    updateCommand.Parameters.AddWithValue("@NName", fileName);
                    updateCommand.Parameters.AddWithValue("@NText", fileContent);
                    updateCommand.ExecuteReader();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Could not update value to Table " + ex.Message);
            }
        }

        /// <summary>
        /// Delete Note in Table
        /// </summary>
        /// <param name="fileName"></param>
        public static void DeleteNote(string fileName)
        {
            string deleteStatement = "DELETE FROM NoteBook " +
                        "WHERE NoteName = @FName;";
            try
            {
                using (dBConnection)
                {
                    dBConnection.Open();
                    SqliteCommand deleteCommand = new SqliteCommand();
                    deleteCommand.Connection = dBConnection;

                    deleteCommand.CommandText = deleteStatement;
                    deleteCommand.Parameters.AddWithValue("@FName", fileName);
                    deleteCommand.ExecuteReader();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Could not delete value from Table " + ex.Message);
            }
        }

        public static List<NoteFile> RetrieveAllFiles()
        {
            List<NoteFile> entries = new List<NoteFile>();
            string fileName;
            string fileContent;

            try
            {
                using (dBConnection)
                {
                    dBConnection.Open();

                    SqliteCommand selectCommand =
                        new SqliteCommand("SELECT * FROM NoteBook;", dBConnection);

                    SqliteDataReader query = selectCommand.ExecuteReader();
                    while (query.Read())
                    {
                        fileName = query.GetString(0);
                        fileContent = query.GetString(1);
                        entries.Add(new NoteFile(fileName,fileContent));
                    }

                    dBConnection.Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Could not retrieve Notes " + ex.Message);
            }

            return entries;
        }
    }
}
