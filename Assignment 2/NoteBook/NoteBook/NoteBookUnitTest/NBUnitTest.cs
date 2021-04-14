using Microsoft.VisualStudio.TestTools.UnitTesting;
using NoteBook.ViewModels;

namespace NoteBookUnitTest
{
    [TestClass]
    public class NoteBookTest
    {

        readonly NoteFileViewModel noteFileViewModel = new NoteFileViewModel();

        [TestMethod]
        public void TestIfVlaue_Test_1_IsLocatedInNoteFile()
        {
            string testName = "Test 1";

            Assert.AreEqual(false, noteFileViewModel.NameExists(testName), testName + " Does not exist in Note File");
        }
    }
}
