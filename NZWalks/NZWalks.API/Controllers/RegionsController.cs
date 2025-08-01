using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;
using System.Text.Json;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;
        private readonly ILogger<RegionsController> logger;

        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper, ILogger<RegionsController> logger )
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAllRegions()
        {
            logger.LogInformation("Getting all regions from the database");
            var regionsDomain = await regionRepository.GetAllAsync();
            logger.LogInformation($"Finished Getting all regions request with data: {JsonSerializer.Serialize(regionsDomain)}");
            return Ok(mapper.Map<List<RegionDto>>(regionsDomain));
        }

        [HttpGet]
        [Route("{Id:Guid}")]
        [Authorize(Roles = "Reader")]
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
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> CreateNewRegion([FromBody] AddRegionRequestDto input)
        {
            var regionDomainModel = mapper.Map<Region>(input);

            regionDomainModel = await regionRepository.AddRegionAsync(regionDomainModel);

            var regionsDto = mapper.Map<RegionDto>(regionDomainModel);

            return CreatedAtAction(nameof(GetRegionById), new { id = regionDomainModel.Id }, regionsDto);
        }

        [HttpPut]
        [Route("{Id:Guid}")]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid Id, [FromBody] UpdateRegionRequestDto input)
        {
            var regionDomainModel = mapper.Map<Region>(input);

            regionDomainModel = await regionRepository.UpdateRegionAsync(Id, regionDomainModel);
            if (regionDomainModel == null)
                return NotFound();

            return Ok(mapper.Map<RegionDto>(regionDomainModel));
        }

        [HttpDelete]
        [Route("{Id:Guid}")]
        [Authorize(Roles = "Writer, Reader")]
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid Id)
        {
            var regionDomainModel = await regionRepository.DeleteRegionAsync(Id);
            if (regionDomainModel == null)
                return NotFound();

            return Ok(mapper.Map<RegionDto>(regionDomainModel));
        }
    }
}
