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
    public partial class Area8 : Form
    {
        public Area8()
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
                "INSERT INTO Laboratories(" +
                "approved_bldg_pln, approved_bldg_pln_doc, reports_pres_reqrmnt," +
                "reports_pres_reqrmnt_doc, certificate_conformity, certificate_conformity_doc," +
                "printed_material, printed_material_doc, inventory_lab_tools," +
                "inventory_lab_tools_doc, list_lab_custodian, list_lab_custodian_doc," +
                "safety_mntnnce_guideline, safety_mntnnce_guideline_doc, business_permit_opt," +
                "business_permit_opt_doc, health_cert, health_cert_doc," +
                "tesda_cert, tesda_cert_doc, timestamp" +

                ") VALUES(" +
                "@approved_bldg_pln, @approved_bldg_pln_doc, " +
                "@reports_pres_reqrmnt, @reports_pres_reqrmnt_doc, " +
                "@certificate_conformity, @certificate_conformity_doc, " +
                "@printed_material, @printed_material_doc," +
                "@inventory_lab_tools, @inventory_lab_tools_doc, " +
                "@list_lab_custodian, @list_lab_custodian_doc, " +
                "@safety_mntnnce_guideline, @safety_mntnnce_guideline_doc, " +
                "@business_permit_opt, @business_permit_opt_doc, " +
                "@health_cert, @health_cert_doc," +
                "@tesda_cert, @tesda_cert_doc, @timestamp)");

                if (doc1.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@approved_bldg_pln_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@approved_bldg_pln", "No document");
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

                        insertCommand.Parameters.AddWithValue("@approved_bldg_pln_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@approved_bldg_pln", name);
                    }
                }

                if (doc2.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@reports_pres_reqrmnt_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@reports_pres_reqrmnt", "No document");
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

                        insertCommand.Parameters.AddWithValue("@reports_pres_reqrmnt_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@reports_pres_reqrmnt", name);
                    }
                }

                if (doc3.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@certificate_conformity_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@certificate_conformity", "No document");
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

                        insertCommand.Parameters.AddWithValue("@certificate_conformity_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@certificate_conformity", name);
                    }
                }

                if (doc4.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@printed_material_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@printed_material", "No document");
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

                        insertCommand.Parameters.AddWithValue("@printed_material_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@printed_material", name);
                    }
                }

                if (doc5.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@inventory_lab_tools_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@inventory_lab_tools", "No document");
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

                        insertCommand.Parameters.AddWithValue("@inventory_lab_tools_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@inventory_lab_tools", name);
                    }
                }

                if (doc6.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@list_lab_custodian_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@list_lab_custodian", "No document");
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

                        insertCommand.Parameters.AddWithValue("@list_lab_custodian_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@list_lab_custodian", name);
                    }
                }

                if (doc7.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@safety_mntnnce_guideline_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@safety_mntnnce_guideline", "No document");
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

                        insertCommand.Parameters.AddWithValue("@safety_mntnnce_guideline_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@safety_mntnnce_guideline", name);
                    }
                }

                if (doc8.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@business_permit_opt_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@business_permit_opt", "No document");
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

                        insertCommand.Parameters.AddWithValue("@business_permit_opt_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@business_permit_opt", name);
                    }
                }

                if (doc9.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@health_cert_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@health_cert", "No document");
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

                        insertCommand.Parameters.AddWithValue("@health_cert_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@health_cert", name);
                    }
                }

                if (doc10.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@tesda_cert_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@tesda_cert", "No document");
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

                        insertCommand.Parameters.AddWithValue("@tesda_cert_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@tesda_cert", name);
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

        private void btnBackArea8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Laboratories backtbtn = new Laboratories();
            backtbtn.Show();
        }
    }
}
