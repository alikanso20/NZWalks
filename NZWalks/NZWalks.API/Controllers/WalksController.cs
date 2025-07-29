using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private IMapper mapper { get; }
        private IWalkRepository walkRepository { get; }

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWalks()
        {
            var walksDomainModel = await walkRepository.GetAllAsync();
            return Ok(mapper.Map<List<WalkDto>>(walksDomainModel));
        }

        [HttpPost]
        public async Task<IActionResult> CreateWalk([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            if (ModelState.IsValid)
            {
                var walkdDomainModel = mapper.Map<Walk>(addWalkRequestDto);
                await walkRepository.CreateWalkAsync(walkdDomainModel);

                return Ok(mapper.Map<WalkDto>(walkdDomainModel));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> GetWalkById(Guid Id)
        {
            var walkDomainModel = await walkRepository.GetWalkByIdAsync(Id);
            if (walkDomainModel == null)
                return NotFound();

            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        [HttpPut]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> UpdateWalk([FromRoute] Guid Id, [FromBody] UpdateWalkRequestDto updateWalkRequestDto)
        {
            if (ModelState.IsValid)
            {
                var walkDomainModel = mapper.Map<Walk>(updateWalkRequestDto);
                var updatedWalk = await walkRepository.UpdateWalkAsync(Id, walkDomainModel);
                if (updatedWalk == null)
                    return NotFound();

                return Ok(mapper.Map<WalkDto>(updatedWalk));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> DeleteWalk([FromRoute] Guid Id)
        {
            var deletedWalkDomainModel = await walkRepository.DeleteWalkAsync(Id);
            if (deletedWalkDomainModel == null)
                return NotFound();

            return Ok(mapper.Map<WalkDto>(deletedWalkDomainModel));
        }
    }
}
