namespace Lb1_2_Lazarishin.Web.Models
{
    public class Questionnaire
    {
        public Questionnaire()
        {
            ValuesToString = new List<string>();
            Values = new List<double>();
        }
        public string PersonName { get; set; }
        public List<string> ValuesToString { get; set; }
        public List<double> Values { get; set; }
    }
}
