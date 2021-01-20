using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TamaguchiBL.Models;
using TamaguchiWebAPI.DataTransferObjects;

namespace TamaguchiWebAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class TamaguchiController : ControllerBase
    {
        #region Add connection to the db context using dependency injection
        TamaguchiContext context;
        public TamaguchiController(TamaguchiContext context)
        {
            this.context = context;
        }
        #endregion
        [Route("Login")]
        [HttpGet]
        public PlayerDTO Login([FromQuery] string email, [FromQuery] string pass)
        {
            Player p = context.Login(email, pass);

            //Check user name and password
            if (p != null)
            {
                PlayerDTO pDTO = new PlayerDTO(p);

                HttpContext.Session.SetObject("player", pDTO);

                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return pDTO;
            }
            else
            {
                
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;
            }
        }

        [Route("GetAnimals")]
        [HttpGet]
        public List<AnimalDTO> GetAnimals()
        {
            PlayerDTO pDto = HttpContext.Session.GetObject<PlayerDTO>("player");
            //Check if user logged in!
            if (pDto != null)
            {
                Player p = context.Player.Where(pp => pp.PlayerId == pDto.PlayerId).FirstOrDefault();
                List<AnimalDTO> list = new List<AnimalDTO>();
                if (p != null)
                {
                    foreach (PlayerAnimals pa in p.PlayerAnimals)
                    {
                        list.Add(new AnimalDTO(pa));
                    }
                }
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;

                return list;
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;
            }
        }

    }
}
