using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TamaguchiBL.Models
{
    public partial class Activity
    {
        [Key]
        [Column("AnimalID")]
        public int AnimalId { get; set; }
        [Key]
        [Column(TypeName = "datetime")]
        public DateTime ActivityDate { get; set; }
        [Column("ActivityTypeID")]
        public int ActivityTypeId { get; set; }
        public double AnimalWeight { get; set; }
        public int HungryLevel { get; set; }
        public int HygieneLevel { get; set; }
        public int HappinessLevel { get; set; }
        [Column("LCStatusID")]
        public int LcstatusId { get; set; }
        [Column("HealthStatusID")]
        public int HealthStatusId { get; set; }
        public int HealthStatusLevel { get; set; }

        [ForeignKey(nameof(ActivityTypeId))]
        [InverseProperty("Activity")]
        public virtual ActivityType ActivityType { get; set; }
        [ForeignKey(nameof(AnimalId))]
        [InverseProperty(nameof(PlayerAnimals.Activity))]
        public virtual PlayerAnimals Animal { get; set; }
        [ForeignKey(nameof(HealthStatusId))]
        [InverseProperty("Activity")]
        public virtual HealthStatus HealthStatus { get; set; }
        [ForeignKey(nameof(LcstatusId))]
        [InverseProperty(nameof(LifeCycleStatus.Activity))]
        public virtual LifeCycleStatus Lcstatus { get; set; }
    }
}
