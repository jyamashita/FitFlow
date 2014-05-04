using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitFlow.Models.Service
{
    public class LoginFormsModel
    {
        /*
         * Forms認証
         */
        public string Id { get; set; }

        public string Password { get; set; }
    }

    public class LoginWindowsModel
    {
        /*
         * windows認証
         */
        public string Alias { get; set; }

        public string Domain { get; set; }

        public string FullName
        { get
            {
                if (!string.IsNullOrEmpty(this.Domain))
                    return this.Domain + "\\" + this.Alias;
                else
                    return this.Alias;
            }
        }

        public LoginWindowsModel(string user)
        {
            if (user.Contains("\\")) {
                var userSet = user.Split('\\');
                this.Domain = userSet[0];
                this.Alias = userSet[1];
            }
            else {
                this.Alias = user;
            }
        }
    }
}