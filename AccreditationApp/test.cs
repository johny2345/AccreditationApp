using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccreditationApp
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }

        DBAccess objAccess = new DBAccess();

        private SqlConnection GetConnection()
        {
            return new SqlConnection(@"Data Source=(local);Initial Catalog=AccreditationDb;Integrated Security=True");
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            txtFilePath.Text = dlg.FileName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFile(txtFilePath.Text, txtFilePath2.Text);

        }

        private void SaveFile(string filePath, string file2)
        {
            string extn = "";
            byte[] buffer, buffer2 = null;
            

            SqlCommand insertCommand = new SqlCommand("INSERT INTO TestTable(Docu, Docu2, FileName, FileName2) VALUES(@data, @data2, @name, @name2)");

            if (filePath.Equals(""))
            {
                insertCommand.Parameters.AddWithValue("@data", System.Data.SqlTypes.SqlBinary.Null);
                insertCommand.Parameters.AddWithValue("@name", "No document");

                MessageBox.Show("empty path");
            } else
            {
                var fi = new FileInfo(filePath);
                using (Stream stream = File.OpenRead(filePath))
                {
                    buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, buffer.Length);
                    fi = new FileInfo(filePath);
                    extn = fi.Extension;
                    string name = fi.Name;

                    insertCommand.Parameters.AddWithValue("@data", buffer);
                    insertCommand.Parameters.AddWithValue("@name", name);
                }
            }
            

            using (Stream stream = File.OpenRead(file2))
            {
                var fi2 = new FileInfo(file2);

                buffer2 = new byte[stream.Length];
                stream.Read(buffer2, 0, buffer2.Length);
                fi2 = new FileInfo(file2);
                string name2 = fi2.Name;

                insertCommand.Parameters.AddWithValue("@data2", buffer2);
                insertCommand.Parameters.AddWithValue("@name2", name2);
            }
            

            int row = objAccess.executeQuery(insertCommand);

            if (row == 1)
            {
                MessageBox.Show("Document added successfully");
            }
            else
            {
                MessageBox.Show("Error occured! try again!.");
            }
        }

        private void dgDocuments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenFileDialog dlg2 = new OpenFileDialog();
            dlg2.ShowDialog();
            txtFilePath.Text = dlg2.FileName;
        }

        private void test_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgDocuments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataTable dtDocs = new DataTable();
            string query = "select id, filename, filename2 from testtable";
            objAccess.readDatathroughAdapter(query, dtDocs);
            dgDocuments.DataSource = dtDocs;
            objAccess.closeConn();

            //using (SqlConnection cn = GetConnection())
            //{
            //    string query = "select id, filename from testtable";
            //    SqlDataAdapter adp = new SqlDataAdapter(query, cn);
            //    adp.Fill(dtDocs);

            //    if (dtDocs.Rows.Count > 0)
            //    {
            //        dgDocuments.DataSource = dtDocs;
            //    }
            //}

        }

        private void btnBrowse2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            txtFilePath2.Text = dlg.FileName;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            var selectedRow = dgDocuments.SelectedRows;
            foreach(var row in selectedRow)
            {
                // var id = ((DataGridViewCell)cell).Value;
                // MessageBox.Show(id.ToString());
                var id = (int)((DataGridViewRow)row).Cells[0].Value;
                OpenFile(id);
            }
        }

        private void OpenFile(int id)
        {
            using (SqlConnection cn = GetConnection())
            {
                string query = "Select * FROM TestTable where ID=@id";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    var name = reader["Filename"].ToString();
                    var name2 = reader["Filename2"].ToString();
                    var data = (byte[])reader["Docu"];
                    var data2 = (byte[])reader["Docu2"];
                    //File.WriteAllBytes(name, data);
                    //System.Diagnostics.Process.Start(name);

                    using (var fs = new FileStream(Path.Combine("D:\\", name), FileMode.Create, FileAccess.Write))
                    {
                        fs.Write(data, 0, data.Length);
                    }using (var fs = new FileStream(Path.Combine("D:\\", name2), FileMode.Create, FileAccess.Write))
                    {
                        fs.Write(data2, 0, data2.Length);
                    }
                    MessageBox.Show("Data downloaded successfully!");
                }
            }
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            dgDocuments.DataSource = null;
        }
    }
}
