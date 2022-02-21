using Microsoft.AspNetCore.Mvc;
using Trilogy.ActivityReporter.BLL.Interfaces;

namespace Trilogy.ActivityReporter.API.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly IActivityService _activityService;
        public BaseController(IActivityService activityService)
        {
            _activityService = activityService;
        }

    }
}