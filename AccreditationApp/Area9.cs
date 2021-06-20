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
    public partial class Area9 : Form
    {
        public Area9()
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

        private void Savefile(string doc1, string doc2, string doc3,
            string doc4, string doc5, string doc6, string doc7,
            string doc8, string doc9, string doc10)
        {
            if (doc1.Equals("No document selected") && doc2.Equals("No document selected")
                && doc3.Equals("No document selected") && doc4.Equals("No document selected")
                && doc5.Equals("No document selected") && doc6.Equals("No document selected") && doc7.Equals("No document selected")
                && doc8.Equals("No document selected") && doc9.Equals("No document selected") && doc10.Equals("No document selected"))
            {
                MessageBox.Show("Please select document");
            }
            else
            {
                SqlCommand insertCommand = new SqlCommand("" +
                "INSERT INTO Administration(" +
                "approved_org_structure, approved_org_structure_doc, list_designated_off," +
                "list_designated_off_doc, cert_proof_transparency, cert_proof_transparency_doc," +
                "strategic_dev_plan, strategic_dev_plan_doc, bids_awards_committe," +
                "bids_awards_committe_doc, financial_mngmt_system, financial_mngmt_system_doc," +
                "record_mngmt_system, record_mngmt_system_doc, financial_dev_plan," +
                "financial_dev_plan_doc, annual_audit_report, annual_audit_report_doc," +
                "performance_eval_system, performance_eval_system_doc, timestamp" +

                ") VALUES(" +
                "@approved_org_structure, @approved_org_structure_doc, " +
                "@list_designated_off, @list_designated_off_doc, " +
                "@cert_proof_transparency, @cert_proof_transparency_doc, " +
                "@strategic_dev_plan, @strategic_dev_plan_doc," +
                "@bids_awards_committe, @bids_awards_committe_doc, " +
                "@financial_mngmt_system, @financial_mngmt_system_doc, " +
                "@record_mngmt_system, @record_mngmt_system_doc, " +
                "@financial_dev_plan, @financial_dev_plan_doc, " +
                "@annual_audit_report, @annual_audit_report_doc," +
                "@performance_eval_system, @performance_eval_system_doc, @timestamp)");

                if (doc1.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@approved_org_structure_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@approved_org_structure", "No document");
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

                        insertCommand.Parameters.AddWithValue("@approved_org_structure_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@approved_org_structure", name);
                    }
                }

                if (doc2.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@list_designated_off_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@list_designated_off", "No document");
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

                        insertCommand.Parameters.AddWithValue("@list_designated_off_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@list_designated_off", name);
                    }
                }

                if (doc3.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@cert_proof_transparency_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@cert_proof_transparency", "No document");
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

                        insertCommand.Parameters.AddWithValue("@cert_proof_transparency_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@cert_proof_transparency", name);
                    }
                }

                if (doc4.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@strategic_dev_plan_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@strategic_dev_plan", "No document");
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

                        insertCommand.Parameters.AddWithValue("@strategic_dev_plan_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@strategic_dev_plan", name);
                    }
                }

                if (doc5.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@bids_awards_committe_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@bids_awards_committe", "No document");
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

                        insertCommand.Parameters.AddWithValue("@bids_awards_committe_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@bids_awards_committe", name);
                    }
                }

                if (doc6.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@financial_mngmt_system_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@financial_mngmt_system", "No document");
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

                        insertCommand.Parameters.AddWithValue("@financial_mngmt_system_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@financial_mngmt_system", name);
                    }
                }

                if (doc7.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@record_mngmt_system_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@record_mngmt_system", "No document");
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

                        insertCommand.Parameters.AddWithValue("@record_mngmt_system_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@record_mngmt_system", name);
                    }
                }

                if (doc8.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@financial_dev_plan_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@financial_dev_plan", "No document");
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

                        insertCommand.Parameters.AddWithValue("@financial_dev_plan_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@financial_dev_plan", name);
                    }
                }

                if (doc9.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@annual_audit_report_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@annual_audit_report", "No document");
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

                        insertCommand.Parameters.AddWithValue("@annual_audit_report_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@annual_audit_report", name);
                    }
                }

                if (doc10.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@performance_eval_system_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@performance_eval_system", "No document");
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

                        insertCommand.Parameters.AddWithValue("@performance_eval_system_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@performance_eval_system", name);
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

        private void btnBackArea9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Administration admin = new Administration();
            admin.Show();
        }
    }
}
