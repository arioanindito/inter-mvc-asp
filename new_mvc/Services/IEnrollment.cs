using System;
using System.Collections.Generic;
using new_mvc.Models;

namespace new_mvc.Services
{
    public interface IEnrollment
    {
        IEnumerable<Enrollment> GetEnrollments { get;}

        Enrollment GetEnrollment(int? Id);
        void Add(Enrollment _Enrollment);
        void Remove(int? Id);
    }
}
