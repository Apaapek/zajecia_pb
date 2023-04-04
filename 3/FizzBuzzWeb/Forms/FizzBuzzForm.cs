using System.ComponentModel.DataAnnotations;

namespace FizzBuzzWeb.Forms
{
    public class FizzBuzzForm
    {
        [Display(Name = "Twój szczęśliwy numerek")]
        [Required(ErrorMessage ="Pole jest obowiązkowe"), Range(1, 1000, ErrorMessage = "Oczekiwana wartość {0} z zakresu {1} i {2}.")]
        public int? Number { get; set; }
        public string Result { get; set; }
        public void Check()
        {
            Result = "";
            if (Number % 3 == 0) Result += "Fizz";
            if (Number % 5 == 0) Result += "Buzz";
            if (Result == "") Result = "Liczba " + Number + " nie spełnia kryteriów FizzBuzz";
        }
    }
}
