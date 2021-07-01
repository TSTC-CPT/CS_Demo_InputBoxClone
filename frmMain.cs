using System;
using System.Windows.Forms;

namespace CS_Demo_InputBoxClone
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            String myString = string.Empty;
            if (InputBox.Show("Title", "My Prompt", "[Enter your message]", ref myString, null) == DialogResult.OK)
            {
                lblResult.Text = myString.Trim();
            }
            else
            {
                lblResult.Text = string.Empty;
                MessageBox.Show("You chose to Cancel", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}