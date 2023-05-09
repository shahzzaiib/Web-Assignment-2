using System.ComponentModel.DataAnnotations;

namespace Web_Assignment_2.Models

{
    public class Student
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Input Name Limit Exceeds", MinimumLength = 3)]
        public string Name { get; set; }

        public string RollNumber { get; set; }
        public DateTime DOB { get; set; }
    }

}
