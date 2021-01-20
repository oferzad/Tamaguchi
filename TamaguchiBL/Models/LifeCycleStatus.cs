using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TamaguchiBL.Models
{
    public partial class LifeCycleStatus
    {
        public LifeCycleStatus()
        {
            Activity = new HashSet<Activity>();
            PlayerAnimals = new HashSet<PlayerAnimals>();
        }

        [Key]
        [Column("StatusID")]
        public int StatusId { get; set; }
        [StringLength(100)]
        public string StatusName { get; set; }
        public int? TimeSpanInSec { get; set; }

        [InverseProperty("Lcstatus")]
        public virtual ICollection<Activity> Activity { get; set; }
        [InverseProperty("Lcstatus")]
        public virtual ICollection<PlayerAnimals> PlayerAnimals { get; set; }
    }
}
