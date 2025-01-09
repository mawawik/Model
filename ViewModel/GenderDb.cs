using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class GenderDb : BaseDb
    {
        static private GenderList list = new GenderList();
        protected override Base NewEntity()
        { 
            return new Gender();
        }
        protected override Base CreateModel(Base entity)
        { 
            Gender g = entity as Gender;
            g.GenderName = reader["genderName"].ToString();
            return base.CreateModel(entity);
        }
        public GenderList SelectAll()
        {
            command.CommandText = $"SELECT * FROM genderTbl";
            GenderList gList = new GenderList(base.Select());
            return gList;
        }

        public static Gender SelectById(int id)
        {
            GenderDb g = new GenderDb();
            list = g.SelectAll();

            Gender G = list.Find(x => x.Id == id);
            return G;
        }

        protected override void CreateDeletedSQL(Base entity, OleDbCommand cmd)
        {
            Gender g = entity as Gender;
            if (g != null)
            {
                string sqlStr = $"DELETE FROM genderTbl where id=@pid";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@pid", g.Id));
            }
        }
        protected override void CreateInsertSQL(Base entity, OleDbCommand cmd)
        {
            Gender g = entity as Gender;
            if (g != null)
            {
                string sqlStr = $"Insert into genderTbl values (@genderName )";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@genderName", g.GenderName));
            }
        }

        protected override void CreateUpdateSQL(Base entity, OleDbCommand cmd)
        {
            Gender g = entity as Gender;
            if (g != null)
            {
                string sqlStr = $"UPDATE genderTbl " +
                                $"VALUES (@GenderName) " +
                                $"Set genderName=@GenderName " +
                                $"WHERE id=@Id";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@genderName", g.GenderName));
            }
        }
    }
}
