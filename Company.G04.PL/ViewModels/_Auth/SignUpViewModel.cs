using System.ComponentModel.DataAnnotations;

namespace Company.G04.PL.ViewModels._Auth
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage ="UserName Is Required !!")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "FirstName Is Required !!")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "LastName Is Required !!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email Is Required !!")]
        [EmailAddress(ErrorMessage ="Invalid Email")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Password Is Required !!")]
        [DataType(DataType.Password )]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "ConfirmedPassword Is Required !!")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage ="Confirmed Password Does Not Match")]
        public string ConfirmedPassword { get; set; }
        
        
        public bool IsAgree { get; set; }
    }
}
