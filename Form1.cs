using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esxv2ModuleCreator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog Klasor = new FolderBrowserDialog();
            Klasor.SelectedPath = Properties.Settings.Default.selectedpath;
            if (Klasor.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = Klasor.SelectedPath + "\\" +textBox2.Text;
                Properties.Settings.Default.selectedpath = Klasor.SelectedPath;
                Properties.Settings.Default.Save();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.selectedpath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string root = Properties.Settings.Default.selectedpath+"\\"+textBox2.Text;
            toolStripProgressBar1.Value += 10;
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
                toolStripProgressBar1.Value += 10;
                Directory.CreateDirectory(root+"\\client");
                toolStripProgressBar1.Value += 10;
                Directory.CreateDirectory(root+"\\data");
                toolStripProgressBar1.Value += 10;
                Directory.CreateDirectory(root+"\\data\\locales");
                toolStripProgressBar1.Value += 10;
                Directory.CreateDirectory(root+"\\server");
                toolStripProgressBar1.Value += 10;
                filecreate(root + "\\client");
                toolStripProgressBar1.Value += 10;
                filecreate(root + "\\server");
                toolStripProgressBar1.Value += 10;
                File.Create(root + "\\data\\locales\\en.lua");
                toolStripProgressBar1.Value += 10;
                File.Create(root + "\\data\\config.lua");
                toolStripProgressBar1.Value += 10;
                modulejsonupdate();
                MessageBox.Show("All files created.");
            }
        }

        private void modulejsonupdate()
        {
            string json = File.ReadAllText(Properties.Settings.Default.selectedpath + "\\modules.json");
            json = json.Trim();
            string modulesJson = json.Substring(0, json.Length - 1);
            modulesJson += ",\"" + textBox2.Text + "\"]";
            File.WriteAllText(Properties.Settings.Default.selectedpath + "\\modules.json", modulesJson);
        }
        private void filecreate(string folder)
        {
            File.Create(folder + "\\main.lua");
            File.Create(folder + "\\events.lua");
            File.Create(folder + "\\module.lua");
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/KedpEgV");
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/abdulkadiraktas");
        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.selectedpath + "\\" + textBox2.Text;
        }
    }
}
