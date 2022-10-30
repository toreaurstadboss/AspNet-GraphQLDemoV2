﻿using AspNet_GraphQLDemoV2.Common.Types.Models;
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

        [UsePaging(MaxPageSize = 1000,IncludeTotalCount = true)]
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
