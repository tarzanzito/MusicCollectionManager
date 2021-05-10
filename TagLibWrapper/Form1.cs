using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = @"E:\Torrents\DownloadsCompleted\Circa - Valley of the Windmill (2016)\01. Silent Resolve.mp3";
            //this.textBox1.Text = @"E:\Torrents\DownloadsCompleted\Circa - Valley of the Windmill (2016)\02 - Dystopian Overture.flac";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TagLibWrapper tlw = new TagLibWrapper();
            tlw.Open(this.textBox1.Text, true);
            this.pictureBox1.Image = tlw.Cover;
        }


    }
}
