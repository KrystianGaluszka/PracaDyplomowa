using Basketball_Manager_Db.DataAccess;
using Basketball_Manager_Db.Interfaces;
using Basketball_Manager_Db.PostModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Basketball_Manager_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly ApplicationDbContext _context;

        public NotificationController(INotificationRepository notificationRepository, ApplicationDbContext context)
        {
            _notificationRepository = notificationRepository;
            _context = context;
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteNotification(int notificationId)
        {
            return Ok(await _notificationRepository.DeleteNotification(notificationId));
        }

        [HttpDelete("deleteAll")]
        public async Task<IActionResult> DeleteAllNotification(string userId)
        {
            return Ok(await _notificationRepository.DeleteAllNotification(userId));
        }

        [HttpPut("read")]
        public async Task<IActionResult> ReadNotification(int notificationId)
        {
            var notification = _context.Notifications.Find(notificationId);
            if (notification != null)
            {
                notification.IsRead = true;
                await _context.SaveChangesAsync();
            }
            return Ok(notification.IsRead);
        }

    }
}
