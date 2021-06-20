using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace AccreditationApp
{
    public partial class Support_to_Students : Form
    {
        public Support_to_Students()
        {
            InitializeComponent();
        }

        DBAccess objAccess = new DBAccess();

        private SqlConnection GetConnection()
        {
            return new SqlConnection(@"Data Source=(local);Initial Catalog=AccreditationDb;Integrated Security=True");
        }

        private void Support_to_Students_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            var selectedRow = displayDocs.SelectedRows;
            foreach (var row in selectedRow)
            {
                var id = (int)((DataGridViewRow)row).Cells[0].Value;
                OpenFile(id);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Area4 addDoc = new Area4();
            this.Hide();
            addDoc.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            displayDocs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataTable dtDocs = new DataTable();

            string query = "SELECT ID, timestamp," +
                "student_handbook AS [Student Handbook], " +
                "guidance_manual AS [Guidance Manual]," +
                "proof_of_license AS [Proof of license]," +
                "scholarship_welf_program AS [Scholarship, Welfare program, Institutional student program]," +
                "list_student_service_proof AS [List of student services]," +
                "budget_sas_office_certified AS [Budget for SAS office certified by the Officer]" +
                "from Area_support_students";

            objAccess.readDatathroughAdapter(query, dtDocs);
            displayDocs.DataSource = dtDocs;
            objAccess.closeConn();
        }

        private void OpenFile(int id)
        {
            using (SqlConnection cn = GetConnection())
            {
                string query = "Select * FROM Area_support_students where ID=@id";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var name = reader["student_handbook"].ToString();
                    if (name != "No document")
                    {
                        var data = (byte[])reader["student_handbook_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data, 0, data.Length);
                        }
                    }

                    var name2 = reader["guidance_manual"].ToString();
                    if (name2 != "No document")
                    {
                        var data2 = (byte[])reader["guidance_manual_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name2), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data2, 0, data2.Length);
                        }
                    }

                    var name3 = reader["proof_of_license"].ToString();
                    if (name3 != "No document")
                    {
                        var data3 = (byte[])reader["proof_of_license_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name3), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data3, 0, data3.Length);
                        }
                    }

                    var name4 = reader["scholarship_welf_program"].ToString();
                    if (name4 != "No document")
                    {
                        var data4 = (byte[])reader["scholarship_welf_program_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name4), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data4, 0, data4.Length);
                        }
                    }

                    var name5 = reader["list_student_service_proof"].ToString();
                    if (name5 != "No document")
                    {
                        var data4 = (byte[])reader["list_student_service_proof_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name5), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data4, 0, data4.Length);
                        }
                    }

                    var name6 = reader["budget_sas_office_certified"].ToString();
                    if (name6 != "No document")
                    {
                        var data4 = (byte[])reader["budget_sas_office_certified_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name6), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data4, 0, data4.Length);
                        }
                    }


                    MessageBox.Show("Data downloaded successfully!");
                }
            }
        }
    }
}
