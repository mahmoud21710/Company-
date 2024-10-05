using System.ComponentModel.DataAnnotations;

namespace Company.G04.PL.ViewModels._Auth
{
    public class ForgetPasswordViewModel
    {
        [Required(ErrorMessage = "Email Is Required !!")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
    }
}
