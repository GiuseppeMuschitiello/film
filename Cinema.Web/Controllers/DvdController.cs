using AutoMapper;
using Cinema.BLL.Interfaces;
using Cinema.BLL.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Web.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class DvdController : ControllerBase
    {
        private readonly IDvdService _dvdService;
        public DvdController(IDvdService dvdService, IMapper mapper)
        {
            _dvdService = dvdService;
        }

        [HttpGet("GetDvd")]
        public IActionResult Get(int id)
        {
            return Ok(_dvdService.GetById(id));
        }

        [HttpGet("GetAllDvds")]
        public IActionResult GetAll()
        {
            return Ok(_dvdService.GetAll());
        }

        [HttpPost("CreateDvd")]
        public IActionResult Insert(DvdModel model)
        {
            try
            {
                _dvdService.Insert(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                throw;
            }
        }

        [HttpPut("UpdateDvd")]
        public IActionResult Update(DvdModel model)
        {
            try
            {
                _dvdService.Update(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                throw;
            }
        }

        [HttpDelete("DeleteDvd")]
        public IActionResult Delete(int id)
        {
            try
            {
                _dvdService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                throw;
            }
        }
    }
}
