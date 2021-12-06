using FurnitureStore.Library;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace FurnitureStore.FurnitureStoreWeb
{
    


    public partial class AdminHomepage : System.Web.UI.Page
    {
SOAPWebServices.FurnitureSOAP proxy = new  SOAPWebServices.FurnitureSOAP();
        string userName;
        ArrayList furnitureList = new ArrayList();
        ArrayList furnitureidList = new ArrayList();
        protected void Page_Load(object sender, EventArgs e)
        {
            //getting user info from session cookie to populate 
             userName = Session["username"].ToString();
             showFurniture();
        }



        protected void btnAdd_Click2(object sender, EventArgs e)
        {
            Response.Redirect("AddFurniture.aspx");
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            deleteDiv.Visible = true;
            displayDiv.Visible = true;
            modifiyDiv.Visible = false;
            requestDiv.Visible = false;
            acceptDiv.Visible = false;
        }

        protected void btnResvRequest_Click(object sender, EventArgs e)


        {
            displayDiv.Visible = false;
            deleteDiv.Visible = false;
            requestDiv.Visible = true;

            int userId = Convert.ToInt32(Session["userID"].ToString());
            DBConnect objDB = new DBConnect();
            SqlCommand cmdShowRequests = new SqlCommand();
            cmdShowRequests.CommandType = CommandType.StoredProcedure;
            cmdShowRequests.CommandText = "TP_GetAllReservations";

            SqlParameter adminID = new SqlParameter("@userId", userId);
            adminID.Direction = ParameterDirection.Input;
            cmdShowRequests.Parameters.Add(adminID);

            DataSet ds = objDB.GetDataSetUsingCmdObj(cmdShowRequests);
            int size = ds.Tables[0].Rows.Count;
            if (size > 0)
            {

                gvResvRequests.DataSource = ds;
                gvResvRequests.DataBind();
                gvResvRequests.Visible = true;
                lblMessageDisplay.Visible = false;
                //ViewDiv.Visible = false;
                displayDiv.Visible = false;
            }
            else
            {
                lblrequestMessage.Visible = true;
                lblrequestMessage.Text = "You do not have any furniture.";
            }

        }

        public void showFurniture()
        {
            int userId = Convert.ToInt32(Session["userID"].ToString());
            DBConnect objDB = new DBConnect();
            SqlCommand cmdShowFurniture = new SqlCommand();
            cmdShowFurniture.CommandType = CommandType.StoredProcedure;
            cmdShowFurniture.CommandText = "TP_GetMyFurniture";

            SqlParameter inputId = new SqlParameter("@userID", userId);
            inputId.Direction = ParameterDirection.Input;
            cmdShowFurniture.Parameters.Add(inputId);

            DataSet ds = objDB.GetDataSetUsingCmdObj(cmdShowFurniture);
            int size = ds.Tables[0].Rows.Count;
            if (size > 0)
            {
                for (int i = 0; i < size; i++)
                {

                    Furniture newFurniture = new Furniture();
                    newFurniture.furnitureID = Int32.Parse(ds.Tables[0].Rows[i]["furnitureID"].ToString());
                    newFurniture.furnitureName = ds.Tables[0].Rows[i]["furnitureName"].ToString();
                    newFurniture.furnitureType = ds.Tables[0].Rows[i]["furnitureType"].ToString();
                    newFurniture.furniturePrice = float.Parse(ds.Tables[0].Rows[i]["furniturePrice"].ToString());
                    newFurniture.furniturePieces = ds.Tables[0].Rows[i]["furniturePieces"].ToString();
                    newFurniture.furnitureDescription = (ds.Tables[0].Rows[i]["furnitureDescription"].ToString());

                    string furnitureName = newFurniture.furnitureName;
                    string furnitureType = newFurniture.furnitureType;
                    float furniturePrice = newFurniture.furniturePrice;
                    string furniturePieces = newFurniture.furniturePieces;
                    string furnitureDescription = newFurniture.furnitureDescription;
                    int furnitureID = newFurniture.furnitureID;
                    furnitureList.Add(newFurniture);
                    furnitureidList.Add(furnitureID);

                }

                gvAllFurniture.DataSource = furnitureList;
                gvAllFurniture.DataBind();
                gvAllFurniture.Visible = true;
                lblMessageDisplay.Visible = false;
            }
            else
            {
                lblMessageDisplay.Visible = true;
                lblMessageDisplay.Text = "You do not have any furniture.";
            }
        }
        protected void gvAllFurniture_SelectedIndexChanged(object sender, EventArgs e)
        {
            int furnitureID = Int32.Parse(gvAllFurniture.SelectedRow.Cells[0].Text);
            string furnitureName = gvAllFurniture.SelectedRow.Cells[1].Text;
            string furnitureType = gvAllFurniture.SelectedRow.Cells[2].Text;
            int furniturePrice = (int)float.Parse(gvAllFurniture.SelectedRow.Cells[3].Text);
            string furniturePieces = gvAllFurniture.SelectedRow.Cells[4].Text;
            string furnitureDescription = gvAllFurniture.SelectedRow.Cells[5].Text;


            displayDiv.Visible = false;
            modifiyDiv.Visible = true;
            txtName.Text = furnitureName;
            txtType.Text = furnitureType;
            txtPrice.Text = furniturePrice.ToString();
            txtPieces.Text = furniturePieces;
            txtDesc.Text = furnitureDescription;
            txtfurnitureidDisplay.Text = "" + furnitureID;

            DBConnect objDB = new DBConnect();
            SqlCommand cmdGetImage = new SqlCommand();
            cmdGetImage.CommandType = CommandType.StoredProcedure;
            cmdGetImage.CommandText = "TP_GetImageById";

            SqlParameter inputId = new SqlParameter("@furnitureID", furnitureID);
            inputId.Direction = ParameterDirection.Input;
            cmdGetImage.Parameters.Add(inputId);

            DataSet ds = objDB.GetDataSetUsingCmdObj(cmdGetImage);
            int size = ds.Tables[0].Rows.Count;

            byte[] bytes = (byte[])ds.Tables[0].Rows[0]["ImageData"];

            string strBase64 = Convert.ToBase64String(bytes);

            furnitureImage.ImageUrl = "data:Image/png;base64," + strBase64;

        }

        protected void btnDeleteFurniture_Click(object sender, EventArgs e)
        {
            int delFurnitureId = Int32.Parse(txtFurnitureID.Text);
            string foundId = "";
            for (int i = 0; i < furnitureidList.Count; i++)
            {
                if (delFurnitureId == Int32.Parse(furnitureidList[i].ToString()))
                {
                    foundId += "Found furniture with furnitureId " + delFurnitureId;

                    SOAPWebServices.Furniture proxy = new SOAPWebServices.Furniture();
                    deleteFurniture(delFurnitureId);
                    deleteFurnitureImage(delFurnitureId);
                    lblDeleteMessage.Visible = true;
                    lblDeleteMessage.Text = "Furniture Deleted. Please refresh page to see changes.";
                }
            }
            if (foundId == "")
            {
                lblDeleteMessage.Visible = true;
                lblDeleteMessage.Text = "The furniture ID you entered in not part of your furniture. Enter a valid ID";
            }
        }

        public void uploadFurnitureImg(int furnitureID)
        {
            //https://docs.microsoft.com/en-us/dotnet/api/system.web.httppostedfile.inputstream?view=netframework-4.8
            DBConnect objDB = new DBConnect();

            SqlCommand objCommand = new SqlCommand();

            int result = 0, fileSize;
            string fileExtention, fileName;

            try
            {
                if (imgUpload.HasFile)
                {
                    //get posted file, file name, exention, and size
                    HttpPostedFile postedFile = imgUpload.PostedFile;
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
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.CommandText = "TP_ReplaceImage";

                        SqlParameter imgData = new SqlParameter("@imageData", bytes);
                        imgData.Direction = ParameterDirection.Input;
                        objCommand.Parameters.Add(imgData);

                        SqlParameter paramPetId = new SqlParameter("@furnitureID", furnitureID);
                        paramPetId.Direction = ParameterDirection.Input;
                        objCommand.Parameters.Add(paramPetId);

                        result = objDB.DoUpdateUsingCmdObj(objCommand);

                        lblModifyMessage.Visible = true;
                        lblModifyMessage.Text = "upload successful";

                    }
                    else
                    {
                        lblModifyMessage.Visible = true;
                        lblModifyMessage.Text = "Only images (.jpg, .jpeg, .gif and .bmp) can be uploaded";

                    }
                }
            }
            catch (Exception ex)
            {
                lblModifyMessage.Text = "Error: " + ex.Message + result;
            }
        }
        protected void btnModify_Click(object sender, EventArgs e)
        {
            int furnitureID = Int32.Parse(txtfurnitureidDisplay.Text);
            string furnitureName = txtName.Text;
            string furnitureType = txtType.Text;
            int furniturePrice = (int)float.Parse(txtPrice.Text);
            int furniturePieces = Int32.Parse(txtPieces.Text);  
            string furnitureDescription = txtDesc.Text; 

            //uploads new image
            uploadFurnitureImg(furnitureID);

           
     
            ModifyFurniture(furnitureID, furnitureName, furnitureType, furniturePrice, furniturePieces, furnitureDescription);
            modifiyDiv.Visible = false;
            displayDiv.Visible = true;
            

            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            displayDiv.Visible = true;
            modifiyDiv.Visible = false;
        }

        protected void gvResvRequests_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ResvId = Int32.Parse(gvResvRequests.SelectedRow.Cells[0].Text);
            int furnitureID = Int32.Parse(gvResvRequests.SelectedRow.Cells[1].Text);
            string ResvDate = gvResvRequests.SelectedRow.Cells[2].Text;
            string ResvTime = gvResvRequests.SelectedRow.Cells[3].Text;


            displayDiv.Visible = false;
            modifiyDiv.Visible = false;
            requestDiv.Visible = false;
            acceptDiv.Visible = true;

            txtResvId.Text = ResvId.ToString();
            txtresvfurnitureId.Text = furnitureID.ToString();
            txtdate.Text = ResvDate;
            txttime.Text = ResvTime;
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            int requestId = Int32.Parse(txtResvId.Text);
            DBConnect objDB = new DBConnect();
            SqlCommand cmdApprove = new SqlCommand();
            cmdApprove.Parameters.Clear();

            cmdApprove.CommandType = CommandType.StoredProcedure;
            cmdApprove.CommandText = "TP_AcceptRequest";

            SqlParameter reqID = new SqlParameter("@reservationId", requestId);
            reqID.Direction = ParameterDirection.Input;
            cmdApprove.Parameters.Add(reqID);

            objDB.DoUpdateUsingCmdObj(cmdApprove);

            acceptDiv.Visible = false;
            requestDiv.Visible = true;

            lblrequestMessage.Text = "You approved the users reservation!";
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            int requestId = Int32.Parse(txtResvId.Text);
            DBConnect objDB = new DBConnect();
            SqlCommand cmdDelete = new SqlCommand();
            cmdDelete.Parameters.Clear();

            cmdDelete.CommandType = CommandType.StoredProcedure;
            cmdDelete.CommandText = "TP_DeleteReservation";

            SqlParameter reqID = new SqlParameter("@reservationID", requestId);
            reqID.Direction = ParameterDirection.Input;
            cmdDelete.Parameters.Add(reqID);

            objDB.DoUpdateUsingCmdObj(cmdDelete);

            acceptDiv.Visible = false;
            requestDiv.Visible = true;

            lblrequestMessage.Text = "You rejected the users reservation! It will no longer be listed here after you refresh.";
        }

        public void deleteFurniture(int furnitureID)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand cmdDeleteFurniture = new SqlCommand();
            cmdDeleteFurniture.Parameters.Clear();

            cmdDeleteFurniture.CommandType = CommandType.StoredProcedure;
            cmdDeleteFurniture.CommandText = "TP_DeleteFurniture";

            cmdDeleteFurniture.Parameters.AddWithValue("@furnitureID", furnitureID);

            int result = objDB.DoUpdateUsingCmdObj(cmdDeleteFurniture);
        }

        public void deleteFurnitureImage(int furnitureID)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand cmdDeleteFurnitureImage = new SqlCommand();
            cmdDeleteFurnitureImage.Parameters.Clear();

            cmdDeleteFurnitureImage.CommandType = CommandType.StoredProcedure;
            cmdDeleteFurnitureImage.CommandText = "TP_DeleteFurnitureImage";

            cmdDeleteFurnitureImage.Parameters.AddWithValue("@furnitureID", furnitureID);

            int result = objDB.DoUpdateUsingCmdObj(cmdDeleteFurnitureImage);
        }
        public DataSet ModifyFurniture(int id, string name, string type, int price, int pieces, string desc)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            DataSet dsFurniture;

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_ModifyFurniture";

            SqlParameter inputParameter = new SqlParameter("@furnitureID", id);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 50;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@furnitureName", name);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 50;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@furnitureType", type);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 50;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@furniturePrice", price);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 50;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@furniturePieces", pieces);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 50;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@furnitureDescription", desc);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 50;
            objCommand.Parameters.Add(inputParameter);

            dsFurniture = objDB.GetDataSetUsingCmdObj(objCommand);
            return dsFurniture;
        }
    }
}