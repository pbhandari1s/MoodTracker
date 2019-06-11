using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Core.Helper
{
    public class CRUDNotification
    {

        public CRUDNotification()
        {
        }

        public string Message { get; set; }

        public NotificationTypes NotificationType { get; set; }

        public enum NotificationTypes
        {
            Success = 1,
            Error = 2,
            Warning = 3
        }

        public string CssClassName
        {
            get
            {
                if (NotificationType == NotificationTypes.Success)
                    return "alert-success";

                if (NotificationType == NotificationTypes.Error)
                    return "alert-error";

                return "alert-warning";
            }
        }

        public string Title
        {
            get
            {
                if (NotificationType == NotificationTypes.Success)
                    return "Success!";

                if (NotificationType == NotificationTypes.Error)
                    return "Error!";

                return "Warning!";
            }
        }

    }
}
