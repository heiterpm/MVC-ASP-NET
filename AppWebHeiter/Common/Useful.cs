namespace AppWebHeiter.Common
{
    public class Useful
    {
        public void SetLogin(int Id, HttpContext httpContext) => httpContext.Session.SetInt32("Id", Id);
    }
}
