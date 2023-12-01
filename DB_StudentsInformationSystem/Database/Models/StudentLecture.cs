using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_StudentsInformationSystem.Database.Models
{
    public class StudentLecture
    {
        public int StudentId { get; set; }
        public int LectureId { get; set; }

        // virtualios kompozicijos i studenta ir paskaita del patogumo, realiai ju lenteleje nebus, jie tik pades joinint lenteles.
        public Student Student { get; set; }
        public Lecture Lecture { get; set; }
    }
}

