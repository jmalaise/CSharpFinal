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
    public partial class frmCharacter : Form
    {
        //form level decs
        String MainDB;
        SQLiteConnection connection;
        SQLiteDataAdapter adapter;
        SQLiteCommand command;

        public frmCharacter()
        {
            InitializeComponent();
        }

        private void chkEdit_CheckedChanged(object sender, EventArgs e)
        {
            grpEdit.Enabled = chkEdit.Checked;
        }

        private void frmCharacter_Load(object sender, EventArgs e)
        {//FORM LOAD!

            //populating listbox
            MainDB = "Data Source = ../../../MainDB.db; Version = 3";
            connection = new SQLiteConnection(MainDB);
            DataSet ListOfNames = new DataSet();
            DataTable tables = new DataTable();


            connection.Open();

            adapter = new SQLiteDataAdapter("SELECT Name FROM Character", connection);

            connection.Close();


            adapter.Fill(ListOfNames, "RowTable");
            tables = ListOfNames.Tables["RowTable"];

            foreach (DataRow line in tables.Rows)
            {
                lstItems.Items.Add(line["Name"]);
            }

            //end lstbox populate

        }

        private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selectedName = lstItems.SelectedItem.ToString();

            String query = "SELECT Strength, Dexterity, Constitution, Wisdom, Charisma, Race, Class, HP, Armor, Description FROM Character WHERE Name = '" + selectedName + "'";
            DataSet output = new DataSet();
            DataTable outTable = new DataTable();

            connection.Open();

            adapter = new SQLiteDataAdapter(query, connection);

            connection.Close();


            adapter.Fill(output, "RowTable");
            outTable = output.Tables["RowTable"];

            txtName.Text = selectedName; 
            txtSTR.Text = outTable.Rows[0]["Strength"].ToString();
            txtDEX.Text = outTable.Rows[0]["Dexterity"].ToString();
            txtCON.Text = outTable.Rows[0]["Constitution"].ToString();
            txtWIS.Text = outTable.Rows[0]["Wisdom"].ToString();
            txtCHA.Text = outTable.Rows[0]["Charisma"].ToString();
            txtINT.Text = "12"; //oh jesus, I forgot to put this in the DB
            txtRace.Text = outTable.Rows[0]["Race"].ToString();
            txtClass.Text = outTable.Rows[0]["Class"].ToString();
            txtHP.Text = outTable.Rows[0]["HP"].ToString();
            txtAC.Text = outTable.Rows[0]["Armor"].ToString();
            txtDescription.Text = outTable.Rows[0]["Description"].ToString();

            
        }
    }
}
