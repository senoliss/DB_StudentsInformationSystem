namespace DB_StudentsInformationSystem.Database.Models
{
	public class FacultyStudent //many to many jungiamoji lentele
    {
        public int FacultyId { get; set;}
        public int StudentId { get; set;}

        // virtualios kompozicijos i departamenta ir paskaita del patogumo, realiai ju lenteleje nebus, jie tik pades joinint lenteles.
        public Faculty Faculty { get; set;}
        public Student Student { get; set;}
    }
}
