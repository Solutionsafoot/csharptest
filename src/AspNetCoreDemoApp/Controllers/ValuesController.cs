using System;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDemoApp.Controllers
{
    public class PdfRequest
    {
        public string Email { get; set; }
    }

    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            Console.WriteLine(Request.GetDisplayUrl());
            Console.WriteLine(Request.GetEncodedUrl());

            return Ok(new[] { "value1", "value2" });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok("value");
        }

        // POST api/values/fakePDF
        [HttpPost("fakePDF")]
        public IActionResult FakePDF([FromBody] PdfRequest pdfRequest)
        {
            if (pdfRequest == null || string.IsNullOrEmpty(pdfRequest.Email))
            {
                return BadRequest("Invalid request format");
            }

            Console.WriteLine($"Received POST request at {Request.GetDisplayUrl()}");
            Console.WriteLine($"Email: {pdfRequest.Email}");

            return Ok("Post body written to console.");
        }
    }
}
