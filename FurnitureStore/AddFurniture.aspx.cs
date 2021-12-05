using SOAPWebServices;
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

    public partial class AddFurniture : System.Web.UI.Page
    {
        string username;
        int userID;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            //username = Session["username"].ToString();
            //userID = (int)Session["userID"];
        }

        protected void btnSubmit_addfurniture_Click(object sender, EventArgs e)
        {
            Furniture newFurniture = new Furniture();
            newFurniture.furnitureName = txtFurnitureName.Text;
            newFurniture.furnitureID = userID;
            newFurniture.furniturePieces = txtFurniturePieces.Text;
            newFurniture.furnitureType = txtFurnitureType.Text;
            newFurniture.furnitureDescription = txtFurnitureDesc.Text;
            newFurniture.furniturePrice = float.Parse(txtFurniturePrice.Text);

            Furniture proxy = new Furniture();
            int furnitureID = addFurniture(newFurniture);
            uploadFurnitureImage(furnitureID);
            btnSubmit_addfurniture.Visible = false;
            btnGoHome.Visible = true;
        }

        public void uploadFurnitureImage(int furnitureID)
        {
            //https://docs.microsoft.com/en-us/dotnet/api/system.web.httppostedfile.inputstream?view=netframework-4.8
            DBConnect objDB = new DBConnect();

            SqlCommand objCommand = new SqlCommand();

            int result = 0, fileSize;
            string fileExtention, fileName;

            try
            {
                if (fileFurnitureImg.HasFile)
                {
                    //get posted file, file name, exention, and size
                    HttpPostedFile postedFile = fileFurnitureImg.PostedFile;
                    fileName = Path.GetFileName(postedFile.FileName);
                    fileExtention = Path.GetExtension(fileName);
                    fileSize = postedFile.ContentLength;
                    //create a byte array
                    byte[] bytes = new byte[fileSize];
                    //read contents of the uploaded file into a byte array
                    postedFile.InputStream.Read(bytes, 0, fileSize);

                    //check file extention 
                    if (fileExtention.ToLower() == ".jpg" || fileExtention.ToLower() == ".bmp" ||
                        fileExtention.ToLower() == ".jpeg" || fileExtention.ToLower() == ".gif")
                    {
                        //Stream stream = postedFile.InputStream;
                        //BinaryReader binaryReader = new BinaryReader(stream);
                        //byte[] bytes = binaryReader.ReadBytes((int)stream.Length);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.CommandText = "TP_AddFurnitureImages";

                        SqlParameter imgName = new SqlParameter("@Name", fileName);
                        imgName.Direction = ParameterDirection.Input;
                        objCommand.Parameters.Add(imgName);

                        SqlParameter imgSize = new SqlParameter("@Size", fileSize);
                        imgSize.Direction = ParameterDirection.Input;
                        objCommand.Parameters.Add(imgSize);

                        SqlParameter imgData = new SqlParameter("@ImageData", bytes);
                        imgData.Direction = ParameterDirection.Input;
                        objCommand.Parameters.Add(imgData);

                        SqlParameter paramFurnitureId = new SqlParameter("@FurnitureID", furnitureID);
                        paramFurnitureId.Direction = ParameterDirection.Input;
                        objCommand.Parameters.Add(paramFurnitureId);

                        result = objDB.DoUpdateUsingCmdObj(objCommand);

                        lblMessage.Visible = true;
                        lblMessage.Text = "upload successful";
                        btnAddMore.Visible = true;
                    }
                    else
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "Only images (.jpg, .jpeg, .gif and .bmp) can be uploaded";
                        btnGoHome.Visible = true;
                        btnSubmit_addfurniture.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error: " + ex.Message + result;
            }
        }
        protected void btnGoHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminHomepage.aspx");
        }

        protected void btnAddMore_Click(object sender, EventArgs e)
        {
            lblMessage.Visible = false;
            btnGoHome.Visible = true;
            btnSubmit_addfurniture.Visible = true;
            btnAddMore.Visible = false;
        }

        public int addFurniture(Furniture newFurniture)
        {
            DBConnect objDB = new DBConnect();
            //SqlCommand objCommand = new SqlCommand();

            if (newFurniture != null)
            {
                SqlCommand cmdAddFurniture = new SqlCommand();
                cmdAddFurniture.Parameters.Clear();
                cmdAddFurniture.CommandType = CommandType.StoredProcedure;
                cmdAddFurniture.CommandText = "TP_AddFurniture";

                SqlParameter furnitureName = new SqlParameter("@furnitureName", newFurniture.furnitureName);
                furnitureName.Direction = ParameterDirection.Input;
                cmdAddFurniture.Parameters.Add(furnitureName);

                SqlParameter furnitureType = new SqlParameter("@furnitureType", newFurniture.furnitureType);
                furnitureType.Direction = ParameterDirection.Input;
                cmdAddFurniture.Parameters.Add(furnitureType);

                SqlParameter furniturePrice = new SqlParameter("@furniturePrice", newFurniture.furniturePrice);
                furniturePrice.Direction = ParameterDirection.Input;
                cmdAddFurniture.Parameters.Add(furniturePrice);

                SqlParameter furniturePieces = new SqlParameter("@furniturePieces", newFurniture.furniturePieces);
                furniturePieces.Direction = ParameterDirection.Input;
                cmdAddFurniture.Parameters.Add(furniturePieces);

                SqlParameter furnitureDescription = new SqlParameter("@furnitureDescription", newFurniture.furnitureDescription);
                furnitureDescription.Direction = ParameterDirection.Input;
                cmdAddFurniture.Parameters.Add(furnitureDescription);

                DataSet ds = objDB.GetDataSetUsingCmdObj(cmdAddFurniture);

                int furnitureID = Int32.Parse(ds.Tables[0].Rows[0][0].ToString());
                if (furnitureID < 0)
                {
                    return -1;
                }

                return furnitureID;
            }
            return -1;
        }
    }
}