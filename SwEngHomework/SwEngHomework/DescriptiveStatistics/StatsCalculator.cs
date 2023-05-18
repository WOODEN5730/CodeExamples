namespace SwEngHomework.DescriptiveStatistics
{
    public class StatsCalculator : IStatsCalculator
    {
        public Stats Calculate(string semicolonDelimitedContributions)
        {
            var testString = semicolonDelimitedContributions;            
            var noDollars = RemoveDollarSigns(testString);
            var noCommas = RemoveCommas(noDollars);
            int index = 0;
            double median = 0;

            List<string> lists = (noCommas.Split(";").ToList());                   
            var totals = new Stats();

            List<double> sum = new List<double>();   
            foreach (var list in lists)
            {
                if (list.Contains("this") )
                {
                    totals.Average = 0;
                    totals.Range = 0;
                    totals.Median = 0;
                    return totals;
                }

                double num;
                bool success = double.TryParse(list, out num);
                if (success)
                {
                    sum.Add(num);
                }
               else
               {
                   sum.Sort();
                   index = sum.Count / 2;
                   totals.Average = Math.Round(sum.Average(), 2);
                   totals.Range   = totals.Range = sum.Max() - sum.Min();
                   totals.Median  = sum[index];
                   return totals;
                }                
            }

            sum.Sort();
            index = sum.Count / 2;
          
            if (sum.Count % 2 == 0)
            {
                median = (sum[index] + sum[index - 1]) / 2;
                totals.Average = Math.Round(sum.Average(), 2);
                totals.Range = sum.Max() - sum.Min();
                totals.Median = Math.Round(median, 2);
            }      
            
            return totals;   
        }
        public string RemoveDollarSigns(string input)
        {
           return input.Replace("$", string.Empty);
        }
        public string RemoveCommas(string input)
        {
            return input.Replace(",", string.Empty);
        }
        public List<string> RemoveSemiColons(string input)
        {
            return input.Split(";").ToList();
        }        
    }
}
