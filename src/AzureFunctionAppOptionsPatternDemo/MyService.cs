using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFunctionAppOptionsPatternDemo
{
    public interface IMyService
    {

        void PrintValue(ILogger logger);

        object GetJsonValue();
        
    }
    public class MyStringService : IMyService
    {

        public string Value { get; set; }

        public void PrintValue(ILogger logger)
        {
            logger.LogInformation(Value);
        }

        public object GetJsonValue()
        {
            return new { Value };
        }

    }
    public class MyIntService : IMyService
    {

        public int Value { get; set; }

        public void PrintValue(ILogger logger)
        {
            logger.LogInformation(Value.ToString());
        }

        public object GetJsonValue()
        {
            return new { Value };
        }

    }
}
