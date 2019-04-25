using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Delicious_Recipes.Dal.Abstract;
using Delicious_Recipes.Dal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Delicious_Recipes.Api.Controllers
{
    public class RequestModel
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }

    public class AddModel
    {
        public string Talimatlar { get; set; }
        public string Kategoriler { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class TariflerController : ControllerBase
    {
        private readonly ITariflerRepo _context;

        public TariflerController(ITariflerRepo context)
        {
            _context = context;
        }

       
        //form
        [HttpGet]
        [Route("AllX")]
        public IActionResult All()
        {
            var model = _context.AllX();
            return new JsonResult(model);
        }


        //json
        [HttpPost]
        [Route("All")]
        public IActionResult AllJson([FromBody] RequestModel requestModel)
        {
            if (requestModel == null)
                return BadRequest();

            var model = _context.All(requestModel.PageNumber, requestModel.PageSize);

            //return JsonConvert.SerializeObject(model);

            return new JsonResult(model);
        }

       
        [HttpPost]
        [Route("Add")]
        public IActionResult Add([FromBody]Tarifler tarifler)
        {
          _context.Add(tarifler);
          return Content("İşlem başarılı");
        }

        [HttpGet]
        [Route("filtre/categories")]
        public IActionResult Categories()
        {
            var model = _context.Categories();
            return new JsonResult(model);
        }


    }
}