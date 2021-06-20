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
    public partial class Laboratories : Form
    {
        public Laboratories()
        {
            InitializeComponent();
        }

        DBAccess objAccess = new DBAccess();

        private SqlConnection GetConnection()
        {
            return new SqlConnection(@"Data Source=(local);Initial Catalog=AccreditationDb;Integrated Security=True");
        }

        private void Laboratoties_Load(object sender, EventArgs e)
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

        private void OpenFile(int id)
        {
            using (SqlConnection cn = GetConnection())
            {
                string query = "Select * FROM Laboratories where ID=@id";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var name = reader["approved_bldg_pln"].ToString();
                    if (name != "No document")
                    {
                        var data = (byte[])reader["approved_bldg_pln_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data, 0, data.Length);
                        }
                    }

                    var name2 = reader["reports_pres_reqrmnt"].ToString();
                    if (name2 != "No document")
                    {
                        var data2 = (byte[])reader["reports_pres_reqrmnt_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name2), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data2, 0, data2.Length);
                        }
                    }

                    var name3 = reader["certificate_conformity"].ToString();
                    if (name3 != "No document")
                    {
                        var data3 = (byte[])reader["certificate_conformity_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name3), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data3, 0, data3.Length);
                        }
                    }

                    var name4 = reader["printed_material"].ToString();
                    if (name4 != "No document")
                    {
                        var data4 = (byte[])reader["printed_material_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name4), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data4, 0, data4.Length);
                        }
                    }

                    var name5 = reader["inventory_lab_tools"].ToString();
                    if (name5 != "No document")
                    {
                        var data4 = (byte[])reader["inventory_lab_tools_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name5), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data4, 0, data4.Length);
                        }
                    }

                    var name6 = reader["list_lab_custodian"].ToString();
                    if (name6 != "No document")
                    {
                        var data4 = (byte[])reader["list_lab_custodian_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name6), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data4, 0, data4.Length);
                        }
                    }

                    var name7 = reader["safety_mntnnce_guideline"].ToString();
                    if (name7 != "No document")
                    {
                        var data4 = (byte[])reader["safety_mntnnce_guideline_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name7), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data4, 0, data4.Length);
                        }
                    }

                    var name8 = reader["business_permit_opt"].ToString();
                    if (name8 != "No document")
                    {
                        var data4 = (byte[])reader["business_permit_opt_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name8), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data4, 0, data4.Length);
                        }
                    }

                    var name9 = reader["health_cert"].ToString();
                    if (name9 != "No document")
                    {
                        var data4 = (byte[])reader["health_cert_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name9), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data4, 0, data4.Length);
                        }
                    }

                    var name10 = reader["tesda_cert"].ToString();
                    if (name10 != "No document")
                    {
                        var data4 = (byte[])reader["printed_material_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name10), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data4, 0, data4.Length);
                        }
                    }


                    MessageBox.Show("Data downloaded successfully!");
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Area8 addDoc = new Area8();
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

            string query = "SELECT ID, timestamp," + "approved_bldg_pln AS [Approved Building Plans], " + "reports_pres_reqrmnt AS [Reports of prescribed minimum requirements]," + "certificate_conformity AS [Certification of conformity (RA6541)]," + "printed_material AS [Laboratory Manual]," + "inventory_lab_tools AS [Inventory of Laboratory tools, equipment required by a specific program]," + "list_lab_custodian AS [List of laboratory custodian]," + "safety_mntnnce_guideline AS [Safety and Maintenance Guidelines]," + "business_permit_opt AS [Business Permit for canteen operations]," + "health_cert AS [Health Certificate]," + "tesda_cert " + " [TESDA certificate of competency for canteen food handlers:]" +
                "from Laboratories";

            objAccess.readDatathroughAdapter(query, dtDocs);
            displayDocs.DataSource = dtDocs;
            objAccess.closeConn();
        }
    }
}
