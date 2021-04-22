using Microsoft.AspNetCore.Mvc;
using PromoCodeService.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PromoCodeService.Helpers
{
	public static class ControllerExtension
	{
        public static async Task<IActionResult> Paginate<T>(this ControllerBase controller, IQueryable<T> source)
        {
            // TODO Move pagination settings into separate source
            int pageSize, page;
            int maxPageSize = 100;
            int minPageSize = 1;
            int defaultPageSize = 10;
            var httpContext = controller.HttpContext;
            if (
                !int.TryParse(httpContext.Request.Query["pageSize"], out pageSize) ||
                pageSize > maxPageSize ||
                pageSize < minPageSize)
            {
                pageSize = defaultPageSize;
            }
            if (!int.TryParse(httpContext.Request.Query["page"], out page))
            {
                page = 1;
            }


            var list = await Pagination<T>.CreateAsync(source, page, pageSize);
            if (list.Count > 0)
            {
                return controller.Ok(new PaginatedResponse<T>(list));
            }

            return controller.NoContent();
        }

        public static string GetUserId(this ControllerBase controller)
        {
            var identity = controller.HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                return identity.FindFirst(ClaimTypes.Name).Value;
            }

            return String.Empty;
        }
    }
}
