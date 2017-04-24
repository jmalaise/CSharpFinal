using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace CSharpFinal
{
    public partial class frmMain : Form
    {
        //form level decs
        String MainDB;
        SQLiteConnection connection;
        SQLiteDataAdapter adapter;
        SQLiteCommand command;

        public frmMain()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {//exit menu item
            this.Close();
        }

        private void characterFormToolStripMenuItem_Click(object sender, EventArgs e)
        {//character form menu item
            frmCharacter frm = new frmCharacter();
            frm.ShowDialog();
        }

        private void itemFormToolStripMenuItem_Click(object sender, EventArgs e)
        {//item form menu item
            frmItem frm = new frmItem();
            frm.ShowDialog();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {//FORM! LOAD!!
            MainDB = "Data Source = ../../../MainDB.db; Version = 3";
            connection = new SQLiteConnection(MainDB);

            radCharacter.Select();
        }

        private void radCharacter_CheckedChanged(object sender, EventArgs e)
        {//character radio table display
            errProvider.Clear();
            String SQLchar = "SELECT Name, HP, Armor, Race, Class FROM Character";
            DataSet CharData = new DataSet();

            connection.Open();
            adapter = new SQLiteDataAdapter(SQLchar, connection);
            adapter.Fill(CharData);
            connection.Close();

            dgvMain.DataSource = CharData.Tables[0].DefaultView;

        }

        private void radItem_CheckedChanged(object sender, EventArgs e)
        {//item radio table display
            errProvider.Clear();
            String SQLitem = "SELECT Name, Quantity, Owner, Description FROM Items ORDER BY Owner DESC";
            DataSet ItemData = new DataSet();

            connection.Open();
            adapter = new SQLiteDataAdapter(SQLitem, connection);
            adapter.Fill(ItemData);
            connection.Close();

            dgvMain.DataSource = ItemData.Tables[0].DefaultView;
        }

        private void btnSearchExact_Click(object sender, EventArgs e)
        {//search EXACT

            //input validation
            errProvider.Clear();
            if (txtSearch.Text.Trim() == "")
            {
                errProvider.SetError(txtSearch, "Entry cannot be empty");
                return;
            }
            else if(txtSearch.Text.Contains(";")){
                errProvider.SetError(txtSearch, "Entry contains invalid character.");
                return;
            }

            string input = txtSearch.Text.Trim();

            //searching based on visible table
            if (radCharacter.Checked == true)
            {
                String SQLchar = "SELECT Name, HP, Armor, Race, Class FROM Character WHERE Name = '"+input+"'";
                DataSet CharData = new DataSet();

                connection.Open();
                adapter = new SQLiteDataAdapter(SQLchar, connection);
                adapter.Fill(CharData);
                connection.Close();

                dgvMain.DataSource = CharData.Tables[0].DefaultView;
            }
            else
            {
                String SQLitem = "SELECT Name, Quantity, Owner, Description FROM Items WHERE Name = '"+input+"' ORDER BY Owner DESC";
                DataSet ItemData = new DataSet();

                connection.Open();
                adapter = new SQLiteDataAdapter(SQLitem, connection);
                adapter.Fill(ItemData);
                connection.Close();

                dgvMain.DataSource = ItemData.Tables[0].DefaultView;
            }
        }

        private void btnSearchLike_Click(object sender, EventArgs e)
        {//search LIKE

            //input validation
            errProvider.Clear();
            if (txtSearch.Text.Trim() == "")
            {
                errProvider.SetError(txtSearch, "Entry cannot be empty");
                return;
            }
            else if (txtSearch.Text.Contains(";"))
            {
                errProvider.SetError(txtSearch, "Entry contains invalid character.");
                return;
            }

            string input = txtSearch.Text.Trim();

            //searching based on visible table
            if (radCharacter.Checked == true)
            {
                String SQLchar = "SELECT Name, HP, Armor, Race, Class FROM Character WHERE Name LIKE '%" + input + "%'";
                DataSet CharData = new DataSet();

                connection.Open();
                adapter = new SQLiteDataAdapter(SQLchar, connection);
                adapter.Fill(CharData);
                connection.Close();

                dgvMain.DataSource = CharData.Tables[0].DefaultView;
            }
            else
            {
                String SQLitem = "SELECT Name, Quantity, Owner, Description FROM Items WHERE Name LIKE '%" + input + "%' ORDER BY Owner DESC";
                DataSet ItemData = new DataSet();

                connection.Open();
                adapter = new SQLiteDataAdapter(SQLitem, connection);
                adapter.Fill(ItemData);
                connection.Close();

                dgvMain.DataSource = ItemData.Tables[0].DefaultView;
            }


        }
    }
}
