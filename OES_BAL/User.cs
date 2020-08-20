using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OES_BAL
{
     public class User
    {
        public int ID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String UserName { get; set; }
       
        public String Gender { get; set; }
        public String Address { get; set; }
        public String Contact { get; set; }
        public DateTime CreateWhen { get; set; }
        public String CreatedBy { get; set; }
        public DateTime EditedWhen { get; set; }
        public String EditeBy { get; set; }

   
        public User()
        {
        }


        public User(int ID)
        {
            var u = Get(ID);
            this.ID = u.ID;
            this.UserName = u.UserName;
            this.Email = u.Email;
            this.Gender = u.Gender;
            this.FirstName = u.FirstName;
            this.LastName = u.LastName;
            this.CreatedBy = u.CreatedBy;
            this.CreateWhen = u.CreateWhen;
            this.EditeBy = u.EditeBy;
            this.EditedWhen = u.EditedWhen;
            this.Address = u.Address;
            this.Contact = u.Contact;
        }
        public User Get(int ID)
        {
            var context = new OES_DALDataContext();
            var rs = context.db_users.Where(x => x.user_id == ID).FirstOrDefault();

            User u = new User();

            u.ID = rs.user_id;
            u.FirstName = rs.first_name;
            u.LastName = rs.last_name;
            u.UserName = rs.user_name;
            u.Email = rs.user_email;
            u.Address = rs.user_address;
            u.Gender = rs.user_gender;
            u.Email = rs.user_email;
            u.Contact = rs.user_contact;
            u.CreatedBy = rs.created_by;
            u.CreateWhen = (DateTime)rs.created_when;

            return u;

        }


        public List<User> GetAll()
        {
            List<User> list = new List<User>();
             var context = new OES_DALDataContext();
             var users = (from u in context.db_users
                       select u);
             foreach (var user in users)
             {
                 var u = new User();
                 u.ID = user.user_id;
                 u.FirstName = user.first_name;
                 u.LastName = user.last_name;
                 u.UserName = user.user_name;
                 u.Email = user.user_email;
                 u.Address = user.user_address;
                 u.Gender = user.user_gender;
                 u.Email = user.user_email;
                 u.Contact = user.user_contact;
                 u.CreatedBy = user.created_by;
                 u.CreateWhen = (DateTime)user.created_when;

                 list.Add(u);
             }
             return list;
             
             

        }


        public void ADD()
        {
            var context = new OES_DALDataContext();
            var u = new db_user();
            u.user_id = GetNewID();
            u.user_name = UserName;
            u.user_gender = Gender;
            u.user_password = GetMD5("abc123");
            u.user_address = Address;
            u.created_when = DateTime.Now;
            u.created_by = CreatedBy;
            u.user_email = Email;
            u.user_contact = Contact;

            context.db_users.InsertOnSubmit(u);
            context.SubmitChanges();
            
             


        }

        

        public void Delete(int ID)
        {
            var context = new OES_DALDataContext();
            var u = context.db_users.Where(x => x.user_id == ID).FirstOrDefault();
            context.db_users.DeleteOnSubmit(u);
            context.SubmitChanges();

        }


        public void Update(int ID)
        {
            var context = new OES_DALDataContext();
            var u = context.db_users.Where(x => x.user_id == ID).FirstOrDefault();
            u.user_name = UserName;
            u.first_name = FirstName;
            u.last_name = LastName;
            u.user_gender = Gender;
            u.user_address = Address;
            u.created_when = DateTime.Now;
            u.created_by = CreatedBy;
            u.user_email = Email;
            u.user_contact = Contact;
            context.SubmitChanges();

        }

        private int GetNewID()
        {
            
            var context = new OES_DALDataContext();
            var id = context.db_users.Max(x => x.user_id);
            if (id!=null)
            {
                id = id + 1;
            }
            else
            {
                id = 1;
            }

            return id;


        }


        public bool Login(string username , string password)
        {
            var context = new OES_DALDataContext();
            var pass = GetMD5(password);
            var count = context.db_users.Where(x => x.user_name == username && x.user_password == pass).Count();
            if (count==1)
            {
                return true;
                    
            }
            return false;

        }

        private string GetMD5(string input)
        {
            // Step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }

    
    }
}
