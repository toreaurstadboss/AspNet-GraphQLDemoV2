using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace AspNet_GraphQLDemoV2.Common.Types.Models
{
    public class Mountain
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? County { get; set; }

        public string? Municipality { get; set; }

        public string OfficialName { get; set; } = null!;

        public double MetresAboveSeaLevel { get; set; }

        public double PrimaryFactor { get; set; }

        public string? Comments { get; set; }

        public string? ReferencePoint { get; set; }      

    }
}
