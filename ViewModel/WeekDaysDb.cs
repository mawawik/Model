using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class WeekDaysDb : BaseDb
    {
        static private WeekDaysList list = new WeekDaysList();
        protected override Base NewEntity()
        {
            return new WeekDays();
        }
        protected override Base CreateModel(Base entity)
        {
            WeekDays w = entity as WeekDays;
            w.WeekDay = reader["weekDay"].ToString();
            return base.CreateModel(entity);
        }
        public WeekDaysList SelectAll()
        {
            command.CommandText = $"SELECT * FROM WeekDays";
            WeekDaysList wList = new WeekDaysList(base.Select());
            return wList;
        }
        public static WeekDays SelectById(int id)
        {
            WeekDaysDb w = new WeekDaysDb();
            list = w.SelectAll();

            WeekDays W = list.Find(x => x.Id == id);
            return W;
        }

        protected override void CreateDeletedSQL(Base entity, OleDbCommand cmd)
        {
            WeekDays w = entity as WeekDays;
            if (w != null)
            {
                string sqlStr = $"DELETE FROM WeekDays where id=@pid";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@pid", w.Id));
            }
        }
        protected override void CreateInsertSQL(Base entity, OleDbCommand cmd)
        {
            WeekDays w = entity as WeekDays;
            if (w != null)
            {
                string sqlStr = $"Insert into WeekDays values (@cName )";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@cName", w.WeekDay));
            }
        }

        protected override void CreateUpdateSQL(Base entity, OleDbCommand cmd)
        {
            WeekDays w = entity as WeekDays;
            if (w != null)
            {
                string sqlStr = $"UPDATE WeekDays " +
                                $"VALUES (@WeekDay) " +
                                $"Set cName=@WeekDay " +
                                $"WHERE id=@Id";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@cName", w.WeekDay));
            }   
        }
    }
}
