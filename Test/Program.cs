using Model;
using System.Collections.Concurrent;
using ViewModel;

#region Difficulty

Console.WriteLine("-----------Difficulty------------");
DifficultyDb dDB = new DifficultyDb();
DifficultyList dList = dDB.SelectAll();
foreach (Difficulty d in dList)
    Console.WriteLine(d.DifficultyDescription + " " + d.Id);
Difficulty dLast = dList.Last();

#endregion

#region Gender

Console.WriteLine("-----------Gender------------");
GenderDb gDB = new GenderDb();
GenderList gList = gDB.SelectAll();
foreach (Gender g in gList)
    Console.WriteLine(g.GenderName + " " + g.Id);
Gender gLast = gList.Last();

#endregion

#region MuscleType

Console.WriteLine("-----------MuscleType------------");
MuscleTypeDb mDB = new MuscleTypeDb();
MuscleTypeList mList = mDB.SelectAll();
foreach (MuscleType m in mList)
    Console.WriteLine(m.MuscleTypeName + " " + m.Id);
MuscleType mLast = mList.Last();

#endregion

#region SubMuscleType

Console.WriteLine("-----------SubMuscleType------------");
SubMuscleTypeDb sDB = new SubMuscleTypeDb();
SubMuscleTypeList sList = sDB.SelectAll();
foreach (SubMuscleType s in sList)
    Console.WriteLine(s.SubMuscleTypeName + " " + s.MuscleId.MuscleTypeName + " " + s.Id);
SubMuscleType sLast = sList.Last();

#endregion

#region WeekDays

Console.WriteLine("-----------WeekDays------------");
WeekDaysDb wDB = new WeekDaysDb();
WeekDaysList wList = wDB.SelectAll();
foreach (WeekDays w in wList)
    Console.WriteLine(w.WeekDay + " " + w.Id);

#endregion

#region User

Console.WriteLine("-----------User------------");
UserDb uDB = new UserDb();
UserList uList = uDB.SelectAll();
foreach (User u in uList)
    Console.WriteLine(u.Password + " " + u.UserName + " " + u.Email + " " + u.BirthDate + " " + u.UserGender.GenderName + " " + u.Id);
//-------------------------------------------------------
//User uLast = uList.Last();
//uDB.Delete(uLast);
//uDB.SaveChanges();
//Console.WriteLine("delete :");
//uList = uDB.SelectAll();
//foreach (User u in uList)
//    Console.WriteLine(u.UserName);
//-------------------------------------------------------
//User u1 = new User() { Password = "pisul", UserName = "denis", Email = "denis@gmail.com", BirthDate = new DateTime(2007, 5, 28), UserGender = gList[2] };
//uDB.Insert(u1);
//uDB.SaveChanges();
//UserList users = uDB.SelectAll();
//Console.WriteLine("after : ");
//foreach (User user in users)
//    Console.WriteLine(user.Password + " " + user.UserName + " " + user.UserGender.GenderName + " " + user.Email + " " + user.BirthDate);
//-------------------------------------------------------
//UserDb u2 = new UserDb();
//UserList users2 = u2.SelectAll();
//User user = users2[0];
//user.Password = "soirgbivj";
//uDB.Insert(user);
//uDB.SaveChanges();
//Console.WriteLine("after: ");
//foreach (User u in users2)
//    Console.WriteLine(u.UserName + " " + u.Password);

#endregion

#region Exercise

Console.WriteLine("-----------Exercise------------");
ExerciseDb eDB = new ExerciseDb();
ExerciseList eList = eDB.SelectAll();
foreach (Exercise e in eList)
    Console.WriteLine(e.Description + " " + e.ExDifficulty.DifficultyDescription + " " + e.ExMuscleType.MuscleTypeName + " " + e.ExSubMuscleType.SubMuscleTypeName + " " + e.Id);
