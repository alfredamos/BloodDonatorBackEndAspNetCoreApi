using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BloodDonatorBackEndAspNetCoreApi.Contracts;
using BloodDonatorBackEndAspNetCoreApi.Models;

namespace BloodDonatorBackEndAspNetCoreApi.Controllers.BloodDonators
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodDonatorsController : ControllerBase
    {        
        private readonly IBloodDonatorRepository _bloodDonatorRepository;
        private readonly IMapper _mapper;

        public BloodDonatorsController(IBloodDonatorRepository bloodDonatorRepository, IMapper mapper)
        {            
            _bloodDonatorRepository = bloodDonatorRepository;
            _mapper = mapper;
        }

        // GET: api/bloodDonators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BloodDonator>>> GetBloodDonators()
        {
            try
            {
                return Ok(await _bloodDonatorRepository.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data.");
            }
            
        }

        // GET: api/bloodDonators/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<BloodDonator>> GetBloodDonator(int id)
        {
            try
            {
                return await _bloodDonatorRepository.GetById(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data.");
            }
            
        }

        // PUT: api/bloodDonators/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id:int}")]
        public async Task<ActionResult<BloodDonator>> PutBloodDonator(int id, BloodDonator bloodDonator)
        {
            try
            {
                if (id != bloodDonator.BloodDonatorId)
                {
                    return BadRequest("Id mismatch");
                }

                var bloodDonatorToUpdate = await _bloodDonatorRepository.GetById(id);
                if (bloodDonatorToUpdate == null)
                {
                    return NotFound($"bloodDonator with {id} not found.");
                }
                _mapper.Map(bloodDonator, bloodDonatorToUpdate);

                return await _bloodDonatorRepository.UpdateEntity(bloodDonatorToUpdate);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data.");
            }
            

        }

        // POST: api/bloodDonators
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BloodDonator>> PostBloodDonator(BloodDonator bloodDonator)
        {
            try
            {
                if (bloodDonator == null)
                {
                    return BadRequest("Invalid input");
                }
                var createdBloodDonator = await _bloodDonatorRepository.AddEntity(bloodDonator);
                return CreatedAtAction(nameof(GetBloodDonator), new { id = createdBloodDonator.BloodDonatorId }, createdBloodDonator);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating data.");
            }

            
        }

        // DELETE: api/bloodDonators/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<BloodDonator>> DeleteBloodDonator(int id)
        {
            try
            {
                var bloodDonatorToDelete = await _bloodDonatorRepository.GetById(id);
                if (bloodDonatorToDelete == null)
                {
                    return NotFound($"bloodDonator with {id} not found.");
                }

                return await _bloodDonatorRepository.DeleteEntity(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data.");
            }                      
        }


        // GET: api/bloodDonators/searchKey
        [HttpGet("{searchKey}")]
        public async Task<ActionResult<IEnumerable<BloodDonator>>> Search(string searchKey)
        {
            try
            {
                return Ok(await _bloodDonatorRepository.Search(searchKey));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data.");
            }

        }

    }
}
