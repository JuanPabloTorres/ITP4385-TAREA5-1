using ITP4385_TAREA5_1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITP4385_TAREA5_1
{
    public partial class Form1 : Form
    {




        bool foundCustomerRecord = false;

        static Client Client = new Client();


        static string filenameJSON = "C:\\EDP\\ITP-4385\\LabTextFile.json";


        static string _connectionString = "Data Source=D:\\database.sqlite;Version=3;New=True;Compress=True;";

        static string imagePhotoValue;

        SQLiteConnection SQLiteConnection = new SQLiteConnection(_connectionString);

        SQLiteCommand SQLiteCommand;

        public Form1()
        {
            InitializeComponent();

            GetFirstRow();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        bool FindCustomer(int customerId)
        {

            string counterQuery = "Select * from customer where id=" + customerId;

            SQLiteCommand = new SQLiteCommand(counterQuery, SQLiteConnection);

            SQLiteConnection.Open();

            SQLiteDataReader sQLiteDataReader = SQLiteCommand.ExecuteReader();

            bool result = false;

            while (sQLiteDataReader.Read())
            {

                txtCustId.Text = sQLiteDataReader["id"].ToString();

                txtFN.Text = sQLiteDataReader["name"].ToString();

                txtLN.Text = sQLiteDataReader["lastname"].ToString();


                txtStreet.Text = sQLiteDataReader["street"].ToString();


                txtCity.Text = sQLiteDataReader["city"].ToString();


                txtZipCode.Text = sQLiteDataReader["zipcode"].ToString();

                txtPhone.Text = sQLiteDataReader["phone"].ToString();

                rtxtNotes.Text = sQLiteDataReader["Notes"].ToString();


                var photoValue = sQLiteDataReader["photo"].ToString();

                if (!string.IsNullOrEmpty(photoValue))
                {

                    Image loadBitmap = Image.FromFile(photoValue);

                    pictureBox1.Image = loadBitmap;
                }



                cbProf.Text = sQLiteDataReader["profession"].ToString();

                cbBT.Text = sQLiteDataReader["businessType"].ToString();

                var statusValue = sQLiteDataReader["isActive"].ToString();

                var genderValue = sQLiteDataReader["gender"].ToString();

                if (genderValue == "F")
                {
                    rbFemale.Checked = true;
                }
                else
                {
                    rbMale.Checked = true;

                }


                result = true;




            }

            SQLiteConnection.Close();


            return result;


        }


        int GetFirstRow()
        {

            try
            {

                string counterQuery = "Select * from customer limit 1";

                SQLiteCommand = new SQLiteCommand(counterQuery, SQLiteConnection);

                SQLiteConnection.Open();

                SQLiteDataReader sQLiteDataReader = SQLiteCommand.ExecuteReader();



                while (sQLiteDataReader.Read())
                {

                    txtCustId.Text = sQLiteDataReader["id"].ToString();

                    txtFN.Text = sQLiteDataReader["name"].ToString();

                    txtLN.Text = sQLiteDataReader["lastname"].ToString();


                    txtStreet.Text = sQLiteDataReader["street"].ToString();


                    txtCity.Text = sQLiteDataReader["city"].ToString();


                    txtZipCode.Text = sQLiteDataReader["zipcode"].ToString();

                    txtPhone.Text = sQLiteDataReader["phone"].ToString();

                    rtxtNotes.Text = sQLiteDataReader["Notes"].ToString();


                    var photoValue = sQLiteDataReader["photo"].ToString();

                    if (!string.IsNullOrEmpty(photoValue))
                    {

                        Image loadBitmap = Image.FromFile(photoValue);

                        pictureBox1.Image = loadBitmap;
                    }



                    cbProf.Text = sQLiteDataReader["profession"].ToString();

                    cbBT.Text = sQLiteDataReader["businessType"].ToString();

                    var statusValue = sQLiteDataReader["isActive"].ToString();

                    var genderValue = sQLiteDataReader["gender"].ToString();

                    if (genderValue == "F")
                    {
                        rbFemale.Checked = true;
                    }
                    else
                    {
                        rbMale.Checked = true;

                    }

                    SQLiteConnection.Close();


                    return int.Parse(txtCustId.Text);




                }

                SQLiteConnection.Close();


                return 0;

            }
            catch (Exception e)
            {
                SQLiteConnection.Close();

                MessageBox.Show(e.Message);

                return 0;
            }

        }


        int GetMinCount()
        {
            string minCountQuery = "select Min(id) as counter from customer";

            int minCounter = -1;

            SQLiteCommand = new SQLiteCommand(minCountQuery, SQLiteConnection);

            SQLiteConnection.Open();

            SQLiteDataReader sQLiteDataReader = SQLiteCommand.ExecuteReader();

            while (sQLiteDataReader.Read())
            {

                minCounter = Int16.Parse(sQLiteDataReader["counter"].ToString());
            }


            SQLiteConnection.Close();

            return minCounter;
        }


        int GetMaxCount()
        {
            string maxCountQuery = "select MAX(id) as counter from customer";

            int maxCounter = -1;

            SQLiteCommand = new SQLiteCommand(maxCountQuery, SQLiteConnection);

            SQLiteConnection.Open();

            SQLiteDataReader sQLiteDataReader = SQLiteCommand.ExecuteReader();

            while (sQLiteDataReader.Read())
            {

                maxCounter = Int16.Parse(sQLiteDataReader["counter"].ToString());
            }


            SQLiteConnection.Close();

            return maxCounter;
        }


        int GetPreviousRow(int id)
        {

            int result = id;

            id--;
            string counterQuery = "Select * from customer where id=" + id;

            SQLiteCommand = new SQLiteCommand(counterQuery, SQLiteConnection);

            SQLiteConnection.Open();

            SQLiteDataReader sQLiteDataReader = SQLiteCommand.ExecuteReader();



            while (sQLiteDataReader.Read())
            {

                txtCustId.Text = sQLiteDataReader["id"].ToString();

                txtFN.Text = sQLiteDataReader["name"].ToString();

                txtLN.Text = sQLiteDataReader["lastname"].ToString();


                txtStreet.Text = sQLiteDataReader["street"].ToString();


                txtCity.Text = sQLiteDataReader["city"].ToString();


                txtZipCode.Text = sQLiteDataReader["zipcode"].ToString();

                txtPhone.Text = sQLiteDataReader["phone"].ToString();

                rtxtNotes.Text = sQLiteDataReader["Notes"].ToString();


                var photoValue = sQLiteDataReader["photo"].ToString();

                if (!string.IsNullOrEmpty(photoValue))
                {

                    Image loadBitmap = Image.FromFile(photoValue);

                    pictureBox1.Image = loadBitmap;
                }



                cbProf.Text = sQLiteDataReader["profession"].ToString();

                cbBT.Text = sQLiteDataReader["businessType"].ToString();

                var statusValue = sQLiteDataReader["isActive"].ToString();

                var genderValue = sQLiteDataReader["gender"].ToString();

                if (genderValue == "F")
                {
                    rbFemale.Checked = true;
                }
                else
                {
                    rbMale.Checked = true;

                }


                result = int.Parse(txtCustId.Text);





            }

            SQLiteConnection.Close();

            return result;




        }

        int GetNextRow(int id)
        {

            int result = id;

            id++;
            string counterQuery = "Select * from customer where id=" + id;

            SQLiteCommand = new SQLiteCommand(counterQuery, SQLiteConnection);

            SQLiteConnection.Open();

            SQLiteDataReader sQLiteDataReader = SQLiteCommand.ExecuteReader();



            while (sQLiteDataReader.Read())
            {

                txtCustId.Text = sQLiteDataReader["id"].ToString();

                txtFN.Text = sQLiteDataReader["name"].ToString();

                txtLN.Text = sQLiteDataReader["lastname"].ToString();


                txtStreet.Text = sQLiteDataReader["street"].ToString();


                txtCity.Text = sQLiteDataReader["city"].ToString();


                txtZipCode.Text = sQLiteDataReader["zipcode"].ToString();

                txtPhone.Text = sQLiteDataReader["phone"].ToString();

                rtxtNotes.Text = sQLiteDataReader["Notes"].ToString();


                var photoValue = sQLiteDataReader["photo"].ToString();

                if (!string.IsNullOrEmpty(photoValue))
                {

                    Image loadBitmap = Image.FromFile(photoValue);

                    pictureBox1.Image = loadBitmap;
                }



                cbProf.Text = sQLiteDataReader["profession"].ToString();

                cbBT.Text = sQLiteDataReader["businessType"].ToString();

                var statusValue = sQLiteDataReader["isActive"].ToString();

                var genderValue = sQLiteDataReader["gender"].ToString();

                if (genderValue == "F")
                {
                    rbFemale.Checked = true;
                }
                else
                {
                    rbMale.Checked = true;

                }


                result = int.Parse(txtCustId.Text);





            }

            SQLiteConnection.Close();

            return result;




        }


        void CreateCustomer()
        {
            Client = new Client();

            //Client.Id = int.Parse(this.txtCustId.Text);

            Client.Name = txtFN.Text;

            Client.LastName = txtLN.Text;

            Client.Street = txtStreet.Text;


            Client.State = cbState.Text;

            Client.City = txtCity.Text;

            Client.Phone = txtPhone.Text;

            Client.DateOfBirth = dateTimePicker1.Value;

            Client.IsActive = isActive.Checked;

            Client.Email = txtEmail.Text;

            Client.ZipCode = txtZipCode.Text;


            Client.Notes = rtxtNotes.Text;

            Client.Photo = imagePhotoValue;

            Client.BusinessType = cbBT.Text;

            Client.Profession = cbProf.Text;
        }
        void ClearAll()
        {
            txtCity.Text = string.Empty;

            txtCustId.Text = string.Empty;

            txtEmail.Text = string.Empty;

            txtFN.Text = string.Empty;

            txtLN.Text = string.Empty;

            txtPhone.Text = string.Empty;

            txtStreet.Text = string.Empty;

            txtZipCode.Text = string.Empty;

            cbState.Text = string.Empty;

            cbProf.Text = string.Empty;

            cbBT.Text = string.Empty;

            rtxtNotes.Text = string.Empty;

            imagePhotoValue = string.Empty;

            pictureBox1.Image = null;
        }
        void InsertUpdateCustomer()
        {

            try
            {

                CreateCustomer();

                //string sqlUpdateCustomer = "Insert  into customer (id,name,lastname,street,city,state,zipcode,phone,isActive,gender,dob,email,profession,businesstype,photo,notes) values('" + Client.Id + "', '" + Client.Name + "', '" + Client.LastName + "' ,  '" + Client.Street + "', '" + Client.City + "',  '" + Client.State + "', '" + Client.ZipCode + "', '" + Client.Phone + "', '" + Client.IsActive + "', '" + Client.Gender + "', '" + Client.DateOfBirth.ToString() + "' , '" + Client.Email + "', '" + Client.Profession + "', '" + Client.BusinessType + "', '" + Client.Photo + "', '" + Client.Notes + "' )";



                string sqlUpdateCustomer = "Insert into customer (name,lastname,street,city,state,zipcode,phone,isActive,gender,dob,email,profession,businesstype,photo,notes) values(@name,@lastname,@street,@city,@state,@zipcode,@phone,@isActive,@gender,@dob,@email,@profession,@bt,@photo,@notes)";



                SQLiteConnection.Open();

                SQLiteCommand = new SQLiteCommand(sqlUpdateCustomer, SQLiteConnection);


                //SQLiteCommand.Parameters.AddWithValue("@id", Client.Id);
                SQLiteCommand.Parameters.AddWithValue("@name", Client.Name);
                SQLiteCommand.Parameters.AddWithValue("@lastname", Client.LastName);
                SQLiteCommand.Parameters.AddWithValue("@street", Client.Street);
                SQLiteCommand.Parameters.AddWithValue("@city", Client.City);
                SQLiteCommand.Parameters.AddWithValue("@state", Client.State);
                SQLiteCommand.Parameters.AddWithValue("@zipcode", Client.ZipCode);
                SQLiteCommand.Parameters.AddWithValue("@phone", Client.Phone);
                SQLiteCommand.Parameters.AddWithValue("@isActive", Client.IsActive);
                SQLiteCommand.Parameters.AddWithValue("@gender", Client.Gender);
                SQLiteCommand.Parameters.AddWithValue("@dob", Client.DateOfBirth.ToString());
                SQLiteCommand.Parameters.AddWithValue("@email", Client.Email);
                SQLiteCommand.Parameters.AddWithValue("@profession", Client.Profession);
                SQLiteCommand.Parameters.AddWithValue("@bt", Client.BusinessType);
                SQLiteCommand.Parameters.AddWithValue("@photo", Client.Photo);
                SQLiteCommand.Parameters.AddWithValue("@notes", Client.Notes);

                SQLiteCommand.Prepare();

                SQLiteCommand.ExecuteNonQuery();


                SQLiteConnection.Close();

                MessageBox.Show("Customer Save Successfully.");

            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }







        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button8_Click(object sender, EventArgs e)
        {

            ClearAll();


        }

        private void button6_Click(object sender, EventArgs e)
        {

            try
            {
                DialogResult dialog = MessageBox.Show("Do you want to delete the customer record?", "Delete Customer", MessageBoxButtons.YesNo);


                if (dialog == DialogResult.Yes)
                {

                    if (!string.IsNullOrEmpty(txtCustId.Text))
                    {


                        string deletequery = "Delete from customer where id=" + int.Parse(txtCustId.Text);


                        SQLiteCommand = new SQLiteCommand(deletequery, SQLiteConnection);

                        SQLiteConnection.Open();

                        SQLiteCommand.ExecuteNonQuery();


                        SQLiteConnection.Close();

                        ClearAll();

                        MessageBox.Show("Delete successfully");

                    }

                }
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }



        }

        private void button4_Click(object sender, EventArgs e)
        {

            int oldValue = int.Parse(txtCustId.Text);

            int tempValue = oldValue;


            while (GetNextRow(oldValue) == tempValue)
            {

                if (oldValue == GetMaxCount())
                {
                    break;
                }

                GetNextRow(oldValue);

            }





        }



        private void button10_Click(object sender, EventArgs e)
        {

            ClearAll();


            SQLiteConnection.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {

                SQLiteConnection.Open();

                string sqlCreateTable = "Create table if not exists Customer(id integer primary key AUTOINCREMENT, name varchar(20) not null, lastname varchar(20) not null, street varchar(30),city varchar(30),state varchar(3), zipCode varchar(10), phone varchar(15),isActive boolean,gender varchar(2),dob varchar(25),email varchar(30), profession varchar(30),businessType varchar(30),photo varchar(30),notes varchar(200))";

                SQLiteCommand sQLiteCommand = new SQLiteCommand(sqlCreateTable, SQLiteConnection);

                sQLiteCommand.ExecuteNonQuery();


                SQLiteConnection.Close();

                foundCustomerRecord = FindCustomer(1);

                if (!foundCustomerRecord)
                {
                    MessageBox.Show("Customer Table is Empty.Enter data to continue.");

                    return;
                }




            }
            catch (Exception exception)
            {
                SQLiteConnection.Close();

                MessageBox.Show(exception.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            InsertUpdateCustomer();
        }

        private void button5_Click(object sender, EventArgs e)
        {


            int oldValue = int.Parse(txtCustId.Text);

            int tempValue = oldValue;


            while (GetPreviousRow(oldValue) == tempValue)
            {

                if (oldValue == GetMinCount())
                {
                    break;
                }

                GetPreviousRow(oldValue);

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string message = "Please Enter a Customer ID:";
            string title = "Find Customer";

            string defaultValue = "1";


            string idValue = Microsoft.VisualBasic.Interaction.InputBox(message, title, defaultValue, 525, 250);

            int idToFind = int.Parse(txtCustId.Text);

            if (int.TryParse(idValue, out idToFind))
            {



                foundCustomerRecord = FindCustomer(idToFind);

                if (!foundCustomerRecord)
                {
                    MessageBox.Show("Customer not found.");

                    return;
                }



            }


        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            var genderRadioButton = sender as RadioButton;

            if (genderRadioButton.Text == "Male")
            {
                Client.Gender = 'M';
            }
            else
            {
                Client.Gender = 'F';
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            var genderRadioButton = sender as RadioButton;

            if (genderRadioButton.Text == "Male")
            {
                Client.Gender = 'M';
            }
            else
            {
                Client.Gender = 'F';
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "All Files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;

            openFileDialog.ShowDialog();

            try
            {
                imagePhotoValue = openFileDialog.FileName.ToString();

                Image loadBitmap = Image.FromFile(imagePhotoValue);

                pictureBox1.Image = loadBitmap;


            }
            catch (Exception exception)
            {

                Console.WriteLine("Error" + exception.Message);




            }
        }
    }
}
