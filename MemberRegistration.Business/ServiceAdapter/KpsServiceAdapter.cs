using MemberRegistration.Entities.Concrete;
using MemberRegistration.Business.KpsServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.Business.ServiceAdapter
{
    public class KpsServiceAdapter : IKpsService
    {
        public bool ValidateUser(Member member)
        {
            KPSPublicSoapClient client = new KPSPublicSoapClient();
            return client.TCKimlikNoDogrula(Convert.ToInt64(member.TcNo),
                member.FirstName.ToUpper(),member.LastName.ToUpper(),Convert.ToInt32(member.DateOfBirth));

        }
    }
}
