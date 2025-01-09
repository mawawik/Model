using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class SubMuscleTypeDb : BaseDb
    {

        static private SubMuscleTypeList list = new SubMuscleTypeList();
        protected override Base NewEntity()
        {
            return new SubMuscleType();
        }
        public static SubMuscleType SelectById(int id)
        {
            SubMuscleTypeDb db = new SubMuscleTypeDb();
            list = db.SelectAll();

            SubMuscleType s = list.Find(item => item.Id == id);
            return s;
        }
        protected override Base CreateModel(Base entity)
        {
            SubMuscleType s = entity as SubMuscleType;
            s.MuscleId = MuscleTypeDb.SelectById(int.Parse(reader["MuscleId"].ToString()));
            s.SubMuscleTypeName = reader["SubMuscleType"].ToString();
            return base.CreateModel(entity);
        }
        public SubMuscleTypeList SelectAll()
        {
            command.CommandText = $"SELECT * FROM SubMuscleType";
            SubMuscleTypeList sList = new SubMuscleTypeList(base.Select());
            return sList;
        }

        protected override void CreateDeletedSQL(Base entity, OleDbCommand cmd)
        {
            SubMuscleType s = entity as SubMuscleType;
            if (s != null)
            {
                string sqlStr = $"DELETE FROM SubMuscleType where id=@pid";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@pid", s.Id));
            }
        }
        protected override void CreateInsertSQL(Base entity, OleDbCommand cmd)
        {
            SubMuscleType s = entity as SubMuscleType;
            if (s != null)
            {
                string sqlStr = $"Insert INTO SubMuscleType (MuscleId, SubMuscleType )" + "VALUES (@MuscleId, @SubMuscleType )";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@MuscleId", s.MuscleId.Id));
                command.Parameters.Add(new OleDbParameter("@SubMuscleType", s.SubMuscleTypeName));
            }
        }

        protected override void CreateUpdateSQL(Base entity, OleDbCommand cmd)
        {
            SubMuscleType s = entity as SubMuscleType;
            if (s != null)
            {
                string sqlStr = $"UPDATE SubMuscleType " +
                                $"VALUES (@MuscleId, @SubMuscleTypeName) " +
                                $"Set MuscleId=@MuscleId, SubMuscleType=@SubMuscleTypeName " +
                                $"WHERE id=@Id";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@MuscleId", s.MuscleId.Id));
                command.Parameters.Add(new OleDbParameter("@SubMuscleType", s.SubMuscleTypeName));
            }
        }
    }
}
