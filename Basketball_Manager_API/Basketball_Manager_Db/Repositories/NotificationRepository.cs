using AutoMapper;
using Basketball_Manager_Db.DataAccess;
using Basketball_Manager_Db.Interfaces;
using Basketball_Manager_Db.Models;
using Basketball_Manager_Db.PostModels;
using System.Linq;
using System.Threading.Tasks;
using static Basketball_Manager_Db.AutoMapperConfig;

namespace Basketball_Manager_Db.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly ApplicationDbContext _context;
        protected string basePath = "https://localhost:44326/images/notificationsIcons/";

        public NotificationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> PostCreateNotification(NotificationPostModel notificationPostModel)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == notificationPostModel.UserId);
            if (user != null)
            {
                var config = MapperConfig();
                var mapper = new Mapper(config);
                var notification = mapper.Map<NotificationPostModel, NotificationModel>(notificationPostModel);
                notification.IconPath = basePath + notificationPostModel.IconPath;
                _context.Notifications.Add(notification);
                await _context.SaveChangesAsync();

                return "success";
            }
            else return "error";
        }

        public async Task<string> DeleteNotification(int id)
        {
            var notification = _context.Notifications.FirstOrDefault(x => x.Id == id);
            if (notification != null)
            {
                _context.Notifications.Remove(notification);
                await _context.SaveChangesAsync();

                return "success";
            }
            else return "error";
        }

        public async Task<string> DeleteAllNotification(string userId)
        {
            var user = _context.Users.FirstOrDefault(x=> x.Id == userId);
            var notifications = user.Notifications;

            if (user != null)
            {
                _context.Notifications.RemoveRange(notifications);
                await _context.SaveChangesAsync();

                return "success";
            }
            else return "error";
        }
    }
}
