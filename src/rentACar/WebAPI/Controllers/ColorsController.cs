﻿using Application.Features.Colors.Commands;
using Application.Features.Colors.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateColorCommand createColorCommand)
        {
            var result = await Mediator.Send(createColorCommand);
            return Created("", result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            var query = new GetColorListQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteColorCommand deleteColorCommand)
        {
            var result = await Mediator.Send(deleteColorCommand);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateColorCommand updateColorCommand)
        {
            var result = await Mediator.Send(updateColorCommand);
            return Ok(result);
        }
    }
}
