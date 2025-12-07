using Trainify.Interfaces;

namespace Trainify.Implementations
{
    public class QualitativeAnalytics : IAnalytics
    {
        public string Name { get; }
        public string Type { get; } = "qualitative";

        public QualitativeAnalytics(string name)
        {
            Name = name;
        }
    }
}
