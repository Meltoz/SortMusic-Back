using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Helper;
using DAO;

namespace SortMusic.Controllers
{
    //[Produces("application/json")]
    [Route("api/[controller]")]
    public class StyleController : Controller
    {
        [HttpGet]
        [Route("all")]
        public IActionResult Recuperer_Style()
        {
            if(CstSortMusic.Instance.Styles.Count == 0)
            {
                ConfigurationDAO.GetStyle();
            }

            return Ok(CstSortMusic.Instance.Styles);
        }

        [HttpPut]
        [Route("add")]
        public IActionResult Ajouter_Style([FromQuery]string style)
        {
            if(!CstSortMusic.Instance.Styles.Contains(style) && !string.IsNullOrEmpty(style))
            {
                CstSortMusic.Instance.Styles.Add(style);
                ConfigurationDAO.SaveStyle();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("remove")]
        public IActionResult Supprimer_Style([FromQuery]string style)
        {
            if(CstSortMusic.Instance.Styles.Contains(style))
            {
                CstSortMusic.Instance.Styles.Remove(style);
                ConfigurationDAO.SaveStyle();

                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
     
}