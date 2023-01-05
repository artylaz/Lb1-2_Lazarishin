namespace Lb1_2_Lazarishin.TaxonLibrary
{
    public static class Calculation
    {
        public static List<Taxon> FindTaxa(List<Vector> vectors, double R)
        {
            if (vectors != null && vectors.Count != 0)
            {
                var taxa = new List<Taxon>
                {
                    new Taxon()
                };
                taxa[0].Vectors.Add(vectors[0]);
                vectors.Remove(vectors[0]);

                for (int i = 0; i < taxa.Count; i++)
                {
                    var addVectors = new List<Vector>();
                    for (int j = 0; j < taxa[i].Vectors.Count; j++)
                    {
                        for (int k = 0; k < vectors.Count; k++)
                        {
                            var r = FindDistance(taxa[i].Vectors[j], vectors[k]);
                            if (r == -1)
                                return null;

                            if (r < R)
                            {
                                addVectors.Add(vectors[k]);
                            }
                        }

                        if (addVectors.Count > 0)
                        {
                            taxa[i].Vectors.AddRange(addVectors);
                            for (int c = 0; c < addVectors.Count; c++)
                            {
                                vectors.Remove(addVectors[c]);
                            }
                            addVectors.Clear();
                        }
                    }

                    if (vectors.Count == 0)
                    {
                        break;
                    }
                    else
                    {
                        var newTaxon = new Taxon();
                        newTaxon.Vectors.Add(vectors[0]);

                        taxa.Add(newTaxon);
                        vectors.Remove(vectors[0]);
                    }
                }

                return taxa;
            }
            else
                return null;
        }
        public static double FindDistance(Vector vector1, Vector vector2)
        {
            if (vector1 == null || vector1 == null)
                return -1;

            double result = 0;

            if (vector1.Values.Count == vector2.Values.Count)
            {
                for (int i = 0; i < vector1.Values.Count; i++)
                {
                    result += Math.Pow(vector1.Values[i] - vector2.Values[i], 2);
                }

                return Math.Sqrt(result);
            }
            else
                return -1;
        }
    }
}
