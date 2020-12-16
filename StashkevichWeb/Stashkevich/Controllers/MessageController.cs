using Stashkevich.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using Stashkevich.Providers;

namespace Stashkevich.Controllers
{
    public class MessageController : ApiController
    {

        public class Message
        {
            public string text { get; set; }
            public int reciever { get; set; }
        };

        [HttpPost]
        [Authorize]
        public HttpResponseMessage SendMessage([FromBody]Message message)
        {
            stashkevichEntities db = new stashkevichEntities();
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var Name = ClaimsPrincipal.Current.Identity.Name;
            var sender = db.GetUsers().FirstOrDefault(x => x.UserName == Name).id;
            DateTime date = DateTime.Now;
            db.CreateMessage(sender, message.reciever, message.text + " FROM: " + Name, date);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        [Authorize]
        public string GetMyMessage()
        {
            stashkevichEntities db = new stashkevichEntities();
            db.Configuration.LazyLoadingEnabled = false;
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var Name = ClaimsPrincipal.Current.Identity.Name;
            var im = db.GetUsers().FirstOrDefault(x => x.UserName == Name).id;
            return JsonConvert.SerializeObject(db.Messages.OrderBy(x => x.date).Where(x => x.id_receiver == im));
        } 
        
        [HttpGet]
        [Authorize]
        public string GetMyStat()
        {
            stashkevichEntities db = new stashkevichEntities();
            db.Configuration.LazyLoadingEnabled = false;
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var Name = ClaimsPrincipal.Current.Identity.Name;
            var im = db.GetUsers().FirstOrDefault(x => x.UserName == Name).id;

            Stat stat = new Stat
            {
                recv = db.Messages.Where(x => x.id_receiver == im).Count(),
                send = db.Messages.Where(x => x.id_sender == im).Count()
            };

            return JsonConvert.SerializeObject(stat);
        }
    }
}
