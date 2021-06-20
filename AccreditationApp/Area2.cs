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
    public partial class Area2 : Form
    {
        public Area2()
        {
            InitializeComponent();
        }

        DBAccess objAccess = new DBAccess();

        private void btnBackArea2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 showForm1 = new Form1();
            showForm1.Show();
        }



        private void txtBoxName_TextChanged(object sender, EventArgs e)
        {

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
            Savefile(txtBoxName.Text, path2.Text, path3.Text, 
                path4.Text, path5.Text, path6.Text, path7.Text, path8.Text);
        }

        private void Savefile(string doc1, string doc2, string doc3, string doc4, string doc5, string doc6, string doc7, string doc8)
        {
            if (doc1.Equals("") && doc2.Equals("No document selected") && doc3.Equals("No document selected") && doc4.Equals("No document selected") && doc5.Equals("No document selected"))
            {
                MessageBox.Show("Please select document");
            }
            else if (doc1.Equals(""))
            {
                MessageBox.Show("Please add the faculty Name");
            }
            else
            {
                SqlCommand insertCommand = new SqlCommand("" +
                "INSERT INTO Area_faculty(" +
                "faculty_name, faculty_manual, faculty_manual_doc," +
                "faculty_dev_plan, faculty_dev_plan_doc, update_fac_prof," +
                "update_fac_prof_doc, teach_load_sched, teach_load_sched_doc," +
                "performance_eval, performance_eval_doc, sholarly_works_fac," +
                "sholarly_works_fac_doc, merit_system_prom_plan, merit_system_prom_plan_doc," +
                "timestamp" +

                ") VALUES(" +
                "@faculty_name, @faculty_manual, " +
                "@faculty_manual_doc, @faculty_dev_plan, " +
                "@faculty_dev_plan_doc, @update_fac_prof, @update_fac_prof_doc, @teach_load_sched," +
                "@teach_load_sched_doc, @performance_eval, " +
                "@performance_eval_doc, @sholarly_works_fac, " +
                "@sholarly_works_fac_doc, @merit_system_prom_plan, " +
                "@merit_system_prom_plan_doc, @timestamp)");

                insertCommand.Parameters.AddWithValue("@faculty_name", doc1);

                if (doc2.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@faculty_manual_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@faculty_manual", "No document");
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

                        insertCommand.Parameters.AddWithValue("@faculty_manual_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@faculty_manual", name);
                    }
                }
                if (doc3.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@faculty_dev_plan_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@faculty_dev_plan", "No document");
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

                        insertCommand.Parameters.AddWithValue("@faculty_dev_plan_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@faculty_dev_plan", name);
                    }
                }

                if (doc4.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@update_fac_prof_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@update_fac_prof", "No document");
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

                        insertCommand.Parameters.AddWithValue("@update_fac_prof_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@update_fac_prof", name);
                    }
                }

                if (doc5.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@teach_load_sched_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@teach_load_sched", "No document");
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

                        insertCommand.Parameters.AddWithValue("@teach_load_sched_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@teach_load_sched", name);
                    }
                }

                if (doc6.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@performance_eval_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@performance_eval", "No document");
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

                        insertCommand.Parameters.AddWithValue("@performance_eval_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@performance_eval", name);
                    }
                }

                if (doc7.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@sholarly_works_fac_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@sholarly_works_fac", "No document");
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

                        insertCommand.Parameters.AddWithValue("@sholarly_works_fac_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@sholarly_works_fac", name);
                    }
                }

                if (doc8.Equals("No document selected"))
                {
                    insertCommand.Parameters.AddWithValue("@merit_system_prom_plan_doc", System.Data.SqlTypes.SqlBinary.Null);
                    insertCommand.Parameters.AddWithValue("@merit_system_prom_plan", "No document");
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

                        insertCommand.Parameters.AddWithValue("@merit_system_prom_plan_doc", buffer);
                        insertCommand.Parameters.AddWithValue("@merit_system_prom_plan", name);
                    }
                }

                insertCommand.Parameters.AddWithValue("@timestamp", DateTime.Now);
                int row = objAccess.executeQuery(insertCommand);

                if (row == 1)
                {
                    MessageBox.Show("Document added successfully");
                    txtBoxName.Text = "";
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

        private void btnBackArea1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Faculty fac = new Faculty();
            fac.Show();
        }
    }  
}
