using AspNet_GraphQLDemoV2.Common.Types.Models;
using AspNet_GraphQLDemoV2.Data;
using Microsoft.EntityFrameworkCore;

namespace AspNet_GraphQLDemoV2.Server.GraphQL.Types.Queries
{
    public class MountainQueries
    {
        //private readonly DbContextOptions<MountainDbContext> _options;

        //public MountainQueries(DbContextOptions<MountainDbContext> options)
        //{
        //    _options = options;
        //}

        [UseFiltering]
        [UseSorting]
        public async Task<List<Mountain>> GetMountains([Service] MountainDbContext mountainDb)
        {
            return await mountainDb.Mountains.ToListAsync();
        }

        /// <summary>
        /// Returns a list of queryable that can project mountain DTO (choose columns to select) 
        /// </summary>
        /// <param name="mountainDb"></param>
        /// <returns></returns>
        [UseProjection]
        public IQueryable<Mountain> GetMountainsQueryable([Service] MountainDbContext mountainDb)
        {
            return mountainDb.Mountains.Select(m => new Mountain
            {
                Id = m.Id,
                Comments = m.Comments,
                MetresAboveSeaLevel = m.MetresAboveSeaLevel,
                County = m.County,
                Municipality = m.Municipality,
                OfficialName = m.OfficialName,
                PrimaryFactor = m.PrimaryFactor,
                ReferencePoint = m.ReferencePoint
            });
        }


        /// <summary>
        /// Returns a list of queryable that can project mountain DTO (choose columns to select) 
        /// </summary>
        /// <param name="mountainDb"></param>
        /// <returns></returns>
        [UseProjection]
        public IQueryable<Mountain> GetMountainQueryable([Service] MountainDbContext mountainDb, int id)
        {
            return mountainDb.Mountains.Select(m => new Mountain
            {
                Id = m.Id,
                Comments = m.Comments,
                MetresAboveSeaLevel = m.MetresAboveSeaLevel,
                County = m.County,
                Municipality = m.Municipality,
                OfficialName = m.OfficialName,
                PrimaryFactor = m.PrimaryFactor,
                ReferencePoint = m.ReferencePoint
            }).Where(m => m.Id == id);
        }

        //[UsePaging(MaxPageSize = 250,IncludeTotalCount = true)]
        [UseOffsetPaging(MaxPageSize = 250,IncludeTotalCount = true)]
        [UseFiltering]
        [UseSorting]
        public async Task<List<Mountain>> GetMountainsPage([Service] MountainDbContext mountainDb)
        {
            return await mountainDb.Mountains.ToListAsync();
        }

        public async Task<Mountain?> GetMountain([Service] MountainDbContext mountainDb, int id)
        {
            return await mountainDb.Mountains.FindAsync(id);
        }
    }
}
