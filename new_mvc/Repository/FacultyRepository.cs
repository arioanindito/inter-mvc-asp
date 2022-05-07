using System;
using System.Collections.Generic;
using new_mvc.Models;
using new_mvc.Services;

namespace new_mvc.Repository
{
    public class FacultyRepository : IFaculty
    {
        private DBContext db;

        public FacultyRepository(DBContext _db)
        {
            db = _db;
        }

        public IEnumerable<Faculty> GetFaculties => db.Faculties;

        public void Add(Faculty _Faculty)
        {
            db.Faculties.Add(_Faculty);
            db.SaveChanges();
        }

        public Faculty GetFaculty(int Id)
        {
            Faculty dbEntitiy = db.Faculties.Find(Id);
            return dbEntitiy;
        }

        public void Remove(int Id)
        {
            Faculty dbEntity = db.Faculties.Find(Id);
            db.Faculties.Remove(dbEntity);
        }
    }
}
