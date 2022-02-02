using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace WebAPI.Controllers
{

    public class BaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator
        {
            get
            {
                return _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());
            }
        }
    }
}