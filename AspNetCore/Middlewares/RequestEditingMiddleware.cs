using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AspNetCore.Middlewares
{
    public class RequestEditingMiddleware
    {
        private RequestDelegate _requestDelegate;
        public RequestEditingMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;     
        }
        public async Task Invoke(HttpContext context)
        {
            ///ysk.com.tr/songül slaş songül path dir
            if (context.Request.Path.ToString() == "/songul")
                await context.Response.WriteAsync("hosgeldin songul");
            else
                await _requestDelegate.Invoke(context);   //asenktronik olduğu için await. Clientden gelen istek middleware e gider.  
        }
    }
}
