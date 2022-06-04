using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SharedGarden.API.Controllers
{
    public class HomeController : ControllerBase
    {
        private IMediator _mediator;
        
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
