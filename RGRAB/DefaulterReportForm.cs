using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Finisar.SQLite;

namespace RGRAB
{
    public partial class DefaulterReportForm : Form
    {
        public DefaulterReportForm(string tempValue)
        {
            InitializeComponent();
            loadDefaultReport(tempValue);
        }

        private void loadDefaultReport(string tempMonth)
        {

            FirstLoad fstLoad = new FirstLoad();
            List<DefaulterDetail> invoiceDetList = fstLoad.getDefaulter(tempMonth);
            dataGridView1.Rows.Clear();

            foreach (var def in invoiceDetList)
            {
                dataGridView1.Rows.Add(def.FlatNo, def.Name, def.Amount);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
