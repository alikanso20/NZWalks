using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        public NZWalksDbContext dbContext { get; }
        public IMapper mapper { get; }

        public SQLWalkRepository(NZWalksDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAscending = true)
        {
            //return await dbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();
            var walks = dbContext.Walks.Include("Difficulty").Include("Region").AsQueryable();
            if(!string.IsNullOrWhiteSpace(filterOn) && !string.IsNullOrWhiteSpace(filterQuery))
            {
                if(filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                    walks = walks.Where(x=> x.Name.Contains(filterQuery));
            }

            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x => x.Name);
                }
                else if (sortBy.Equals("LengthInKm", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(x => x.LengthInKm) : walks.OrderByDescending(x => x.LengthInKm);
                }
            }

            return await walks.ToListAsync();
        }

        public async Task<Walk> CreateWalkAsync(Walk walk)
        {
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();

            return walk;
        }

        public async Task<Walk?> DeleteWalkAsync(Guid id)
        {
            var existingWalk = await dbContext.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(x => x.Id == id);
            if (existingWalk == null)
                return null;

            dbContext.Walks.Remove(existingWalk);
            await dbContext.SaveChangesAsync();
            return existingWalk;
        }


        public async Task<Walk?> GetWalkByIdAsync(Guid id)
        {
            return await dbContext.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk?> UpdateWalkAsync(Guid id, Walk walk)
        {
            var existingWalk = await dbContext.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(x => x.Id == id);
            if(existingWalk == null)
                return null;

            existingWalk.Name = walk.Name;
            existingWalk.LengthInKm = walk.LengthInKm;
            existingWalk.RegionId = walk.RegionId;
            existingWalk.DifficultyId = walk.DifficultyId;
            existingWalk.Description = walk.Description;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;

            await dbContext.SaveChangesAsync();
            return existingWalk;
        }
    }
}
