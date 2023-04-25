using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicLibrariesManager
{
    class TreeViewActions
    {


        public void PopulateTreeNodeFromCleanFile(System.Windows.Forms.TreeNode treeNodeRoot, string inputCleanFile)
        {
            System.IO.StreamReader fileR = new System.IO.StreamReader(inputCleanFile);

            string rootName = "<ROOT>";

            string dirCurr = "";
            string nameCurr = "";
            string dirOld = "";
            char[] chrsSeparator = new char[1] { '\\' };
            string separator = new string(chrsSeparator);

            treeNodeRoot.Tag = rootName;
            System.Windows.Forms.TreeNode treeNodeCurr = treeNodeRoot;

            int pos;
            string line;

            while ((line = fileR.ReadLine()) != null)
            {
                pos = line.IndexOf("||");
                if (pos != -1)
                {
                    dirCurr = line.Substring(0, pos);
                    nameCurr = line.Substring(pos);
                }

                if (dirCurr != dirOld)
                {
                    string[] dirNames = dirCurr.Split(chrsSeparator);
                    string dirFullName = "";

                    treeNodeCurr = treeNodeRoot;

                    foreach (string dirName in dirNames)
                    {
                        dirFullName += (separator + dirName);

                        if (treeNodeCurr.Name != dirFullName)
                        {
                            System.Windows.Forms.TreeNode[] treeNodes = treeNodeRoot.Nodes.Find(dirFullName, true);
                            if (treeNodes.Length > 0)
                                treeNodeCurr = treeNodes[0];
                            else
                            {
                                System.Windows.Forms.TreeNode treeNode = new System.Windows.Forms.TreeNode();
                                treeNode.Name = dirFullName;
                                treeNode.Text = dirName;
                                treeNode.Tag = "<DIR>";
                                treeNodeCurr.Nodes.Add(treeNode);
                                //System.Diagnostics.Debug.Print(treeNode.Name);
                                treeNodeCurr = treeNode;
                            }
                        }

                        dirOld = dirFullName;
                    }
                }

                ////Including all files make the process very very slow
                //System.Windows.Forms.TreeNode treeNodeFile = new System.Windows.Forms.TreeNode(nameCurr);
                //treeNodeFile.Name = dirCurr + "?" + nameCurr;
                //treeNodeFile.Tag = "<FILE>";
                //treeNodeCurr.Nodes.Add(treeNodeFile);
                ////System.Diagnostics.Debug.Print(treeNodeFile.Name);
            }

            fileR.Close();
        }

        public void PopulateTreeNodeFromCleanArray(System.Windows.Forms.TreeNode treeNodeRoot, System.Collections.Generic.List<BasicFileSystem> list)
        {
            string rootName = "<ROOT>";

            string dirCurr = "";
            string nameCurr = "";
            string dirOld = "";
            char[] chrsSeparator = new char[1] { '\\' };
            string separator = new string(chrsSeparator);

            treeNodeRoot.Tag = rootName;
            System.Windows.Forms.TreeNode treeNodeCurr = treeNodeRoot;

            foreach (BasicFileSystem bfs in list)
            {
                dirCurr = bfs.Dir;
                nameCurr = bfs.Name;

                if (dirCurr != dirOld)
                {
                    string[] dirNames = dirCurr.Split(chrsSeparator);
                    string dirFullName = "";

                    treeNodeCurr = treeNodeRoot;

                    foreach (string dirName in dirNames)
                    {

                        dirFullName += (separator + dirName);

                        if (treeNodeCurr.Name != dirFullName)
                        {
                            System.Windows.Forms.TreeNode[] treeNodes = treeNodeRoot.Nodes.Find(dirFullName, true);
                            if (treeNodes.Length > 0)
                                treeNodeCurr = treeNodes[0];
                            else
                            {
                                System.Windows.Forms.TreeNode treeNode = new System.Windows.Forms.TreeNode();
                                treeNode.Name = dirFullName;
                                treeNode.Text = dirName;
                                treeNode.Tag = "<DIR>";
                                treeNodeCurr.Nodes.Add(treeNode);
                                //System.Diagnostics.Debug.Print(treeNode.Name);
                                treeNodeCurr = treeNode;
                            }
                        }
                        
                        dirOld = dirFullName;
                    }
                }

                ////Including all files make the process very very slow
                //System.Windows.Forms.TreeNode treeNodeFile = new System.Windows.Forms.TreeNode(nameCurr);
                //treeNodeFile.Name = dirCurr + "?" + nameCurr;
                //treeNodeFile.Tag = "<FILE>";
                //treeNodeCurr.Nodes.Add(treeNodeFile);
                ////System.Diagnostics.Debug.Print(treeNodeFile.Name);
            }
        }

        public void PopulateTreeNodeFromCleanArrayOnLetter(System.Windows.Forms.TreeNode treeNodeRoot, System.Collections.Generic.List<BasicFileSystem> list, string letter)
        {
            string rootName = "<ROOT>";

            string dirCurr = "";
            string nameCurr = "";
            string dirOld = "";
            char[] chrsSeparator = new char[1] { '\\' };
            string separator = new string(chrsSeparator);

            treeNodeRoot.Tag = rootName;
            System.Windows.Forms.TreeNode treeNodeCurr = treeNodeRoot;

            foreach (BasicFileSystem bfs in list)
            {
                dirCurr = bfs.Dir;
                nameCurr = bfs.Name;

                if (dirCurr != dirOld)
                {
                    string[] dirNames = dirCurr.Split(chrsSeparator);
                    string dirFullName = "";

                    treeNodeCurr = treeNodeRoot;

                    if ((letter != "") && (dirNames[0] != letter))
                        continue;

                    int i = 0;
                    foreach (string dirName in dirNames)
                    {

                        dirFullName += (separator + dirName);

                        if (treeNodeCurr.Name != dirFullName)
                        {
                            System.Windows.Forms.TreeNode[] treeNodes = treeNodeRoot.Nodes.Find(dirFullName, true);
                            if (treeNodes.Length > 0)
                                treeNodeCurr = treeNodes[0];
                            else
                            {
                                if (i != 0)
                                {
                                    System.Windows.Forms.TreeNode treeNode = new System.Windows.Forms.TreeNode();
                                    treeNode.Name = dirFullName;
                                    treeNode.Text = dirName;
                                    treeNode.Tag = "<DIR>";
                                    treeNodeCurr.Nodes.Add(treeNode);
                                    treeNodeCurr = treeNode;
                                }
                                //System.Diagnostics.Debug.Print(treeNode.Name);
                                i++;
                            }
                        }

                        dirOld = dirFullName;
                    }
                }

                ////Including all files make the process very very slow
                //System.Windows.Forms.TreeNode treeNodeFile = new System.Windows.Forms.TreeNode(nameCurr);
                //treeNodeFile.Name = dirCurr + "?" + nameCurr;
                //treeNodeFile.Tag = "<FILE>";
                //treeNodeCurr.Nodes.Add(treeNodeFile);
                ////System.Diagnostics.Debug.Print(treeNodeFile.Name);
            }
        }

        private void xx(string a)
        {}

        public void ExportToXml(System.Windows.Forms.TreeView treeView, string filename)
        {
            System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(filename, false, System.Text.Encoding.UTF8);
            //Write the header
            streamWriter.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            //Write our root node
            streamWriter.WriteLine("<Node Text='" + treeView.Nodes[0].Text + "' Name='" + treeView.Nodes[0].Name + "' Level='" + treeView.Nodes[0].Level.ToString() + "' >");
            foreach (System.Windows.Forms.TreeNode node in treeView.Nodes)
            {
                SaveNodeXml(node.Nodes, streamWriter);
            }

            //Close the root node
            streamWriter.WriteLine("</Node>"); // + treeView.Nodes[0].Text + ">");
            streamWriter.Close();
        }

        private void SaveNodeXml(System.Windows.Forms.TreeNodeCollection treeNodeCollection, System.IO.StreamWriter streamWriter)
        {
            foreach (System.Windows.Forms.TreeNode node in treeNodeCollection)
            {
                ////If we have child nodes, we'll write 
                ////a parent node, then iterrate through
                ////the children
                //if (node.Nodes.Count > 0)
                //{
                    streamWriter.WriteLine("<Node Text='" + node.Text + "' Name='" + node.Name + "' Level='" + node.Level.ToString() + "' >");
                    SaveNodeXml(node.Nodes, streamWriter);
                    streamWriter.WriteLine("</Node>"); // + node.Text + ">");
                //}
                //else //No child nodes, so we just write the text
                //    streamWriter.WriteLine(node.Text);
            }
        }

        public void ExportToTxt(System.Windows.Forms.TreeView treeView, string filename)
        {
            System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(filename, false, System.Text.Encoding.UTF8);
            //Write the header
            //Write our root node
            streamWriter.WriteLine("Text=|" + treeView.Nodes[0].Text + "| Name=|" + treeView.Nodes[0].Name + "| Level=|" + treeView.Nodes[0].Level.ToString() + "|");
            foreach (System.Windows.Forms.TreeNode node in treeView.Nodes)
            {
                SaveNodeTxt(node.Nodes, streamWriter);
            }

            //Close the root node
            //streamWriter.WriteLine("</" + treeView.Nodes[0].Text + ">");
            streamWriter.Close();
        }

        private void SaveNodeTxt(System.Windows.Forms.TreeNodeCollection treeNodeCollection, System.IO.StreamWriter streamWriter)
        {
            foreach (System.Windows.Forms.TreeNode node in treeNodeCollection)
            {
                ////If we have child nodes, we'll write 
                ////a parent node, then iterrate through
                ////the children
                //if (node.Nodes.Count > 0)
                //{
                streamWriter.WriteLine("Text=|" + node.Text + "| Name=|" + node.Name + "| Level=|" + node.Level.ToString() + "|");
                SaveNodeXml(node.Nodes, streamWriter);
                //streamWriter.WriteLine("</" + node.Text + ">");
                //}
                //else //No child nodes, so we just write the text
                //    streamWriter.WriteLine(node.Text);
            }
        }
    }
}
