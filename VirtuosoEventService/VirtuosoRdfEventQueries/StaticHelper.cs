using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtuosoRdfEventQueries
{
    public enum OrderDirection
    {
        ASC, DESC, NONE
    }
    public enum DirecFile
    {
        File, Directory
    }
    public enum GroupPerson
    {
        Group, Person
    }
    public enum CommonRoots
    {
        NONE, Dropbox, OwnCloud, GoogleDrive
    }
    class StaticHelper
    {
        public static Dictionary<string, string> GetRootDirectories()
        {
            Dictionary<string, string> zw = new Dictionary<string, string>();
            zw.Add("Dropbox", "C:\\Users\\m.freudenberg\\Dropbox\\");
            zw.Add("Desktop", "C:\\Users\\Administrator\\Desktop\\");
            //TODO
            return new Dictionary<string, string>();
        }
    }
}
