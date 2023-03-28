using System.ComponentModel.DataAnnotations;
namespace FizzBuzzWeb.Pages.Dto.Forms
{
    public class FizzBuzzForm
    {
        [Required]
        [RegularExpression("^(?!2137$).*", ErrorMessage = "Tak nie wolno")]
        public int Number { get; set; }
    }
}
