using HotChocolate.Data.Filters;
using HotChocolate.Data.Filters.Expressions;

namespace AspNetGraphQLDemoV2.Server
{
    public class FilterConventionExtensionForInvariantContainsStrings : FilterConventionExtension
    {
        protected override void Configure(IFilterConventionDescriptor descriptor)
        {
            descriptor.AddProviderExtension(new QueryableFilterProviderExtension(
                                    y => y.AddFieldHandler<QueryableStringInvariantContainsHandler>()));
        }    
    }
}
