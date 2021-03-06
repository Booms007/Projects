using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace HCG_KHMT2_K7
{
    public partial class frmsukien : Form
    {
        public frmsukien()
        {
            InitializeComponent();
        }
        int vt;
        bool cothem;
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtTenSK.Text = "";
            txtNgunghia.Text = "";
            txtTenSK.Focus();
            btThem.Enabled = false;
            btLuu.Enabled = true;
            cothem = true;
            
        }

        public void list_text(int vt)
        { 
            txtTenSK.Text = listView1.Items[vt].SubItems[0].Text;
            txtNgunghia.Text = listView1.Items[vt].SubItems[1].Text;
        }
        public void text_list(int vt)
        {
            listView1.Items[vt].SubItems[0].Text = txtTenSK.Text;
            listView1.Items[vt].SubItems[1].Text = txtNgunghia.Text;
        }
        private void btLuu_Click(object sender, EventArgs e)
        {
            if (cothem)
            {

                string[] s = new string[2];
                s[0] = txtTenSK.Text;
                s[1] = txtNgunghia.Text;
                ListViewItem lv = new ListViewItem(s);
                listView1.Items.Add(lv);
            }
            else
            {
                text_list(vt);

            }
           LuuFile();
           btSua.Enabled = true;
            btLuu.Enabled = false;
            btThem.Enabled = true; 
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            txtTenSK.Focus();
            cothem = false;
            btLuu.Enabled = true;
            btSua.Enabled = false;
            btThem.Enabled = false;
            
        }
        frmSuydien f = new frmSuydien();
        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader f = new StreamReader("dulieu.dat");

            
            while (f.Peek() != -1)
            {
                vt = vt + 1;

                string s = f.ReadLine();
                string[] ss = s.Split('|');
                ListViewItem lv = new ListViewItem(ss);
                listView1.Items.Add(lv);
            }
            f.Close();
            if (vt != -1)
            {
                txtTenSK.Text = listView1.Items[0].SubItems[0].Text;
                txtNgunghia.Text = listView1.Items[0].SubItems[1].Text;
                vt = 0;
            }

        }
        private void LuuFile()
        {
            StreamWriter f = new StreamWriter("dulieu.dat", false, Encoding.Unicode);
            for (int i = 0; i <= listView1.Items.Count - 1; i++)
            {
                string s = string.Format("{0}|{1}",
                listView1.Items[i].SubItems[0].Text,
                listView1.Items[i].SubItems[1].Text);
                f.WriteLine(s);
            }
            MessageBox.Show(" Lưu thành công ! ", "ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
            f.Close();
        }
        private void btLuuFile_Click(object sender, EventArgs e)
        {
            
        }

        public void text_rong()
        {
            txtTenSK.Text = "";
            txtNgunghia.Text = "";
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            listView1.Items.RemoveAt(vt);
            if (listView1.Items.Count == 0)
            {
                text_rong();
                vt = -1;
            }
            else
            {
                if (vt != 0)
                    vt = vt - 1;
                list_text(vt);
            }
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            if (vt != 1)
                list_text(vt);
            else
                text_rong();
            
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            txtTenSK.Text = e.Item.SubItems[0].Text;
            txtNgunghia.Text = e.Item.SubItems[1].Text;
            vt = e.ItemIndex;

        }

        private void btLuuFile_Click_1(object sender, EventArgs e)
        {
           
        }
    }
}