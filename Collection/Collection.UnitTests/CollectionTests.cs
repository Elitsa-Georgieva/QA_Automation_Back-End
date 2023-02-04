using Collections;

namespace Collection.UnitTests
{
    public class CollectionTests
    {
        

        [TestCase("Peter,Maria,Ivan", 0, "Peter")]
        public void Test_Collection_GetByValidIndex(string data, int index, string expected)
        {
            var coll = new Collection<string>(data.Split(","));

            var actual = coll[index];

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}