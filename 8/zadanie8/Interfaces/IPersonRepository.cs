using zadanie8.Models;

namespace zadanie8.Interfaces
{
    public interface IPersonRepository
    {
        IQueryable<Person> GetActivePeople();
    }
}
