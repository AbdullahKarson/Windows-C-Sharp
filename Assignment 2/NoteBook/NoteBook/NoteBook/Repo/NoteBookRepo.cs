using System;
using System.Diagnostics;
using Windows.Storage;

namespace NoteBook.Repositories
{
    class NoteBookRepo
    {
        //Create a storage Folder
        private static StorageFolder storageFolder = ApplicationData.Current.LocalFolder;

        /// <summary>
        /// Create a file with the given FileName and Content
        /// </summary>
        /// <param name="pFileName"></param>
        /// <param name="pContent"></param>
        public async void CreateNewFile(string pFileName, string pContent)
        {
            try
            {
                StorageFile tempFile =
                    await storageFolder.CreateFileAsync((pFileName + ".txt"),
                    CreationCollisionOption.OpenIfExists);
                await FileIO.AppendTextAsync(tempFile, pContent);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("An error occurred while creating a file " + ex.Message);
            }
        }

        /// <summary>
        /// Delete an existing file
        /// </summary>
        /// <param name="pFileName"></param>
        public async void DeleteFile(string pFileName)
        {
            try
            {
                StorageFile tempFile =
                    await storageFolder.GetFileAsync(pFileName + ".txt");
                await tempFile.DeleteAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("An error occurred while deleting the file " + ex.Message);
            }
        }

        /// <summary>
        /// Edit an existing file
        /// </summary>
        /// <param name="pFileName"></param>
        /// <param name="pContent"></param>
        public async void WriteToFile(string pFileName, string pContent)
        {
            try
            {
                StorageFile tempFile =
                    await storageFolder.GetFileAsync(pFileName + ".txt");
                await FileIO.WriteTextAsync(tempFile, pContent);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("An error occurred while writing to the file " + ex.Message);
            }
        }
    }
}