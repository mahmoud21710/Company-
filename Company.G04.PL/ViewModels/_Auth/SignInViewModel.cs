using System.ComponentModel.DataAnnotations;

namespace Company.G04.PL.ViewModels._Auth
{
	public class SignInViewModel
	{
		[Required(ErrorMessage = "Email Is Required !!")]
		[EmailAddress(ErrorMessage = "Invalid Email")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Password Is Required !!")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
