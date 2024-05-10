using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net;
using log4net.Core;
using log4net.Layout;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Layout
{
    public class JsonLayout : LayoutSkeleton
    {
        public override void ActivateOptions()
        {

        }

        public override void Format(TextWriter writer, LoggingEvent loggingEvent)
        {
            var logEvent = new SerializableLogEvent(loggingEvent);

            var json = JsonConvert.SerializeObject(logEvent);  // buraya 2. parametre olarak format eklemek gerekebilir
                                                               // Formatting.Indented şeklinde
            writer.WriteLine(json);
        }
    }
}
