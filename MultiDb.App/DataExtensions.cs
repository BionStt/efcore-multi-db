using MultiDb.One;
using MultiDb.Two;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultiDb.App
{
    public static class DataExtensions
    {
        public static List<LectureModel> GetLectures(this DbOneContext db1, DbTwoContext db2)
        {
            var model = db1.Lectures.Select(x => new LectureModel
            {
                id = x.Id,
                name = x.Name,
                proctor = db2.GetUser(x.UserId),
                attendees = db2.GetAttendees(x.Id)
            }).OrderBy(x => x.name).ToList();

            return model;
        }

        public static UserModel GetUser(this DbTwoContext db2, int id)
        {
            var user = db2.Users.Find(id);

            return new UserModel
            {
                id = user.Id,
                name = user.Name
            };
        }

        public static List<UserModel> GetAttendees(this DbTwoContext db2, int id)
        {
            var model = db2.UserLectures.Where(x => x.LectureId == id).Select(x => new UserModel
            {
                id = x.UserId,
                name = x.User.Name
            }).OrderBy(x => x.name).ToList();

            return model;
        }
    }
}
