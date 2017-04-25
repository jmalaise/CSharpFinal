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
    public partial class frmItem : Form
    {
        //form decs
        String MainDB;
        SQLiteConnection connection;
        SQLiteDataAdapter adapter;
        SQLiteCommand command;


        public frmItem()
        {
            InitializeComponent();
        }

        private void chkEdit_CheckedChanged(object sender, EventArgs e)
        {//edit checkbox
            pnlModify.Visible = chkEdit.Checked;

        }

        private void frmItem_Load(object sender, EventArgs e)
        {//FORM! LOAD!

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
                cbxOwner.Items.Add(line["Name"]);
            }

            cbxItem.Enabled = false;
        }

        private void cbxOwner_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxItem.Enabled = true;
            cbxItem.Items.Clear();

            String selectedName = cbxOwner.SelectedItem.ToString();

            String query = " SELECT * FROM Items WHERE Owner = '" + selectedName + "'";

            DataSet output = new DataSet();
            DataTable outTable = new DataTable();

            connection.Open();

            adapter = new SQLiteDataAdapter(query, connection);

            connection.Close();

            adapter.Fill(output, "RowTable");
            outTable = output.Tables["RowTable"];

            foreach (DataRow line in outTable.Rows)
            {
                cbxItem.Items.Add(line["Name"]);
            }

        }

        private void cbxItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selectedName = cbxItem.SelectedItem.ToString();
            String nl = Environment.NewLine;

            String query = " SELECT Name, Quantity, Description FROM Items WHERE Name = '" + selectedName + "'";

            DataSet output = new DataSet();
            DataTable outTable = new DataTable();

            connection.Open();

            adapter = new SQLiteDataAdapter(query, connection);

            connection.Close();

            adapter.Fill(output, "RowTable");
            outTable = output.Tables["RowTable"];

            String quantity = "";

            if (Convert.ToInt32(outTable.Rows[0]["Quantity"]) != 1)
            {
                quantity = "Quantity: " + (outTable.Rows[0]["Quantity"].ToString()) +nl+nl;
            }

            txtDescription.Text = "Item: " + selectedName + nl+nl + quantity + outTable.Rows[0]["Description"].ToString();

        }
    }
}
