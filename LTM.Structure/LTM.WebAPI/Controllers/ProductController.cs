using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LTM.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LTM.WebAPI.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    public class ProductController : Controller
    {
        private IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.GetAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetWithCurrentPrice()
        {
            var result = await _service.GetWithPrice(DateTime.Today);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetWithCurrentPriceAtReferenceDate(DateTime referenceDate)
        {
            var result = await _service.GetWithPrice(referenceDate);
            return Ok(result);
        }

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
