using MountainsClientDemoV2;

namespace MountainsDemo.PresentationModels
{

    /// <summary>
    /// This class is similar to a query class model which is generated, but setters are added to be able to use it in an editable Blazorise datagrid component. 
    /// </summary>
    public class MountainItem
    {

        public MountainItem(global::System.Int32 id, global::System.String officialName, global::System.Double metresAboveSeaLevel, global::System.Double primaryFactor, global::System.String? referencePoint, global::System.String? county, global::System.String? municipality, global::System.String? comments)
        {
            Id = id;
            OfficialName = officialName;
            MetresAboveSeaLevel = metresAboveSeaLevel;
            PrimaryFactor = primaryFactor;
            ReferencePoint = referencePoint;
            County = county;
            Municipality = municipality;
            Comments = comments;
        }

        public MountainItem(IGetMountains_Mountains mountain) :
            this(mountain.Id, mountain.OfficialName, mountain.MetresAboveSeaLevel, mountain.PrimaryFactor, mountain.ReferencePoint, mountain.County, mountain.Municipality, mountain.Comments)
        {

        }

        public global::System.Int32 Id { get; set; }

        public global::System.String OfficialName { get; set; }

        public global::System.Double MetresAboveSeaLevel { get; set; }

        public global::System.Double PrimaryFactor { get; set; }

        public global::System.String? ReferencePoint { get; set; }

        public global::System.String? County { get; set; }

        public global::System.String? Municipality { get; set; }

        public global::System.String? Comments { get; set; }

      
    }

}
