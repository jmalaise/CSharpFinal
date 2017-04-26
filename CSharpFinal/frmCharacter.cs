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

            FreshLoad();

        }

        private void FreshLoad()
        {//loads fresh list of names from DB

            lstItems.Items.Clear();

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

        private void btnNew_Click(object sender, EventArgs e)
        {//NEW button

            if (!ValidateInput())
            {
                return;
            }

            string SQLadd =
                "INSERT INTO Character(Name, Strength, Dexterity, Constitution, Wisdom, Charisma, Race, Class, HP, Armor, Description) " +
                "VALUES(@Name, @Strength, @Dexterity, @Constitution, @Wisdom, @Charisma, @Race, @Class, @HP, @Armor, @Description)";

            connection.Open();

            command = new SQLiteCommand(SQLadd, connection);
            command.Parameters.AddWithValue("@Name", txtName.Text);
            command.Parameters.AddWithValue("@Strength", Convert.ToInt32(txtSTR.Text));
            command.Parameters.AddWithValue("@Dexterity", Convert.ToInt32(txtDEX.Text));
            command.Parameters.AddWithValue("@Constitution", Convert.ToInt32(txtCON.Text));
            command.Parameters.AddWithValue("@Wisdom", Convert.ToInt32(txtWIS.Text));
            command.Parameters.AddWithValue("@Charisma", Convert.ToInt32(txtCHA.Text));
            command.Parameters.AddWithValue("@Race", txtRace.Text);
            command.Parameters.AddWithValue("@Class", txtClass.Text);
            command.Parameters.AddWithValue("@HP", Convert.ToInt32(txtHP.Text));
            command.Parameters.AddWithValue("@Armor", Convert.ToInt32(txtAC.Text));
            command.Parameters.AddWithValue("@Description", txtDescription.Text);
            command.ExecuteNonQuery();

            connection.Close();

            FreshLoad();
        }

        /**
         *Validates the form entry shit
         * returns boolean false if something's wrong
         * otherwise returns true
         */
        private Boolean ValidateInput()
        {
            int inSTR;

            if (txtSTR.Text == "")
            {
                errProvider.SetError(txtSTR, "Cannot be empty.");
                return false;
            }else if (!Int32.TryParse(txtSTR.Text, out inSTR) || inSTR < 1 || inSTR >20)
            {
                errProvider.SetError(txtSTR, "Invalid Input.");
                return false;
            }

            int inDEX;

            if (txtSTR.Text == "")
            {
                errProvider.SetError(txtDEX, "Cannot be empty.");
                return false;
            }
            else if (!Int32.TryParse(txtDEX.Text, out inDEX) || inDEX < 1 || inDEX > 20)
            {
                errProvider.SetError(txtDEX, "Invalid Input.");
                return false;
            }

            int inCON;

            if (txtSTR.Text == "")
            {
                errProvider.SetError(txtCON, "Cannot be empty.");
                return false;
            }
            else if (!Int32.TryParse(txtCON.Text, out inCON) || inCON < 1 || inCON > 20)
            {
                errProvider.SetError(txtCON, "Invalid Input.");
                return false;
            }

            int inWIS;

            if (txtSTR.Text == "")
            {
                errProvider.SetError(txtWIS, "Cannot be empty.");
                return false;
            }
            else if (!Int32.TryParse(txtWIS.Text, out inWIS) || inWIS < 1 || inWIS > 20)
            {
                errProvider.SetError(txtWIS, "Invalid Input.");
                return false;
            }

            int inCHA;

            if (txtCHA.Text == "")
            {
                errProvider.SetError(txtCHA, "Cannot be empty.");
                return false;
            }
            else if (!Int32.TryParse(txtCHA.Text, out inCHA) || inCHA < 1 || inCHA > 20)
            {
                errProvider.SetError(txtCHA, "Invalid Input.");
                return false;
            }

            if (txtRace.Text == "")
            {
                errProvider.SetError(txtRace, "Cannot be empty.");
                return false;
            }

            if (txtClass.Text == "")
            {
                errProvider.SetError(txtClass, "Cannot be empty.");
                return false;
            }

            int HitPoints;

            if (txtHP.Text == "")
            {
                errProvider.SetError(txtHP, "Cannot be empty.");
                return false;
            }else if(!Int32.TryParse(txtHP.Text, out HitPoints))
            {
                errProvider.SetError(txtHP, "Invalid Input.");
                return false;
            }

            int Armor;

            if (txtAC.Text == "")
            {
                errProvider.SetError(txtAC, "Cannot be empty.");
                return false;
            }else if(!Int32.TryParse(txtAC.Text, out Armor) || Armor > 0)
            {
                errProvider.SetError(txtAC, "Invalid Input.");
                return false;
            }

            if (txtName.Text.Trim() == "")
            {
                errProvider.SetError(txtName, "Cannot be empty.");
                return false;
            }
            

            if (txtDescription.Text == "")
            {
                errProvider.SetError(txtDescription, "Cannot be empty.");
                return false;
            }

            return true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {//DELETE button

            String target = "'" + lstItems.SelectedItem.ToString() + "'";
            String desc = "'"+txtDescription.Text+"'";
            String SQLremove = "DELETE FROM Character WHERE Name = " + target+ " AND Description = "+desc;

            connection.Open();
            command = new SQLiteCommand(SQLremove, connection);
            command.ExecuteNonQuery();
            connection.Close();

            FreshLoad();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            String target = "'" + lstItems.SelectedItem.ToString() + "'";
            String SQLedit =
                "UPDATE Character SET (Name, Strength, Dexterity, Constitution, Wisdom, Charisma, Race, Class, HP, Armor, Description) " +
                "VALUES ((@Name, @Strength, @Dexterity, @Constitution, @Wisdom, @Charisma, @Race, @Class, @HP, @Armor, @Description) " +
                "WHERE Name = " + target;

            connection.Open();

            command = new SQLiteCommand(SQLedit, connection);
            command.Parameters.AddWithValue("@Name", lstItems.SelectedItem.ToString());
            command.Parameters.AddWithValue("@Strength", Convert.ToInt32(txtSTR.Text));
            command.Parameters.AddWithValue("@Dexterity", Convert.ToInt32(txtDEX.Text));
            command.Parameters.AddWithValue("@Constitution", Convert.ToInt32(txtCON.Text));
            command.Parameters.AddWithValue("@Wisdom", Convert.ToInt32(txtWIS.Text));
            command.Parameters.AddWithValue("@Charisma", Convert.ToInt32(txtCHA.Text));
            command.Parameters.AddWithValue("@Race", txtRace.Text);
            command.Parameters.AddWithValue("@Class", txtClass.Text);
            command.Parameters.AddWithValue("@HP", Convert.ToInt32(txtHP.Text));
            command.Parameters.AddWithValue("@Armor", Convert.ToInt32(txtAC.Text));
            command.Parameters.AddWithValue("@Description", txtDescription.Text);

            connection.Close();

            FreshLoad();

        }
    }
}
