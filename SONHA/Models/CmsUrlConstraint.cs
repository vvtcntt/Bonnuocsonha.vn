using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace SONHA.Models
{
    public class CmsUrlConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            SONHAContext db = new SONHAContext();
            if (values[parameterName] != null)
            {
                var tag = values[parameterName].ToString();
                return db.tblGroupProducts.Any(p => p.Tag == tag);
            }
            return false;
        }
    }
}