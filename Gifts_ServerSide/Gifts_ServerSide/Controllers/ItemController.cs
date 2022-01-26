using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Gifts_ServerSide.Models;

namespace Gifts_ServerSide.Controllers
{
    public class ItemController : ApiController
    {

        // POST api/<controller> 
        [HttpPost]
        public HttpResponseMessage Post(Items item)
        {
            int num = item.Insert();
            if (num == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.PreconditionFailed, "Faild to post item");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "success");
            }
        }
    }
}
