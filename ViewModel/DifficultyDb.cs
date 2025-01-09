using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class DifficultyDb : BaseDb
    {
        static private DifficultyList list = new DifficultyList();
        protected override Base NewEntity()
        {
            return new Difficulty();
        }
        protected override Base CreateModel(Base entity)
        {
            Difficulty d = entity as Difficulty;
            d.DifficultyDescription = reader["difficultyDescription"].ToString();
            return base.CreateModel(entity);
        }
        public DifficultyList SelectAll()
        {
            command.CommandText = $"SELECT * FROM DifficultyTbl";
            DifficultyList dList = new DifficultyList(base.Select());
            return dList;
        }
        public static Difficulty SelectById(int id)
        {
            DifficultyDb d = new DifficultyDb();
            list = d.SelectAll();

            Difficulty D = list.Find(x => x.Id == id);
            return D;
        }

        protected override void CreateDeletedSQL(Base entity, OleDbCommand cmd)
        {
            Difficulty d = entity as Difficulty;
            if (d != null)
            {
                string sqlStr = $"DELETE FROM DifficultyTbl where id=@pid";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@pid", d.Id));
            }
        }
        protected override void CreateInsertSQL(Base entity, OleDbCommand cmd)
        {
            Difficulty d = entity as Difficulty;
            if (d != null)
            {
                string sqlStr = $"Insert INTO DifficultyTbl (difficultyDescription )" + "VALUES (@DifficultyDescription)";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@difficultyDescription", d.DifficultyDescription));
            }
        }

        protected override void CreateUpdateSQL(Base entity, OleDbCommand cmd)
        {
            Difficulty d = entity as Difficulty;
            if (d != null)
            {
                string sqlStr = $"UPDATE DifficultyTbl " +
                                $"Set difficultyDescription=@DifficultyDescription " +
                                $"WHERE id=@Id";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@difficultyDescription", d.DifficultyDescription));
            }
        }
    }
}
