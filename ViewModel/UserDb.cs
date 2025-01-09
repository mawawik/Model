using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class UserDb : BaseDb
    {
        static private UserList list = new UserList();
        protected override Base NewEntity()
        {
            return new User();
        }

        public static User SelectById(int id)
        {
            UserDb db = new UserDb();
            list = db.SelectAll();

            User u = list.Find(item => item.Id == id);
            return u;
        }

        protected override Base CreateModel(Base entity)
        {
            User u = entity as User;
            u.Password = reader["password"].ToString();
            u.UserName = reader["UserName"].ToString();
            u.Email = reader["mail"].ToString();
            u.BirthDate = (DateTime)(reader["birthDate"]);
            u.UserGender = GenderDb.SelectById(int.Parse(reader["gender"].ToString()));
            return base.CreateModel(entity);
        }
        
        public UserList SelectAll()        
        {
            command.CommandText = $"SELECT * FROM [User]";
            UserList uList = new UserList(base.Select());
            return uList;
        }

        protected override void CreateDeletedSQL(Base entity, OleDbCommand cmd)
        {
            User u = entity as User;
            if (u != null)
            {
                string sqlStr = $"DELETE FROM [User] where id=@pid";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@pid", u.Id));
            }
        }
        protected override void CreateInsertSQL(Base entity, OleDbCommand cmd)
        {
            User u = entity as User;
            if (u != null)
            {
                string sqlStr = $"INSERT INTO [User] ( [password], UserName, mail, birthDate, gender ) VALUES (@pasword, @Username, @mail, @birthDate, @gender )";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@password", u.Password));
                command.Parameters.Add(new OleDbParameter("@Username", u.UserName));
                command.Parameters.Add(new OleDbParameter("@mail", u.Email));
                command.Parameters.Add(new OleDbParameter("@birthDate", u.BirthDate));
                command.Parameters.Add(new OleDbParameter("@gender", u.UserGender.Id));
            }
        }

        protected override void CreateUpdateSQL(Base entity, OleDbCommand cmd)
        {
            User u = entity as User;
            if (u != null)
            {
                string sqlStr = $"UPDATE [User] " +
                                $"Set [password]=@Password, [Username]=@UserName, [mail]=@Email, [birthDate]=@BirthDate, [gender]=@UserGender " +
                                $"WHERE id=@Id";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@password", u.Password));
                command.Parameters.Add(new OleDbParameter("@Username", u.UserName));
                command.Parameters.Add(new OleDbParameter("@mail", u.Email));
                command.Parameters.Add(new OleDbParameter("@birthDate", u.BirthDate));
                command.Parameters.Add(new OleDbParameter("@gender", u.UserGender.Id));
                command.Parameters.Add(new OleDbParameter("@id", u.Id));
            }
        }
    }
}
