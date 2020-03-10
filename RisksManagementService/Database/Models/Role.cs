﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RisksManagementService.Attributes;

namespace RisksManagementService.Database.Models
{
    [DataDescription("role", "Role", FieldType.TableName)]
    public class Role
    {
        [DataDescription("id", "Id")]
        public int Id { get; set; }

        [DataDescription("name", "Name")]
        public string Name { get; set; }

        [DataDescription("role_pattern", "RolePattern")]
        public RolePattern RolePattern { get; set; }

        [DataDescription("settings", "Settings")]
        public Settings Settings { get; set; }
    }
}