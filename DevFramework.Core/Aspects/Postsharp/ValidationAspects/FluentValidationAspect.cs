using DevFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using FluentValidation;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.Aspects.Postsharp
{
    [Serializable]
    public class FluentValidationAspect: OnMethodBoundaryAspect
    {
        Type _validatiorType;

        public FluentValidationAspect(Type validatorType)
        {
            _validatiorType = validatorType;
        }
        public override void OnEntry(MethodExecutionArgs args)  // Metoda girdiğimzdeki hatalar için kullanıldı
        {
            var validator = (IValidator)Activator.CreateInstance(_validatiorType);
            var entityType = _validatiorType.BaseType.GetGenericArguments()[0];  // 1 tane var onun indexi 0 olduğundan 0 girdik
            var entities = args.Arguments.Where(t=>t.GetType() == entityType);   // ToList yapmak gerekebilir
                                                                                 // 
            foreach ( var entity in entities )
            {
                ValidatorTool.FluentValidate(validator, entity);
            }
        }
    }
}
