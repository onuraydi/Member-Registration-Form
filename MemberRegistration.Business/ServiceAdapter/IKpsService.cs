using MemberRegistration.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.Business.ServiceAdapter
{
    public interface IKpsService
    {
        bool ValidateUser(Member member);

    }
}
