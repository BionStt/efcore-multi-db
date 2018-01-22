using System;
using System.Collections.Generic;
using System.Text;

namespace MultiDb.App
{
    public class LectureModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public UserModel proctor { get; set; }

        public List<UserModel> attendees { get; set; }
    }
}
