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

        [TestCase("", 0)]
        [TestCase("Peter",-1)]
        [TestCase("Peter", 1)]
        [TestCase("Peter,Maria,Ivan", -1)]
        [TestCase("Peter,Maria,Ivan", 3)]
        [TestCase("Peter,Maria,Ivan", 150)]
        public void Test_Collection_GetByInvalidIndex(string data, int index)
        {
            var coll = new Collection<string>(data.Split(",", StringSplitOptions.RemoveEmptyEntries));

            Assert.That(() => coll[index], Throws.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}