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
    public partial class Area3 : Form
    {
        public Area3()
        {
            InitializeComponent();
        }

        DBAccess objAccess = new DBAccess();

        private void btnBackArea3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Curriculum_and_Insruction showForm1 = new Curriculum_and_Insruction();
            showForm1.Show();
        }

        private void btnDoc1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            path1.Text = dlg.FileName;
        }

        private void btnDoc2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            path2.Text = dlg.FileName;
        }

        private void btnDoc3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            path3.Text = dlg.FileName;
        }

        private void btnDoc4_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            path4.Text = dlg.FileName;
        }

        private void btnDoc5_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            path5.Text = dlg.FileName;
        }

        private void btnDoc6_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            path6.Text = dlg.FileName;
        }

        private void btnDoc7_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            path7.Text = dlg.FileName;
        }

        private void btnDoc8_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            path8.Text = dlg.FileName;
        }

        private void btnDoc9_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            path9.Text = dlg.FileName;
        }

        private void btnDoc10_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            path10.Text = dlg.FileName;
        }

        private void btnDoc11_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            path11.Text = dlg.FileName;
        }

        private void btnDoc12_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            path12.Text = dlg.FileName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Savefile(path1.Text, path2.Text, path3.Text, path4.Text, path5.Text, path6.Text, path7.Text, path8.Text, path9.Text, path10.Text, path11.Text, path12.Text);
        }


        private void Savefile(string doc1, string doc2, string doc3, string doc4, string doc5, string doc6, string doc7, string doc8, string doc9, string doc10, string doc11, string doc12)
        {
            if (doc1.Equals("No document selected") && doc2.Equals("No document selected") && doc3.Equals("No document selected") 
                && doc4.Equals("No document selected") && doc5.Equals("No document selected") && doc6.Equals("No document selected") &&
                doc7.Equals("No document selected") && doc8.Equals("No document selected") && doc9.Equals("No document selected") && 
                doc10.Equals("No document selected") && doc11.Equals("No document selected") && doc12.Equals("No document selected"))
            {
                MessageBox.Show("Please select document");
            }
            else
            {
                SqlCommand insertCommand = new SqlCommand("" +
                "INSERT INTO Area_curriculum_instructor(" +
                "program_curriculum, program_curriculum_doc, proof_function_curr_review, proof_function_curr_review_doc," +
                "cmo_policies_guildelines, cmo_policies_guildelines_doc, teaching_methodology, teaching_methodology_doc," +
                "completed_obs_forms, completed_obs_forms_doc, awards_received_suc, awards_received_suc_doc," +
                "performance_license_cert, performance_license_cert_doc, tesda_skills_and_competencies, tesda_skills_and_competencies_doc," +
                "tracer_studies, tracer_studies_doc, certificate_recognition, certificate_recognition_doc," +
                "program_under_survey, program_under_survey_doc, sample_student_outputs, sample_student_outputs_doc, timestamp" +

                ") VALUES(" +
                "@program_curriculum, @program_curriculum_doc, @proof_function_curr_review, @proof_function_curr_review_doc," +
                "@cmo_policies_guildelines, @cmo_policies_guildelines_doc, @teaching_methodology, @teaching_methodology_doc," +
                "@completed_obs_forms, @completed_obs_forms_doc, @awards_received_suc,  @awards_received_suc_doc," +
                "@performance_license_cert, @performance_license_cert_doc, @tesda_skills_and_competencies, @tesda_skills_and_competencies_doc," +
                "@tracer_studies, @tracer_studies_doc, @certificate_recognition, @certificate_recognition_doc," +
                "@program_under_survey, @program_under_survey_doc, @sample_student_outputs, @sample_student_outputs_doc, @timestamp)");


                if (doc1.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@program_curriculum_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@program_curriculum", "No document");
                }
                else
                {
                    var fi = new FileInfo(doc1);
                    using (Stream stream = File.OpenRead(doc1))
                    {
                        byte[] buffer = new byte[stream.Length];
                        stream.Read(buffer, 0, buffer.Length);
                        fi = new FileInfo(doc1);
                        string name = fi.Name;

                        insertCommand.Parameters.AddWithValue("@program_curriculum_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@program_curriculum", name);
                    }
                }

                if (doc2.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@proof_function_curr_review_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@proof_function_curr_review", "No document");
                }
                else
                {
                    var fi = new FileInfo(doc2);
                    using (Stream stream = File.OpenRead(doc2))
                    {
                        byte[] buffer = new byte[stream.Length];
                        stream.Read(buffer, 0, buffer.Length);
                        fi = new FileInfo(doc2);
                        string name = fi.Name;

                        insertCommand.Parameters.AddWithValue("@proof_function_curr_review_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@proof_function_curr_review", name);
                    }
                }

                if (doc3.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@cmo_policies_guildelines_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@cmo_policies_guildelines", "No document");
                }
                else
                {
                    var fi = new FileInfo(doc3);
                    using (Stream stream = File.OpenRead(doc3))
                    {
                        byte[] buffer = new byte[stream.Length];
                        stream.Read(buffer, 0, buffer.Length);
                        fi = new FileInfo(doc3);
                        string name = fi.Name;

                        insertCommand.Parameters.AddWithValue("@cmo_policies_guildelines_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@cmo_policies_guildelines", name);
                    }
                }

                if (doc4.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@teaching_methodology_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@teaching_methodology", "No document");
                }
                else
                {
                    var fi = new FileInfo(doc4);
                    using (Stream stream = File.OpenRead(doc4))
                    {
                        byte[] buffer = new byte[stream.Length];
                        stream.Read(buffer, 0, buffer.Length);
                        fi = new FileInfo(doc4);
                        string name = fi.Name;

                        insertCommand.Parameters.AddWithValue("@teaching_methodology_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@teaching_methodology", name);
                    }
                }

                if (doc5.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@completed_obs_forms_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@completed_obs_forms", "No document");
                }
                else
                {
                    var fi = new FileInfo(doc5);
                    using (Stream stream = File.OpenRead(doc5))
                    {
                        byte[] buffer = new byte[stream.Length];
                        stream.Read(buffer, 0, buffer.Length);
                        fi = new FileInfo(doc5);
                        string name = fi.Name;

                        insertCommand.Parameters.AddWithValue("@completed_obs_forms_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@completed_obs_forms", name);
                    }
                }

                if (doc6.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@awards_received_suc_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@awards_received_suc", "No document");
                }
                else
                {
                    var fi = new FileInfo(doc6);
                    using (Stream stream = File.OpenRead(doc6))
                    {
                        byte[] buffer = new byte[stream.Length];
                        stream.Read(buffer, 0, buffer.Length);
                        fi = new FileInfo(doc6);
                        string name = fi.Name;

                        insertCommand.Parameters.AddWithValue("@awards_received_suc_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@awards_received_suc", name);
                    }
                }

                if (doc7.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@performance_license_cert_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@performance_license_cert", "No document");
                }
                else
                {
                    var fi = new FileInfo(doc7);
                    using (Stream stream = File.OpenRead(doc7))
                    {
                        byte[] buffer = new byte[stream.Length];
                        stream.Read(buffer, 0, buffer.Length);
                        fi = new FileInfo(doc7);
                        string name = fi.Name;

                        insertCommand.Parameters.AddWithValue("@performance_license_cert_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@performance_license_cert", name);
                    }
                }

                if (doc8.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@tesda_skills_and_competencies_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@tesda_skills_and_competencies", "No document");
                }
                else
                {
                    var fi = new FileInfo(doc8);
                    using (Stream stream = File.OpenRead(doc8))
                    {
                        byte[] buffer = new byte[stream.Length];
                        stream.Read(buffer, 0, buffer.Length);
                        fi = new FileInfo(doc8);
                        string name = fi.Name;

                        insertCommand.Parameters.AddWithValue("@tesda_skills_and_competencies_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@tesda_skills_and_competencies", name);
                    }
                }

                if (doc9.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@tracer_studies_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@tracer_studies", "No document");
                }
                else
                {
                    var fi = new FileInfo(doc9);
                    using (Stream stream = File.OpenRead(doc9))
                    {
                        byte[] buffer = new byte[stream.Length];
                        stream.Read(buffer, 0, buffer.Length);
                        fi = new FileInfo(doc9);
                        string name = fi.Name;

                        insertCommand.Parameters.AddWithValue("@tracer_studies_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@tracer_studies", name);
                    }
                }

                if (doc10.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@certificate_recognition_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@certificate_recognition", "No document");
                }
                else
                {
                    var fi = new FileInfo(doc10);
                    using (Stream stream = File.OpenRead(doc10))
                    {
                        byte[] buffer = new byte[stream.Length];
                        stream.Read(buffer, 0, buffer.Length);
                        fi = new FileInfo(doc10);
                        string name = fi.Name;

                        insertCommand.Parameters.AddWithValue("@certificate_recognition_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@certificate_recognition", name);
                    }
                }

                if (doc11.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@program_under_survey_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@program_under_survey", "No document");
                }
                else
                {
                    var fi = new FileInfo(doc11);
                    using (Stream stream = File.OpenRead(doc11))
                    {
                        byte[] buffer = new byte[stream.Length];
                        stream.Read(buffer, 0, buffer.Length);
                        fi = new FileInfo(doc11);
                        string name = fi.Name;

                        insertCommand.Parameters.AddWithValue("@program_under_survey_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@program_under_survey", name);
                    }
                }

                if (doc12.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@sample_student_outputs_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@sample_student_outputs", "No document");
                }
                else
                {
                    var fi = new FileInfo(doc12);
                    using (Stream stream = File.OpenRead(doc12))
                    {
                        byte[] buffer = new byte[stream.Length];
                        stream.Read(buffer, 0, buffer.Length);
                        fi = new FileInfo(doc12);
                        string name = fi.Name;

                        insertCommand.Parameters.AddWithValue("@sample_student_outputs_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@sample_student_outputs", name);
                    }
                }
                insertCommand.Parameters.AddWithValue("@timestamp", DateTime.Now);
                int row = objAccess.executeQuery(insertCommand);

                if (row == 1)
                {
                    MessageBox.Show("Document added successfully");
                    path1.Text = "No document selected";
                    path2.Text = "No document selected";
                    path3.Text = "No document selected";
                    path4.Text = "No document selected";
                    path5.Text = "No document selected";
                    path6.Text = "No document selected";
                    path7.Text = "No document selected";
                    path8.Text = "No document selected";
                    path9.Text = "No document selected";
                    path10.Text = "No document selected";
                    path11.Text = "No document selected";
                    path12.Text = "No document selected";
                }
                else
                {
                    MessageBox.Show("Error occured! try again!.");
                }
            }
        }
    }
}
