/*
 * COP 4814 :: Assigment #4
 * Martino Benjamin, Gregory Vila
 */


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassRollConsumer.localhost; 


namespace ClassRollConsumer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnCallService_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceClient client = new ServiceClient();
                dgvStudents.DataSource = client.StudentList();
                dgvStudents.Columns[0].DefaultCellStyle.Format = "n";
                lblClassAverage.Text = client.GetClassAverage().ToString("n");
                client.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to load client.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
