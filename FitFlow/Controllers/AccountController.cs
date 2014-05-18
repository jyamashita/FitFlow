using FitFlow.Models;
using FitFlow.Models.FitFlow;
using FitFlow.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FitFlow.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return this.View();
        }

        //
        // POST: /User/Login
        [HttpPost]
        public ActionResult Login(LoginFormsModel model, string returnUrl)
        {
            using (var dbc = new FitFlowEntities()) {
                var user = dbc.UserView.FirstOrDefault(u => u.Id == model.Id && u.Password == model.Password);
                if (user != null) {
                    // ユーザー認証 成功
                    FormsAuthentication.SetAuthCookie(model.Id, true);
                    Session["LoginUser"] = user;
                    return this.Redirect(returnUrl ?? "/");
                }
                else {
                    // ユーザー認証 失敗
                    this.ModelState.AddModelError(string.Empty, "指定されたユーザー名またはパスワードが正しくありません。");
                    return this.View(model);
                }
            }
        }

        //
        // POST: /User/Logout
        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return this.Redirect("/");
        }
	}
}