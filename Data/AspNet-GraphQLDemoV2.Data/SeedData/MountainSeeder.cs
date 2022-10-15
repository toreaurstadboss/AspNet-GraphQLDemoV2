using AspNet_GraphQLDemoV2.Common.Types.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Data.SeedData
{
    public static class MountainSeeder
    {

        public static List<Mountain> GetMountainInfos()
        {
            string jsonData = File.ReadAllText("Kommunetopper.json");
            var mountains = JsonConvert.DeserializeObject<List<Mountain>>(jsonData);
            //mountains.ForEach(mnt =>
            //{
            //    mnt.CalculatedMetresAboveSeaLevel = mnt.CalculateMetresAboveSeaLevel;
            //    mnt.CalculatedPrimaryFactor = mnt.CalculatePrimaryFactor;

            //});
            return mountains;
        }


    }
}
