using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RisksManagementService.Attributes;

namespace RisksManagementService.Database.Models
{
    [DataDescription("team_user", "TeamUser", FieldType.TableName)]
    public class TeamUser : IDatabaseModel
    {
        [DataDescription("id", "Id")]
        public int Id { get; set; }

        [DataDescription("team", "Team")]
        public Team Team { get; set; }

        [DataDescription("app_user", "AppUser")]
        public AppUser AppUser { get; set; }

        [DataDescription("is_active", "IsActive")]
        public bool IsActive { get; set; }

        [DataDescription("created_by", "CreatedBy")]
        public string CreatedBy { get; set; }

        [DataDescription("modified_by", "ModifiedBy")]
        public string ModifiedBy { get; set; }

        [DataDescription("time_created", "TimeCreated")]
        public DateTime TimeCreated { get; set; }

        [DataDescription("time_modified", "TimeModified")]
        public DateTime TimeModified { get; set; }
    }
}