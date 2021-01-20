using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamaguchiBL.Models;

namespace TamaguchiWebAPI.DataTransferObjects
{
    public class AnimalDTO
    {
        public int AnimalId { get; set; }
        public string AnimalName { get; set; }
        public int PlayerId { get; set; }
        public double AnimalWeight { get; set; }
        public DateTime BirthDate { get; set; }
        public int HungryLevel { get; set; }
        public int HygieneLevel { get; set; }
        public int HappinessLevel { get; set; }
        
        public AnimalDTO() { }
        public AnimalDTO(PlayerAnimals a)
        {
            AnimalId = a.AnimalId;
            AnimalName = a.AnimalName;
            PlayerId = a.PlayerId;
            AnimalWeight = a.AnimalWeight;
            BirthDate = a.BirthDate;
            HungryLevel = a.HungryLevel;
            HygieneLevel = a.HygieneLevel;
            HappinessLevel = a.HappinessLevel;
        }
    }
}
