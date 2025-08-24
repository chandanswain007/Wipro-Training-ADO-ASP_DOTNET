// Constraints/ValidCategoryConstraint.cs
using ECommerceApp.Services;
using System.Linq;

namespace ECommerceApp.Constraints
{
    public class ValidCategoryConstraint : IRouteConstraint
    {
        // 👇 This is the CORRECT signature to fix CS0535
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            // Ensure httpContext and its services are not null
            if (httpContext == null) return false;

            var productService = httpContext.RequestServices.GetRequiredService<ProductService>();

            // The variable 'validCategories' is declared only ONCE here to fix CS0136
            var validCategories = productService.GetCategories();

            if (values.TryGetValue(routeKey, out var value))
            {
                var category = value?.ToString();

                if (string.IsNullOrEmpty(category))
                {
                    return false;
                }

                // The .Contains() method now works because of 'using System.Linq;'
                return validCategories.Contains(category, StringComparer.OrdinalIgnoreCase);
            }

            return false;
        }
    }
}