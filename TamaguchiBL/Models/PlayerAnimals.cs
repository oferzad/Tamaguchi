using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TamaguchiBL.Models
{
    public partial class PlayerAnimals
    {
        public PlayerAnimals()
        {
            Activity = new HashSet<Activity>();
        }

        [Key]
        [Column("AnimalID")]
        public int AnimalId { get; set; }
        [Required]
        [StringLength(100)]
        public string AnimalName { get; set; }
        [Column("PlayerID")]
        public int PlayerId { get; set; }
        public double AnimalWeight { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime BirthDate { get; set; }
        public int HungryLevel { get; set; }
        public int HygieneLevel { get; set; }
        public int HappinessLevel { get; set; }
        [Column("LCStatusID")]
        public int LcstatusId { get; set; }
        [Column("LCStatusDate", TypeName = "datetime")]
        public DateTime LcstatusDate { get; set; }
        [Column("HealthStatusID")]
        public int HealthStatusId { get; set; }
        public int HealthStatusLevel { get; set; }

        [ForeignKey(nameof(HealthStatusId))]
        [InverseProperty("PlayerAnimals")]
        public virtual HealthStatus HealthStatus { get; set; }
        [ForeignKey(nameof(LcstatusId))]
        [InverseProperty(nameof(LifeCycleStatus.PlayerAnimals))]
        public virtual LifeCycleStatus Lcstatus { get; set; }
        [ForeignKey(nameof(PlayerId))]
        [InverseProperty("PlayerAnimals")]
        public virtual Player PlayerNavigation { get; set; }
        [InverseProperty("ActiveAnimalNavigation")]
        public virtual Player Player { get; set; }
        [InverseProperty("Animal")]
        public virtual ICollection<Activity> Activity { get; set; }
    }
}
