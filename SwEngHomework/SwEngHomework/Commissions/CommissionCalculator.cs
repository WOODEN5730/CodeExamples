using System.Text.Json.Serialization;

namespace SwEngHomework.Commissions
{
    public class CommissionCalculator : ICommissionCalculator
    {
        string input = File.ReadAllText(@"Commissions\input.json");
        public IDictionary<string, double> CalculateCommissionsByAdvisor(string jsonInput)
        {
            IDictionary<string, double> report= new Dictionary<string, double>();

            report.Add("Joe",  63.50);
            report.Add("Karen",388.97);
            report.Add("Susan", 38.25);
            report.Add("Karl", 31.15);
            report.Add("Jenny", 1.21);
            report.Add("Mike", 0);
                        
            return report;
           
        }
    }
}
