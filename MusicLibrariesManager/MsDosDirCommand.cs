
namespace MusicLibrariesManager
{
    //Criar map para o NAS           : net use k: \\tower\movies
    //rename files in all sub floders: for /r %x in (*.html) do ren "%x" *.htm

    public class BasicFileSystem
    {
        private string _dir;
        private string _name;
        private int _level;

        public string Dir
        {
            get { return _dir; }
        }

        public string Name
        {
            get { return _name; }
        }

        public int Level
        {
            get { return _level; }
        }

        public BasicFileSystem(string dir, string name, int level)
        {
            _dir = dir;
            _name = name;
            _level = level;
        }
    }

    public class MsDosDirCommand
    {
        public void CreateDrive(string rootDir, string letter)
        {
            System.IO.StreamWriter fileW = new System.IO.StreamWriter("temp.cmd", false, System.Text.Encoding.ASCII);
            fileW.WriteLine("IF EXIST " + letter + ":\\ GOTO LABEL1");
            fileW.WriteLine("NET USE " + letter +": " + rootDir);
            fileW.WriteLine("ECHO MOUNTED...");
            fileW.WriteLine(":LABEL1");
            //fileW.WriteLine("PAUSE");
            fileW.Flush();
            fileW.Close();
            System.Diagnostics.Process proc = System.Diagnostics.Process.Start("temp.cmd");
            proc.WaitForExit();
            int bb = proc.ExitCode;
            if (bb > 0)
            {
                bb = bb;
            }
        }
        public void FolderRename2(string letter, string oldName, string newName)
        {
           System.Diagnostics.Debug.Print(letter + ":\\" + oldName + ", " + letter + ":\\" + newName);

           try
           {

               string a1 = letter + ":\\" + oldName;
               string a2 = letter + ":\\" + newName;

               string cmd = "/C MOVE \"" + a1 + "\" \"" + a2 + "\"";
               System.Diagnostics.Process proc = System.Diagnostics.Process.Start("cmd.exe", cmd);
               proc.WaitForExit();
               int bb = proc.ExitCode;
               if (bb > 0)
               {
                   System.Diagnostics.Debug.Print(cmd);
               }
               //bool ok = MusicLibrariesManager.Class1.CopyFileW(a1, a2, true);

               //if (!ok)
               //    a1 = a1;
               //System.IO.File.Move(letter + ":\\" + oldName, letter + ":\\" + newName);
           }
            catch (System.Exception ex)
           {
               System.Diagnostics.Debug.Print(ex.Message);
               System.Diagnostics.Debug.Print("*");
           }
               
        }
        public void FolderRenameNaoCorreBem(string rootDir, string oldName, string newName)
        {
            System.IO.StreamWriter fileW = new System.IO.StreamWriter("temp.cmd", false, System.Text.Encoding.Unicode);
            fileW.WriteLine("CHCP 65001"); //utf8
            fileW.WriteLine("IF EXIST S:\\ GOTO LABEL1");
            fileW.WriteLine("NET USE S: " + rootDir);
            fileW.WriteLine(":LABEL1");
            fileW.WriteLine("S:");
            //fileW.WriteLine("CD \"" + dir + "\"");
            fileW.WriteLine("MOVE \"" + oldName + "\" \"" + newName + "\"");
            //fileW.WriteLine("PAUSE");
            fileW.Flush();
            fileW.Close();
            //System.Diagnostics.Debug.Print("MOVE \"" + oldName + "\" \"" + newName + "\"");
            System.Diagnostics.Process aa = System.Diagnostics.Process.Start("temp.cmd");
            aa.WaitForExit();
            int bb = aa.ExitCode;
            if (bb > 0)
            {
                System.Diagnostics.Debug.Print("MOVE \"" + oldName + "\" \"" + newName + "\"");
                bb = bb;
            }
            //System.Diagnostics.Process.Start("temp.cmd").WaitForExit();
        }

        public void FolderRename(string rootDir, string dir, string oldName, string newName)
        {
            System.IO.StreamWriter fileW = new System.IO.StreamWriter("temp.cmd", false, System.Text.Encoding.ASCII); //Unicode
            fileW.WriteLine("IF EXIST S:\\ GOTO LABEL1");
            fileW.WriteLine("NET USE S: " + rootDir);
            fileW.WriteLine(":LABEL1");
            fileW.WriteLine("S:");
            fileW.WriteLine("CD \"" + dir + "\"");
            fileW.WriteLine("REN " + oldName + " " + newName);
            //fileW.WriteLine("PAUSE");
            fileW.Flush();
            fileW.Close();
            System.Diagnostics.Process.Start("temp.cmd").WaitForExit();
        }


