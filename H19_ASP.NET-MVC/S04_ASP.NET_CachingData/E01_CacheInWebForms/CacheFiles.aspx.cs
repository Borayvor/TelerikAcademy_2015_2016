namespace E01_CacheInWebForms
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Web.Caching;

    public partial class CacheFiles : System.Web.UI.Page
    {
        public List<string> allFilesPaths = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            var directoryPath = Path.GetFullPath(Server.MapPath("~/TestDirectory")); ;

            ProcessDirectory(directoryPath);
        }

        private void ProcessDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                ProcessFile(fileName);

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);
        }

        // Insert logic for processing found files here.
        private void ProcessFile(string path)
        {

            if (this.Cache["files"] == null)
            {
                var dependency = new CacheDependency(path);
                var content = string.Format("{0} [{1}]", File.ReadAllText(path), DateTime.Now);
                Cache.Insert(
                    "files",                    // key
                    content,                   // object
                    dependency,                // dependencies
                    DateTime.Now.AddSeconds(60),  // absolute exp.
                    TimeSpan.Zero,             // sliding exp.
                    CacheItemPriority.Default, // priority
                    null);                     // callback delegate
            }

            //this.filePathSpan.InnerText = path;

            allFilesPaths.Add(path);
            this.currentTimeSpan.InnerText = this.Cache["files"] as string;
        }
    }
}