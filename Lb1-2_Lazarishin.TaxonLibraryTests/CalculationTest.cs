using Lb1_2_Lazarishin.TaxonLibrary;
using NUnit.Framework;

namespace Lb1_2_Lazarishin.TaxonLibraryTests
{
    public class CalculationTest
    {
        [Test]
        public void FindTaxaTest()
        {
            //arrange
            var vectors = new List<Vector>()
            {
               new Vector {Name = "Вектор 1", Values = new List<double>{2, 2} },
               new Vector {Name = "Вектор 2", Values = new List<double>{1, 3} },
               new Vector {Name = "Вектор 3", Values = new List<double>{2, 3} },
               new Vector {Name = "Вектор 4", Values = new List<double>{2, 4} },
               new Vector {Name = "Вектор 5", Values = new List<double>{3, 4} },
               new Vector {Name = "Вектор 6", Values = new List<double>{2, 5} },
               new Vector {Name = "Вектор 7", Values = new List<double>{6, 1} },
               new Vector {Name = "Вектор 8", Values = new List<double>{5, 2} },
               new Vector {Name = "Вектор 9", Values = new List<double>{6, 2} },
               new Vector {Name = "Вектор 10", Values = new List<double>{7, 2} },
               new Vector {Name = "Вектор 11", Values = new List<double>{5, 1} },
               new Vector {Name = "Вектор 12", Values = new List<double>{7, 3} },
               new Vector {Name = "Вектор 13", Values = new List<double>{5, 4} },
               new Vector {Name = "Вектор 14", Values = new List<double>{5, 5} },
            };
            double R = 2;

            var expected = new List<Taxon>
            {
                new Taxon
                {
                    Vectors = new List<Vector>
                    {
                        new Vector {Name = "Вектор 1", Values = new List<double>{2, 2} },
                        new Vector {Name = "Вектор 2", Values = new List<double>{1, 3} },
                        new Vector {Name = "Вектор 3", Values = new List<double>{2, 3} },
                        new Vector {Name = "Вектор 4", Values = new List<double>{2, 4} },
                        new Vector {Name = "Вектор 5", Values = new List<double>{3, 4} },
                        new Vector {Name = "Вектор 6", Values = new List<double>{2, 5} },
                    }
                },
                new Taxon
                {
                    Vectors = new List<Vector>
                    {
                        new Vector {Name = "Вектор 7", Values = new List<double>{6, 1} },
                        new Vector {Name = "Вектор 8", Values = new List<double>{5, 2} },
                        new Vector {Name = "Вектор 9", Values = new List<double>{6, 2} },
                        new Vector {Name = "Вектор 10", Values = new List<double>{7, 2} },
                        new Vector {Name = "Вектор 11", Values = new List<double>{5, 1} },
                        new Vector {Name = "Вектор 12", Values = new List<double>{7, 3} },
                    }
                },
                new Taxon
                {
                    Vectors = new List<Vector>
                    {
                        new Vector {Name = "Вектор 13", Values = new List<double>{5, 4} },
                        new Vector {Name = "Вектор 14", Values = new List<double>{5, 5} },
                    }
                }
            };

            //act
            var actual = Calculation.FindTaxa(vectors, R);

            bool equal = true;
            if (expected.Count == actual.Count)
            {
                for (int i = 0; i < expected.Count; i++)
                {
                    if (expected[i].Vectors.Count != actual[i].Vectors.Count)
                    {
                        equal = false; break;
                    }
                    for (int j = 0; j < expected[i].Vectors.Count; j++)
                    {
                        if (expected[i].Vectors[j].Values.Count != actual[i].Vectors[j].Values.Count)
                        {
                            equal = false; break;
                        }
                        for (int k = 0; k < expected[i].Vectors[j].Values.Count; k++)
                        {
                            if (expected[i].Vectors[j].Values[k] != actual[i].Vectors[j].Values[k])
                                equal = false;
                        }
                    }
                }
            }
            else
                equal = false;

            //assert
            Assert.That(equal, Is.True);


        }

        [Test]
        public void FindDistanceTest()
        {
            //arrange
            Vector vector1 = new() { Name = "Вектор 1", Values = new List<double> { 2, 2 } };
            Vector vector2 = new() { Name = "Вектор 2", Values = new List<double> { 1, 3 } };
            double expected = 1.41;

            //act
            var actual = Calculation.FindDistance(vector1, vector2);

            //assert
            Assert.That(actual, Is.EqualTo(expected).Within(2));

        }
    }
}