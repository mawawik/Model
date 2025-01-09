using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ExerciseDb : BaseDb
    {
        static private ExerciseList list = new ExerciseList();
        protected override Base NewEntity()
        {
            return new Exercise();
        }

        public static Exercise SelectById(int id)
        {
            ExerciseDb db = new ExerciseDb();
            list = db.SelectAll();

            Exercise e = list.Find(item => item.Id == id);
            return e;
        }

        protected override Base CreateModel(Base entity)
        {
            Exercise e = entity as Exercise;
            e.Description = reader["description"].ToString();
            e.ExDifficulty = DifficultyDb.SelectById(int.Parse(reader["difficulty"].ToString()));
            e.ExMuscleType = MuscleTypeDb.SelectById(int.Parse(reader["MuscleType"].ToString()));
            e.ExSubMuscleType = SubMuscleTypeDb.SelectById(int.Parse(reader["SubMuscleType"].ToString()));
            return base.CreateModel(entity);
        }

        public ExerciseList SelectAll()
        {
            command.CommandText = $"SELECT * FROM Exercise";
            ExerciseList eList = new ExerciseList(base.Select());
            return eList;
        }

        protected override void CreateDeletedSQL(Base entity, OleDbCommand cmd)
        {
            Exercise e = entity as Exercise;
            if (e != null)
            {
                string sqlStr = $"DELETE FROM Exercise where id=@pid";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@pid", e.Id));
            }
        }
        protected override void CreateInsertSQL(Base entity, OleDbCommand cmd)
        {
            Exercise e = entity as Exercise;
            if (e != null)
            {
                string sqlStr = $"Insert INTO Exercise (description, difficulty, MuscleType, SubMuscleType) " + "VALUES (@description, @difficulty, @MuscleType, @SubMuscleType) ";
                
                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@description", e.Description));
                command.Parameters.Add(new OleDbParameter("@difficulty", e.ExDifficulty.Id));
                command.Parameters.Add(new OleDbParameter("@MuscleType", e.ExMuscleType.Id));
                command.Parameters.Add(new OleDbParameter("@SubMuscleType", e.ExSubMuscleType.Id));
            }
        }

        protected override void CreateUpdateSQL(Base entity, OleDbCommand cmd)
        {
            Exercise e = entity as Exercise;
            if (e != null)
            {
                string sqlStr = $"UPDATE Exercise " +
                                $"Set [description]=@Description, [difficulty]=@ExDifficulty , [MuscleType]=@ExMuscleType, [SubMuscleType]=@ExSubMuscleType " +
                                $"WHERE id=@Id";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@description", e.Description));
                command.Parameters.Add(new OleDbParameter("@difficulty", e.ExDifficulty.Id));
                command.Parameters.Add(new OleDbParameter("@MuscleType", e.ExMuscleType.Id));
                command.Parameters.Add(new OleDbParameter("@SubMuscleType", e.ExSubMuscleType.Id));
                command.Parameters.Add(new OleDbParameter("@id", e.Id));

            }
        }
    }
}
