using AspNet_GraphQLDemoV2.Common.Types.Models;

namespace AspNetGraphQLDemoV2.Server.GraphQL.Types.Subscriptions
{
    public class MountainSubscriptions
    {

        [Subscribe]
        public MountainCommentUpdatedInfo? CommentUpdated([EventMessage] Mountain? mountain) => new MountainCommentUpdatedInfo
        {
            Id = mountain?.Id,
            OfficialName = mountain?.OfficialName,
            Comments = mountain?.Comments
        };

        public class MountainCommentUpdatedInfo
        {
            public int? Id { get; set; }
            public string? OfficialName { get; set; }
            public string? Comments { get; set; }
        }

    }
}
