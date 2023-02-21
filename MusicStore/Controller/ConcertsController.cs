﻿using Microsoft.AspNetCore.Mvc;
using MusciStore.Dto.Request;
using MusicStore.Services.Interfaces;

namespace MusicStore.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConcertsController : ControllerBase
    {
        private readonly IConcertService _service;

        public ConcertsController(IConcertService service) {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ListAsync(string? filter, int page = 1, int rows = 10) {
            var response = await _service.ListAsync(filter, page, rows);
            return response.Success ? Ok(response) : NotFound(response);
        }

        // POST api/Concerts
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] ConcertDtoRequest request) {  //FromBody se utiliza para indicar que debe validar el dto
            var response = await _service.AddAsync(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        // GET api/Concerts/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> FindByIdAsync(int id)   {
            var response = await _service.FindByIdAsync(id);
            return response.Success ? Ok(response) : NotFound(response);
        }

        // PUT api/Concerts/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] ConcertDtoRequest request) {
            var response = await _service.UpdateAsync(id, request);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        // DELETE api/Concerts/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)        {
            var response = await _service.DeleteAsync(id);
            return response.Success ? Ok(response) : NotFound(response);
        }

        // PATCH api/Concerts/5
        [HttpPatch("{id:int}")]
        public async Task<IActionResult> FinalizeAsync(int id) {
            var response = await _service.FinalizeAsync(id);
            return response.Success ? Ok(response) : NotFound(response);
        }
    }
}