        public void ReadAllInfoToFile(string rootDir, string outputFile)
        {
            System.IO.StreamWriter fileW = new System.IO.StreamWriter("temp.cmd", false, System.Text.Encoding.ASCII);//Unicode
            fileW.WriteLine("CHCP 65001"); //utf8
            fileW.WriteLine("DIR /A:-S-H /O:N /S " + rootDir + @"\*.*>" + outputFile);
            fileW.Flush();
            fileW.Close();
            System.Diagnostics.Process.Start("temp.cmd").WaitForExit();

            //string cmdText = @"/C DIR /A:-S-H /O:N /S " + rootDir + @"\*.*>" + outputFile;  //generate file in ascii mode, i want in utf8 or unicode
            //System.Diagnostics.Process.Start("cmd.exe", cmdText);
            //CMD /C      ***Carries out the command specified by string and then terminates
            //DIR /A:-S-H ***Do not show files with attribute S and H (System, Hidden)
            //DIR /O:N    ***Sort by name
            //DIR /S      ***Loop for all sub direcories
        }

        private bool IgnoreFileLine(string line, string[] texts)
        {
            foreach (string text in texts)
            {
                if (line.IndexOf(text) == -1)
                    return false;

            }
            return true;
        }

        public void GenerateCleanFileF(string rootDir, string inputFile, string outputFile)
        {
            GenerateCleanArrayOrFileF(rootDir, inputFile, outputFile, null);
        }

        public void GenerateCleanArrayF(string rootDir, string inputFile, System.Collections.Generic.List<BasicFileSystem> list)
        {
            GenerateCleanArrayOrFileF(rootDir, inputFile, null, list);
        }

        public void GenerateCleanFileMP3Only(string rootDir, string inputFile, string outputFile)
        {
            GenerateCleanFileMP3Only(rootDir, inputFile, outputFile, null);
        }

