using AspNet_GraphQLDemoV2.Common.Types.Models;
using AspNet_GraphQLDemoV2.Data;

namespace AspNet_GraphQLDemoV2.Server.GraphQL.Types.Mutations
{
    public class MountainMutations
    {

        public async Task<Mountain> AddMountain([Service] MountainDbContext mountainDb, Mountain mountainToAdd)
        {
            var mountainAdded = await mountainDb.Mountains.AddAsync(mountainToAdd);
            mountainDb.SaveChanges();
            return mountainAdded.Entity;
        }

        public async Task<Mountain?> RemoveMountain([Service] MountainDbContext mountainDb, int id)
        {
            var mountainToRemove = await mountainDb.Mountains.FindAsync(id);
            if (mountainToRemove == null)
                return null;
            var removedMountain = mountainDb.Remove(mountainToRemove);
            mountainDb.SaveChanges();
            return removedMountain.Entity;
        }

    }
}
