/**
 * frmAbout.cs
 * Code behind the form frmAbout
 * author:  Tonya Chung
 *          Matthew Brennan
 *          Michael Sehdev
 *          Wesley Whitmore
 * date:    February 19, 2017
 * */

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
    public partial class frmAbout : Form
    {
        /// <summary>
        /// Constructor 
        /// </summary>
        public frmAbout()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Handles loading for the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAbout_Load(object sender, EventArgs e)
        {
            //Critical information concerning the coders of the game & purpose of it.
            lblInformation.Text = "The following Durak game has been created for the\nOOP 4200 - 03, Winter 2017 in Durham College." +
                                    "The group\n consists of Wesley Whitmore, Matthew Brennan, Michael\nSehdev, and Tonya Chung.";
        }
    }
}
