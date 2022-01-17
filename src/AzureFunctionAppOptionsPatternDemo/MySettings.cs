
namespace AzureFunctionAppOptionsPatternDemo
{
    public class MySettings
    {

        public const string SectionName = nameof(MySettings);

        public string StringValue { get; set; }

        public int NumericValue { get; set; }

    }
}
