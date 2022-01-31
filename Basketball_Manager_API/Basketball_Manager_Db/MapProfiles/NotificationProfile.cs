using AutoMapper;
using Basketball_Manager_Db.Models;
using Basketball_Manager_Db.PostModels;
using Basketball_Manager_Db.ViewModel;

namespace Basketball_Manager_Db.MapProfiles
{
    public class NotificationProfile: Profile
    {
        public NotificationProfile()
        {
            CreateMap<NotificationModel, NotificationViewModel>();
            CreateMap<NotificationPostModel, NotificationModel>();
            AllowNullCollections = true;
        }
    }
}
