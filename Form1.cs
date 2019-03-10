using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Notpad
{
    public partial class startFRM : Form
    {
        string OurFilename;

        void DoSave(string filename)
        {
            OurFilename = filename;
            mainRTB.SaveFile(filename);
        }

        void DoSaveAs()
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                DoSave(saveFileDialog1.FileName);
            }
        }

        public startFRM()
        {
            InitializeComponent();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainRTB.Undo();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                mainRTB.LoadFile(openFileDialog1.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(OurFilename))
            {
                DoSaveAs();
            }
            else
            {
                DoSave(OurFilename);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoSaveAs();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowColor = true;

            fontDialog1.Font = mainRTB.Font;
            fontDialog1.Color = mainRTB.ForeColor;


            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                mainRTB.Font = fontDialog1.Font;
                mainRTB.ForeColor = fontDialog1.Color;
            }
        }
    }
}
