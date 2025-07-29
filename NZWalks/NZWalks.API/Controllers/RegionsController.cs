using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            var regionsDomain = await regionRepository.GetAllAsync();
            return Ok(mapper.Map<List<RegionDto>>(regionsDomain));
        }

        [HttpGet]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> GetRegionById([FromRoute] Guid Id)
        {
            var region = await regionRepository.GetRegionByIdAsync(Id);
            if (region == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<RegionDto>(region));
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewRegion([FromBody] AddRegionRequestDto input)
        {
            if (ModelState.IsValid)
            {
                var regionDomainModel = mapper.Map<Region>(input);

                regionDomainModel = await regionRepository.AddRegionAsync(regionDomainModel);

                var regionsDto = mapper.Map<RegionDto>(regionDomainModel);

                return CreatedAtAction(nameof(GetRegionById), new { id = regionDomainModel.Id }, regionsDto);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid Id, [FromBody] UpdateRegionRequestDto input)
        {
            if (ModelState.IsValid)
            {
                var regionDomainModel = mapper.Map<Region>(input);

                regionDomainModel = await regionRepository.UpdateRegionAsync(Id, regionDomainModel);
                if (regionDomainModel == null)
                    return NotFound();

                return Ok(mapper.Map<RegionDto>(regionDomainModel));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid Id)
        {
            var regionDomainModel = await regionRepository.DeleteRegionAsync(Id);
            if (regionDomainModel == null)
                return NotFound();

            return Ok(mapper.Map<RegionDto>(regionDomainModel));
        }
    }
}
