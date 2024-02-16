using Microsoft.EntityFrameworkCore;

namespace miniproject.Models
{
    public class StudentViewModel
    {
        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

    }
}
