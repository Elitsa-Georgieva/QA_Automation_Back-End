using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownsTests
{
    public class TownsCollectionTests
    {
        [Test]
        public void Test_Constructor_EmptyConstructor()
        {
            var townCollection = new TownsCollection();
            Assert.That(townCollection.Towns.Count, Is.EqualTo(0));
            Assert.That(townCollection.ToString(), Is.Empty);
        }

        [Test]
        public void Test_Constructor_SingleTown()
        {
            var townCollection = new TownsCollection("Varna");
            Assert.That(townCollection.Towns.Count, Is.EqualTo(1));
            Assert.That(townCollection.ToString(), Is.EqualTo("Varna"));
        }

        [Test]
        public void Test_Constructor_TwoTowns()
        {
            var townCollection = new TownsCollection("Varna, Ruse");
            Assert.That(townCollection.Towns.Count, Is.EqualTo(2));
            Assert.That(townCollection.ToString(), Is.EqualTo("Varna, Ruse"));
        }

        [Test]
        public void Test_Add_AddsATownToTownCollection()
        {
            var townCollection = new TownsCollection();
            var returned = townCollection.Add("London");
            Assert.That(returned, Is.EqualTo(true));
            Assert.That(townCollection.Towns.Count, Is.EqualTo(1));
        }

        [Test]
        public void Test_Add_AddSingleTown()
        {
            var townCollection = new TownsCollection();
            var returned = townCollection.Add("Sofia");
            Assert.That(townCollection.ToString, Is.EqualTo("Sofia"));
        }

        [Test]
        public void Test_Add_AddAnEmptyStringToTownCollection()
        {
            var townCollection = new TownsCollection();
            var returned = townCollection.Add("");
            Assert.That(returned, Is.EqualTo(false));
            Assert.That(townCollection.Towns.Count, Is.EqualTo(0));
        }

        [Test]
        public void Test_Add_DuplicateTown()
        {
            var townCollection = new TownsCollection("Paris, London");
            var isAdded = townCollection.Add("Paris");
            Assert.That(townCollection.Towns.Count, Is.EqualTo(2));
            Assert.That(townCollection.ToString, Is.EqualTo("Paris, London"));
        }

        [Test]
        public void Test_Add_DuplicateTown_Alternative()
        {
            var townCollection = new TownsCollection("Paris, London");
            var isAdded = townCollection.Add("Paris");
            Assert.False(isAdded);
            
        }

        [Test]
        public void Test_RemoveAt_ValidIndex()
        {
            var townCollection = new TownsCollection("Paris, London");
            townCollection.RemoveAt(0);
            Assert.That(townCollection.Towns.Count, Is.EqualTo(1));
            Assert.That(townCollection.ToString, Is.EqualTo("London"));

        }

        [Test]
        public void Test_RemoveAt_InvalidIndex()
        {
            var townCollection = new TownsCollection("Paris, London");
            //Assert.That(townCollection.Towns.Count, Is.EqualTo(2));
            Assert.That(() => townCollection.RemoveAt(3), Throws.InstanceOf<ArgumentException>());

        }

        [Test]
        public void Test_ReverseCollection()
        {
            var townCollection = new TownsCollection("Paris, London");
            townCollection.Reverse();
            Assert.That(townCollection.ToString(), Is.EqualTo("London, Paris"));

        }

        [Test]
        public void Test_ReverseZeroTownsCollection()
        {
            var townCollection = new TownsCollection();
            townCollection.Towns = null;
            Assert.That(() => townCollection.Reverse(), Throws.InstanceOf<ArgumentNullException>());

        }

        [Test]
        public void Test_ReverseCollectionOfLessThanTwoTowns()
        {
            var townCollection = new TownsCollection("Paris");
            Assert.That(() => townCollection.Reverse(), Throws.InstanceOf<InvalidOperationException>());

        }
    }
}
