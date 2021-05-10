
namespace MusicLibrariesManager
{
    class ArrayActions
    {
        
        public void ListAllExtensions(System.Collections.Generic.List<BasicFileSystem> list, System.Collections.Generic.HashSet<string> hashSet)
        {
            string dirCurr;
            string nameCurr;
            string ext;
            int pos;

            foreach (BasicFileSystem bfs in list)
            {
                dirCurr = bfs.Dir;
                nameCurr = bfs.Name;
                pos = nameCurr.LastIndexOf(".");
                if (pos == -1)
                    System.Diagnostics.Debug.Print(dirCurr + "||" + nameCurr); //Ext
                else
                {
                    ext = nameCurr.Substring(pos);
                    hashSet.Add(ext);
                }
            }
        }

        public void CustomizedExtensionAction(string rootDir, System.Collections.Generic.List<BasicFileSystem> list, string extension)
        {
            //System.Windows.Forms.MessageBox.Show("Customize action !!!!!!");
            //return;

            string dirCurr;
            string nameCurr;
            string extFound;
            int pos;

            foreach (BasicFileSystem bfs in list)
            {
                dirCurr = bfs.Dir;
                nameCurr = bfs.Name;
                pos = nameCurr.LastIndexOf(".");
                if (pos > 0)
                {
                    extFound = nameCurr.Substring(pos);
                    if (extFound == extension)
                    {
                        string fullName = rootDir + @"\" + dirCurr + @"\" + nameCurr;

                        System.Diagnostics.Debug.Print(fullName);

                        //DELETE
                        //System.IO.File.Delete(fullName); 

                        //RENAME
                        //if (nameCurr == "HasOriginalCD.txt")
                        //{
                        //    char[] chrs = new char[1] { '\\' };
                        //    string[] names = dirCurr.Split(chrs);
                        //    string name = names[names.Length - 1];
                        //    pos = name.IndexOf("]");
                        //    string final = "#CD " + name.Substring(0, pos + 1) + ".Original";
                        //    string fullNameD = @"\\NAS-QNAP\music\_COLLECTION\" + dirCurr + @"\" + final;

                        //    System.IO.File.Move(fullName, fullNameD);
                        //}

                    }
                }
            }
        }

        public void FindBandsNotFormated(System.Collections.Generic.List<BasicFileSystem> list)
        {
            System.IO.StreamWriter streamWriter = new System.IO.StreamWriter("BandsNotFormatted.txt", false, System.Text.Encoding.UTF8);

            System.Collections.Generic.HashSet<string> hashSet = new System.Collections.Generic.HashSet<string>();
            char[] chrs = new char[1] { '\\'};
            bool error = false;

            foreach (BasicFileSystem bfs in list)
            {
                //if (bfs.Level == 2)
                {
                    //hashSet.Add(rootDir + @"\" + bfs.Dir);

                    //string fullName = rootDir + @"\" + bfs.Dir + @"\" + bfs.Name;
                    //System.Diagnostics.Debug.Print(fullName);
                    //streamWriter.WriteLine(fullName);
                    string[] names = bfs.Dir.Split(chrs);

                    int pos1 = names[1].IndexOf("{");
                    int pos2 = names[1].IndexOf("}");

                    int pos3 = names[1].IndexOf("[");
                    int pos4 = names[1].IndexOf("]");

                    error = (pos1 == -1);
                    
                    if (!error)
                        error = (pos2 == -1);
                    
                    if (!error)
                        error = (pos2 < pos1);

                    if (!error)
                        error = (pos2 == pos1+1);

                    if (!error)
                        error = ((pos3 != -1) || (pos4 != -1));

                    if (!error)
                    {
                        string letter = names[1].Substring(0, 1);

                        if ("ABCDEFGHIJKLMNOPQRSTUVWXYZ".Contains(names[0]))
                            error = names[0] != letter;
                        else
                        {
                            if (names[0] == "0-9")
                                error = (!("0123456789".Contains(letter)));

                            if (names[0] == "VA")
                            {
                                string va = names[1].Substring(0, 15);
                                error = va != "Various Artists";
                            }
                        }

                    }

                    if (error)
                    {
                        System.Diagnostics.Debug.Print(bfs.Dir);
                        streamWriter.WriteLine(bfs.Dir);
                        streamWriter.Flush();
                    }

                }

            }

            streamWriter.Flush();
            streamWriter.Close();


        }

        public void FindEntriesInLevel(System.Collections.Generic.List<BasicFileSystem> list)
        {
            System.IO.StreamWriter streamWriter = new System.IO.StreamWriter("EntriesInLevel.txt", false, System.Text.Encoding.UTF8);

            System.Collections.Generic.HashSet<string> hashSet = new System.Collections.Generic.HashSet<string>();
            char[] chrs = new char[1] { '\\' };
            bool error = false;

            foreach (BasicFileSystem bfs in list)
            {
                if (bfs.Level < 3)
                {
                    System.Diagnostics.Debug.Print(bfs.Dir);
                    streamWriter.WriteLine(bfs.Dir);
                    streamWriter.Flush();

                }
            }

            streamWriter.Flush();
            streamWriter.Close();
            
            return;
        }

