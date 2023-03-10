using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAppWebAPI_HIENLTH.Data;
using MyAppWebAPI_HIENLTH.Models;
using MyAppWebAPI_HIENLTH.Services;

namespace MyAppWebAPI_HIENLTH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaisController : ControllerBase
    {
        private readonly ILoaiReponsitory _loaiReponsitory;

        public LoaisController(ILoaiReponsitory loaiReponsitory) 
        {
            _loaiReponsitory = loaiReponsitory;
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            try
            {
                return Ok(_loaiReponsitory.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var data = _loaiReponsitory.GetById(id);
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, LoaiVM loai)
        {
            if(id != loai.MaLoai)
            {
                return BadRequest();
            }
            try
            {
                _loaiReponsitory.Update(loai);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _loaiReponsitory.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult Add(LoaiModel loai)
        {
            try
            {
                
                return Ok(_loaiReponsitory.Add(loai));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
