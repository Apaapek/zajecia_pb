using System.ComponentModel.DataAnnotations;

namespace pd3.Extra
{
    public class Person
    {
        [Display(Name = "Rok urodzenia")]
        [Required(ErrorMessage = "Pole jest obowiązkowe")]
        [Range(1899, 2022, ErrorMessage = "Oczekiwana wartość {0} z zakresu {1} i {2}.")]
        public int Year { get; set; }
        [Display(Name = "Imie")]
        [Required(ErrorMessage = "Pole jest obowiązkowe")]
        [MaxLength(100, ErrorMessage = "Maks. ilość znaków - {1}")]
        public string Name { get; set; }
        public string Result = string.Empty;
        public string Result2 = string.Empty;
        public void Check()
        {
            Result = Name;
            Result2 = Name + ", " + Year + " - ";
            if (Name[Name.Length-1] == 'a')
            {
                Result += " urodziała się w " + Year + " roku. ";
            }
            else
            {
                Result += " urodział się w " + Year + " roku. ";
            }
            if(Year % 400 == 0)
            {
                Result += "To był rok przestępny.";
                Result2 += "rok przestępny";
            }
            else if(Year % 4 == 0 && Year % 100 != 0)
            {
                Result += "To był rok przestępny.";
                Result2 += "rok przestępny";
            }
            else
            {
                Result += "To nie był rok przestępny.";
                Result2 += "rok nie przestępny";
            }
        }
    }
}
