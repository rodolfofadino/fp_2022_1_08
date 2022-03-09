using fiapweb2022.core.Contexts;
using fiapweb2022.core.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fiapweb2022.api.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    //[EnableCors("Default")]
    public class TimesController : Controller
    {
        private CopaContext _context;

        public TimesController(CopaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<Time> Post(Time time)
        {
            if (ModelState.IsValid)
            {

                _context.Add(time);
                _context.SaveChanges();

                return Created($"/api/times/{time.Id}", time);
            }

            return BadRequest(ModelState);
        }


        [HttpGet]
        [ProducesResponseType(400)]
        public ActionResult<List<Time>> Get()
        {
            var times = _context.Times.ToList();

            if (!times.Any())
                return NotFound();

            return times;
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Time> Get(int id)
        {
            return _context.Times.FirstOrDefault(t => t.Id == id);
            ////pega o primeiro e se nao tiver da um exception (select top 1)
            //return _context.Times.First(t => t.Id == id);

            ////pega o primeiro e se nao tiver retorna um null (select top 1)
            //return _context.Times.FirstOrDefault(t => t.Id == id);

            ////pega top 2 e se nao tiver da um exception, se tiver mais do que 1 da uma exception (select top 2)
            //return _context.Times.Single(t => t.Id == id);

            ////pega top 2 e se nao tiver retorna null, se tiver mais do que 1 da uma exception (select top 2)
            //return _context.Times.SingleOrDefault(t => t.Id == id);
        }



        //[HttpGet]
        //[ProducesResponseType(200, Type = typeof(List<Time>))]
        //[ProducesResponseType(404)]
        //[ProducesResponseType(400)]
        //public IActionResult Get()
        //{
        //    var times = _context.Times.ToList();

        //    if(!times.Any())
        //        return NotFound();


        //    return Ok(times);
        //}

        //[HttpGet]
        //public List<Time> Get()
        //{

        //    //return NotFound();

        //    return _context.Times.ToList();
        //}
    }
}
