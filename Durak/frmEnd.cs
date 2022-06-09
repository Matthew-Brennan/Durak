using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Durak
{
    public partial class frmEnd : Form
    {
        public frmEnd()
        {
            InitializeComponent();
        }

        private void frmEnd_Load(object sender, EventArgs e)
        {
            lblInfo.Text = "Thank you for player Durak.\nStats are displayed below as well as a log file has\n been created in the subdirectory of this game.";
            lblName.Text = DataContainer.playerName;
            lblNumGames.Text = DataContainer.playerTotalGames.ToString();
            lblNumWins.Text = DataContainer.playerWins.ToString();
            lblNumTies.Text = DataContainer.playerTies.ToString();
            lblNumLosses.Text = DataContainer.playerLoses.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
