using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using miniproject.data;
using miniproject.Models;
using miniproject.Models.Entity;




namespace miniproject.Controllers
{
    public class StudentsController : Controller
    {
        private readonly Applicationdbcontext dbContext;
        public StudentsController(Applicationdbcontext dbContext)
        {
            this.dbContext = dbContext;   
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> Add(StudentViewModel Viewmodel)
        {
            var student = new Student
            {
                Name = Viewmodel.Name,
                Email = Viewmodel.Email,
                Phone = Viewmodel.Phone,
                    
            };
            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();
            return View(Viewmodel);
        }
        [HttpGet]
        public async Task <IActionResult> List()
        {
            var Student = await dbContext.Students.ToListAsync();
            return View(Student);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await dbContext.Students.FindAsync(id);

            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Student viewmodel)
        {
            var student = await dbContext.Students.FindAsync(viewmodel.Id);

            if(student is not null)
            {
                student.Name = viewmodel.Name;
                student.Email = viewmodel.Email;
                student.Phone = viewmodel.Phone;

                await dbContext.SaveChangesAsync();
            }
           return RedirectToAction("List","Students");
        }
        [HttpPost]
        public async Task<IActionResult> delete(Student viewmodel)
        {
            var student = await dbContext.Students.AsNoTracking().FirstOrDefaultAsync(x => x.Id == viewmodel.Id);
            if (student is not null)
            {
                dbContext.Students.Remove(viewmodel);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Students");
        }
    }
    
}