        public void FindAlbunsNotFormated(System.Collections.Generic.List<BasicFileSystem> list)
        {
            System.IO.StreamWriter streamWriter = new System.IO.StreamWriter("AlbunsNotFormatted.txt", false, System.Text.Encoding.UTF8);
            char[] chrs = new char[1] { '\\' };
            bool error = false;

            foreach (BasicFileSystem bfs in list)
            {
                if (bfs.Level >= 3)
                {
                    //hashSet.Add(rootDir + @"\" + bfs.Dir);

                    //string fullName = rootDir + @"\" + bfs.Dir + @"\" + bfs.Name;
                    //System.Diagnostics.Debug.Print(fullName);
                    //streamWriter.WriteLine(fullName);
                    string[] names = bfs.Dir.Split(chrs);

                    int pos1 = names[2].IndexOf("{");
                    int pos2 = names[2].IndexOf("}");

                    int pos3 = names[2].IndexOf("[");
                    int pos4 = names[2].IndexOf("]");

                    string letter = names[1].Substring(0, 1);


                    //{}
                    error = (pos1 == -1);

                    if (!error)
                        error = (pos2 == -1);

                    if (!error)
                        error = (pos2 < pos1);

                    if (!error)
                        error = (pos2 == pos1 + 1);

                    //[]
                    if (!error)
                        error = (pos3 == -1);

                    if (!error)
                        error = (pos4 == -1);

                    if (!error)
                        error = (pos4 < pos3);

                    if (!error)
                        error = (pos4 == pos3 + 1);

                    //[ before {
                    if (!error)
                        error = (pos1 < pos3);







                    if (error)
                    {
                        //System.Diagnostics.Debug.Print(bfs.Dir);
                        streamWriter.WriteLine(bfs.Dir);
                        streamWriter.Flush();
                    }

                }
                else
                    System.Diagnostics.Debug.Print("-------------" + bfs.Dir);

            }

            streamWriter.Flush();
            streamWriter.Close();


        }

        public void RenameAlbuns(System.Collections.Generic.List<BasicFileSystem> list, string rootDir)
        {
            System.Collections.Generic.HashSet<string> hashSet = new System.Collections.Generic.HashSet<string>();

            char[] chrs = new char[1] { '\\' };
            bool error = false;

            foreach (BasicFileSystem bfs in list)
            {
                string[] names = bfs.Dir.Split(chrs);

                foreach (string name in names)
                {
                    int pos1 = name.IndexOf("{");
                    int pos2 = name.IndexOf("}");

                    int pos3 = name.IndexOf("[");
                    int pos4 = name.IndexOf("]");


                    //{}
                    error = (pos1 == -1);

                    if (!error)
                        error = (pos2 == -1);

                    if (!error)
                        error = (pos2 < pos1);

                    //[]
                    if (!error)
                        error = (pos3 == -1);

                    if (!error)
                        error = (pos4 == -1);

                    if (!error)
                        error = (pos4 < pos3);

                    if (!error)
                        error = (pos1 < pos3);

                    if (!error)
                        error = (pos2 != (name.Length - 1));

                    if (!error)
                    {
                        string aBand = name.Substring(0, pos3).Trim();
                        string aAlbum = name.Substring(pos3, pos4 - pos3 + 1).Trim();
                        string aDate = name.Substring(pos1, pos2 - pos1 + 1).Trim();

                        string newName = bfs.Dir.Replace(name, aBand + " " + aDate + " " + aAlbum + " @MP3");

                        hashSet.Add(bfs.Dir +  "||" + newName);
                    }
                }

            }

            char[] chrs2 = new char[2] { '|', '|' };

            ////Efective rename folder
            //MsDosDirCommand dos = new MsDosDirCommand();
            //dos.CreateDrive(rootDir, "S");
            //foreach (string name in hashSet)
            //{
            //     string[] names = name.Split(chrs2);
            //     dos.FolderRename2("S", names[0], names[2]);

            //}
            
            
            //Output to file
            System.IO.StreamWriter streamWriter = new System.IO.StreamWriter("FolderNOTrenamed.txt", false, System.Text.Encoding.UTF8);
            foreach (string name in hashSet)
            {
                string[] names = name.Split(chrs2);
                //dos.FolderRenameNaoCorreBem(rootDir, names[0], names[2]);
                streamWriter.WriteLine(names[0] + "|||" + names[2]);
                streamWriter.Flush();

            }
            streamWriter.Close();


        }

