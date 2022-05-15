using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void ListComparisonTest()
        {
            List<int> dbList = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };
            List<int> list = new List<int>()
            {
                8, 9, 10, 21, 22
            };

            List<int> saveList = list.Where(x => !dbList.Exists(y => y == x)).ToList(); //count 2
            List<int> updateList = list.Where(x => dbList.Exists(y => x == y)).ToList();

            List<int> expectedSaveList = new List<int>()
            {
                21, 22
            };
            List<int> expectedUpdateList = new List<int>()
            {
                8, 9, 10
            };

            bool test = expectedSaveList.Equals(saveList);

            Assert.True(expectedSaveList.SequenceEqual(saveList));
            Assert.True(expectedUpdateList.SequenceEqual(updateList));
            Assert.Equal(saveList.Count + updateList.Count, list.Count);

        }
    }
}

