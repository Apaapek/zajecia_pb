using sprawko.ViewModels.History;

namespace sprawko.Interfaces
{
    public interface IHistoryService
    {
        ListHistoryForListVM GetHistory(int pageIndex);
        bool DeleteEvent(int checkId, int userId);
    }
}
