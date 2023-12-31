﻿using Domain.Base;
using Domain.Contracts.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var data = await this._productService.GetAll();
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
                var data = await this._productService.GetById(id);
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

        [HttpGet("code")]
        public async Task<IActionResult> GetByCode(string code)
        {
            try
            {
                var data = await this._productService.GetByCode(code);
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