namespace NoteBook.Models
{
    public class NoteFile
    {
        public string fileName { get; set; }
        public string fileContent { get; set; }

        /// <summary>
        /// The File Class. It will hold the File name and content
        /// </summary>
        /// <param name="pFileName"></param>
        /// <param name="pFileContent"></param>
        public NoteFile(string pFileName, string pFileContent)
        {
            fileName = pFileName;
            fileContent = pFileContent;
        }
    }
}
