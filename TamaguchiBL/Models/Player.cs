using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TamaguchiBL.Models
{
    public partial class Player
    {
        public Player()
        {
            PlayerAnimals = new HashSet<PlayerAnimals>();
        }

        [Key]
        [Column("PlayerID")]
        public int PlayerId { get; set; }
        [Required]
        [StringLength(100)]
        public string PlayerName { get; set; }
        [Required]
        [StringLength(100)]
        public string PlayerFamilyName { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime BirthDate { get; set; }
        [Required]
        [StringLength(10)]
        public string Pswd { get; set; }
        public int? ActiveAnimal { get; set; }

        [ForeignKey(nameof(ActiveAnimal))]
        [InverseProperty("Player")]
        public virtual PlayerAnimals ActiveAnimalNavigation { get; set; }
        [InverseProperty("PlayerNavigation")]
        public virtual ICollection<PlayerAnimals> PlayerAnimals { get; set; }
    }
}
