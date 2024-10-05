using Company.G04.DAL.Model;
using System.ComponentModel.DataAnnotations;

namespace Company.G04.PL.ViewModels.Employes
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name Is Required !! ")]
        public string Name { get; set; }
        [Range(18, 60, ErrorMessage = "Age Must Be Between 18,60")]
        public int? Age { get; set; }

        //[RegularExpression("^\\d{1,5}\\s\\w+(\\s\\w+)*,\\s\\w+,\\s[A-Z]{2}\\s\\d{5}(-\\d{4})?$\r\n",
        //ErrorMessage = "Invalid address format. Please ensure the format is: '1234 Main St, Anytown, NY 12345")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Salary Is Required !! ")]
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        //[DataType(DataType.EmailAddress,ErrorMessage ="")]
        [EmailAddress(ErrorMessage = "Is valid ")]
        [Required(ErrorMessage = "Email Is Required !! ")]
        public string Email { get; set; }

        //[RegularExpression("^(\\+20|0)?1[0125]\\d{8}$\r\n",
        //    ErrorMessage = "Invalid phone number format. Please enter a valid Egyptian phone number, e.g.," +
        //    " '+20123456789' or '0123456789'.")]
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }     
        public DateTime HiringDate { get; set; }
      
        public int? WorkForId { get; set; } //F.k
        public Department? WorkFor { get; set; }  //Navigation Property

        public IFormFile? Image { get; set; }
        public string? ImageName { get; set; }
    }
}
