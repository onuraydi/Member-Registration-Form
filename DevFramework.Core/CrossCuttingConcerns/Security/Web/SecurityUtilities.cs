using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace DevFramework.Core.CrossCuttingConcerns.Security.Web
{
    public class SecurityUtilities
    {
        public Identity FormsAuthTicketToIdentity(FormsAuthenticationTicket ticket)
        {
            var identity = new Identity 
            {
                Id = SetId(ticket),
                Name = SetName(ticket),
                Email = SetEmail(ticket),
                Roles = SetRoles(ticket),
                FirstName = SetFirsName(ticket),
                LastName = SetLastName(ticket),
                AuthenticationType = SetAuthType(),
                IsAuthenticated = SetIsAuthenticated()
            };
            return identity;
        }

        private string SetAuthType()
        {
            return "Forms";
        }

        private bool SetIsAuthenticated( )
        {
            return true;
        }

        private string SetFirsName(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return data[2];
        }

        private string SetLastName(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return data[3];  // AuthenticationHelper classındaki CreateAuthTags metodunda lastname'in indexi 3 old. için
        }

        private string[] SetRoles(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            string[] roles = data[1].Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries);
            return roles;
        }

        private string SetEmail(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return data[0];
        }

        private string SetName(FormsAuthenticationTicket ticket)
        {
            return ticket.Name;
        }

        private Guid SetId(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return new Guid(data[4]);
        }
    }
}
