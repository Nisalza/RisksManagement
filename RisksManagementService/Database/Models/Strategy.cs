using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RisksManagementService.Attributes;

namespace RisksManagementService.Database.Models
{
    [DataDescription("strategy", "Strategy")]
    public class Strategy
    {
        [DataDescription("id", "Id")]
        public int Id { get; set; }

        [DataDescription("description", "Description")]
        public string Description { get; set; }

        [DataDescription("strategy_type", "StrategyType")]
        public StrategyType StrategyType { get; set; }
    }
}