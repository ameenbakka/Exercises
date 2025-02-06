namespace WebApplication2_new.Middleware
{
        public class Cm
        {
            private readonly RequestDelegate _next;
            public Cm(RequestDelegate next)
            {
                _next = next;
            }
            public async Task Invoke(HttpContext context)
            {
                Console.WriteLine("Cm - Before Request");
                await _next(context);
                Console.WriteLine("Cm After");
            }
        }

}
