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
    public partial class Physical_Plant_and_Facilities : Form
    {
        public Physical_Plant_and_Facilities()
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
            Area7 addDoc = new Area7();
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

        private void Physical_Plant_and_Facilities_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            displayDocs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataTable dtDocs = new DataTable();

            string query = "SELECT ID, timestamp," +
                "scanned_picture AS [Scanned pictures of the entire campus], " +
                "certificate_occupancy AS [Certificate of Occupancy]," +
                "campus_dev_plan AS [Campus Development Plan]," +
                "maintenance_dev_plan AS [Maintenance Development Plan]," +
                "infrastructure_dev_plan AS [Infrastructure Development Plan]," +
                "disaster_preparedness AS [Disaster's Preparedness Development]," +
                "waste_mngmt_program AS [Waste Management Program]" +
                "from Physical_plant_facilities";

            objAccess.readDatathroughAdapter(query, dtDocs);
            displayDocs.DataSource = dtDocs;
            objAccess.closeConn();
        }

        private void OpenFile(int id)
        {
            using (SqlConnection cn = GetConnection())
            {
                string query = "Select * FROM Physical_plant_facilities where ID=@id";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var name = reader["scanned_picture"].ToString();
                    if (name != "No document")
                    {
                        var data = (byte[])reader["scanned_picture_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data, 0, data.Length);
                        }
                    }

                    var name2 = reader["certificate_occupancy"].ToString();
                    if (name2 != "No document")
                    {
                        var data2 = (byte[])reader["certificate_occupancy_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name2), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data2, 0, data2.Length);
                        }
                    }

                    var name3 = reader["campus_dev_plan"].ToString();
                    if (name3 != "No document")
                    {
                        var data3 = (byte[])reader["campus_dev_plan_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name3), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data3, 0, data3.Length);
                        }
                    }

                    var name4 = reader["maintenance_dev_plan"].ToString();
                    if (name4 != "No document")
                    {
                        var data4 = (byte[])reader["maintenance_dev_plan_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name4), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data4, 0, data4.Length);
                        }
                    }

                    var name5 = reader["infrastructure_dev_plan"].ToString();
                    if (name5 != "No document")
                    {
                        var data4 = (byte[])reader["infrastructure_dev_plan_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name5), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data4, 0, data4.Length);
                        }
                    }

                    var name6 = reader["disaster_preparedness"].ToString();
                    if (name6 != "No document")
                    {
                        var data4 = (byte[])reader["disaster_preparedness_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name6), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data4, 0, data4.Length);
                        }
                    }

                    var name7 = reader["waste_mngmt_program"].ToString();
                    if (name7 != "No document")
                    {
                        var data4 = (byte[])reader["waste_mngmt_program_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name7), FileMode.Create, FileAccess.Write))
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
