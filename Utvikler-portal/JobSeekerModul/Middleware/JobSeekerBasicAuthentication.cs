using System;

namespace JobSeekerModul.Middleware;

public class JobSeekerBasicAuthentication : IMiddleware
{
    public JobSeekerBasicAuthentication()
    {
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context.Request.Path.StartsWithSegments("/api/Hello") &&
                    context.Request.Method == "GET")
        {
            await next(context);
            return;
        }
    }
    private string DecodeBase64String(string base64string)
    {
        byte[] base64bytes = System.Convert.FromBase64String(base64string);
        string usrname_and_password = System.Text.Encoding.UTF8.GetString(base64bytes);
        return usrname_and_password;
    }
}

