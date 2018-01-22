using System;
using System.Collections.Generic;
using System.Text;

namespace MultiDb.Two
{
    public class UserLecture
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int LectureId { get; set; }

        public User User { get; set; }
    }
}
