using Microsoft.VisualStudio.TestTools.UnitTesting;
using NoteBook.ViewModels;
using NoteBook.Repo;
using NoteBook.Models;
using System.Collections.Generic;

namespace NoteBookUnitTest
{
    [TestClass]
    public class NoteBookTest
    {
        //[TestMethod]
        //public void TestIfVlaue_Test_1_IsLocatedInNoteFile()
        //{
        //    string testName = "Test 1";

        //    Assert.AreEqual(false, noteFileViewModel.NameExists(testName), testName + " Does not exist in Note File");
        //}

        [TestMethod]
        public void TestDatabaseConnectionIsClosed()
        {
            DBNoteBook.dBConnection.Open();
            Assert.AreEqual(System.Data.ConnectionState.Open, DBNoteBook.dBConnection.State);
        }

        [TestMethod]
        public void TestInsertMethodToDataBase()
        {
            bool available = false;
            DBNoteBook.InsertNote("Test 1", "Test 1 Text");
            List<NoteFile> testList = DBNoteBook.RetrieveAllFiles();
            foreach(NoteFile note in testList)
            {
                if ("Test 1" == note.fileName)
                {
                    available = true;
                    break;
                }
            }
            Assert.IsTrue(available);
        }

        [TestMethod]
        public void TestUpdateMethodToDataBase()
        {
            bool available = false;
            DBNoteBook.UpdateNote("Test 1", "Test 1 Content");
            List<NoteFile> testList = DBNoteBook.RetrieveAllFiles();
            foreach (NoteFile note in testList)
            {
                if ("Test 1 Content" == note.fileContent)
                {
                    available = true;
                    break;
                }
            }
            Assert.IsTrue(available);
        }

        [TestMethod]
        public void TestDeleteMethodToDataBase()
        {
            bool notAvailable = false;
            DBNoteBook.DeleteNote("Test 1");
            List<NoteFile> testList = DBNoteBook.RetrieveAllFiles();
            foreach (NoteFile note in testList)
            {
                if ("Test 1" != note.fileName)
                {
                    notAvailable = true;
                    break;
                }
            }
            Assert.IsTrue(notAvailable);
        }
    }
}
