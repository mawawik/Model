using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_Model.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SelectController : ControllerBase
    {
        //--------------------------------Select------------------------------------
        // GET: api/<FirstController>
        [HttpGet]
        [ActionName("DifficultySelector")]
        public DifficultyList SelectAllDifficulties()
        {
            DifficultyDb db = new DifficultyDb();
            DifficultyList difficulties = db.SelectAll();
            return difficulties;
        }
        [HttpGet]
        [ActionName("AdminSelector")]
        public AdminList SelectAllAdmins()
        {
            AdminDb db = new AdminDb();
            AdminList admins = db.SelectAll();
            return admins;
        }
        [HttpGet]
        [ActionName("ExerciseSelector")]
        public ExerciseList SelectAllExercises()
        {
            ExerciseDb db = new ExerciseDb();
            ExerciseList exercises = db.SelectAll();
            return exercises;
        }
        [HttpGet]
        [ActionName("ExerciseForUserSelector")]
        public ExerciseForUserList SelectAllExerciseForUsers()
        {
            ExerciseForUserDb db = new ExerciseForUserDb();
            ExerciseForUserList exerciseForUsers = db.SelectAll();
            return exerciseForUsers;
        }
        [HttpGet]
        [ActionName("GenderSelector")]
        public GenderList SelectAllGenders()
        {
            GenderDb db = new GenderDb();
            GenderList genders = db.SelectAll();
            return genders;
        }
        [HttpGet]
        [ActionName("MuscleTypeSelector")]
        public MuscleTypeList SelectAllMuscleTypes()
        {
            MuscleTypeDb db = new MuscleTypeDb();
            MuscleTypeList muscleTypes = db.SelectAll();
            return muscleTypes;
        }
        [HttpGet]
        [ActionName("SubMuscleTypeSelector")]
        public SubMuscleTypeList SelectAllSubMuscleTypes()
        {
            SubMuscleTypeDb db = new SubMuscleTypeDb();
            SubMuscleTypeList subMuscleTypes = db.SelectAll();
            return subMuscleTypes;
        }
        [HttpGet]
        [ActionName("UserSelector")]
        public UserList SelectAllUsers()
        {
            UserDb db = new UserDb();
            UserList users = db.SelectAll();
            return users;
        }
        [HttpGet]
        [ActionName("WeekDaysSelector")]
        public WeekDaysList SelectAllWeekDayss()
        {
            WeekDaysDb db = new WeekDaysDb();
            WeekDaysList weekDays = db.SelectAll();
            return weekDays;
        }

        //---------------------------------Delete-----------------------------------

        [HttpDelete("{id}")]
        public int DeleteAUser(int id)
        {
            User u = UserDb.SelectById(id);
            UserDb uDB = new UserDb();
            uDB.Delete(u);
            int x = uDB.SaveChanges();
            return x;
        }

        [HttpDelete("{id}")]
        public int DeleteAnExercise(int id)
        {
            Exercise e = ExerciseDb.SelectById(id);
            ExerciseDb eDB = new ExerciseDb();
            eDB.Delete(e);
            int x = eDB.SaveChanges();
            return x;
        }

        [HttpDelete("{id}")]
        public int DeleteAnExerciseForUser(int id)
        {
            ExerciseForUser ex = ExerciseForUserDb.SelectById(id);
            ExerciseForUserDb exDB = new ExerciseForUserDb();
            exDB.Delete(ex);
            int x = exDB.SaveChanges();
            return x;
        }

        [HttpDelete("{id}")]
        public int DeleteAnAdmin(int id)
        {
            Admin a = AdminDb.SelectById(id);
            AdminDb aDB = new AdminDb();
            aDB.Delete(a);
            int x = aDB.SaveChanges();
            return x;
        }

        //---------------------------------Insert-----------------------------------

        [HttpPost]
        public int InsertAUser([FromBody] User user)
        {
            UserDb db = new UserDb();
            db.Insert(user);
            int x = db.SaveChanges();
            return (x);
        }

        [HttpPost]
        public int InsertAnExercise([FromBody] Exercise exercise)
        {
            ExerciseDb db = new ExerciseDb();
            db.Insert(exercise);
            int x = db.SaveChanges();
            return (x);
        }

        [HttpPost]
        public int InsertAnExerciseForUser([FromBody] ExerciseForUser exerciseForUser)
        {
            ExerciseForUserDb db = new ExerciseForUserDb();
            db.Insert(exerciseForUser);
            int x = db.SaveChanges();
            return (x);
        }

        [HttpPost]
        public int InsertAnAdmin([FromBody] Admin admin)
        {
            AdminDb db = new AdminDb();
            db.Insert(admin);
            int x = db.SaveChanges();
            return (x);
        }

        //---------------------------------Update-----------------------------------

        [HttpPut]
        [ActionName("UpdateUser")]
        public int UpdateAUser([FromBody] User user)
        {
            UserDb db = new UserDb();
            db.Update(user);
            int x = db.SaveChanges();
            return (x);
        }

        [HttpPut]
        [ActionName("UpdateExercise")]
        public int UpdateAnExercise([FromBody] Exercise exercise)
        {
            ExerciseDb db = new ExerciseDb();
            db.Update(exercise);
            int x = db.SaveChanges();
            return (x);
        }

        [HttpPut]
        [ActionName("UpdateExerciseForUser")]
        public int UpdateAnExerciseForUser([FromBody] ExerciseForUser exerciseForUser)
        {
            ExerciseForUserDb db = new ExerciseForUserDb();
            db.Update(exerciseForUser);
            int x = db.SaveChanges();
            return (x);
        }
    }
}
