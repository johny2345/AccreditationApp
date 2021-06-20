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
    public partial class Area5 : Form
    {
        public Area5()
        {
            InitializeComponent();
        }

        DBAccess objAccess = new DBAccess();

        private void btnBackArea5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Extension_and_community_involvement showForm1 = new Extension_and_community_involvement();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            Savefile(path1.Text, path2.Text, path3.Text,
                path4.Text, path5.Text, path6.Text, path7.Text, path8.Text);
        }

        private void Savefile(string doc1, string doc2, string doc3, string doc4, string doc5, string doc6, string doc7, string doc8)
        {
            if (doc1.Equals("No document selected") && doc2.Equals("No document selected") && doc3.Equals("No document selected") && doc4.Equals("No document selected") && doc5.Equals("No document selected"))
            {
                MessageBox.Show("Please select document");
            }
            else
            {
                SqlCommand insertCommand = new SqlCommand("" +
                "INSERT INTO Area_community_involvement(" +
                "extension_service_manual, extension_service_manual_doc, extension_agenda," +
                "extension_agenda_doc, approved_budgetary_alloc, approved_budgetary_alloc_doc," +
                "report_relevant_success_ext, report_relevant_success_ext_doc, video_actual_comm_ext," +
                "video_actual_comm_ext_doc, effect_short_term_ext_prog, effect_short_term_ext_prog_doc," +
                "impact_assess_ext_prog, impact_assess_ext_prog_doc, list_proof_partnership," +
                "list_proof_partnership_doc, timestamp" +

                ") VALUES(" +
                "@extension_service_manual, @extension_service_manual_doc, " +
                "@extension_agenda, @extension_agenda_doc, " +
                "@approved_budgetary_alloc, @approved_budgetary_alloc_doc, @report_relevant_success_ext, @report_relevant_success_ext_doc," +
                "@video_actual_comm_ext, @video_actual_comm_ext_doc, " +
                "@effect_short_term_ext_prog, @effect_short_term_ext_prog_doc, " +
                "@impact_assess_ext_prog, @impact_assess_ext_prog_doc, " +
                "@list_proof_partnership, @list_proof_partnership_doc, @timestamp)");

                insertCommand.Parameters.AddWithValue("@faculty_name", doc1);

                if (doc1.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@extension_service_manual_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@extension_service_manual", "No document");
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

                        insertCommand.Parameters.AddWithValue("@extension_service_manual_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@extension_service_manual", name);
                    }
                }

                if (doc2.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@extension_agenda_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@extension_agenda", "No document");
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

                        insertCommand.Parameters.AddWithValue("@extension_agenda_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@extension_agenda", name);
                    }
                }

                if (doc3.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@approved_budgetary_alloc_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@approved_budgetary_alloc", "No document");
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

                        insertCommand.Parameters.AddWithValue("@approved_budgetary_alloc_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@approved_budgetary_alloc", name);
                    }
                }

                if (doc4.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@report_relevant_success_ext_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@report_relevant_success_ext", "No document");
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

                        insertCommand.Parameters.AddWithValue("@report_relevant_success_ext_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@report_relevant_success_ext", name);
                    }
                }

                if (doc5.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@video_actual_comm_ext_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@video_actual_comm_ext", "No document");
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

                        insertCommand.Parameters.AddWithValue("@video_actual_comm_ext_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@video_actual_comm_ext", name);
                    }
                }

                if (doc6.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@effect_short_term_ext_prog_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@effect_short_term_ext_prog", "No document");
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

                        insertCommand.Parameters.AddWithValue("@effect_short_term_ext_prog_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@effect_short_term_ext_prog", name);
                    }
                }

                if (doc7.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@impact_assess_ext_prog_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@impact_assess_ext_prog", "No document");
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

                        insertCommand.Parameters.AddWithValue("@impact_assess_ext_prog_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@impact_assess_ext_prog", name);
                    }
                }

                if (doc8.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@list_proof_partnership_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@list_proof_partnership", "No document");
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

                        insertCommand.Parameters.AddWithValue("@list_proof_partnership_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@list_proof_partnership", name);
                    }
                }

                insertCommand.Parameters.AddWithValue("@timestamp", DateTime.Now);
                int row = objAccess.executeQuery(insertCommand);

                if (row == 1)
                {
                    MessageBox.Show("Document added successfully");
                    path1.Text = "";
                    path2.Text = "No document selected";
                    path3.Text = "No document selected";
                    path4.Text = "No document selected";
                    path5.Text = "No document selected";
                    path6.Text = "No document selected";
                    path7.Text = "No document selected";
                    path8.Text = "No document selected";
                }
                else
                {
                    MessageBox.Show("Error occured! try again!.");
                }
            }
        }
    }
}
