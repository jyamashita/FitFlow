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

namespace FitFlow.Controllers
{
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

            if (this.Client == null) {
                FormsAuthentication.SignOut();
                Session.Clear();
            }
            else {
                this.Dbc = new FitFlowEntities();
                this.Dbc.Database.Log = (mess) => { };
                this.Dbc.Configuration.AutoDetectChangesEnabled = false;

                this.Client = new ActivitiRestClient(Settings.Default.ActivitiRestUrl,
                    this.LoginUser.Id, this.LoginUser.ActivitiPassword);
            }
        }

        protected override void OnActionExecuted(ActionExecutedContext aec)
        {
            base.OnActionExecuted(aec);
        }
	}
}