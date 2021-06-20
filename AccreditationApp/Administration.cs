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
    public partial class Administration : Form
    {
        public Administration()
        {
            InitializeComponent();
        }

        DBAccess objAccess = new DBAccess();

        private SqlConnection GetConnection()
        {
            return new SqlConnection(@"Data Source=(local);Initial Catalog=AccreditationDb;Integrated Security=True");
        }

        private void Administration_Load(object sender, EventArgs e)
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
            Area9 addDoc = new Area9();
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
                "approved_org_structure AS [Approved Organizational Structure], " +
                "list_designated_off AS [List of Designated Officials approved by the BOT/BOR]," +
                "cert_proof_transparency AS [Certification of Proof of Transparency Seal]," +
                "strategic_dev_plan AS [Strategic Development Plan]," +
                "bids_awards_committe AS [Bids and Awards Committee (BAC)]," +
                "financial_mngmt_system AS [Financial Management System]," +
                "record_mngmt_system AS [Records Management System]," +
                "financial_dev_plan AS [Financial Development Plan]," +
                "annual_audit_report AS [Annual Auditor's Report]," + 
                "performance_eval_system AS [Performance Evaluation System for Faculty and Non-Teaching staff]" +
                "from Administration";

            objAccess.readDatathroughAdapter(query, dtDocs);
            displayDocs.DataSource = dtDocs;
            objAccess.closeConn();
        }

        private void OpenFile(int id)
        {
            using (SqlConnection cn = GetConnection())
            {
                string query = "Select * FROM Administration where ID=@id";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var name = reader["approved_org_structure"].ToString();
                    if (name != "No document")
                    {
                        var data = (byte[])reader["approved_org_structure_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data, 0, data.Length);
                        }
                    }

                    var name2 = reader["list_designated_off"].ToString();
                    if (name2 != "No document")
                    {
                        var data2 = (byte[])reader["list_designated_off_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name2), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data2, 0, data2.Length);
                        }
                    }

                    var name3 = reader["cert_proof_transparency"].ToString();
                    if (name3 != "No document")
                    {
                        var data3 = (byte[])reader["cert_proof_transparency_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name3), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data3, 0, data3.Length);
                        }
                    }

                    var name4 = reader["strategic_dev_plan"].ToString();
                    if (name4 != "No document")
                    {
                        var data4 = (byte[])reader["strategic_dev_plan_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name4), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data4, 0, data4.Length);
                        }
                    }

                    var name5 = reader["bids_awards_committe"].ToString();
                    if (name5 != "No document")
                    {
                        var data4 = (byte[])reader["bids_awards_committe_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name5), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data4, 0, data4.Length);
                        }
                    }

                    var name6 = reader["financial_mngmt_system"].ToString();
                    if (name6 != "No document")
                    {
                        var data4 = (byte[])reader["financial_mngmt_system_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name6), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data4, 0, data4.Length);
                        }
                    }

                    var name7 = reader["record_mngmt_system"].ToString();
                    if (name7 != "No document")
                    {
                        var data4 = (byte[])reader["record_mngmt_system_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name7), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data4, 0, data4.Length);
                        }
                    }

                    var name8 = reader["financial_dev_plan"].ToString();
                    if (name8 != "No document")
                    {
                        var data4 = (byte[])reader["financial_dev_plan_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name8), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data4, 0, data4.Length);
                        }
                    }

                    var name9 = reader["annual_audit_report"].ToString();
                    if (name9 != "No document")
                    {
                        var data4 = (byte[])reader["annual_audit_report_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name9), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data4, 0, data4.Length);
                        }
                    }

                    var name10 = reader["performance_eval_system"].ToString();
                    if (name10 != "No document")
                    {
                        var data4 = (byte[])reader["performance_eval_system_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name10), FileMode.Create, FileAccess.Write))
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
