using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Support.Models;

namespace Support.Controllers
{

    public class ValuesController : ApiController
    {
        [HttpGet]
        [Route("supportid/{supportId}")]
        public async Task<string> TroubleShootProblem(int supportId)
        {
            var model = new SupportModel();
            return await model.retrieveSupportStringForId(supportId);
        }

        [HttpGet]
        public bool Email(EmailModel emailModel)
        {
            var model = new SupportModel();
            //return Redirect("/");
           // return View(model);
            return model.sendMail(emailModel);
        }
    }
}
