using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace SortBDay
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadPersons();
        }

        private void LoadPersons()
        {
            var data = new DataTable();
            data.Columns.Add(new DataColumn("Name"));
            data.Columns.Add(new DataColumn("Date Of Birth"));
            data.Columns.Add(new DataColumn("Current Age"));

            using (var reader = new StreamReader("input_file.txt"))
            {
                var line = string.Empty;

                while ((line = reader.ReadLine()) != null)
                {
                    var lineRecords = line.Split("|");

                    if (lineRecords.Length != 2)
                    {
                        // Something is not right with the line, lets skip it.
                        continue;
                    }

                    var personName = lineRecords[0];
                    DateTime.TryParse(lineRecords[1], out var dateOfBirth);
                    int age = CalculateAge(dateOfBirth);

                    var row = data.NewRow();
                    row["Name"] = personName;
                    row["Date Of Birth"] = dateOfBirth.ToString("dd MMMM yyyy");
                    row["Current Age"] = age;
                    data.Rows.Add(row);
                }

                var sortedData = SortDataByBirthDate(data, SortingDirection.Ascending);
                dataGridView1.DataSource = sortedData;
            }
        }

        private int CalculateAge(DateTime dateOfBirth)
        {
            int age = 0;

            if (dateOfBirth != DateTime.MinValue)
            {
                age = DateTime.Now.Year - dateOfBirth.Year;

                if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                    age--;
            }

            return age;
        }

        private DataTable SortDataByBirthDate(DataTable inputData, SortingDirection direction)
        {
            switch (direction)
            {
                case SortingDirection.Ascending:
                    return SortByAscending(inputData, null);
                case SortingDirection.Descending:
                    return SortByDescending(inputData, null);
                default:
                    return inputData;
            }
        }

        private DataTable SortByDescending(DataTable inputData, DataTable newTable)
        {
            if (newTable == null)
            {
                newTable = new DataTable();
                newTable.Columns.Add(new DataColumn("Name"));
                newTable.Columns.Add(new DataColumn("Date Of Birth"));
                newTable.Columns.Add(new DataColumn("Current Age"));
            }

            DataRow lastRow = inputData.Rows.Count > 0 ? inputData.Rows[0] : inputData.NewRow();
            foreach (DataRow row in inputData.Rows)
            {
                var lastAge = lastRow["Current Age"].ToString();

                if (string.IsNullOrWhiteSpace(lastAge))
                    lastAge = "0";

                if (Convert.ToInt32(row["Current Age"].ToString()) < Convert.ToInt32(lastAge))
                {
                    lastRow = row;
                }
            }

            var newRow = newTable.NewRow();
            newRow["Name"] = lastRow["Name"];
            newRow["Date Of Birth"] = lastRow["Date Of Birth"];
            newRow["Current Age"] = lastRow["Current Age"];
            newTable.Rows.Add(newRow);
            inputData.Rows.Remove(lastRow);

            if (inputData.Rows.Count > 0)
                SortByDescending(inputData, newTable);

            return newTable;
        }

        private DataTable SortByAscending(DataTable inputData, DataTable newTable)
        {
            if (newTable == null)
            {
                newTable = new DataTable();
                newTable.Columns.Add(new DataColumn("Name"));
                newTable.Columns.Add(new DataColumn("Date Of Birth"));
                newTable.Columns.Add(new DataColumn("Current Age"));
            }

            DataRow lastRow = inputData.Rows.Count > 0 ? inputData.Rows[0] : inputData.NewRow();
            foreach (DataRow row in inputData.Rows)
            {
                var lastAge = lastRow["Current Age"].ToString();

                if (string.IsNullOrWhiteSpace(lastAge))
                    lastAge = "0";

                if (Convert.ToInt32(row["Current Age"].ToString()) < Convert.ToInt32(lastAge))
                {
                    lastRow = row;
                }
            }

            var newRow = newTable.NewRow();
            newRow["Name"] = lastRow["Name"];
            newRow["Date Of Birth"] = lastRow["Date Of Birth"];
            newRow["Current Age"] = lastRow["Current Age"];
            newTable.Rows.Add(newRow);
            inputData.Rows.Remove(lastRow);

            if (inputData.Rows.Count > 0)
                SortByAscending(inputData, newTable);

            return newTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("First name is required.", "First Name Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Last name is required.", "Last Name Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(dateTimePicker1.Text))
            {
                MessageBox.Show("Date of birth is required.", "Date of birth Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var name = $"{textBox1.Text} {textBox3.Text}";
            var dateOfBirth = dateTimePicker1.Value;

            using (var streamWriter = new StreamWriter("input_file.txt", true))
            {
                streamWriter.WriteLine($"{name}|{dateOfBirth.ToString("dd/MM/yyyy")}");
                streamWriter.Close();
            }

            MessageBox.Show("New person added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadPersons();
        }
    }

    public enum SortingDirection
    {
        Ascending = 1,
        Descending = 2
    }
}
