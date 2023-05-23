using System.Text.Json.Serialization;

namespace SwEngHomework.Commissions
{
     public class Account
    {
        public string advisor { get; set; } = string.Empty;
        public int presentValue { get; set; } = 0;
    }

    public class Advisor
    {
        public string name { get; set; }
        public string level { get; set; }
    }

    public class Root
    {
        public List<Advisor> advisors { get; set; }
        public List<Account>? accounts { get; set; }
    }
    public class CommissionCalculator : ICommissionCalculator
    {
        string input = File.ReadAllText(@"Commissions\input.json");
        public IDictionary<string, double> CalculateCommissionsByAdvisor(string jsonInput)
        {
            double amountFee = 0;
            double basicPoint5 = 0.05 / 100;
            double basicPoint6 = 0.06 / 100;
            double basicPoint7 = 0.07 / 100;
            double juniorPercent = 0.25;
            double ExperiencePercent = 0.50;
            double SeniorPercent = 1.00;
            List<double> commissions = new List<double>();
            
            IDictionary<string, double> report= new Dictionary<string, double>();
            var root = JsonSerializer.Deserialize<Root>(jsonInput);
            
            foreach (Advisor a in root.advisors.ToList())
            {
                foreach (Account account in root.accounts.ToList())
                {
                    if ((a.level == "Senior") && (account.advisor == a.name))
                    {
                        if (account.presentValue < 50000)
                        {
                            amountFee = account.presentValue * basicPoint5 * SeniorPercent;
                            commissions.Add(amountFee);
                        }

                        if (account.presentValue >= 50000 && account.presentValue < 100000)
                        {
                            amountFee = account.presentValue * basicPoint6 * SeniorPercent;
                            commissions.Add(amountFee);
                        }
                        if (account.presentValue >= 100000)
                        {
                            amountFee = account.presentValue * basicPoint7 * SeniorPercent;
                            commissions.Add(amountFee);
                        }
                    }
                    else
                    {
                        if ((a.name == account.advisor) && (a.level == "Experienced"))
                        {
                            if (account.presentValue < 50000)
                            {
                                amountFee = account.presentValue * basicPoint5 * ExperiencePercent;
                                commissions.Add(amountFee);

                            }
                            if (account.presentValue >= 50000 && account.presentValue < 100000)
                            {
                                amountFee = account.presentValue * basicPoint6 * ExperiencePercent;
                                commissions.Add(amountFee);

                            }
                            if (account.presentValue >= 100000)
                            {
                                amountFee = account.presentValue * basicPoint7 * ExperiencePercent;
                                commissions.Add(amountFee);

                            }
                        }
                    }
                    if ((a.name == account.advisor) && (a.level == "Junior"))
                    {
                        var tt5 = account.presentValue < 50000 ? 1 : 0;
                        if (tt5 == 1)
                        {
                            amountFee = account.presentValue * basicPoint5 * juniorPercent;
                            commissions.Add(amountFee);
                        }

                        if (account.presentValue >= 50000 && account.presentValue < 100000)
                        {
                            amountFee = account.presentValue * basicPoint6 * juniorPercent;
                            commissions.Add(amountFee);

                        }
                        if (account.presentValue >= 100000)
                        {
                            amountFee = account.presentValue * basicPoint7 * juniorPercent;
                            commissions.Add(amountFee);
                        }
                    }
                }

                var commAmount = Math.Round(commissions.Sum(), 2);
                report.Add(a.name, commAmount);
                commissions.Clear();
            }       
                        
            return report;          
           
        }
    }
}
