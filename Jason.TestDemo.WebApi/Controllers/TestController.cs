namespace Jason.TestDemo.WebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Jason.TestDemo.Contracts;
    using Newtonsoft.Json;
    using Jason.TestDemo.Domain;

    [Area("TestService")]
    [Route("api/TestService/[Controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITest001Interface _test001Interface;
        public TestController(ITest001Interface test001Interface)
        {
            _test001Interface = test001Interface;
        }

        /// <summary>
        /// 测试接口001
        /// </summary>
        /// <returns></returns>
        [HttpGet("test001")]
        public async Task<List<PersonInfoDto>> DoTest()
        {
            var result = await _test001Interface.Dotest001();
            return result;
        }
    }
}
