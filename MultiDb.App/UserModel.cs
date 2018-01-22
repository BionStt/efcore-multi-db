using System;
using System.Collections.Generic;
using System.Text;

namespace MultiDb.App
{
    public class UserModel
    {
        public int id { get; set; }
        public string name { get; set; }

        public List<LectureModel> lectures { get; set; }
    }
}
