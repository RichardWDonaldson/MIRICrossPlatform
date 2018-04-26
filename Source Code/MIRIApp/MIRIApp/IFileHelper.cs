using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MIRIApp
{   //interface to allow each platform to get the local file path of the database
    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);
    }
}
