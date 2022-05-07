using System;
using System.Collections.Generic;
using new_mvc.Models;

namespace new_mvc.Services
{
    public interface IFaculty
    {
        IEnumerable<Faculty> GetFaculties { get; }

        Faculty GetFaculty(int Id);
        void Add(Faculty _Faculty);
        void Remove(int Id);
    }
}
