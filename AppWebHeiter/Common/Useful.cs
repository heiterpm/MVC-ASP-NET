namespace AppWebHeiter.Common
{
    public class Useful
    {
        public void Login(int Id, HttpContext httpContext) => httpContext.Session.SetInt32("Id", Id);
    }
}
