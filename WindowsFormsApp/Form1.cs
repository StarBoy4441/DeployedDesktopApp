using Newtonsoft.Json;
using System;
using System.Windows.Forms;
using Dapper;
using CsvHelper;
using System.IO;
using System.Globalization;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        // Controls
        private TextBox txtNum1;
        private TextBox txtNum2;
        private Button btnSum;
        private Label lblResult;

        public Form1()
        {
            InitializeComponent();

            // Make form large enough
            this.Text = "Calculator App";
            this.Width = 400;
            this.Height = 300;

            // Show welcome message with Newtonsoft.Json
            string json = "{ \"message\": \"Welcome to WindowsFormsApp with Multiple Dependencies!\" }";
            dynamic obj = JsonConvert.DeserializeObject(json);
            MessageBox.Show((string)obj.message);

            // Alignment variables
            int labelX = 30;
            int textBoxX = 150;
            int controlWidth = 200;

            // Number 1
            Label lbl1 = new Label();
            lbl1.Text = "Number 1:";
            lbl1.Location = new System.Drawing.Point(labelX, 40);
            lbl1.AutoSize = true;

            txtNum1 = new TextBox();
            txtNum1.Location = new System.Drawing.Point(textBoxX, 38);
            txtNum1.Width = controlWidth;

            // Number 2
            Label lbl2 = new Label();
            lbl2.Text = "Number 2:";
            lbl2.Location = new System.Drawing.Point(labelX, 80);
            lbl2.AutoSize = true;

            txtNum2 = new TextBox();
            txtNum2.Location = new System.Drawing.Point(textBoxX, 78);
            txtNum2.Width = controlWidth;

            // Button
            btnSum = new Button();
            btnSum.Text = "Calculate Sum";
            btnSum.Location = new System.Drawing.Point(labelX, 120);
            btnSum.Width = 120;
            btnSum.Height = 30;
            btnSum.Click += BtnSum_Click;

            // Result Label
            lblResult = new Label();
            lblResult.Text = "Result:";
            lblResult.Location = new System.Drawing.Point(labelX, 170);
            lblResult.AutoSize = true;

            // Add controls
            this.Controls.Add(lbl1);
            this.Controls.Add(txtNum1);
            this.Controls.Add(lbl2);
            this.Controls.Add(txtNum2);
            this.Controls.Add(btnSum);
            this.Controls.Add(lblResult);

            // --- Proof of Dapper (just a reference, not used)
            using (var connection = new System.Data.SqlClient.SqlConnection("Data Source=(local);Initial Catalog=master;Integrated Security=True"))
            {
                string query = "SELECT 1";
            }

            // --- Proof of CsvHelper (creates dummy CSV file)
            using (var writer = new StreamWriter("test.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteField("Hello, CSV!");
                csv.NextRecord();
            }
        }

        private void BtnSum_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtNum1.Text, out int num1) && int.TryParse(txtNum2.Text, out int num2))
            {
                int sum = num1 + num2;
                lblResult.Text = $"Result: {sum}";
            }
            else
            {
                lblResult.Text = "Please enter valid numbers.";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
