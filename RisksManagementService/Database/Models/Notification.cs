using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RisksManagementService.Attributes;

namespace RisksManagementService.Database.Models
{
    [DataDescription("notification", "Notification", FieldType.TableName)]
    public class Notification
    {
        [DataDescription("id", "Id")]
        public int Id { get; set; }

        [DataDescription("application", "NotificationApplication")]
        public NotificationApplication NotificationApplication { get; set; }

        [DataDescription("is_active", "IsActive")]
        public bool IsActive { get; set; }
    }
}