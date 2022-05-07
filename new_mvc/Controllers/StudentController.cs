using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using new_mvc.Models;
using new_mvc.Repository;
using new_mvc.Services;

namespace new_mvc.Controllers
{
    public class StudentController : Controller
    {
        private readonly DBContext _context;

        private readonly IStudent _student;

        private readonly IFaculty _faculty;

        //private readonly ICourse _course;

        public StudentController(DBContext context,IStudent _IStudent, IFaculty _IFaculty)
        {
            _context = context;
            _student = _IStudent;
            _faculty = _IFaculty;
            //_course = _ICourse;
        }

        // GET: Student
        public async Task<IActionResult> Index()
        //public IActionResult Index()
        {
            return View(await _context.Students
                .Include(s => s.Faculty)
                .ToListAsync());
            //return View(_student.GetStudents);
        }

        // GET: Student/Details/5
        //public async Task<IActionResult> Details(int? id)
        public IActionResult Details(int? id)

        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var student = await _context.Students.Include(s => s.Faculty)
            //    .FirstOrDefaultAsync(m => m.StudentId == id);
            //if (student == null)
            //{
            //    return NotFound();
            //}

            //return View(student);

            //return View(_Borrower.GetBorrower(ID));
            return View(_student.GetStudent(id));
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            ViewBag.Faculties = _faculty.GetFaculties;
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,FirstName,LastName,DOB,EnrollmentDate,Gender,FacultyId")] Student student)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(student);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                _student.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.Include(s => s.Faculty)
                .FirstOrDefaultAsync(m => m.StudentId == id);

            ViewBag.Faculties = _faculty.GetFaculties;

            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,FirstName,LastName,DOB,EnrollmentDate,Gender,FacultyId")] Student student)
        {
            if (id != student.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StudentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.Include(s => s.Faculty)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.StudentId == id);
        }
    }
}
