using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class MuscleTypeDb : BaseDb
    {
        protected override Base NewEntity()
        {
            return new MuscleType();
        }
        protected override Base CreateModel(Base entity)
        {
            MuscleType m = entity as MuscleType;
            m.MuscleTypeName = reader["MuscleName"].ToString();
            return base.CreateModel(entity);
        }
        public MuscleTypeList SelectAll()
        {
            command.CommandText = $"SELECT * FROM MuscleType";
            MuscleTypeList mList = new MuscleTypeList(base.Select());
            return mList;
        }
        static private MuscleTypeList list = new MuscleTypeList();
        public static MuscleType SelectById(int id)
        {
            MuscleTypeDb db = new MuscleTypeDb();
            list = db.SelectAll();

            MuscleType m = list.Find(item => item.Id == id);
            return m;
        }

        protected override void CreateDeletedSQL(Base entity, OleDbCommand cmd)
        {
            MuscleType m = entity as MuscleType;
            if (m != null)
            {
                string sqlStr = $"DELETE FROM MuscleType where id=@pid";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@pid", m.Id));
            }
        }
        protected override void CreateInsertSQL(Base entity, OleDbCommand cmd)
        {
            MuscleType m = entity as MuscleType;
            if (m != null)
            {
                string sqlStr = $"Insert into MuscleType (MuscleName ) values (@MuscleName )";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@MuscleName", m.MuscleTypeName));
            }
        }

        protected override void CreateUpdateSQL(Base entity, OleDbCommand cmd)
        {
            MuscleType m = entity as MuscleType;
            if (m != null)
            {
                string sqlStr = $"UPDATE MuscleType " +
                                $"VALUES (@MuscleTypeName) " +
                                $"Set MuscleName=@MuscleTypeName " +
                                $"WHERE id=@Id";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@MuscleName", m.MuscleTypeName));
            }
        }
    }
}
