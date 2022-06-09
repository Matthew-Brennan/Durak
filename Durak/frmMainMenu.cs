using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Durak
{
    public partial class frmMainMenu : Form
    {
        
        public frmMainMenu()
        {
            InitializeComponent();
            rad36Cards.Checked = true;
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            lblRules.Text = "Rules\n\u2022You VS the Computer\n\u2022Trump Card will only be beaten\nby a higher trump card\n\u2022Player attacks the Computer first" 
                            + "\n\u2022First one to lose all their cards win\n\u2022Stats Log will be provided at the end";
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout aboutForm = new frmAbout();
            aboutForm.Show();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (rad20Cards.Checked)
            {
                DataContainer.DeckSize = 20;
            }
            else if (rad36Cards.Checked)
            {
                DataContainer.DeckSize = 36;
            }
            else if (rad52Cards.Checked)
            {
                DataContainer.DeckSize = 52;
            }

            //Check if theres a log file 
            if (!File.Exists(DataContainer.logPath))
            {
                File.Create(DataContainer.logPath);
            }

            //Check if theres a name
            if (txtName.Text != "")
            {
                DataContainer.playerName = txtName.Text;
            }
            else
            {
                MessageBox.Show("Please enter a player name.");
            }


            //Check if user wishes to clear stats file if it exists
            if (chkRestart.Checked && File.Exists(DataContainer.statPath))
            {
                File.WriteAllText(DataContainer.statPath, string.Empty);
                frmGame gameForm = new frmGame();
                gameForm.Show();
            } //No stats file therefore a fresh game can automatically start
            else if (chkRestart.Checked && !(File.Exists(DataContainer.statPath)))
            {
                frmGame gameForm = new frmGame();
                gameForm.Show();
            }

            //Not wishing to restart stat file (as it exists and the stat file is greater than 1 line
            if (!chkRestart.Checked && File.Exists(DataContainer.statPath) && File.ReadLines(DataContainer.statPath).Count() >= 1)
            {
                string statLogName = File.ReadLines(DataContainer.statPath).First();
                //Verifies the user wishes to not re-write over previous data seeing as it has similar name
                if (statLogName == txtName.Text)
                {
                    DialogResult restart = MessageBox.Show("Would you like to re-write over previous data?",
                        "Stat File", MessageBoxButtons.YesNo);
                    if (restart == DialogResult.Yes)
                    {
                        File.WriteAllText(DataContainer.logPath, string.Empty);
                        frmGame gameForm = new frmGame();
                        gameForm.Show();
                    }
                }
                //Verifies that user meant to enter a different name apart from the stat file and wishes to start a new stat log
                else
                {
                    DialogResult message = MessageBox.Show("You have a previous stat file for the player " + statLogName + ". Would you like to write over it?",
                        "Stat File", MessageBoxButtons.YesNo);
                    if (message == DialogResult.Yes)
                    {
                        File.WriteAllText(DataContainer.logPath, string.Empty);
                        frmGame gameForm = new frmGame();
                        gameForm.Show();
                    }
                }
            }

            //if (chkRestart.Checked || !chkRestart.Checked)
            //{
            //    frmGame gameForm = new frmGame();
            //    gameForm.Show();
            //}


            //frmGame gameForm = new frmGame();
            //gameForm.Show();
        }
    }
}
