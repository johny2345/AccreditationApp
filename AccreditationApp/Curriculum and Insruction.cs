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
    public partial class Curriculum_and_Insruction : Form
    {
        public Curriculum_and_Insruction()
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

        private void OpenFile(int id)
        {
            using (SqlConnection cn = GetConnection())
            {
                string query = "Select * FROM Area_curriculum_instructor where ID=@id";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var name = reader["program_curriculum"].ToString();
                    if (name != "No document")
                    {
                        var data = (byte[])reader["program_curriculum_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data, 0, data.Length);
                        }
                    }

                    var name2 = reader["proof_function_curr_review"].ToString();
                    if (name2 != "No document")
                    {
                        var data2 = (byte[])reader["proof_function_curr_review_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name2), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data2, 0, data2.Length);
                        }
                    }

                    var name3 = reader["cmo_policies_guildelines"].ToString();
                    if (name3 != "No document")
                    {
                        var data3 = (byte[])reader["cmo_policies_guildelines_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name3), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data3, 0, data3.Length);
                        }
                    }

                    var name4 = reader["teaching_methodology"].ToString();
                    if (name4 != "No document")
                    {
                        var data4 = (byte[])reader["teaching_methodology_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name4), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data4, 0, data4.Length);
                        }
                    }

                    var name5 = reader["completed_obs_forms"].ToString();
                    if (name5 != "No document")
                    {
                        var data4 = (byte[])reader["completed_obs_forms_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name5), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data4, 0, data4.Length);
                        }
                    }

                    var name6 = reader["awards_received_suc"].ToString();
                    if (name6 != "No document")
                    {
                        var data4 = (byte[])reader["awards_received_suc_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name6), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data4, 0, data4.Length);
                        }
                    }

                    var name7 = reader["performance_license_cert"].ToString();
                    if (name7 != "No document")
                    {
                        var data4 = (byte[])reader["performance_license_cert_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name7), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data4, 0, data4.Length);
                        }
                    }

                    var name8 = reader["tesda_skills_and_competencies"].ToString();
                    if (name8 != "No document")
                    {
                        var data4 = (byte[])reader["tesda_skills_and_competencies_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name8), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data4, 0, data4.Length);
                        }
                    }

                    var name9 = reader["tracer_studies"].ToString();
                    if (name9 != "No document")
                    {
                        var data4 = (byte[])reader["tracer_studies_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name9), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data4, 0, data4.Length);
                        }
                    }

                    var name10 = reader["certificate_recognition"].ToString();
                    if (name10 != "No document")
                    {
                        var data4 = (byte[])reader["certificate_recognition_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name10), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data4, 0, data4.Length);
                        }
                    }

                    var name11 = reader["program_under_survey"].ToString();
                    if (name11 != "No document")
                    {
                        var data4 = (byte[])reader["program_under_survey_doc"];
                        using (var fs = new FileStream(Path.Combine("D:\\", name11), FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(data4, 0, data4.Length);
                        }
                    }

                    var name12 = reader["sample_student_outputs"].ToString();
                    if (name12 != "No document")
                    {
                        var data4 = (byte[])reader["sample_student_outputs_doc"];
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
            Area3 addDoc = new Area3();
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
                "program_curriculum AS [Program Curriculum]," +
                "proof_function_curr_review AS [Proof of functional Curriculum Review Committee], " +
                "cmo_policies_guildelines AS [CMOs/Policies/Guildelines]," +
                "teaching_methodology AS [Teaching Methodologies]," +
                "completed_obs_forms AS [Completed classroom observation forms]," +
                "awards_received_suc AS [Awards/Recognitions received by SUC graduates]," +
                "performance_license_cert AS [Performace in Licensure Exam/ PRC Certification]," +
                "tesda_skills_and_competencies AS [TESDA on skills and Competencies]," +
                "tracer_studies as [Tracer Studies]," +
                "certificate_recognition AS [Certificate of Recognition/Awards]," +
                "program_under_survey AS [Program under survey]," +
                "sample_student_outputs AS [Samples of student Outputs]" +
                "from Area_curriculum_instructor";

            objAccess.readDatathroughAdapter(query, dtDocs);
            displayDocs.DataSource = dtDocs;
            objAccess.closeConn();
        }

        private void Curriculum_and_Insruction_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
