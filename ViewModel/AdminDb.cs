using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class AdminDb : UserDb
    {
        static private AdminList list = new AdminList();
        protected override Base NewEntity()
        {
            return new Admin();
        }
        protected override Base CreateModel(Base entity)
        {
            Admin a = entity as Admin;
            return base.CreateModel(entity);
        }
        public AdminList SelectAll()
        {
            command.CommandText = $"SELECT admin.id, [User].[password], [User].UserName, [User].mail, [User].birthDate, [User].gender "
                                + $" FROM (admin INNER JOIN [User] ON admin.id = [User].id)";
            AdminList aList = new AdminList(base.Select());
            return aList;
        }
        public static Admin SelectById(int id)
        {
            AdminDb a = new AdminDb();
            list = a.SelectAll();

            Admin A = list.Find(x => x.Id == id);
            return A;
        }
        protected override void CreateDeletedSQL(Base entity, OleDbCommand cmd)
        {
            Admin a = entity as Admin;
            if (a != null)
            {
                string sqlStr = $"DELETE FROM [admin] " + " Where [id] = @Id ";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@Id", a.Id));
            }
        }

        public override void Delete(Base entity)
        {
            Base reqEntity = this.NewEntity();
            if (entity != null & entity.GetType() == reqEntity.GetType())
            {
                deleted.Add(new ChangeEntity(this.CreateDeletedSQL, entity));
                deleted.Add(new ChangeEntity(base.CreateDeletedSQL, entity));
            }
        }
        protected override void CreateInsertSQL(Base entity, OleDbCommand cmd)
        {
            Admin a = entity as Admin;
            if (a != null)
            {
                string sqlStr = $"INSERT INTO [admin] (Id) " + " VALUES (@Id)";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@Id", a.Id));
            }
        }
        public override void Insert(Base entity)
        {
            Base reqEntity = this.NewEntity();
            if (entity != null & entity.GetType() == reqEntity.GetType())
            {
                inserted.Add(new ChangeEntity(base.CreateInsertSQL, entity));
                inserted.Add(new ChangeEntity(this.CreateInsertSQL, entity));
            }
        }
        protected override void CreateUpdateSQL(Base entity, OleDbCommand cmd)
        {
            Admin a = entity as Admin;
            if (a != null)
            {
                string sqlStr = $"UPDATE [admin] "+
                                $"Set id=@Id "+
                                $"WHERE id=@Id";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@Id", a.Id));
            }
        }
        public override void Update(Base entity)
        {
            Base reqEntity = this.NewEntity();
            if (entity != null & entity.GetType() == reqEntity.GetType())
            {
                updated.Add(new ChangeEntity(base.CreateUpdateSQL, entity));
                updated.Add(new ChangeEntity(this.CreateUpdateSQL, entity));
            }
        }
    }

}
