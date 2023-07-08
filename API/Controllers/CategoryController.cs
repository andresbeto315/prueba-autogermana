using Domain.Base;
using Domain.Contracts.Application;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var data = await this._categoryService.GetAll();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseResponse<string>
                {
                    Code = System.Net.HttpStatusCode.BadRequest,
                    Message = ex.Message
                });
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var data = await this._categoryService.GetById(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseResponse<string>
                {
                    Code = System.Net.HttpStatusCode.BadRequest,
                    Message = ex.Message
                });
            }
        }
    }
}