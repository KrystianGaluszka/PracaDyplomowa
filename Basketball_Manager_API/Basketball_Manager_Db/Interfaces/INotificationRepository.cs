using Basketball_Manager_Db.PostModels;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.Interfaces
{
    public interface INotificationRepository
    {
        Task<string> DeleteNotification(int id);
        Task<string> DeleteAllNotification(string userId);
    }
}
