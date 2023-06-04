using zadanie8.Data;
using zadanie8.Interfaces;
using zadanie8.Models;

namespace zadanie8.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PeopleContext _context;
        public PersonRepository(PeopleContext context)
        {
            _context = context;
        }
        public IQueryable<Person> GetActivePeople()
        {
            return _context.Person.Where(p => p.IsActive);
        }
    }
}
