using System;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontDesk.Web.Pages.Shared
{
    public class PageModelBase : PageModel
    {
        protected readonly IMediator Mediator;

        public string SortOrder { get; set; }

        public PageModelBase(IMediator mediator) =>
            Mediator = mediator;
    }
}
