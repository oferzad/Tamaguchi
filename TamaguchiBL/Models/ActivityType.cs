using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TamaguchiBL.Models
{
    public partial class ActivityType
    {
        public ActivityType()
        {
            Activity = new HashSet<Activity>();
        }

        [Key]
        [Column("ActivityTypeID")]
        public int ActivityTypeId { get; set; }
        [StringLength(100)]
        public string ActivityName { get; set; }
        [Column("CategoryID")]
        public int? CategoryId { get; set; }
        public double WeightFactor { get; set; }
        public double HygieneFactor { get; set; }
        public double HapinessFactor { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty(nameof(ActivityCategory.ActivityType))]
        public virtual ActivityCategory Category { get; set; }
        [InverseProperty("ActivityType")]
        public virtual ICollection<Activity> Activity { get; set; }
    }
}