        public void ShowFolderInLevel(string rootDirMp3, System.Collections.Generic.List<BasicFileSystem> list, int level)
        {

            MsDosDirCommand msDosDirCommand = new MsDosDirCommand();

            System.Collections.Generic.HashSet<string> hashSet = new System.Collections.Generic.HashSet<string>();

            System.IO.StreamWriter streamWriter = new System.IO.StreamWriter("FolderInLevel-" + level.ToString().Trim() + ".txt", false, System.Text.Encoding.UTF8);

            char[] chrs = new char[1] { '\\' };

            foreach (BasicFileSystem bfs in list)
            {
                if (bfs.Level == level)
                {
                    string[] names = bfs.Dir.Split(chrs);
 
                    if (names[3] == "Artwork") 
                        continue;

                    int a = names[3].Length;
                    if (a > 5)
                    {
                        string cd = names[3].Substring(0, 6);
                        if ((cd == "CD 1 [") || (cd == "CD 2 [") || (cd == "CD 3 [") || (cd == "CD 4 [") || (cd == "CD 5 [") || (cd == "CD 6 [") || (cd == "CD 7 [") || (cd == "CD 8 [") || (cd == "CD 9 ["))
                            continue;
                    }

                    hashSet.Add(names[3]);
                    //System.Diagnostics.Debug.Print(rootDirMp3 + "\\" + bfs.Dir);
                    streamWriter.WriteLine(rootDirMp3 + "\\" + bfs.Dir);
                    streamWriter.Flush();
                    System.Windows.Forms.Application.DoEvents();

                    if (names[3] == "covers")
                    {
                        string source = "\\" + names[0] + "\\" + names[1] + "\\" + names[2];
                        //msDosDirCommand.FolderRename(rootDirMp3, source, "covers", "Artwork");

                        //string source = "\\" + names[0] + "\\" + names[1] + "\\" + names[2];
                        //string rootDirMp3B = "\\\\Svbst001fls13\\users\\user\\Tests";
                        //System.IO.StreamWriter fileW = new System.IO.StreamWriter("temp.cmd", false, System.Text.Encoding.ASCII);
                        //fileW.WriteLine("IF EXIST S:\\ GOTO LABEL1");
                        //fileW.WriteLine("NET USE S: " + rootDirMp3B);
                        //fileW.WriteLine(":LABEL1");
                        //fileW.WriteLine("S:");
                        //fileW.WriteLine("CD \"" + source + "\"");
                        //fileW.WriteLine("REN Covers Artwork");
                        ////fileW.WriteLine("PAUSE");
                        //fileW.Flush();
                        //fileW.Close();

                        //System.Diagnostics.Process.Start("temp.cmd").WaitForExit();
                    }
                }
            }

            streamWriter.Flush();
            streamWriter.Close();


            System.IO.StreamWriter streamWriter1 = new System.IO.StreamWriter("FolderInLevel-Name-" + level.ToString().Trim() + ".txt", false, System.Text.Encoding.UTF8);
            foreach (string item in hashSet)
            {
                streamWriter1.WriteLine(item);
                streamWriter1.Flush();
                System.Windows.Forms.Application.DoEvents();
            }
            streamWriter1.Flush();
            streamWriter1.Close();

        }



        public void AlbumFoldersAction(string rootDir, System.Collections.Generic.List<BasicFileSystem> list)
        {
            //System.Windows.Forms.MessageBox.Show("Customize action !!!!!!");
            //return;

            System.IO.StreamWriter streamWriter = new System.IO.StreamWriter("FoldersAlbuns.txt", false, System.Text.Encoding.UTF8);

            System.Collections.Generic.HashSet<string> hashSet = new System.Collections.Generic.HashSet<string>();

            foreach (BasicFileSystem bfs in list)
            {
                if (bfs.Level > 3)
                {
                    hashSet.Add(rootDir + @"\" + bfs.Dir);

                    string fullName = rootDir + @"\" + bfs.Dir + @"\" + bfs.Name;
                    System.Diagnostics.Debug.Print(fullName);
                    streamWriter.WriteLine(fullName);

                    //DELETE
                    //System.IO.File.Delete(fullName); 

                    //RENAME
                    //if (nameCurr == "HasOriginalCD.txt")
                    //{
                    //    char[] chrs = new char[1] { '\\' };
                    //    string[] names = dirCurr.Split(chrs);
                    //    string name = names[names.Length - 1];
                    //    pos = name.IndexOf("]");
                    //    string final = "#CD " + name.Substring(0, pos + 1) + ".Original";
                    //    string fullNameD = @"\\NAS-QNAP\music\_COLLECTION\" + dirCurr + @"\" + final;

                    //    System.IO.File.Move(fullName, fullNameD);
                    //}

                }
            }

            streamWriter.Close();

            System.IO.StreamWriter streamWriterB = new System.IO.StreamWriter("FoldersAlbunsHeaders.txt", false, System.Text.Encoding.UTF8);

            foreach (string txt in hashSet)
                streamWriterB.WriteLine(txt);

            streamWriterB.Close();

        }
    }

}

