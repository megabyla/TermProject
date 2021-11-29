using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FurnitureStore.Library
{
    public class User
    {
        private int userId;
        private string userName;
        private string userPassword;
        private string userType;
        private string email;
        private int phonenumber;
        private string securityQ1;
        private string securityQ2;
        private string securityQ3;
        private string verfiedU;

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string UserPassword
        {
            get { return userPassword; }
            set { userPassword = value; }
        }

        public string UserType
        {
            get { return userType; }
            set { userType = value; }

        }

        public int PhoneNumber
        {
            get { return phonenumber; }
            set { phonenumber = value; }

        }

        public string Email
        {
            get { return email; }
            set { email = value; }

        }
        public string SecurityQ1
        {

            get { return securityQ1; }
            set { securityQ1 = value; }
        }

        public string SecurityQ2
        {

            get { return securityQ2; }
            set { securityQ2 = value; }
        }

        public string SecurityQ3
        {

            get { return securityQ3; }
            set { securityQ3 = value; }
        }
        public string VerfiedU
        {

            get { return verfiedU; }
            set { verfiedU = value; }
        }
    }
}
