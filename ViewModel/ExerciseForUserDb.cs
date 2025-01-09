using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ExerciseForUserDb : BaseDb
    {
        static private ExerciseForUserList list = new ExerciseForUserList();
        protected override Base NewEntity()
        {
            return new ExerciseForUser();
        }

        public static ExerciseForUser SelectById(int id)
        {
            ExerciseForUserDb db = new ExerciseForUserDb();
            list = db.SelectAll();

            ExerciseForUser e = list.Find(item => item.Id == id);
            return e;
        }

        protected override Base CreateModel(Base entity)
        {
            ExerciseForUser e = entity as ExerciseForUser;
            e.UserId = UserDb.SelectById(int.Parse(reader["UserId"].ToString()));
            e.ExerciseId = ExerciseDb.SelectById(int.Parse(reader["ExerciseId"].ToString()));
            e.DayOfWeek = WeekDaysDb.SelectById(int.Parse(reader["Day_Week"].ToString()));
            return base.CreateModel(entity);
        }

        public ExerciseForUserList SelectAll()
        {
            command.CommandText = $"SELECT * FROM ExerciseForUser";
            ExerciseForUserList eList = new ExerciseForUserList(base.Select());
            return eList;
        }

        protected override void CreateDeletedSQL(Base entity, OleDbCommand cmd)
        {
            ExerciseForUser e = entity as ExerciseForUser;
            if (e != null)
            {
                string sqlStr = $"DELETE FROM ExerciseForUser where id=@pid";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@pid", e.Id));
            }
        }
        protected override void CreateInsertSQL(Base entity, OleDbCommand cmd)
        {
            ExerciseForUser ex = entity as ExerciseForUser;
            if (ex != null)
            {
                string sqlStr = $"Insert INTO ExerciseForUser (UserId, ExerciseId, Day_Week) " + "VALUES (@UserId, @ExerciseId, @Day_Week)";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@UserId", ex.UserId.Id));
                command.Parameters.Add(new OleDbParameter("@ExerciseId", ex.ExerciseId.Id));
                command.Parameters.Add(new OleDbParameter("@Day_Week", ex.DayOfWeek.Id));
            }
        }

        protected override void CreateUpdateSQL(Base entity, OleDbCommand cmd)
        {
            ExerciseForUser ex = entity as ExerciseForUser;
            if (ex != null)
            {
                string sqlStr = $"UPDATE [ExerciseForUser] " +                                
                                $"Set [UserId]=@UserId, [ExerciseId]=@ExerciseId, [Day_Week]=@DayOfWeek " +
                                $"WHERE id=@Id";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@UserId", ex.UserId.Id));
                command.Parameters.Add(new OleDbParameter("@ExerciseId", ex.ExerciseId.Id));
                command.Parameters.Add(new OleDbParameter("@Day_Week", ex.DayOfWeek.Id));
                command.Parameters.Add(new OleDbParameter("@id", ex.Id));

            }
        }
    }
}
