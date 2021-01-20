using System;
using System.Collections.Generic;
using System.Text;

namespace TamaguchiBL.Models
{
    
    public partial class Player
    {
        public void FeedAnimal(ActivityType at)
        {
            //write the activity
            Activity activity = new Activity()
            {
                ActivityTypeId = at.ActivityTypeId,
                //Add more logic here!!
                AnimalWeight = this.ActiveAnimalNavigation.AnimalWeight + at.WeightFactor * this.ActiveAnimalNavigation.AnimalWeight,
                LcstatusId = this.ActiveAnimalNavigation.LcstatusId,
                HealthStatusId = this.ActiveAnimalNavigation.HealthStatusId
            };

            //update the animal
            this.ActiveAnimalNavigation.AnimalWeight = activity.AnimalWeight;
            this.ActiveAnimalNavigation.Activity.Add(activity);
        }

    }
}
