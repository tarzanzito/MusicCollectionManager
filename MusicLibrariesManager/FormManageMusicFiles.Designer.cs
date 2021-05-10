namespace MusicLibrariesManager
{
    partial class FormManageMusicFiles
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeViewCollectionMP3 = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageInitial = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.buttonMountInternalArraysDirs = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonFilesAction = new System.Windows.Forms.Button();
            this.buttonExtentionAction = new System.Windows.Forms.Button();
            this.buttonListAllExtensions = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.buttonPopulateTreeViews = new System.Windows.Forms.Button();
            this.buttonMountInternalArraysFiles = new System.Windows.Forms.Button();
            this.buttonReadMusicFolders = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.treeViewResolveMP3 = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxMP3Letter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.treeViewResolveLossless = new System.Windows.Forms.TreeView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.treeViewCollectionLossless = new System.Windows.Forms.TreeView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buttonMountInternalArraysDirsMP3 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPageInitial.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewCollectionMP3
            // 
            this.treeViewCollectionMP3.Location = new System.Drawing.Point(6, 52);
            this.treeViewCollectionMP3.Name = "treeViewCollectionMP3";
            this.treeViewCollectionMP3.Size = new System.Drawing.Size(520, 514);
            this.treeViewCollectionMP3.TabIndex = 4;
            this.treeViewCollectionMP3.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewCollectionMP3_AfterSelect);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageInitial);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1492, 620);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPageInitial
            // 
            this.tabPageInitial.Controls.Add(this.buttonMountInternalArraysDirsMP3);
            this.tabPageInitial.Controls.Add(this.button4);
            this.tabPageInitial.Controls.Add(this.buttonMountInternalArraysDirs);
            this.tabPageInitial.Controls.Add(this.button3);
            this.tabPageInitial.Controls.Add(this.button2);
            this.tabPageInitial.Controls.Add(this.button1);
            this.tabPageInitial.Controls.Add(this.buttonFilesAction);
            this.tabPageInitial.Controls.Add(this.buttonExtentionAction);
            this.tabPageInitial.Controls.Add(this.buttonListAllExtensions);
            this.tabPageInitial.Controls.Add(this.listView1);
            this.tabPageInitial.Controls.Add(this.buttonPopulateTreeViews);
            this.tabPageInitial.Controls.Add(this.buttonMountInternalArraysFiles);
            this.tabPageInitial.Controls.Add(this.buttonReadMusicFolders);
            this.tabPageInitial.Location = new System.Drawing.Point(4, 22);
            this.tabPageInitial.Name = "tabPageInitial";
            this.tabPageInitial.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInitial.Size = new System.Drawing.Size(1484, 594);
            this.tabPageInitial.TabIndex = 2;
            this.tabPageInitial.Text = "Actions";
            this.tabPageInitial.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(50, 309);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(177, 31);
            this.button4.TabIndex = 16;
            this.button4.Text = "Rename Albuns";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // buttonMountInternalArraysDirs
            // 
            this.buttonMountInternalArraysDirs.Location = new System.Drawing.Point(6, 94);
            this.buttonMountInternalArraysDirs.Name = "buttonMountInternalArraysDirs";
            this.buttonMountInternalArraysDirs.Size = new System.Drawing.Size(248, 31);
            this.buttonMountInternalArraysDirs.TabIndex = 15;
            this.buttonMountInternalArraysDirs.Text = "Export Clean Array DirOnly And All FullFileNames";
            this.buttonMountInternalArraysDirs.UseVisualStyleBackColor = true;
            this.buttonMountInternalArraysDirs.Click += new System.EventHandler(this.buttonExportCleanArrayDirOnlyAndAll_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(286, 233);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(177, 31);
            this.button3.TabIndex = 14;
            this.button3.Text = "Show Level 4 folders";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(286, 196);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(177, 31);
            this.button2.TabIndex = 13;
            this.button2.Text = "Find Albuns Name Not Formated";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(286, 159);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 31);
            this.button1.TabIndex = 12;
            this.button1.Text = "Find Bands Name Not Formated";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonFilesAction
            // 
            this.buttonFilesAction.Location = new System.Drawing.Point(473, 88);
            this.buttonFilesAction.Name = "buttonFilesAction";
            this.buttonFilesAction.Size = new System.Drawing.Size(161, 28);
            this.buttonFilesAction.TabIndex = 11;
            this.buttonFilesAction.Text = "Files Action (Customize)";
            this.buttonFilesAction.UseVisualStyleBackColor = true;
            this.buttonFilesAction.Click += new System.EventHandler(this.buttonFilesAction_Click);
            // 
            // buttonExtentionAction
            // 
            this.buttonExtentionAction.Location = new System.Drawing.Point(473, 54);
            this.buttonExtentionAction.Name = "buttonExtentionAction";
            this.buttonExtentionAction.Size = new System.Drawing.Size(161, 28);
            this.buttonExtentionAction.TabIndex = 10;
            this.buttonExtentionAction.Text = "Extention Action (Customize)";
            this.buttonExtentionAction.UseVisualStyleBackColor = true;
            this.buttonExtentionAction.Click += new System.EventHandler(this.buttonExtentionAction_Click);
            // 
            // buttonListAllExtensions
            // 
            this.buttonListAllExtensions.Location = new System.Drawing.Point(473, 20);
            this.buttonListAllExtensions.Name = "buttonListAllExtensions";
            this.buttonListAllExtensions.Size = new System.Drawing.Size(161, 28);
            this.buttonListAllExtensions.TabIndex = 9;
            this.buttonListAllExtensions.Text = "List Extenstions";
            this.buttonListAllExtensions.UseVisualStyleBackColor = true;
            this.buttonListAllExtensions.Click += new System.EventHandler(this.buttonListAllExtensions_Click);
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(640, 6);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(526, 396);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // buttonPopulateTreeViews
            // 
            this.buttonPopulateTreeViews.Location = new System.Drawing.Point(50, 371);
            this.buttonPopulateTreeViews.Name = "buttonPopulateTreeViews";
            this.buttonPopulateTreeViews.Size = new System.Drawing.Size(222, 31);
            this.buttonPopulateTreeViews.TabIndex = 4;
            this.buttonPopulateTreeViews.Text = "Populate TreeViews (very long, long time)";
            this.buttonPopulateTreeViews.UseVisualStyleBackColor = true;
            this.buttonPopulateTreeViews.Click += new System.EventHandler(this.buttonPopulateTreeViews_Click);
            // 
            // buttonMountInternalArraysFiles
            // 
            this.buttonMountInternalArraysFiles.Location = new System.Drawing.Point(6, 57);
            this.buttonMountInternalArraysFiles.Name = "buttonMountInternalArraysFiles";
            this.buttonMountInternalArraysFiles.Size = new System.Drawing.Size(177, 31);
            this.buttonMountInternalArraysFiles.TabIndex = 3;
            this.buttonMountInternalArraysFiles.Text = "Mount Internal Clean Arrays Files";
            this.buttonMountInternalArraysFiles.UseVisualStyleBackColor = true;
            this.buttonMountInternalArraysFiles.Click += new System.EventHandler(this.buttonMountInternalArraysFiles_Click);
            // 
            // buttonReadMusicFolders
            // 
            this.buttonReadMusicFolders.Location = new System.Drawing.Point(6, 20);
            this.buttonReadMusicFolders.Name = "buttonReadMusicFolders";
            this.buttonReadMusicFolders.Size = new System.Drawing.Size(177, 31);
            this.buttonReadMusicFolders.TabIndex = 1;
            this.buttonReadMusicFolders.Text = "Read Music Folders (DOS DIR)";
            this.buttonReadMusicFolders.UseVisualStyleBackColor = true;
            this.buttonReadMusicFolders.Click += new System.EventHandler(this.buttonReadMusicFolders_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button6);
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1484, 594);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "MP3";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1390, 25);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(78, 28);
            this.button6.TabIndex = 8;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(547, 22);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(78, 28);
            this.button5.TabIndex = 7;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.treeViewResolveMP3);
            this.groupBox2.Location = new System.Drawing.Point(630, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(535, 580);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "To Resolve (MP3)";
            // 
            // treeViewResolveMP3
            // 
            this.treeViewResolveMP3.Location = new System.Drawing.Point(6, 16);
            this.treeViewResolveMP3.Name = "treeViewResolveMP3";
            this.treeViewResolveMP3.Size = new System.Drawing.Size(520, 550);
            this.treeViewResolveMP3.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxMP3Letter);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.treeViewCollectionMP3);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(535, 580);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Collection (MP3)";
            // 
            // comboBoxMP3Letter
            // 
            this.comboBoxMP3Letter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMP3Letter.FormattingEnabled = true;
            this.comboBoxMP3Letter.Items.AddRange(new object[] {
            "0-9",
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.comboBoxMP3Letter.Location = new System.Drawing.Point(476, 19);
            this.comboBoxMP3Letter.Name = "comboBoxMP3Letter";
            this.comboBoxMP3Letter.Size = new System.Drawing.Size(40, 21);
            this.comboBoxMP3Letter.TabIndex = 6;
            this.comboBoxMP3Letter.SelectedIndexChanged += new System.EventHandler(this.comboBoxMP3Letter_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(399, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Letter Filter:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button8);
            this.tabPage2.Controls.Add(this.button7);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1484, 594);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "LossLess";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(1390, 25);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(78, 28);
            this.button8.TabIndex = 10;
            this.button8.Text = "button8";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(547, 22);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(78, 28);
            this.button7.TabIndex = 9;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.treeViewResolveLossless);
            this.groupBox3.Location = new System.Drawing.Point(630, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(535, 580);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "To Resolve (Lossless)";
            // 
            // treeViewResolveLossless
            // 
            this.treeViewResolveLossless.Location = new System.Drawing.Point(6, 16);
            this.treeViewResolveLossless.Name = "treeViewResolveLossless";
            this.treeViewResolveLossless.Size = new System.Drawing.Size(520, 550);
            this.treeViewResolveLossless.TabIndex = 4;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.treeViewCollectionLossless);
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(535, 580);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Collection (Lossless)";
            // 
            // treeViewCollectionLossless
            // 
            this.treeViewCollectionLossless.Location = new System.Drawing.Point(6, 16);
            this.treeViewCollectionLossless.Name = "treeViewCollectionLossless";
            this.treeViewCollectionLossless.Size = new System.Drawing.Size(520, 550);
            this.treeViewCollectionLossless.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(372, 644);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(135, 20);
            this.textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(371, 680);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(800, 20);
            this.textBox2.TabIndex = 7;
            // 
            // buttonMountInternalArraysDirsMP3
            // 
            this.buttonMountInternalArraysDirsMP3.Location = new System.Drawing.Point(6, 144);
            this.buttonMountInternalArraysDirsMP3.Name = "buttonMountInternalArraysDirsMP3";
            this.buttonMountInternalArraysDirsMP3.Size = new System.Drawing.Size(177, 31);
            this.buttonMountInternalArraysDirsMP3.TabIndex = 17;
            this.buttonMountInternalArraysDirsMP3.Text = "Export Only MP3 FullFilesName";
            this.buttonMountInternalArraysDirsMP3.UseVisualStyleBackColor = true;
            this.buttonMountInternalArraysDirsMP3.Click += new System.EventHandler(this.buttonMountInternalArraysDirsMP3_Click);
            // 
            // FormManageMusicFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 712);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormManageMusicFiles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPageInitial.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewCollectionMP3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TreeView treeViewResolveMP3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TreeView treeViewResolveLossless;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TreeView treeViewCollectionLossless;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TabPage tabPageInitial;
        private System.Windows.Forms.Button buttonExtentionAction;
        private System.Windows.Forms.Button buttonListAllExtensions;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button buttonPopulateTreeViews;
        private System.Windows.Forms.Button buttonMountInternalArraysFiles;
        private System.Windows.Forms.Button buttonReadMusicFolders;
        private System.Windows.Forms.Button buttonFilesAction;
        private System.Windows.Forms.ComboBox comboBoxMP3Letter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonMountInternalArraysDirs;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button buttonMountInternalArraysDirsMP3;
    }
}

