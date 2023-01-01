using Lb1_2_Lazarishin.TaxonLibrary;

namespace Lb1_2_Lazarishin.Web.Models
{
    public class TaxonVM
    {
        public TaxonVM()
        {
            Taxa = new List<Taxon>();
        }
        public TaxonVM(List<Taxon> taxa)
        {
            Taxa = taxa;
        }
        public List<Taxon> Taxa { get; set; }
    }
}
