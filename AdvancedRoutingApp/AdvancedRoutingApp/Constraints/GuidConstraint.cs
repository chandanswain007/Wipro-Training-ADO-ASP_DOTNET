using Microsoft.AspNetCore.Routing;

namespace AdvancedRoutingApp.Constraints
{
    public class GuidConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (values.TryGetValue(routeKey, out var value) && value is string stringValue)
            {
                return Guid.TryParse(stringValue, out _);
            }
            return false;
        }
    }
}