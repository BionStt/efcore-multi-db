using MultiDb.One;
using MultiDb.Two;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultiDb.App
{
    public static class DbInitializer
    {
        public static void Initialize(DbOneContext db1, DbTwoContext db2)
        {            
            db1.Database.EnsureCreated();
            db2.Database.EnsureCreated();

            if (!db2.Users.Any() && !db1.Lectures.Any())
            {
                var users = new User[]
                {
                    new User { Name = "User A" },
                    new User { Name = "User B" },
                    new User { Name = "User C" }
                };

                db2.Users.AddRange(users);
                db2.SaveChanges();

                var lectures = new Lecture[]
                {
                    new Lecture { Name = "Lecture A", UserId = 1 },
                    new Lecture { Name = "Lecture B", UserId = 2 },
                    new Lecture { Name = "Lecture C", UserId = 3 }
                };

                db1.Lectures.AddRange(lectures);
                db1.SaveChanges();

                var userLectures = new UserLecture[]
                {
                    new UserLecture { LectureId = 1, UserId = 2 },
                    new UserLecture { LectureId = 1, UserId = 3 },
                    new UserLecture { LectureId = 2, UserId = 1 },
                    new UserLecture { LectureId = 2, UserId = 3 },
                    new UserLecture { LectureId = 3, UserId = 1 },
                    new UserLecture { LectureId = 3, UserId = 2 }
                };

                db2.UserLectures.AddRange(userLectures);
                db2.SaveChanges();
            }
        }
    }
}
