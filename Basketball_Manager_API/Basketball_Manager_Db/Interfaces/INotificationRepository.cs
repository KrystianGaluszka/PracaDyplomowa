using Basketball_Manager_Db.PostModels;
using System.Threading.Tasks;

namespace Basketball_Manager_Db.Interfaces
{
    public interface INotificationRepository
    {
        Task<string> PostCreateNotification(NotificationPostModel notificationPostModel);
        Task<string> DeleteNotification(int id);
    }
}
