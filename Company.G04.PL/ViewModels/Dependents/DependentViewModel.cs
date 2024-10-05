using Company.G04.DAL.Model;
using System.ComponentModel.DataAnnotations;

namespace Company.G04.PL.ViewModels.Dependents
{
    public class DependentViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name Is Requird !!")]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateOnly BirthDate { get; set; }
        [Range(1,24,ErrorMessage = "Age Must Be Between 1, 24")]
        public int Age { get; set; }
        public string Gender { get; set; }
        public int? ParentId { get; set; } //F.K
        public Employee? Parent { get; set; } //Navigation Property 
    }
}
