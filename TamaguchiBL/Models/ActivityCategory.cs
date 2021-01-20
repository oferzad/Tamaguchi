using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TamaguchiBL.Models
{
    public partial class ActivityCategory
    {
        public ActivityCategory()
        {
            ActivityType = new HashSet<ActivityType>();
        }

        [Key]
        [Column("CategoryID")]
        public int CategoryId { get; set; }
        [StringLength(20)]
        public string CategoryName { get; set; }

        [InverseProperty("Category")]
        public virtual ICollection<ActivityType> ActivityType { get; set; }
    }
}
