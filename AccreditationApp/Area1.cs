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
    public partial class Area1 : Form
    {
        public Area1()
        {
            InitializeComponent();
        }

        DBAccess objAccess = new DBAccess();

        private void btnBackArea1_Click(object sender, EventArgs e)
        {
            this.Hide();
            VMGO nav = new VMGO();
            nav.Show();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            Savefile(path1.Text, path2.Text, path3.Text, path4.Text, path5.Text);
            
        }

        private void Savefile(string doc1, string doc2, string doc3, string doc4, string doc5)
        {
            if (doc1.Equals("No document selected") && doc2.Equals("No document selected") && doc3.Equals("No document selected") && doc4.Equals("No document selected") && doc5.Equals("No document selected"))
            {
                MessageBox.Show("Please select document");
            }
            else
            {
                SqlCommand insertCommand = new SqlCommand("" +
                "INSERT INTO Area_VMGO(" +
                "copy_of_vgmo, copy_of_vgmo_doc, suc_charter, suc_charter_doc," +
                "univ_code, univ_code_doc, admin_manual, admin_manual_doc," +
                "annual_report, annual_report_doc, timestamp" +

                ") VALUES(" +
                "@copy_of_vgmo, @copy_of_vgmo_doc, " +
                "@suc_charter, @suc_charter_doc, " +
                "@univ_code, @univ_code_doc, " +
                "@admin_manual, @admin_manual_doc, " +
                "@annual_report, @annual_report_doc, " +
                "@timestamp)");


                if (doc1.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@copy_of_vgmo_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@copy_of_vgmo", "No document");
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

                        insertCommand.Parameters.AddWithValue("@copy_of_vgmo_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@copy_of_vgmo", name);
                    }
                }

                if (doc2.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@suc_charter_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@suc_charter", "No document");
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

                        insertCommand.Parameters.AddWithValue("@suc_charter_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@suc_charter", name);
                    }
                }

                if (doc3.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@univ_code_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@univ_code", "No document");
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

                        insertCommand.Parameters.AddWithValue("@univ_code_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@univ_code", name);
                    }
                }

                if (doc4.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@admin_manual_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@admin_manual", "No document");
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

                        insertCommand.Parameters.AddWithValue("@admin_manual_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@admin_manual", name);
                    }
                }

                if (doc5.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@annual_report_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@annual_report", "No document");
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

                        insertCommand.Parameters.AddWithValue("@annual_report_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@annual_report", name);
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
                }
                else
                {
                    MessageBox.Show("Error occured! try again!.");
                }
            }


        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void path1_Click(object sender, EventArgs e)
        {

        }
    }
}
