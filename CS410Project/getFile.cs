﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS410Project
{
    class getFile
    {
        private static readonly log4net.ILog Log = LogHelper.GetLogger();
        private string savePath;
        private List<string> targetFiles;
        private String[] targetFilesArray;

        public getFile(string targetfile, string savepath)
        {
            savePath = savepath;
            targetFiles = new List<string>(1);
            targetFiles.Add(targetfile);

            if (savePath == "")
                setSavePathToDesktop();
        }

        public getFile(List<string> targetfiles, string savepath)
        {
            savePath = savepath;
            targetFiles = targetfiles;

            if (savePath == "")
                setSavePathToDesktop();
        }

        public getFile(string[] targetFiles, string savepath)
        {
            targetFilesArray = targetFiles;
            savePath = savepath;

            if (savePath == "")
                setSavePathToDesktop();
        }

		public void saveFiles(Client toUse, Boolean success)
		{
			int failed = 0;
			int succeeded = 0;
			if (targetFilesArray != null)
			{
				for (int i = 0; i < targetFilesArray.Length; ++i)
				{
					Console.WriteLine(targetFilesArray[i]);
					if (toUse.getFile(targetFilesArray[i], savePath))
					{
						++succeeded;
					}
					else
					{
						++failed;
					}
				}
			}
			else if (targetFiles != null)
			{
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
			}

			if (succeeded > 0)
				success = true;
			if (failed > 0)
				success = false;

			Console.WriteLine(succeeded + " file gets successful");
			Console.WriteLine(failed + " file gets failed.");
		}

        public void saveFiles(Client toUse, BackgroundWorker backgroundWorker1)
        {
            int failed = 0;
            int succeeded = 0;
            if (targetFilesArray != null)
            {
                for (int i = 0; i < targetFilesArray.Length; ++i)
                {
                    Console.WriteLine(targetFilesArray[i]);
                    if (toUse.getFile(targetFilesArray[i], savePath, backgroundWorker1))
                    {
                        ++succeeded;
                    }
                    else
                    {
                        ++failed;
                    }
                }
            }
            else if (targetFiles != null)
            {
                for (int i = 0; i < targetFiles.Count; ++i)
                {
                    if (toUse.getFile(targetFiles[i], savePath, backgroundWorker1))
                    {
                        ++succeeded;
                    }
                    else
                    {
                        ++failed;
                    }
                }
            }

            Console.WriteLine(succeeded + " file gets successful");
            Console.WriteLine(failed + " file gets failed.");
        }

        public void setSavePathToDesktop()
        {
            savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        public void setSavePath(String toset)
        {
            savePath = toset;
        }

        public void setTargetFiles(string toset)
        {
            targetFiles = new List<string>(1);
            targetFiles.Add(toset);
        }

        public void setTargetFiles(List<string> toset)
        {
            targetFiles = toset;
        }
    }


}
