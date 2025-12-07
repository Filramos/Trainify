using Trainify.Interfaces;

namespace Trainify.Implementations
{
    public class TextParameter : IConfigurableParameter
    {
        public string Name { get; }
        public string Type { get; } = "text/plain";

        public TextParameter(string name)
        {
            Name = name;
        }
    }
}
