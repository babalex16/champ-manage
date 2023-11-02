using AutoMapper;
using ChampManage.API.Entities;
using ChampManage.API.Models;
using ChampManage.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ChampManage.API.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class ChampionshipsController : ControllerBase
    {
        private readonly IChampionshipRepository _championshipRepository;
        private readonly IMapper _mapper;

        public ChampionshipsController(IChampionshipRepository championshipRepository,
                                        IMapper mapper)
        {
            _championshipRepository = championshipRepository ??
                throw new ArgumentNullException(nameof(championshipRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetChampionships()
        {
            var championships = await _championshipRepository.GetChampionshipsAsync();
            var result = _mapper.Map<IEnumerable<ChampionshipDto>>(championships);
            return Ok(result);
        }

        [HttpGet("{championshipId}", Name = "GetChampionship")]
        public async Task<IActionResult> GetChampionship(int championshipId)
        {
            var championship = await _championshipRepository.GetChampionshipByIdAsync(championshipId);

            if (championship == null)
            {
                return NotFound();
            }

            var championshipDto = _mapper.Map<ChampionshipDto>(championship);
            return Ok(championshipDto);
        }

        [HttpPost]
        [Authorize(Policy = "OrganizerOnly")]
        public async Task<ActionResult<ChampionshipDto>> CreateChampionship(
                ChampionshipForCreationDto championshipForCreationDto)
        {
            if (championshipForCreationDto == null)
            {
                return BadRequest();
            }

            var championshipToCreate = _mapper.Map<Championship>(championshipForCreationDto);

            _championshipRepository.CreateChampionship(championshipToCreate);
            await _championshipRepository.SaveChangesAsync();

            var createdChampionshipDtoToReturn = _mapper.Map<ChampionshipDto>(championshipToCreate);

            return CreatedAtRoute("GetChampionship",
                new { championshipId = createdChampionshipDtoToReturn.Id },
                createdChampionshipDtoToReturn);
        }

        [HttpDelete("{championshipId}")]
        public async Task<IActionResult> DeleteChampionship(int championshipId)
        {

            var championshipEntity = await _championshipRepository.GetChampionshipByIdAsync(championshipId);

            if (championshipEntity == null)
            {
                return NotFound();
            }

            _championshipRepository.DeleteChampionship(championshipEntity);
            await _championshipRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{championshipId}")]
        public async Task<IActionResult> PartiallyUpdateChampionship(
                int championshipId,
                JsonPatchDocument<ChampionshipForUpdateDto> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var existingChampionshipEntity = await _championshipRepository.GetChampionshipByIdAsync(championshipId);

            if (existingChampionshipEntity == null)
            {
                return NotFound();
            }

            var championshipToPatch = _mapper.Map<ChampionshipForUpdateDto>(existingChampionshipEntity);

            patchDoc.ApplyTo(championshipToPatch, ModelState);

            if (!TryValidateModel(championshipToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(championshipToPatch, existingChampionshipEntity);
            await _championshipRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
