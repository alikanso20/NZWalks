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

        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            var regionsDomain = await regionRepository.GetAllAsync();
            var regionsDto = new List<RegionDto>();

            foreach (var regionDomain in regionsDomain)
            {
                regionsDto.Add(new RegionDto()
                {
                    Id = regionDomain.Id,
                    Name = regionDomain.Name,
                    Code = regionDomain.Code,
                    RegionImageUrl = regionDomain.RegionImageUrl,
                });
            }
            return Ok(regionsDto);
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

            var regionDto = new RegionDto()
            {
                Id = region.Id,
                Name = region.Name,
                Code = region.Code,
                RegionImageUrl = region.RegionImageUrl,
            };
            return Ok(regionDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewRegion([FromBody] AddRegionRequestDto input)
        {
            var regionDomainModel = new Region()
            {
                Name = input.Name,
                Code = input.Code,
                RegionImageUrl = input.RegionImageUrl,
            };

            regionDomainModel = await regionRepository.AddRegionAsync(regionDomainModel);

            var regionsDto = new RegionDto()
            {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
                Code = regionDomainModel.Code,
                RegionImageUrl = regionDomainModel.RegionImageUrl,
            };

            return CreatedAtAction(nameof(GetRegionById), new { id = regionDomainModel.Id }, regionsDto);
        }

        [HttpPut]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid Id, [FromBody] UpdateRegionRequestDto input)
        {
            var regionDomainModel = new Region()
            {
                Code = input.Code,
                Name = input.Name,
                RegionImageUrl = input.RegionImageUrl,
            };

            regionDomainModel = await regionRepository.UpdateRegionAsync(Id, regionDomainModel);
            if (regionDomainModel == null)
                return NotFound();

            var regionDto = new RegionDto()
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl,
            };
            return Ok(regionDto);
        }

        [HttpDelete]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid Id)
        {
            var regionDomainModel = await regionRepository.DeleteRegionAsync(Id);
            if (regionDomainModel == null)
                return NotFound();

            var regionDto = new RegionDto()
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl,
            };
            return Ok(regionDto);
        }
    }
}
