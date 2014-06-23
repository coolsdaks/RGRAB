using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RGRAB
{
    public partial class Security : Form
    {
        public Security()
        {
            InitializeComponent();
            textPassword.PasswordChar = '*';
        }

        private void clkSubmit_Click(object sender, EventArgs e)
        {
            string valuePass = textPassword.Text;
            if (valuePass == "MVSCHS")
            {
                this.Close();
                OptionsForm form2 = new OptionsForm();
                form2.Show();
            }
            else if (valuePass == "p@ssword")
            {
                this.Close();
                DBForm form3 = new DBForm();
                form3.Show();
            }
            else
            {
                MessageBox.Show("Wrong Admin Password!! Please try again.","Warning");
                textPassword.Text = "";
                return;
            }
        }

    }
}
