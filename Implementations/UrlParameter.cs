using Trainify.Interfaces;

namespace Trainify.Implementations
{
    public class UrlParameter : IConfigurableParameter
    {
        public string Name { get; }
        public string Type { get; } = "URL";

        public UrlParameter(string name)
        {
            Name = name;
        }
    }
}
