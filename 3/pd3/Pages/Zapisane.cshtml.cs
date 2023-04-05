using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using pd3.Extra;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace pd3.Pages
{
    public class ZapisaneModel : PageModel
    {
        public List<Person> Tablica = new List<Person>();
        public string Zawartosc = string.Empty;
        public void OnGet()
        {
            var Data = HttpContext.Session.GetString("Data");
            if (Data != null)
                Tablica.Add(JsonConvert.DeserializeObject<Person>(Data));
            Przeladuj();
        }
        public void Przeladuj()
        {
            Zawartosc = "";
            Tablica?.ForEach(delegate (Person os)
            {
                Zawartosc += os.Result2 + "\n";
            });
        }
    }
}
