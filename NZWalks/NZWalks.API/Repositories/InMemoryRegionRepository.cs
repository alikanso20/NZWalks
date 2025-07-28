using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class InMemoryRegionRepository : IRegionRepository
    {
        public async Task<List<Region>> GetAllAsync()
        {
            return new List<Region>
            {
                new Region()
                {
                    Id = Guid.NewGuid(),
                    Code = "SAM",
                    Name = "Sameer's Region"
                }
            };
        }

        Task<Region> IRegionRepository.AddRegionAsync(Region region)
        {
            throw new NotImplementedException();
        }

        Task<Region?> IRegionRepository.DeleteRegionAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<List<Region>> IRegionRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Region?> IRegionRepository.GetRegionByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<Region?> IRegionRepository.UpdateRegionAsync(Guid id, Region region)
        {
            throw new NotImplementedException();
        }
    }
}
