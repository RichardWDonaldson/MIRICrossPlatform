using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MIRIApp
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);
    }
}
