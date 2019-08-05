using System.Web.Http;

namespace WebApiDemo.Controller
{
    // [EnableCors(origins: "htttp://mywebclient.azurewebsites.net", headers: "*", methods: "*")]

    //This below snippet is to enable cross-origin request when this service is been used by another application else it will result in error  
    //[EnableCors(origins: "htttp://parthiban.somee.com", headers: "*", methods: "*")]

    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {
        WebapiDAL.WebapiDAL objWebapiDal = new WebapiDAL.WebapiDAL();

        public int GetLoginStatus_controller()
        {
            int ds = objWebapiDal.GetLoginStatus();
            return ds;
        }

    }
}
