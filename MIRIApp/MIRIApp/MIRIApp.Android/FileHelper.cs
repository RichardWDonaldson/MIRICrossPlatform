using System;
using System.IO;
using MIRIApp.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace MIRIApp.Droid
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}