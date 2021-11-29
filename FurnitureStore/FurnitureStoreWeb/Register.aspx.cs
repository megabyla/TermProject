using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using FurnitureStoreLibrary;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace FurnitureStore.FurnitureStoreWeb
{
    public partial class Register : System.Web.UI.Page
    {

        Library.User newUser = new Library.User();
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        private Byte[] key = { 250, 101, 18, 76, 45, 135, 207, 118, 4, 171, 3, 168, 202, 241, 37, 199 };
        private Byte[] vector = { 146, 64, 191, 111, 23, 3, 113, 119, 231, 121, 252, 112, 79, 32, 114, 156 };

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {

            Response.Redirect("Login.aspx");
        }

        protected void btnSubmit_Click1(object sender, EventArgs e)
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetUser";
            objCommand.Parameters.AddWithValue("@username", txtUsername.Text);
            objCommand.Parameters.AddWithValue("@email", txtEmail.Text);

            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);

            int size = ds.Tables[0].Rows.Count;
            //password encryption
            if (size == 0)
            {
                String plainTextPassword = txtPassword.Text;
                String encryptedPassword;

                UTF8Encoding encoder = new UTF8Encoding();      // used to convert bytes to characters, and back
                Byte[] textBytes;                               // stores the plain text data as bytes

                // Perform Encryption
                // Convert a string to a byte array, which will be used in the encryption process.
                textBytes = encoder.GetBytes(plainTextPassword);

                RijndaelManaged rmEncryption = new RijndaelManaged();
                MemoryStream myMemoryStream = new MemoryStream();
                CryptoStream myEncryptionStream = new CryptoStream(myMemoryStream, rmEncryption.CreateEncryptor(key, vector), CryptoStreamMode.Write);

                // Use the crypto stream to perform the encryption on the plain text byte array.
                myEncryptionStream.Write(textBytes, 0, textBytes.Length);
                myEncryptionStream.FlushFinalBlock();

                // Retrieve the encrypted data from the memory stream, and write it to a separate byte array.
                myMemoryStream.Position = 0;
                Byte[] encryptedBytes = new Byte[myMemoryStream.Length];
                myMemoryStream.Read(encryptedBytes, 0, encryptedBytes.Length);

                // Close all the streams.
                myEncryptionStream.Close();
                myMemoryStream.Close();

                // Convert the bytes to a string and display it.
                encryptedPassword = Convert.ToBase64String(encryptedBytes);

                if (txtUsername.Text == "" || txtPassword.Text == "" || txtEmail.Text == "" || txtPhoneNumber.Text == "" || txtSq1.Text == ""
                    || txtSq2.Text == "" || txtSq3.Text == "")
                {
                    lblDisplay.Text = "Must complete all fields!";
                }
                else
                {
                    try
                    {
                        objCommand.Parameters.Clear();
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.CommandText = "TP_AddUser";


                        objCommand.Parameters.AddWithValue("@username", txtUsername.Text);
                        objCommand.Parameters.AddWithValue("@email", txtEmail.Text);
                        objCommand.Parameters.AddWithValue("@password", encryptedPassword);
                        objCommand.Parameters.AddWithValue("@phonenumber", txtPhoneNumber.Text);
                        objCommand.Parameters.AddWithValue("@accountType", RadioBtnUserType.SelectedItem.Value);
                        objCommand.Parameters.AddWithValue("@securityQ1", txtSq1.Text);
                        objCommand.Parameters.AddWithValue("@securityQ2", txtSq2.Text);
                        objCommand.Parameters.AddWithValue("@securityQ3", txtSq3.Text);

                        int result = objDB.DoUpdateUsingCmdObj(objCommand);

                        if (result == -1)
                        {
                            lblError.Text = "An error occured. Please try again!";
                            lblError.Visible = false;
                        }
                        else
                        {
                            lblSuccess.Text = "User created successfully!";
                            if (lblError.Visible == true)
                            {
                                lblError.Visible = false;
                            }
                            lblSuccess.Visible = true;
                            btnSubmit.Visible = false;
                        }

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    //Response.Redirect("Home.aspx");

                }
            }
            else
            {
                lblError.Text = "The username or email is already taken";
                lblError.Visible = true;
            }
        }

    }
}

//"First Name cannot be left empty or contain numbers/special characters!"
//"Last Name cannot be left empty or contain numbers/special characters!"
//"Phone Number cannot be left empty or contain letters/special characters!"