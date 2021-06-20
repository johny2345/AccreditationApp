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
    public partial class Area6 : Form
    {
        public Area6()
        {
            InitializeComponent();
        }

        DBAccess objAccess = new DBAccess();

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            Savefile(path1.Text, path2.Text, path3.Text,
                path4.Text, path5.Text, path6.Text, path7.Text, 
                path8.Text, path9.Text, path10.Text);
        }

        private void Savefile(string doc1, string doc2, string doc3, string doc4, string doc5, string doc6, string doc7, string doc8, string doc9, string doc10)
        {
            if (doc1.Equals("No document selected") && doc2.Equals("No document selected") && doc3.Equals("No document selected") 
                && doc4.Equals("No document selected") && doc5.Equals("No document selected")
                && doc6.Equals("No document selected") && doc7.Equals("No document selected")
                && doc8.Equals("No document selected") && doc9.Equals("No document selected")
                && doc10.Equals("No document selected"))
            {
                MessageBox.Show("Please select document");
            }
            else
            {
                SqlCommand insertCommand = new SqlCommand("" +
                "INSERT INTO Area_research(" +
                "research_manual, research_manual_doc, research_agenda," +
                "research_agenda_doc, institution_research_journal, institution_research_journal_doc," +
                "approved_budget_alloc, approved_budget_alloc_doc, list_of_researchers," +
                "list_of_researchers_doc, proof_paper_presentation_faculty, proof_paper_presentation_faculty_doc," +
                "relevant_awards_on_research, relevant_awards_on_research_doc, list_research_collab," +
                "list_research_collab_doc, publication_peer_reviewed, publication_peer_reviewed_doc," +
                "list_proof_of_patents, list_proof_of_patents_doc, timestamp" +

                ") VALUES(" +
                "@research_manual, @research_manual_doc, " +
                "@research_agenda, @research_agenda_doc, " +
                "@institution_research_journal, @institution_research_journal_doc," +
                "@approved_budget_alloc, @approved_budget_alloc_doc," +
                "@list_of_researchers, @list_of_researchers_doc, " +
                "@proof_paper_presentation_faculty, @proof_paper_presentation_faculty_doc, " +
                "@relevant_awards_on_research, @relevant_awards_on_research_doc," +
                "@list_research_collab, @list_research_collab_doc," +
                "@publication_peer_reviewed, @publication_peer_reviewed_doc," +
                "@list_proof_of_patents, @list_proof_of_patents_doc," +
                "@timestamp)");

                if (doc1.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@research_manual_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@research_manual", "No document");
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

                        insertCommand.Parameters.AddWithValue("@research_manual_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@research_manual", name);
                    }
                }

                if (doc2.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@research_agenda_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@research_agenda", "No document");
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

                        insertCommand.Parameters.AddWithValue("@research_agenda_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@research_agenda", name);
                    }
                }

                if (doc3.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@institution_research_journal_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@institution_research_journal", "No document");
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

                        insertCommand.Parameters.AddWithValue("@institution_research_journal_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@institution_research_journal", name);
                    }
                }

                if (doc4.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@approved_budget_alloc_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@approved_budget_alloc", "No document");
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

                        insertCommand.Parameters.AddWithValue("@approved_budget_alloc_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@approved_budget_alloc", name);
                    }
                }

                if (doc5.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@list_of_researchers_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@list_of_researchers", "No document");
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

                        insertCommand.Parameters.AddWithValue("@list_of_researchers_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@list_of_researchers", name);
                    }
                }

                if (doc6.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@proof_paper_presentation_faculty_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@proof_paper_presentation_faculty", "No document");
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

                        insertCommand.Parameters.AddWithValue("@proof_paper_presentation_faculty_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@proof_paper_presentation_faculty", name);
                    }
                }

                if (doc7.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@relevant_awards_on_research_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@relevant_awards_on_research", "No document");
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

                        insertCommand.Parameters.AddWithValue("@relevant_awards_on_research_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@relevant_awards_on_research", name);
                    }
                }

                if (doc8.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@list_research_collab_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@list_research_collab", "No document");
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

                        insertCommand.Parameters.AddWithValue("@list_research_collab_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@list_research_collab", name);
                    }
                }

                if (doc9.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@publication_peer_reviewed_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@publication_peer_reviewed", "No document");
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

                        insertCommand.Parameters.AddWithValue("@publication_peer_reviewed_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@publication_peer_reviewed", name);
                    }
                }

                if (doc10.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@list_proof_of_patents_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@list_proof_of_patents", "No document");
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

                        insertCommand.Parameters.AddWithValue("@list_proof_of_patents_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@list_proof_of_patents", name);
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
                }
                else
                {
                    MessageBox.Show("Error occured! try again!.");
                }

            }
        }

        private void btnBackArea5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Research reach = new Research();
            reach.Show();
        }
    }
}