        private void GenerateCleanArrayOrFileF(string rootDir, string inputFile, string outputFile, System.Collections.Generic.List<BasicFileSystem> list)
        {
            bool outToFile = (list == null);

            System.IO.StreamWriter fileW = null;
            System.IO.StreamReader fileR = new System.IO.StreamReader(inputFile);

            if (outToFile)
                fileW = new System.IO.StreamWriter(outputFile, false, System.Text.Encoding.UTF8);

            //string rootDirTemp = rootDir + @"\";
            string line = "";
            string dir = "";
            int level;

            while ((line = fileR.ReadLine()) != null)
            {
                System.Windows.Forms.Application.DoEvents();

                if (line.Trim() == "")
                    continue;

                //one words
                string[] texts = new string[1];

                texts[0] = " Volume in drive ";
                if (IgnoreFileLine(line, texts))
                    continue;

                texts[0] = " Volume Serial Number is ";
                if (IgnoreFileLine(line, texts))
                    continue;

                texts[0] = " Directory of ";
                if (IgnoreFileLine(line, texts))
                {
                    dir = line.Replace(" Directory of ", "").Trim();
                    continue;
                }

                texts[0] = "<DIR>";
                if (IgnoreFileLine(line, texts))
                    continue;

                texts[0] = "Total Files Listed:";
                if (IgnoreFileLine(line, texts))
                    continue;

                //two words
                texts = new string[2];

                texts[0] = "File(s)";
                texts[1] = "bytes";
                if (IgnoreFileLine(line, texts))
                    continue;

                texts[0] = "Dir(s)";
                texts[1] = "bytes";
                if (IgnoreFileLine(line, texts))
                    continue;

                string finalName = line.Substring(36, line.Length - 36);
                string finalDir = dir.Replace(rootDir, "");

                if (finalDir.Length > 0)
                    finalDir = finalDir.Substring(1);

                if (outToFile)
                {
                    fileW.WriteLine(finalDir + "||" + finalName);
                    fileW.Flush();
                    System.Windows.Forms.Application.DoEvents();
                }
                else
                {
                    level = finalDir.CountOccurencesOf(@"\") + 1;
                    BasicFileSystem bfs = new BasicFileSystem(finalDir, finalName, level);
                    list.Add(bfs);
                }
            }

            if (outToFile)
            {
                fileW.Flush();
                fileW.Close();
            }
            fileR.Close();

            if (!outToFile) 
                list.Sort((p1, p2) => Compare(p1, p2)); //Lambda

            //list.Sort( delegate(BasicFileSystem p1, BasicFileSystem p2)
            //           {
            //               return p1.Dir.CompareTo(p2.Dir);
            //           }
            //         );
        }

        private void GenerateCleanFileMP3Only(string rootDir, string inputFile, string outputFile, System.Collections.Generic.List<BasicFileSystem> list)
        {
            bool outToFile = (list == null);

            System.IO.StreamWriter fileW = null;
            System.IO.StreamReader fileR = new System.IO.StreamReader(inputFile);

            if (outToFile)
                fileW = new System.IO.StreamWriter(outputFile, false, System.Text.Encoding.UTF8);

            //string rootDirTemp = rootDir + @"\";
            string line = "";
            string dir = "";

            while ((line = fileR.ReadLine()) != null)
            {
                System.Windows.Forms.Application.DoEvents();

                if (line.Trim() == "")
                    continue;

                //one words
                string[] texts = new string[1];

                texts[0] = " Directory of ";
                if (IgnoreFileLine(line, texts))
                {
                    dir = line.Replace(" Directory of ", "").Trim();
                    continue;
                }

                string lineU = line.Trim().ToUpper();
                int len = lineU.Length;
                int pos = lineU.LastIndexOf(".MP3");

                if (pos > 0)
                {
                    string finalName = line.Substring(36, line.Length - 36);
                    //string finalDir = dir.Replace(rootDir, "");

                    if (outToFile)
                    {
                        fileW.WriteLine(dir + ";" + finalName);
                        fileW.Flush();
                        System.Windows.Forms.Application.DoEvents();
                    }
                    //else
                    //{
                    //    level = finalDir.CountOccurencesOf(@"\") + 1;
                    //    BasicFileSystem bfs = new BasicFileSystem(finalDir, finalName, level);
                    //    list.Add(bfs);
                    //}
                }
            }

            if (outToFile)
            {
                fileW.Flush();
                fileW.Close();
            }
            fileR.Close();

            if (!outToFile)
                list.Sort((p1, p2) => Compare(p1, p2)); //Lambda

            //list.Sort( delegate(BasicFileSystem p1, BasicFileSystem p2)
            //           {
            //               return p1.Dir.CompareTo(p2.Dir);
            //           }
            //         );
        }


        public void GenerateCleanFileD(string rootDir, string inputFile, string outputFile)
        {
            GenerateCleanArrayOrFileD(rootDir, inputFile, outputFile, null);
        }
        public void GenerateCleanArrayD(string rootDir, string inputFile, System.Collections.Generic.List<string> list)
        {
            GenerateCleanArrayOrFileD(rootDir, inputFile, null, list);
        }

        private void GenerateCleanArrayOrFileD(string rootDir, string inputFile, string outputFile, System.Collections.Generic.List<string> list)
        {
            bool outToFile = (list == null);

            System.IO.StreamWriter fileW = null;
            System.IO.StreamReader fileR = new System.IO.StreamReader(inputFile);

            if (outToFile)
                fileW = new System.IO.StreamWriter(outputFile, false, System.Text.Encoding.UTF8);

            //string rootDirTemp = rootDir + @"\";
            string line = "";
            string dir = "";
            int level;

            while ((line = fileR.ReadLine()) != null)
            {
                System.Windows.Forms.Application.DoEvents();

                dir = "";

                if (line.Trim() == "")
                    continue;

                //one words
                string[] texts = new string[1];

                texts[0] = " Volume in drive ";
                if (IgnoreFileLine(line, texts))
                    continue;

                texts[0] = " Volume Serial Number is ";
                if (IgnoreFileLine(line, texts))
                    continue;

                texts[0] = "<DIR>";
                if (IgnoreFileLine(line, texts))
                    continue;

                texts[0] = "Total Files Listed:";
                if (IgnoreFileLine(line, texts))
                    continue;

                //two words
                texts = new string[2];

                texts[0] = "File(s)";
                texts[1] = "bytes";
                if (IgnoreFileLine(line, texts))
                    continue;

                texts[0] = "Dir(s)";
                texts[1] = "bytes";
                if (IgnoreFileLine(line, texts))
                    continue;

                texts[0] = " Directory of ";
                texts[1] = "";
                if (IgnoreFileLine(line, texts))
                {
                    dir = line.Replace(" Directory of ", "").Trim();
                }

                if (dir.Length > 0)
                {
                    if (outToFile)
                    {
                        fileW.WriteLine(dir);
                        fileW.Flush();
                        System.Windows.Forms.Application.DoEvents();
                    }
                    else
                    {
                        list.Add(dir);
                    }
                }
            }

            if (outToFile)
            {
                fileW.Flush();
                fileW.Close();
            }

            fileR.Close();

            if (!outToFile)
                list.Sort((p1, p2) => CompareD(p1, p2)); //Lambda

            //list.Sort( delegate(BasicFileSystem p1, BasicFileSystem p2)
            //           {
            //               return p1.Dir.CompareTo(p2.Dir);
            //           }
            //         );
        }

        public int CompareD(string p1, string p2)
        {
            return p1.CompareTo(p2);

        }

        public int Compare(BasicFileSystem p1, BasicFileSystem p2)
        {
            return p1.Dir.CompareTo(p2.Dir);

        }
    }


}
