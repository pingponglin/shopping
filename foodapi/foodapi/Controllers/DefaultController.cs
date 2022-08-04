using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace foodapi.Controllers
{
    public class DefaultController : ApiController
    {
        [HttpGet]
        public string Post(string ss)
        {
            return ss;
        }
    }
}
