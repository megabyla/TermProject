using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace FurnitureStore.FurnitureStoreWeb
{
    public partial class Login : System.Web.UI.Page
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        private Byte[] key = { 250, 101, 18, 76, 45, 135, 207, 118, 4, 171, 3, 168, 202, 241, 37, 199 };
        private Byte[] vector = { 146, 64, 191, 111, 23, 3, 113, 119, 231, 121, 252, 112, 79, 32, 114, 156 };

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack && Request.Cookies["login_cookie"] != null)
            //{
            //    HttpCookie cookie = Request.Cookies["login_cookie"];
            //    txtUseremail.Text = cookie["username"].ToString();
            //    txtPassword.Text = cookie["password"].ToString();
            //}
        }

        protected void btnLogin_Click2(object sender, EventArgs e)
        {
            String email = txtUseremail.Text;
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

            if (email == "")
            {
                txtUseremail.Focus();
                lblMessage.Text = "Please enter your email address.";
            }
            else if (plainTextPassword == "")
            {
                txtPassword.Focus();
                lblMessage.Text = "Please enter your password.";
            }
            else
            {

                DataSet myData = getLoginData(email, encryptedPassword);
                int size = myData.Tables[0].Rows.Count;
                if (size > 0)
                {
                    string userVerificationStatus = (objDB.GetField("VerifiedU", 0).ToString());
                    if (userVerificationStatus == "no")
                    {
                        Response.Write("<script>alert('You're not verified. Please verify your login.')</script>");
                    }
                    else
                    {
                        //gets the user TYPE from the database and stores in a variable
                        string userType = objDB.GetField("accountType", 0).ToString();

                        //checks to see if the user wants their login information recorded and stores it in a cookie
                        if (ckRem.Checked == true)
                        {
                            HttpCookie userCookie = new HttpCookie("login_cookie");
                            userCookie.Values["email"] = txtUseremail.Text;
                            userCookie.Values["password"] = txtPassword.Text;
                            userCookie.Values["LastVisited"] = DateTime.Now.ToString();
                            userCookie.Expires = new DateTime(2025, 1, 1);
                            Response.Cookies.Add(userCookie);
                        }

                        //stores session data and redirects user based on their account type
                        if (userType == "User")
                        {
                            Session["userID"] = objDB.GetField("userID", 0);
                            Session["username"] = objDB.GetField("username", 0);
                            Session["phonenumber"] = objDB.GetField("phonenumber", 0);
                            Session["email"] = txtUseremail.Text;
                            Response.Redirect("Homepage.aspx");
                        }
                        else
                        {
                            Session["userID"] = objDB.GetField("userID", 0);
                            Session["username"] = objDB.GetField("username", 0);
                            Session["phonenumber"] = objDB.GetField("phonenumber", 0);
                            Session["email"] = txtUseremail.Text;
                            Response.Redirect("AdminHomepage.aspx");
                        }
                    }
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Please check your email and password and try again!";
                }


            }
        }

        public DataSet getLoginData(string user, string password)
        {
            objCommand.Parameters.Clear();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_LogIn";

            SqlParameter inputEmailAddress = new SqlParameter("@email", user);
            inputEmailAddress.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputEmailAddress);

            SqlParameter inputPassword = new SqlParameter("@password", password);
            inputPassword.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputPassword);

            DataSet mydata = objDB.GetDataSetUsingCmdObj(objCommand);
            return mydata;
        }


        protected void btnForgot_Click1(object sender, EventArgs e)
        {
            Response.Redirect("ForgotPass.aspx");
        }
    }
}