using Entities.Models;
using Repository.Extensions.Utilities;
using System.Linq.Dynamic.Core;

namespace Repository.Extensions
{
    public static class RepositoryWaterSampleExtension
    {
        public static IQueryable<WaterSample> Search(this IQueryable<WaterSample> waterSamples, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return waterSamples;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return waterSamples.Where(x => x.Color.ToLower().Contains(searchTerm)
            || x.Odor.ToLower().Contains(searchTerm));
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }

        public static IQueryable<WaterSample> Sort(this IQueryable<WaterSample> waterSamples, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return waterSamples.OrderBy(p => p.CreatedAt);

            var orderByQuery = OrderQueryBuilder.CreateOrderQuery<WaterSample>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderByQuery))
                return waterSamples.OrderBy(p => p.CreatedAt);

            return waterSamples.OrderBy(orderByQuery);
        }
    }
}
