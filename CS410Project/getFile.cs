using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS410Project
{
    class getFile
    {
        private string savePath;
        private List<string> targetFiles;

        public getFile(List<string> targetfiles, string savepath)
        {
            savePath = savepath;
            targetFiles = targetfiles;

            if (savePath == "")
                setSavePathToDesktop();
        }

        public void saveFiles(FTPClient toUse)
        {
            int failed = 0;
            int succeeded = 0;
            for (int i = 0; i < targetFiles.Count; ++i)
            {
                if (toUse.getFile(targetFiles[i], savePath))
                {
                    ++succeeded;
                }
                else
                {
                    ++failed;
                }
            }
            Console.WriteLine(succeeded + " file gets successful");
            Console.WriteLine(failed + " file gets failed.");
        }

        public void setSavePathToDesktop()
        {
            savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }
    }


}
