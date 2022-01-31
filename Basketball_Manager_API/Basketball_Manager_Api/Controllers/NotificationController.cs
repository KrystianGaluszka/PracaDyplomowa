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
        //private readonly ApplicationDbContext _context;

        public NotificationController(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateNotification(NotificationPostModel notificationPostModel)
        {
            return Ok(await _notificationRepository.PostCreateNotification(notificationPostModel));
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteNotification(int notificationId)
        {
            return Ok(await _notificationRepository.DeleteNotification(notificationId));
        }

    }
}
