using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using System.Data;

namespace WebApiDemo.Controller
{
    public class WebapiController : ApiController
    {
        WebapiDAL.WebapiDAL objWebapiDal = new WebapiDAL.WebapiDAL();

        public DataSet Getrecord()
        {
            DataSet ds = objWebapiDal.GetRecordFromDb();
            return ds;
        }
    }
}
