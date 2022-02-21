using Microsoft.AspNetCore.Mvc;
using Trilogy.ActivityReporter.BLL.Interfaces;
using Trilogy.ActivityReporter.DataModels.Models;

namespace Trilogy.ActivityReporter.API.Controllers
{
    public class ActivityController : BaseController
    {
        public ActivityController(IActivityService activityService) : base(activityService)
        {
        }


        [HttpGet("{key}/total")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(string key)
        {
            var activity = _activityService.GetActivities(key);
            if (activity == null)
            {
                return NotFound("No such key in a registry.");
            }
            return Ok(activity);
        }


        [HttpPost("{key}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(string key, [FromBody] ValueModel value)
        {
            if (value == null) return BadRequest("Parameter Value is required.");
            var result = _activityService.AddActivity(key, value);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}