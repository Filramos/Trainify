namespace Trainify.Interfaces
{
    public interface IParameterFactory
    {
        IConfigurableParameter CreateParameter(string name, string type);
        IAnalytics CreateAnalytics(string name, string type);
    }
}
