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
    public partial class Area4 : Form
    {
        public Area4()
        {
            InitializeComponent();
        }

        DBAccess objAccess = new DBAccess();

        private void btnBackArea4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Support_to_Students showForm1 = new Support_to_Students();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            Savefile(path1.Text, path2.Text, path3.Text, path4.Text, path5.Text, path6.Text);
        }

        private void Savefile(string doc1, string doc2, string doc3, string doc4, string doc5, string doc6)
        {
            if (doc1.Equals("No document selected") && doc2.Equals("No document selected") && doc3.Equals("No document selected") && doc4.Equals("No document selected") && doc5.Equals("No document selected"))
            {
                MessageBox.Show("Please select document");
            }
            else
            {
                SqlCommand insertCommand = new SqlCommand("" +
                "INSERT INTO Area_support_students(" +
                "student_handbook, student_handbook_doc, guidance_manual, guidance_manual_doc," +
                "proof_of_license, proof_of_license_doc, scholarship_welf_program, scholarship_welf_program_doc," +
                "list_student_service_proof, list_student_service_proof_doc," +
                "budget_sas_office_certified, budget_sas_office_certified_doc, timestamp" +

                ") VALUES(" +
                "@student_handbook, @student_handbook_doc, " +
                "@guidance_manual, @guidance_manual_doc, " +
                "@proof_of_license, @proof_of_license_doc, " +
                "@scholarship_welf_program, @scholarship_welf_program_doc," +
                "@list_student_service_proof, @list_student_service_proof_doc," +
                "@budget_sas_office_certified, @budget_sas_office_certified_doc," +
                "@timestamp)");


                if (doc1.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@student_handbook_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@student_handbook", "No document");
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

                        insertCommand.Parameters.AddWithValue("@student_handbook_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@student_handbook", name);
                    }
                }

                if (doc2.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@guidance_manual_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@guidance_manual", "No document");
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

                        insertCommand.Parameters.AddWithValue("@guidance_manual_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@guidance_manual", name);
                    }
                }

                if (doc3.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@proof_of_license_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@proof_of_license", "No document");
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

                        insertCommand.Parameters.AddWithValue("@proof_of_license_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@proof_of_license", name);
                    }
                }

                if (doc4.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@scholarship_welf_program_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@scholarship_welf_program", "No document");
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

                        insertCommand.Parameters.AddWithValue("@scholarship_welf_program_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@scholarship_welf_program", name);
                    }
                }

                if (doc5.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@list_student_service_proof_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@list_student_service_proof", "No document");
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

                        insertCommand.Parameters.AddWithValue("@list_student_service_proof_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@list_student_service_proof", name);
                    }
                }

                if (doc6.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@budget_sas_office_certified_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@budget_sas_office_certified", "No document");
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

                        insertCommand.Parameters.AddWithValue("@budget_sas_office_certified_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@budget_sas_office_certified", name);
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
                }
                else
                {
                    MessageBox.Show("Error occured! try again!.");
                }
            }
        }
    }
}