Exercise eLast = eList.Last();
//-------------------------------------------------------
//eDB.Delete(eLast);
//eDB.SaveChanges();
//Console.WriteLine("delete :");
//eList = eDB.SelectAll();
//foreach (Exercise e in eList)
//    Console.WriteLine(e.Description);
//-------------------------------------------------------
//Exercise e1 = new Exercise() { Description = "bench", ExDifficulty = dList[2], ExMuscleType = mList[0], ExSubMuscleType = sList[0] };
//eDB.Insert(e1);
//eDB.SaveChanges();
//ExerciseList exercises = eDB.SelectAll();
//Console.WriteLine("after : ");
//foreach (Exercise e in exercises)
//    Console.WriteLine(e.Description + " " + e.ExDifficulty.DifficultyDescription + " " + e.ExMuscleType.MuscleTypeName + " " + e.ExSubMuscleType.SubMuscleTypeName);
////-------------------------------------------------------
//ExerciseDb e2 = new ExerciseDb();
//ExerciseList exercises2 = e2.SelectAll();
//Exercise exercise = exercises2[0];
//exercise.Description = "exorcisem";
//eDB.Insert(exercise);
//eDB.SaveChanges();
//Console.WriteLine("after: ");
//foreach (Exercise e in exercises2)
//    Console.WriteLine(e.Description + " " + e.ExMuscleType.MuscleTypeName);

#endregion

#region ExerciseForUser

Console.WriteLine("-----------ExerciseForUser------------");
ExerciseForUserDb exDB = new ExerciseForUserDb();
ExerciseForUserList exList = exDB.SelectAll();
foreach (ExerciseForUser ex in exList)
    Console.WriteLine(ex.UserId.UserName + " " + ex.ExerciseId.Description + " " + ex.DayOfWeek.WeekDay + " " + ex.Id);
//--------------------------------------------------------------
//ExerciseForUser exLast = exList.Last();
//exDB.Delete(exLast);
//exDB.SaveChanges();
//Console.WriteLine("delete :");
//exList = exDB.SelectAll();
//foreach (ExerciseForUser ex in exList)
//    Console.WriteLine(ex.UserId.UserName);
//-------------------------------------------------------
//ExerciseForUser ex1 = new ExerciseForUser() { UserId = uList[3], ExerciseId = eList[2], DayOfWeek = wList[5] };
//exDB.Insert(ex1);
//exDB.SaveChanges();
//ExerciseForUserList exerciseForUsers = exDB.SelectAll();
//Console.WriteLine("after : ");
//foreach (ExerciseForUser exerciseForUser in exerciseForUsers)
//    Console.WriteLine(exerciseForUser.UserId.UserName + " " + exerciseForUser.ExerciseId.Description + " " + exerciseForUser.DayOfWeek.WeekDay);
////-------------------------------------------------------
//ExerciseForUserDb ex2 = new ExerciseForUserDb();
//ExerciseForUserList exerciseForUsers2 = ex2.SelectAll();
//ExerciseForUser exerciseforuser = exerciseForUsers2[0];
//exerciseforuser.DayOfWeek = wList[6];
//ex2.Update(exerciseforuser);
//ex2.SaveChanges();0       
//exerciseForUsers2 = ex2.SelectAll();
//Console.WriteLine("after: ");
//foreach (ExerciseForUser ex in exerciseForUsers2)
//    Console.WriteLine(ex.UserId.UserName + " " + ex.DayOfWeek.WeekDay);

#endregion

#region Admin

Console.WriteLine("-----------Admin------------");
AdminDb aDB = new AdminDb();
AdminList aList = aDB.SelectAll();
foreach (Admin a in aList)
    Console.WriteLine(a.Id);
//------------------------------------------------------
//Admin aLast = aList.Last();
//aDB.Delete(aLast);
//aDB.SaveChanges();
//Console.WriteLine("delete :");
//aList = aDB.SelectAll();
//foreach (Admin a in aList)
//    Console.WriteLine(a.Id);
//-------------------------------------------------------
//Admin a1 = new Admin() { Password = "uisegsr", UserName = "sresjfsk,", Email = "dsyth", BirthDate = new DateTime(2007, 5, 29), UserGender = gList[1] };
//aDB.Insert(a1);
//aDB.SaveChanges();
//AdminList admins = aDB.SelectAll();
//Console.WriteLine("after : ");
//foreach (Admin admin in admins)
//    Console.WriteLine(admin.UserName + " " + admin.Password + " " + admin.Email);

#endregion