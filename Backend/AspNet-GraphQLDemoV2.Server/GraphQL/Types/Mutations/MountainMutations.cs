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

        public async Task<Mountain?> UpdateMountainComment([Service] MountainDbContext mountainDb, int mountainId, string comments)
        {              
            var mountainToUpdate = await mountainDb.Mountains.FindAsync(mountainId);
            if (mountainToUpdate == null)
                return null;
            mountainToUpdate.Comments = comments;
            var updatedMountain = mountainDb.Update(mountainToUpdate);
            mountainDb.SaveChanges();
            return updatedMountain.Entity;
        }

        public async Task<Mountain?> UpdateMountain([Service] MountainDbContext mountainDb, Mountain mountain)
        {
            if (mountain == null)
            {
                return null; 
            }
            var mountainToUpdate = await mountainDb.Mountains.FindAsync(mountain.Id);
            if (mountainToUpdate == null)
                return null;
            MapMountainUpdate(mountainToUpdate, mountain);
            var updatedMountain = mountainDb.Update(mountainToUpdate);
            mountainDb.SaveChanges();
            return updatedMountain.Entity;
        }

        private void MapMountainUpdate(Mountain mountainToUpdate, Mountain mountain)
        {
            mountainToUpdate.Id = mountain.Id;
            mountainToUpdate.Comments = mountain.Comments;
            mountainToUpdate.PrimaryFactor = mountain.PrimaryFactor;
            mountainToUpdate.ReferencePoint = mountain.ReferencePoint;
            mountainToUpdate.County = mountain.County;
            mountainToUpdate.OfficialName = mountain.OfficialName;
            mountainToUpdate.Municipality = mountain.Municipality;
            mountainToUpdate.MetresAboveSeaLevel = mountain.MetresAboveSeaLevel;
        }

    }
}
