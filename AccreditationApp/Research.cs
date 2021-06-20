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
    public partial class Research : Form
    {
        public Research()
        {
            InitializeComponent();
        }

        DBAccess objAccess = new DBAccess();

        private SqlConnection GetConnection()
        {
            return new SqlConnection(@"Data Source=(local);Initial Catalog=AccreditationDb;Integrated Security=True");
        }

        private void Research_Load(object sender, EventArgs e)
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
                string query = "Select * FROM Area_research where ID=@id";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var name = reader["research_manual"].ToString();
                    if (name != "No document")
                    {
                        var data = (byte[])reader["research_manual_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data, 0, data.Length);
                        }
                    }

                    var name2 = reader["research_agenda"].ToString();
                    if (name2 != "No document")
                    {
                        var data2 = (byte[])reader["research_agenda_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name2), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data2, 0, data2.Length);
                        }
                    }

                    var name3 = reader["institution_research_journal"].ToString();
                    if (name3 != "No document")
                    {
                        var data3 = (byte[])reader["institution_research_journal_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name3), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data3, 0, data3.Length);
                        }
                    }

                    var name4 = reader["approved_budget_alloc"].ToString();
                    if (name4 != "No document")
                    {
                        var data4 = (byte[])reader["approved_budget_alloc_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name4), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data4, 0, data4.Length);
                        }
                    }

                    var name5 = reader["list_of_researchers"].ToString();
                    if (name5 != "No document")
                    {
                        var data4 = (byte[])reader["list_of_researchers_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name5), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data4, 0, data4.Length);
                        }
                    }

                    var name6 = reader["approved_budget_alloc"].ToString();
                    if (name4 != "No document")
                    {
                        var data4 = (byte[])reader["approved_budget_alloc_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name6), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data4, 0, data4.Length);
                        }
                    }

                    var name7 = reader["list_of_researchers"].ToString();
                    if (name7 != "No document")
                    {
                        var data4 = (byte[])reader["list_of_researchers_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name7), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data4, 0, data4.Length);
                        }
                    }

                    var name8 = reader["proof_paper_presentation_faculty"].ToString();
                    if (name8 != "No document")
                    {
                        var data4 = (byte[])reader["proof_paper_presentation_faculty_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name8), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data4, 0, data4.Length);
                        }
                    }

                    var name9 = reader["relevant_awards_on_research"].ToString();
                    if (name9 != "No document")
                    {
                        var data4 = (byte[])reader["relevant_awards_on_research_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name9), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data4, 0, data4.Length);
                        }
                    }

                    var name10 = reader["list_research_collab"].ToString();
                    if (name10 != "No document")
                    {
                        var data4 = (byte[])reader["list_research_collab_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name10), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data4, 0, data4.Length);
                        }
                    }

                    var name11 = reader["publication_peer_reviewed"].ToString();
                    if (name11 != "No document")
                    {
                        var data4 = (byte[])reader["publication_peer_reviewed_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name11), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data4, 0, data4.Length);
                        }
                    }

                    var name12 = reader["list_proof_of_patents"].ToString();
                    if (name12 != "No document")
                    {
                        var data4 = (byte[])reader["list_proof_of_patents_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name12), FileMode.Create, FileAccess.Write))
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
            Area6 addDoc = new Area6();
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
                "research_manual AS [Research Manual], " +
                "research_agenda AS [Research Agenda]," +
                "institution_research_journal AS [Institutions's Research Journal]," +
                "approved_budget_alloc AS [Approved Budget Allocation]," +
                "list_of_researchers AS [List of Researchers (proposals, On going, Completed researches)]," +
                "proof_paper_presentation_faculty AS [Proof/evidence of paper presentation by a faculty and student]," +
                "relevant_awards_on_research AS [Relevant awards on research]," +
                "list_research_collab AS [List of Research Collaborations]," +
                "publication_peer_reviewed AS [Publication  in peer reviewed, referred journals]," +
                "list_proof_of_patents AS [List and proof of Patents/utility models/inventions]" +
                "from Area_research";

            objAccess.readDatathroughAdapter(query, dtDocs);
            displayDocs.DataSource = dtDocs;
            objAccess.closeConn();
        }
    }
}
