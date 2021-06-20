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
    public partial class Extension_and_community_involvement : Form
    {
        public Extension_and_community_involvement()
        {
            InitializeComponent();
        }

        DBAccess objAccess = new DBAccess();

        private SqlConnection GetConnection()
        {
            return new SqlConnection(@"Data Source=(local);Initial Catalog=AccreditationDb;Integrated Security=True");
        }

        private void Extension_and_community_involvement_Load(object sender, EventArgs e)
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
            Area5 addDoc = new Area5();
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
                "extension_service_manual AS [Extension Services Manual], " +
                "extension_agenda AS [Extension Agenda/Program]," +
                "approved_budgetary_alloc AS [Approved Budgetary Allocation]," +
                "report_relevant_success_ext AS [Report of relevant and successful Extension Projects conducted]," +
                "video_actual_comm_ext AS [Video of actual community Extension Services programs]," +
                "effect_short_term_ext_prog AS [Effect of the short term extension program/s on the beneficiaries]," +
                "impact_assess_ext_prog AS [Impact Assessment of the extension program]," +
                "list_proof_partnership AS [List and proof of partnership/linkages]" +
                "from Area_community_involvement";

            objAccess.readDatathroughAdapter(query, dtDocs);
            displayDocs.DataSource = dtDocs;
            objAccess.closeConn();
        }

        private void OpenFile(int id)
        {
            using (SqlConnection cn = GetConnection())
            {
                string query = "Select * FROM Area_community_involvement where ID=@id";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var name = reader["extension_service_manual"].ToString();
                    if (name != "No document")
                    {
                        var data = (byte[])reader["extension_service_manual_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data, 0, data.Length);
                        }
                    }

                    var name2 = reader["extension_agenda"].ToString();
                    if (name2 != "No document")
                    {
                        var data2 = (byte[])reader["extension_agenda_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name2), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data2, 0, data2.Length);
                        }
                    }

                    var name3 = reader["approved_budgetary_alloc"].ToString();
                    if (name3 != "No document")
                    {
                        var data3 = (byte[])reader["approved_budgetary_alloc_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name3), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data3, 0, data3.Length);
                        }
                    }

                    var name4 = reader["report_relevant_success_ext"].ToString();
                    if (name4 != "No document")
                    {
                        var data4 = (byte[])reader["report_relevant_success_ext_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name4), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data4, 0, data4.Length);
                        }
                    }

                    var name5 = reader["video_actual_comm_ext"].ToString();
                    if (name5 != "No document")
                    {
                        var data4 = (byte[])reader["video_actual_comm_ext_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name5), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data4, 0, data4.Length);
                        }
                    }

                    var name6 = reader["effect_short_term_ext_prog"].ToString();
                    if (name6 != "No document")
                    {
                        var data4 = (byte[])reader["effect_short_term_ext_prog_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name6), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data4, 0, data4.Length);
                        }
                    }

                    var name7 = reader["impact_assess_ext_prog"].ToString();
                    if (name7 != "No document")
                    {
                        var data4 = (byte[])reader["impact_assess_ext_prog_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name7), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data4, 0, data4.Length);
                        }
                    }

                    var name8 = reader["list_proof_partnership"].ToString();
                    if (name4 != "No document")
                    {
                        var data4 = (byte[])reader["list_proof_partnership_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name8), FileMode.Create, FileAccess.Write))
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
