using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

// Bunu uygulama boyunca hata olduğunda yapmak için business katmanındaki assemblyinfo'ya ekleyeceğiz


namespace DevFramework.Core.Aspects.Postsharp.ExceptionAspect
{
    [Serializable]
    public class ExceptionLogAspect:OnExceptionAspect
    {
        [NonSerialized]
        private LoggerService _loggerService;
        private readonly Type _loggerType;

        public ExceptionLogAspect(Type loggertype = null)
        {
            _loggerType = loggertype;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            if(_loggerType !=null)
            {
                if(_loggerType.BaseType != typeof(LoggerService))
                {
                    throw new Exception("Wrong logger Type!");
                }
                _loggerService = (LoggerService)Activator.CreateInstance(_loggerType,Type.EmptyTypes);
            }
            base.RuntimeInitialize(method);
        }

        public override void OnException(MethodExecutionArgs args)
        {
            if(_loggerService != null)
            {
                _loggerService.Error(args.Exception);
            }
        }
    }
}
