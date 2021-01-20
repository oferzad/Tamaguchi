using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TamaguchiBL.Models
{
    public partial class TamaguchiContext
    {
        //Here write general methods to extract root objects from the database!
        public Player GetPlayerByID(int id)
        {
            Player p = this.Player.Where(p => p.PlayerId==id).FirstOrDefault();
            return p;
        }

        public ActivityType GetActivityTypeByID(int id)
        {
            ActivityType at = this.ActivityType.Single(item => item.ActivityTypeId == id);
            return at;
        }

        //Log in method. Return a player or null if not succeed!
        public Player Login(string email, string pswd)
        {
            Player p = this.Player.Where(p => p.Email==email && p.Pswd == pswd).FirstOrDefault();
            return p;
        }


    }
}
