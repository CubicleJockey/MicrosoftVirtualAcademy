using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class FooController
    {
        [HttpGet("/")]
        public string Index() => "Hello from MVC, well acutally just the C(Controller)!";

        [HttpGet("/Foo")]
        public string SomethingElse() => "Hello from Foo.";
    }
}
