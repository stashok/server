using Newtonsoft.Json;
using Stashkevich.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Stashkevich.Controllers
{
    public class UserController : ApiController
    {

        public class Users
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public int isAdmin { get; set; }
        };

        [HttpPost]
        public HttpResponseMessage CreateUser([FromBody] Users user)
        {
            stashkevichEntities db = new stashkevichEntities();
            db.CreateUser(user.UserName, user.Password, user.isAdmin);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [Authorize]
        [HttpGet]
        public string GetUsers()
        {
            stashkevichEntities db = new stashkevichEntities();
            return JsonConvert.SerializeObject(db.GetUsers());
        }
    }
}
