using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MusicLibrariesManager
{
    public partial class FormManageMusicFiles : Form
    {
        string rootDirMp3 = @"\\NAS-QNAP\music\_COLLECTION";
        string rootDirMp3Resolve = @"\\NAS-QNAP\music\_MUSIC_TO_RESOLVE";
        string rootDirLossless = @"\\NAS-QNAP\music_lossless\_COLLECTION";
        string rootDirLosslessResolve = @"\\NAS-QNAP\music_lossless\_FLACS_TO_RESOLVE";

        System.Collections.Generic.List<BasicFileSystem> listCollectionMp3 = new System.Collections.Generic.List<BasicFileSystem>();
        System.Collections.Generic.List<BasicFileSystem> listResolveMp3 = new System.Collections.Generic.List<BasicFileSystem>();
        System.Collections.Generic.List<BasicFileSystem> listCollectionLossless = new System.Collections.Generic.List<BasicFileSystem>();
        System.Collections.Generic.List<BasicFileSystem> listResolveLossless = new System.Collections.Generic.List<BasicFileSystem>();

        System.Collections.Generic.List<string> listCollectionMp3D = new System.Collections.Generic.List<string>();
        System.Collections.Generic.List<string> listResolveMp3D = new System.Collections.Generic.List<string>();
        System.Collections.Generic.List<string> listCollectionLosslessD = new System.Collections.Generic.List<string>();
        System.Collections.Generic.List<string> listResolveLosslessD = new System.Collections.Generic.List<string>();

        System.Collections.Generic.HashSet<string> hashSetCollectionMp3 = new System.Collections.Generic.HashSet<string>();
        System.Collections.Generic.HashSet<string> hashSetResolveMp3 = new System.Collections.Generic.HashSet<string>();
        System.Collections.Generic.HashSet<string> hashSetCollectionLossless = new System.Collections.Generic.HashSet<string>();
        System.Collections.Generic.HashSet<string> hashSetResolveLossless = new System.Collections.Generic.HashSet<string>();


        public FormManageMusicFiles()
        {
            InitializeComponent();
        }

        private void treeViewCollectionMP3_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode aa = e.Node;
            this.textBox1.Text = aa.Level.ToString();


            this.textBox2.Text = aa.FullPath;

        }


        private void buttonListAllExtensions_Click(object sender, EventArgs e)
        {
            ArrayActions arrayActions = new ArrayActions();

            arrayActions.ListAllExtensions(listCollectionMp3, hashSetCollectionMp3);
            //arrayActions.ListAllExtensions(listResolveMp3, hashSetMP3Resolve);
            //arrayActions.ListAllExtensions(listCollectionLossless, hashSetLossLess);
            //arrayActions.ListAllExtensions(listResolveLossless, hashSetLossLessResolve);


            listView1.Items.Clear();
            //listView1.sty
            foreach(string item in hashSetCollectionMp3)
                listView1.Items.Add(item);
        }

        private void buttonExtentionAction_Click(object sender, EventArgs e)
        {
            ArrayActions arrayActions = new ArrayActions();

            //arrayActions.CustomizedExtensionAction(rootDirMp3, listCollectionMp3, ".gif");
            arrayActions.CustomizedExtensionAction(rootDirMp3, listCollectionMp3, ".txt");

        }

//1-garantir que todos os directorios têm nomes certos
//2-apagar todos os ficheiros desnecessarios
//3-zippar images
//4-rename (trocar ano) e colocar @mp3

        //[0]: ".mp3"
        //[6]: ".Mp3"
        //[10]: ".MP3"
        //[1]: ".jpg"
        //[2]: ".JPG"
        //[9]: ".Jpg"
        //[7]: ".jpeg"
        //[3]: ".Original"
        //[4]: ".lnk"
        //[5]: ".txt"
        //[8]: ".png"
        //[11]: ".pdf"

        private void buttonReadMusicFolders_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Enabled = false;


            MsDosDirCommand msDosDirCommand = new MsDosDirCommand();

            //Ler directorios
            msDosDirCommand.ReadAllInfoToFile(rootDirMp3, "music_collection_mp3.txt");

            //msDosDirCommand.ReadAllInfoToFile(rootDirMp3Resolve, "music_resolve_mp3.txt");
            //msDosDirCommand.ReadAllInfoToFile(rootDirLossless, "music_collection_lossless.txt");
            //msDosDirCommand.ReadAllInfoToFile(rootDirLosslessResolve, "music_resolve_lossless.txt");

            this.Cursor = Cursors.Default;
            this.Enabled = true;

        }

        private void buttonMountInternalArraysFiles_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Enabled = false;

            MsDosDirCommand msDosDirCommand = new MsDosDirCommand();
            //monta num array limpo

            msDosDirCommand.GenerateCleanArrayF(rootDirMp3, "music_collection_mp3.txt", listCollectionMp3);
            //msDosDirCommand.GenerateCleanArray(rootDirMp3Resolve, "music_resolve_mp3.txt", listResolveMp3);
            //msDosDirCommand.GenerateCleanArray(rootDirLossless, "music_collection_lossless.txt", listCollectionLossless);
            //msDosDirCommand.GenerateCleanArray(rootDirLosslessResolve, "music_resolve_lossless.txt", listResolveLossless);

            this.Cursor = Cursors.Default;
            this.Enabled = true;

        }

        private void buttonPopulateTreeViews_Click(object sender, EventArgs e)
        {
            //Monta treeView
            this.Cursor = Cursors.WaitCursor;
            this.Enabled = false;

            System.DateTime dtIni = System.DateTime.Now;

            string letter = this.comboBoxMP3Letter.Text;

            TreeViewActions treeViewActions = new TreeViewActions();

            this.treeViewCollectionMP3.Nodes.Clear();
            System.Windows.Forms.TreeNode treeNodeRoot = new System.Windows.Forms.TreeNode("ROOT");
            treeViewActions.PopulateTreeNodeFromCleanArray(treeNodeRoot, listCollectionMp3);
            this.treeViewCollectionMP3.Nodes.Add(treeNodeRoot);

            //this.treeViewCollectionMP3.Nodes.Clear();
            //System.Windows.Forms.TreeNode treeNodeRoot = new System.Windows.Forms.TreeNode("ROOT");
            //treeViewActions.PopulateTreeNodeFromCleanArray(treeNodeRoot, listCollectionMp3);
            //this.treeViewCollectionMP3.Nodes.Add(treeNodeRoot);


            this.Cursor = Cursors.Default;
            this.Enabled = true;
            System.DateTime dtEnd = System.DateTime.Now;

            System.TimeSpan diff1 = dtEnd.Subtract(dtIni);

            System.Windows.Forms.MessageBox.Show(diff1.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
             TreeViewActions treeViewActions = new TreeViewActions();
             treeViewActions.ExportToXml(this.treeViewCollectionMP3, "My_TreeView.xml");
             treeViewActions.ExportToXml(this.treeViewCollectionMP3, "My_TreeView.txt");
        }

        private void buttonFilesAction_Click(object sender, EventArgs e)
        {
            ArrayActions arrayActions = new ArrayActions();

            arrayActions.AlbumFoldersAction(rootDirMp3, listCollectionMp3);
        }

        private void comboBoxMP3Letter_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Monta treeView
            this.Cursor = Cursors.WaitCursor;
            this.Enabled = false;

            System.DateTime dtIni = System.DateTime.Now;

            string letter = this.comboBoxMP3Letter.Text;

            TreeViewActions treeViewActions = new TreeViewActions();

            this.treeViewCollectionMP3.Nodes.Clear();
            System.Windows.Forms.TreeNode treeNodeRoot = new System.Windows.Forms.TreeNode("Root");
            treeViewActions.PopulateTreeNodeFromCleanArrayOnLetter(treeNodeRoot, listCollectionMp3, letter);
            this.treeViewCollectionMP3.Nodes.Add(treeNodeRoot);


            foreach (TreeNode tn in treeViewCollectionMP3.Nodes)
            {
                tn.Expand();
            }

            this.Cursor = Cursors.Default;
            this.Enabled = true;
            System.DateTime dtEnd = System.DateTime.Now;

            System.TimeSpan diff1 = dtEnd.Subtract(dtIni);

            //System.Windows.Forms.MessageBox.Show(diff1.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ArrayActions arrayActions = new ArrayActions();

            arrayActions.FindBandsNotFormated(listCollectionMp3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ArrayActions arrayActions = new ArrayActions();

            arrayActions.FindAlbunsNotFormated(listCollectionMp3);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ArrayActions arrayActions = new ArrayActions();

            arrayActions.ShowFolderInLevel(rootDirMp3, listCollectionMp3,  4);
        }

        private void buttonExportCleanArrayDirOnlyAndAll_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Enabled = false;

            MsDosDirCommand msDosDirCommand = new MsDosDirCommand();
            //monta num array limpo

            msDosDirCommand.GenerateCleanFileD(rootDirMp3, "music_collection_mp3.txt", "music_collection_mp3D.txt");
            msDosDirCommand.GenerateCleanFileF(rootDirMp3, "music_collection_mp3.txt", "music_collection_mp3F.txt");

            //msDosDirCommand.GenerateCleanArray(rootDirMp3Resolve, "music_resolve_mp3.txt", listResolveMp3);
            //msDosDirCommand.GenerateCleanArray(rootDirLossless, "music_collection_lossless.txt", listCollectionLossless);
            //msDosDirCommand.GenerateCleanArray(rootDirLosslessResolve, "music_resolve_lossless.txt", listResolveLossless);

            this.Cursor = Cursors.Default;
            this.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //MsDosDirCommand msDosDirCommand = new MsDosDirCommand();
            //msDosDirCommand.GenerateCleanFileD(rootDirMp3, "music_collection_mp3.txt", "music_collection_mp3D.txt");

            ArrayActions arrayActions = new ArrayActions();

            arrayActions.RenameAlbuns(listCollectionMp3, rootDirMp3);
        }

        private void buttonMountInternalArraysDirsMP3_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Enabled = false;

            MsDosDirCommand msDosDirCommand = new MsDosDirCommand();
            //monta num array limpo

            msDosDirCommand.GenerateCleanFileMP3Only(rootDirMp3, "music_collection_mp3.txt", "music_collection_mp3FilesOnly.txt");

            this.Cursor = Cursors.Default;
            this.Enabled = true;
        }



    }
}
