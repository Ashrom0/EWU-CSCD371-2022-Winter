using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTest
    {
        [TestMethod]
        public void Import_SeeIfFileWrittenIntoArray()
        {
            SampleData SampleData = new();
            Assert.IsTrue(SampleData.CsvRows.Count() == 50);
            Assert.IsTrue(SampleData.CsvRows.Contains("12,Vince,Dee,vdeeb@japanpost.jp,98027 Ridgeview Lane,Houston,TX,67224"));
            Assert.IsTrue(SampleData.CsvRows.ElementAt(11) == "12,Vince,Dee,vdeeb@japanpost.jp,98027 Ridgeview Lane,Houston,TX,67224");
        }

        public void GetUniqueSortedListOfStatesGivenCsvRowsSortedandUnique()
        {
            SampleData sampleData = new();
            
        }

    }
}
