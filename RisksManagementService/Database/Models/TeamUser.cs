using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RisksManagementService.Attributes;

namespace RisksManagementService.Database.Models
{
    [DataDescription("team_user", "TeamUser", FieldType.TableName)]
    public class TeamUser
    {
        [DataDescription("id", "Id")]
        public int Id { get; set; }

        [DataDescription("team", "Team")]
        public Team Team { get; set; }

        [DataDescription("app_user", "AppUser")]
        public AppUser AppUser { get; set; }

        [DataDescription("is_active", "IsActive")]
        public bool IsActive { get; set; }
    }
}