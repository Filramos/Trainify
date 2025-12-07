namespace Trainify.Models
{
    public class ClientAnalytics : ClientAccessRequest
    {
        public List<QuantitativeAnalytic> QuantAnalytics { get; set; } = new();
        public List<QualitativeAnalytic> QualAnalytics { get; set; } = new();

    }
}
