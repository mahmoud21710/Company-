using System.ComponentModel.DataAnnotations;

namespace Company.G04.PL.ViewModels._Auth
{
	public class ResetPasswordViewModel
	{
		[Required(ErrorMessage = "Password Is Required !!")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required(ErrorMessage = "ConfirmedPassword Is Required !!")]
		[DataType(DataType.Password)]
		[Compare(nameof(Password), ErrorMessage = "Confirmed Password Does Not Match")]
		public string ConfirmedPassword { get; set; }
	}
}
