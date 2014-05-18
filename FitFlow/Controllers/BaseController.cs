using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FitFlow.Models;
using FitFlow.Extensions;
using FitFlow.Models.Base;
using ActivitiClient.RestClients;
using FitFlow.Properties;
using FitFlow.Models.Service;
using System.Web.Security;
using FitFlow.Models.Activiti;
using FitFlow.Models.FitFlow;
using FitFlow.Filter;

namespace FitFlow.Controllers
{
    [NoClientCache]
    public class BaseController : Controller
    {
        protected ActivitiRestClient Client { get; set; }
        protected UserView LoginUser { get { return Session["LoginUser"] as UserView; } }
        protected FitFlowContext fDbc { get; set; }
        protected FitFlowEntities Dbc { get; set; }
        protected ActivitiEntities ADbc { get; set; }

        protected override void OnActionExecuting(ActionExecutingContext aec)
        {
            base.OnActionExecuting(aec);

#if !DEBUG
            if (this.LoginUser == null) {
                FormsAuthentication.SignOut();
                Session.Clear();
                aec.Result = RedirectToAction("Login", "Account", new { Area = string.Empty });
                return;
            }
#endif

            this.Dbc = new FitFlowEntities();
            this.Dbc.Database.Log = (mess) => { };
            this.Dbc.Configuration.AutoDetectChangesEnabled = false;

            this.ADbc = new ActivitiEntities();
            this.ADbc.Database.Log = (mess) => { };
            this.ADbc.Configuration.AutoDetectChangesEnabled = false;

#if DEBUG
            if (this.LoginUser == null) {
                var user = Dbc.UserView.First(u => u.Id == User.Identity.Name);
                Session["LoginUser"] = user;
            }
#endif

            this.Client = new ActivitiRestClient(Settings.Default.ActivitiRestUrl,
                this.LoginUser.Id, this.LoginUser.ActivitiPassword);

            Session["ActivitiRestUrl"] = Settings.Default.ActivitiRestUrl;
        }

        protected override void OnActionExecuted(ActionExecutedContext aec)
        {
            base.OnActionExecuted(aec);
        }
	}
}