using AcademyG.Week6.TestFinale.Core.Entities;
using AcademyG.Week6.TestFinale.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyG.Week6.TestFinale.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdineController : ControllerBase
    {

        private readonly IGestionaleBL mainBL;

        public OrdineController(IGestionaleBL mainBL)
        {
            this.mainBL = mainBL;
        }

        [HttpGet]
        public ActionResult GetOrdini()
        {
            var result = mainBL.FetchOrdini();
            return Ok(result.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult GetOrderBy(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID");

            var result = mainBL
                .FetchOrdini(o => o.Id == id)
                .FirstOrDefault();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public ActionResult PostOrder([FromBody] Ordine ordine)
        {
            if (ordine == null)
                return BadRequest("Invalid Order");

            var result = mainBL
                .CreateOrdine(ordine);

            if (!result)
                return BadRequest();

            return CreatedAtAction(
                "GetOrderBy",
                new { id = ordine.Id },
                ordine);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Ordine ordine)
        {
            if (ordine == null || id != ordine.Id)
                return BadRequest("Invalid Order");

            var result = mainBL
                .EditOrdine(ordine);

            if (!result)
                return BadRequest();

            return Ok(ordine);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID");

            var ordine = mainBL
                .FetchOrdini(o => o.Id == id)
                .FirstOrDefault();

            if (ordine == null)
                return NotFound("Order cannot be found");

            var result = mainBL
                .DeleteOrdine(ordine);

            if (!result)
                return BadRequest();

            return Ok();
        }
    }
}
