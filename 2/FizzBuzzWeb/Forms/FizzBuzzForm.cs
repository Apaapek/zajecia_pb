using Microsoft.Extensions.Primitives;
using System.ComponentModel.DataAnnotations;

namespace FizzBuzzWeb.Forms
{
    public class FizzBuzzForm
    {
        [Display(Name = "Twój szczęśliwy numerek")]
        [Required(ErrorMessage = "To pole nie może być puste")]
        [Range(1, 1000, ErrorMessage = "Wartość musi być z przedziału od 1 do 1000")]
        public int? Number { get; set; }

        public string? Result { get; set; }

        public void FizzBuzzResult()
        {
            if (Number % 3 == 0 && Number % 5 == 0)
            {
                Result = "FizzBuzz";
            }
            else if (Number % 3 == 0)
            {
                Result = "Fizz";
            }
            else if (Number % 5 == 0)
            {
                Result = "Buzz";
            }
            else
            {
                Result = $"Liczba: {Number} nie spełnia kryteriów FizzBuzz.";
            }
        }
    }
}
