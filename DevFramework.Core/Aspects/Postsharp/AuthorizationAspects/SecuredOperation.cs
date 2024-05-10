using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

// bu classı product managerda hangi metoda hangi rol erişebilecek şeklinde kullanabiliriz ya da bir rol her metoda
// ulaşabilecekse bunu assebmly seviyesinde kullanabiliriz.
namespace DevFramework.Core.Aspects.Postsharp.AuthorizationAspects
{
    [Serializable]
    public class SecuredOperation:OnMethodBoundaryAspect  // metodun hemen başında çalışacağı için bunu kullanıyoruz
    {
        public string Roles { get; set; }

        // metoda girdiğinmiz zaman
        public override void OnEntry(MethodExecutionArgs args)
        {
            string[] roles = Roles.Split(',');
            bool isAuthorized = false;
            for (int i = 0; i < roles.Length; i++)
            {
                if (System.Threading.Thread.CurrentPrincipal.IsInRole(roles[i]))
                {
                    isAuthorized = true;
                }
            }
            
            if(isAuthorized==false)
            {
                throw new SecurityException("You are not authorized!");
            }
        }
    }
}
