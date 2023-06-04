using zadanie8.Interfaces;
using zadanie8.ViewModels.Person;

namespace zadanie8.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepo;

        public PersonService(IPersonRepository personRepo)
        {
            _personRepo = personRepo;
        }
        public ListPersonForListVM GetActivePeopleForList()
        {
            var people = _personRepo.GetActivePeople();
            ListPersonForListVM result = new ListPersonForListVM();
            result.People = new List<PersonForListVM>();
            foreach (var person in people)
            {
                // mapowanie obiektów
                var pVM = new PersonForListVM()
                {
                    Id = person.Id,
                    FullName = person.FirstName + " " +
                person.LastName
                };
                result.People.Add(pVM);
            }
            result.Count = result.People.Count;
            return result;
        }
    }
}
