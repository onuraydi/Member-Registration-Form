using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using MemberRegistration.Business.Abstract;
using MemberRegistration.Business.DependencyResolver.Ninject;
using MemberRegistration.Entities.Concrete;

namespace MemberRegistration.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var memberService = InstanceFactory.GetInstance<IMemberService>();
            memberService.Add(new Member
            {
                FirstName = "Onur",
                LastName = "Aydı",
                DateOfBirth =(2004 ),
                TcNo = "18043790338",
                Email = "onuraydi@outlook.com"
            });
            Console.WriteLine("Eklendi!");
            Console.ReadLine();
        }
    }
}
