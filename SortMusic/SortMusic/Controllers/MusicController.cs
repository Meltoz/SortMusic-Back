using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAO;
using BuisnessObject;

namespace SortMusic.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class MusicController : Controller
    {
        [HttpGet]
        [Route("all")]
        public IActionResult Recuperer_ListeMusique()
        {
            List<Music> musics = new MusicDAO().All();

           return Ok(musics);
        }

        [HttpPost]
        [Route("save")]
        public IActionResult Sauvegarder_Music([FromBody]Music music)
        {
            if(music != null)
            {
                new MusicDAO().SaveMusic(music);
                return NoContent();
            }
            else
            {
                return BadRequest();
            }

            
        }
    }
}