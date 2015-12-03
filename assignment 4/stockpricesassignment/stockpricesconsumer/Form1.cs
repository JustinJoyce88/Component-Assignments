using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockPricesConsumer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dateBegin = new DateTime(2005,1,1);
            DateTime dateEnd = new DateTime(2005,3,1);
            localhost.StockWebServiceClient client = new localhost.StockWebServiceClient();
            lblStatus.Text = client.getDateRangeTest(dateBegin, dateEnd).Rank.ToString();
            MessageBox.Show(client.getDateRangeTest(dateBegin, dateEnd).ToString());
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

    }
}
