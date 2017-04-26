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

        private void btnAdd_Click(object sender, EventArgs e)
        {// ADD button

            int qty = ValidateInput();

            if (qty < 1)
            {
                return;
            }

            String selectedName = cbxOwner.SelectedItem.ToString();

            String SQLadd = "INSERT INTO Items(Name, Quantity, Owner, Description) VALUES (@Name, @Quantity, @Owner, @Description)";

            connection.Open();

            command = new SQLiteCommand(SQLadd, connection);
            command.Parameters.AddWithValue("@Name", txtName.Text);
            command.Parameters.AddWithValue("@Quantity", qty);
            command.Parameters.AddWithValue("@Owner", selectedName);
            command.Parameters.AddWithValue("@Description", txtDescription.Text);
            command.ExecuteNonQuery();
            connection.Close();
        }

        /**
         * Validates Item form inputs.
         * returns -1 if any invalid input
         * otherwise returns quantity value as int.
         */
        private int ValidateInput()
        {
            if (txtName.Text == "")
            {
                errProvider.SetError(txtName, "Cannot be empty.");
                return -1;
            }

            if (txtQuantity.Text == "")
            {
                errProvider.SetError(txtQuantity, "Cannot be empty.");
                return -1;
            }

            if (txtDescription.Text == "")
            {
                errProvider.SetError(txtDescription, "Cannot be empty.");
                return -1;
            }

            int qty;

            if (!(Int32.TryParse(txtQuantity.Text, out qty)))
            {
                errProvider.SetError(txtQuantity, "Invalid entry.");
                return -1;
            }
            else if (qty < 1)
            {
                errProvider.SetError(txtQuantity, "Cannot be Zero or Negitive.");
                return -1;
            }

            return qty;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {//DELETE button

            String owner = "'" + cbxOwner.SelectedItem.ToString() + "'";
            String target = "'" + cbxItem.SelectedItem.ToString() + "'";
            String SQLdel = "DELETE FROM Items WHERE Owner = " + owner + " AND Name = " + target;


            connection.Open();
            command = new SQLiteCommand(SQLdel, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {//EDIT button

            int qty = ValidateInput();

            if (qty > 1)
            {
                return;
            }

            String owner = "'" + cbxOwner.SelectedItem.ToString() + "'";
            String target = "'" + cbxItem.SelectedItem.ToString() + "'";
            String SQLedit = 
                "UPDATE Items SET (Name, Quantity, Owner, Description) " +
                "VALUES (@Name, @Quantity, @Owner, @Description) " +
                "WHERE Owner ="+owner+" AND Name = "+target;

            connection.Open();
            command = new SQLiteCommand(SQLedit, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
