using DevFramework.Core.CrossCuttingConcerns.Logging;
using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

// Performans testeleri için hangi metodun ne kadar sürede çalışacağını gösteren ve bizim belirlediğimiz sürenin
// üstünde çalışan metotları loglayacak kısım bunu da business -> assemblyinfo'da kullanacağız.

namespace DevFramework.Core.Aspects.Postsharp.PerformanceAspects
{
    [Serializable]
    public class PerformanceCounterAspect:OnMethodBoundaryAspect
    {
        private int _interval;
        [NonSerialized]
        private Stopwatch _stopwatch;

        

        public PerformanceCounterAspect(int interval = 5)
        {
            _interval = interval;
        }
        public override void RuntimeInitialize(MethodBase method)
        {
            _stopwatch = Activator.CreateInstance<Stopwatch>();
            base.RuntimeInitialize(method);
        }
        public override void OnEntry(MethodExecutionArgs args)
        {
            _stopwatch.Start();
            base.OnEntry(args);
        }
        public override void OnExit(MethodExecutionArgs args)
        {
            _stopwatch.Stop();
            if(_stopwatch.Elapsed.TotalSeconds>_interval)
            {
                //burası şimdilik basit yapıldı ama istersek loglama, kendimize mail atma gibi şeyler yapabiliriz.
                Debug.WriteLine("Performance: {0}.{1}-->>{2}", args.Method.DeclaringType.FullName, args.Method.Name, _stopwatch.Elapsed.TotalSeconds);
            }
            _stopwatch.Reset();
            base.OnExit(args);
        }
    }
}
