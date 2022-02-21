using Microsoft.AspNetCore.Mvc;
using Trilogy.ActivityReporter.API.Controllers;
using Trilogy.ActivityReporter.BLL.Interfaces;
using Trilogy.ActivityReporter.DataModels.Models;
using Xunit;

namespace Trilogy.ActivityReporter.API.Tests
{
    public class ActivityControllerTests
    {
        private readonly IActivityService _activityService;
        public ActivityControllerTests(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [Fact]
        public void Post_Positive_Case()
        {
            var controller = new ActivityController(_activityService);

            var result = controller.Post("TestKey", new DataModels.Models.ValueModel { Value = 20 });
            Assert.IsAssignableFrom<OkResult>(result);
        }

        [Fact]
        public void Post_Negative_Case()
        {
            var controller = new ActivityController(_activityService);

            var result = controller.Post("TestKey", null);
            Assert.IsAssignableFrom<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Get_Negative_Case()
        {
            var controller = new ActivityController(_activityService);

            var result = controller.Get("RandomKey");
            Assert.IsAssignableFrom<NotFoundObjectResult>(result);
        }

        [Fact]
        public void Get_After_Single_Add()
        {
            var controller = new ActivityController(_activityService);

            var post = controller.Post("TestKey", new ValueModel { Value = 20 });
            Assert.IsAssignableFrom<OkResult>(post);

            var result = controller.Get("TestKey");
            Assert.IsAssignableFrom<OkObjectResult>(result);
            
            var value = result as OkObjectResult;
            Assert.NotNull(value?.Value);
            
            var sum = value?.Value as ValueModel;
            Assert.Equal(20, sum?.Value);
        }

        [Fact]
        public void Get_After_Multiple_Adds()
        {
            var controller = new ActivityController(_activityService);

            var post1 = controller.Post("TestKey", new ValueModel { Value = 20 });
            Assert.IsAssignableFrom<OkResult>(post1);


            var post2 = controller.Post("TestKey", new ValueModel { Value = 30 });
            Assert.IsAssignableFrom<OkResult>(post2);


            var post3 = controller.Post("TestKey", new ValueModel { Value = 40 });
            Assert.IsAssignableFrom<OkResult>(post3);

            var result = controller.Get("TestKey");
            Assert.IsAssignableFrom<OkObjectResult>(result);

            var value = result as OkObjectResult;
            Assert.NotNull(value?.Value);

            var sum = value?.Value as ValueModel;
            Assert.Equal(90, sum?.Value);
        }

        [Fact]
        public void Get_After_Multiple_Key_Adds()
        {
            var controller = new ActivityController(_activityService);

            var post1 = controller.Post("TestKey1", new ValueModel { Value = 20 });
            Assert.IsAssignableFrom<OkResult>(post1);

            var post2 = controller.Post("TestKey1", new ValueModel { Value = 30 });
            Assert.IsAssignableFrom<OkResult>(post2);

            var post3 = controller.Post("TestKey2", new ValueModel { Value = 40 });
            Assert.IsAssignableFrom<OkResult>(post3);

            var post4 = controller.Post("TestKey2", new ValueModel { Value = 50 });
            Assert.IsAssignableFrom<OkResult>(post4);

            var post5 = controller.Post("TestKey3", new ValueModel { Value = 60 });
            Assert.IsAssignableFrom<OkResult>(post5);

            var post6 = controller.Post("TestKey3", new ValueModel { Value = 70 });
            Assert.IsAssignableFrom<OkResult>(post6);

            var result1 = controller.Get("TestKey1");
            Assert.IsAssignableFrom<OkObjectResult>(result1);

            var value1 = result1 as OkObjectResult;
            Assert.NotNull(value1?.Value);

            var sum1 = value1?.Value as ValueModel;
            Assert.Equal(50, sum1?.Value);

            var result2 = controller.Get("TestKey2");
            Assert.IsAssignableFrom<OkObjectResult>(result2);

            var value2 = result2 as OkObjectResult;
            Assert.NotNull(value2?.Value);

            var sum2 = value2?.Value as ValueModel;
            Assert.Equal(90, sum2?.Value);

            var result3 = controller.Get("TestKey3");
            Assert.IsAssignableFrom<OkObjectResult>(result3);

            var value3 = result3 as OkObjectResult;
            Assert.NotNull(value3?.Value);

            var sum3 = value3?.Value as ValueModel;
            Assert.Equal(130, sum3?.Value);
        }

        [Fact]
        public void Get_After_Single_Add_Double_Number()
        {
            var controller = new ActivityController(_activityService);

            var post = controller.Post("TestKey", new ValueModel { Value = 20.15 });
            Assert.IsAssignableFrom<OkResult>(post);

            var result = controller.Get("TestKey");
            Assert.IsAssignableFrom<OkObjectResult>(result);

            var value = result as OkObjectResult;
            Assert.NotNull(value?.Value);

            var sum = value?.Value as ValueModel;
            Assert.Equal(20, sum?.Value);
        }
    }
}