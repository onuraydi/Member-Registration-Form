using FluentValidation;
using NHibernate.Classic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.CrossCuttingConcerns.Validation.FluentValidation
{
    public class ValidatorTool
    {
        public static void FluentValidate(IValidator validator,object entity)
        {
            var context = new ValidationContext<object>(entity);  // Bu kısımda hata olabilir
            var result = validator.Validate(context);  // buraya eski sürümlerde direkt entity yazabilirdik ancak 9.0
                                                       // sürümünden sonra bu kaldırılmış ve hata veriyor
            if(result.Errors.Count > 0)
            {
                throw new ValidationException(result.Errors);  // validationException fluentvalidationdan gelmeli buna dikkat!
            }
        }
    }
}
