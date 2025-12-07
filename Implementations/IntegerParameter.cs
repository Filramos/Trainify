using Trainify.Interfaces;

namespace Trainify.Implementations
{
    public class IntegerParameter : IConfigurableParameter
    {
        public string Name { get; }
        public string Type { get; } = "integer";

        public IntegerParameter(string name)
        {
            Name = name;
        }
    }
}
