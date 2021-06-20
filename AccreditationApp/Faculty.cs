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
    public partial class Faculty : Form
    {
        public Faculty()
        {
            InitializeComponent();
        }

        DBAccess objAccess = new DBAccess();

        private SqlConnection GetConnection()
        {
            return new SqlConnection(@"Data Source=(local);Initial Catalog=AccreditationDb;Integrated Security=True");
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
            Area2 addDoc = new Area2();
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
                "faculty_name AS [Faculty name]," +
                "faculty_manual AS [Faculty Manual], " +
                "faculty_dev_plan AS [Faculty Development Plan]," +
                "update_fac_prof AS [Updated Faculty Profile]," +
                "teach_load_sched AS [Teaching load and Schedule for the period of accreditation]," +
                "performance_eval AS [Performance evaluation]," +
                "sholarly_works_fac AS [Scholarly Works]," +
                "merit_system_prom_plan as [Merit System and Promotion Plan]" +
                "from Area_faculty";

            objAccess.readDatathroughAdapter(query, dtDocs);
            displayDocs.DataSource = dtDocs;
            objAccess.closeConn();
        }

        private void OpenFile(int id)
        {
            using (SqlConnection cn = GetConnection())
            {
                string query = "Select * FROM Area_faculty where ID=@id";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var name = reader["faculty_manual"].ToString();
                    if (name != "No document")
                    {
                        var data = (byte[])reader["faculty_manual_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data, 0, data.Length);
                        }
                    }

                    var name2 = reader["faculty_dev_plan"].ToString();
                    if (name2 != "No document")
                    {
                        var data2 = (byte[])reader["faculty_dev_plan_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name2), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data2, 0, data2.Length);
                        }
                    }

                    var name3 = reader["update_fac_prof"].ToString();
                    if (name3 != "No document")
                    {
                        var data3 = (byte[])reader["update_fac_prof_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name3), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data3, 0, data3.Length);
                        }
                    }

                    var name4 = reader["teach_load_sched"].ToString();
                    if (name4 != "No document")
                    {
                        var data4 = (byte[])reader["teach_load_sched_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name4), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data4, 0, data4.Length);
                        }
                    }

                    var name5 = reader["performance_eval"].ToString();
                    if (name5 != "No document")
                    {
                        var data5 = (byte[])reader["performance_eval_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name5), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data5, 0, data5.Length);
                        }
                    }

                    var name6 = reader["performance_eval"].ToString();
                    if (name5 != "No document")
                    {
                        var data = (byte[])reader["performance_eval_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name6), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data, 0, data.Length);
                        }
                    }

                    var name7 = reader["sholarly_works_fac"].ToString();
                    if (name7 != "No document")
                    {
                        var data = (byte[])reader["sholarly_works_fac_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name7), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data, 0, data.Length);
                        }
                    }

                    var name8 = reader["merit_system_prom_plan"].ToString();
                    if (name8 != "No document")
                    {
                        var data = (byte[])reader["merit_system_prom_plan_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name8), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data, 0, data.Length);
                        }
                    }

                    MessageBox.Show("Data downloaded successfully!");
                }
            }
        }

        private void Faculty_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
