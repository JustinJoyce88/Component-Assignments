
//by: Alberto Fortuny and Justin Joyce

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace StockServiceConsumer
{
    public partial class Form1 : Form
    {
        localhost.StockServiceClient client = new localhost.StockServiceClient();
        string startDateText { get; set; }
        string endDateText { get; set; }
        Series avg = new Series("Moving Average");
        Series normData = new Series("Closing Prices");
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        protected void button1_Click(object sender, EventArgs e)
        {
            try
            {   myChart1.Series.Clear();
                myChart1.Series.Remove(avg);
                string startDateText = txtStartDate.Text;
                string endDateText = txtEndDate.Text;
                startDateText = startDateText.Replace("/", ",");
                endDateText = endDateText.Replace("/", ",");
                DateTime startDate = Convert.ToDateTime(startDateText);
                DateTime endDate = Convert.ToDateTime(endDateText);

                normData.Color = Color.LimeGreen;
                normData.XValueMember = "Date";
                normData.YValueMembers = "Value";
                normData.ChartType = SeriesChartType.Line;
                normData.XValueType = ChartValueType.Date;
                normData.YValueType = ChartValueType.Double;

                myChart1.Series.Add(normData);                
                myChart1.DataSource = client.GetDateRange(startDate, endDate);
                myChart1.ChartAreas[0].AxisY.Maximum = client.getLargest() + 2.5;
                myChart1.ChartAreas[0].AxisY.Minimum = client.getSmallest() - 2.5;
                myChart1.Legends.Clear();
                toolStripStatusLabel1.Text = string.Format("");
                client.setLargest(0);
                client.setSmallest(2100000000);
            }
            catch (Exception)
            {
                toolStripStatusLabel1.Text = string.Format("You did not enter a valid date or format.");
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void myChart1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                myChart1.Series.Clear();
                string movAvgText = MvingAvgTxt.Text;
                startDateText = txtStartDate.Text;
                endDateText = txtEndDate.Text;
                startDateText = startDateText.Replace("/", ",");
                endDateText = endDateText.Replace("/", ",");
                DateTime startDate = Convert.ToDateTime(startDateText);
                DateTime endDate = Convert.ToDateTime(endDateText);
                Int32 numDays = Convert.ToInt32(movAvgText);
  
                avg.Color = Color.DarkRed;
                avg.XValueMember = "Date";
                avg.YValueMembers = "Value";
                avg.ChartType = SeriesChartType.Line;
                avg.XValueType = ChartValueType.Date;
                avg.YValueType = ChartValueType.Double;
                              
                myChart1.Series.Add(avg);
                myChart1.DataSource = client.CalcMovingAverages(startDate, endDate, numDays);
                myChart1.ChartAreas[0].AxisY.Maximum = client.getLargest() + 2.5;
                myChart1.ChartAreas[0].AxisY.Minimum = client.getSmallest() - 2.5;
                myChart1.Legends.Clear();          
                toolStripStatusLabel1.Text = string.Format("");
                client.setLargest(0);
                client.setSmallest(2100000000);
            }
            catch (Exception)
            {
                toolStripStatusLabel1.Text = string.Format("You did not enter a valid moving average.");
            }
        }

        private void Exitbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
