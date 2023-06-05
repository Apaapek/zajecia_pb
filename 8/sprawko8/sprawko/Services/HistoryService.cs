using sprawko.Interfaces;
using sprawko.Models.Entities;
using sprawko.Services.Repositories;
using sprawko.ViewModels.History;

namespace sprawko.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly IHistoryRepository<LeapYearCheck> _repository;
        private readonly int _pageSize;

        public HistoryService(IHistoryRepository<LeapYearCheck> repository, IConfiguration configuration)
        {
            _repository = repository;
            _pageSize = int.TryParse(configuration["HistoryPageSize"], out var temp) ? temp : 20;
        }

        public bool DeleteEvent(int checkId, int userId)
        {
            var @event = _repository.Get(x => x.LeapYearCheckId == checkId).FirstOrDefault();

            if (@event == null || @event.UserId == null || @event.UserId != userId)
            {
                return false;
            }

            _repository.Remove(@event);
            return _repository.SaveChanges() > 0;
        }

        public ListHistoryForListVM GetHistory(int pageIndex)
        {
            var checks = _repository.GetAll(x => x.User!)
                .OrderByDescending(x => x.CheckedAt)
                .Skip((pageIndex - 1) * _pageSize)
                .Take(_pageSize);

            return new ListHistoryForListVM()
            {
                Events = checks.Select(x => new HistoryForListVM()
                {
                    CheckId = x.LeapYearCheckId,
                    UserId = x.UserId,
                    UserName = x.User == null ? null : x.User.UserName,
                    Name = x.Name,
                    Year = x.Year,
                    IsLeap = x.IsLeap,
                    CheckedAt = x.CheckedAt
                })
            };
        }
    }
}
