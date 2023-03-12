using Lift;
using NUnit.Framework;

namespace LiftTests
{
    public class LiftTests
    {
        [Test]
        public void Test_FitPeopleOnTheLiftAndGetResultWithNotEnoughSpace()
        {
            var liftSimulator = new LiftSimulator();
            int[] inputLiftState = { 0, 2, 0 };
            var actual = liftSimulator.FitPeopleOnTheLiftAndGetResult(20, inputLiftState);

            Assert.That(actual, Is.EqualTo("There isn't enough space! 10 people in a queue!\r\n4 4 4"));
        }

        [Test]
        public void Test_FitPeopleOnTheLiftAndGetResultLiftHasEmptySpaces()
        {
            var liftSimulator = new LiftSimulator();
            int[] inputLiftState = { 0, 0, 0, 0 };
            var actual = liftSimulator.FitPeopleOnTheLiftAndGetResult(15, inputLiftState);

            Assert.That(actual, Is.EqualTo("The lift has 1 empty spots!\r\n4 4 4 3"));
        }

        [Test]
        public void Test_FitPeopleOnTheLiftAndGetResultLiftIsFull()
        {
            var liftSimulator = new LiftSimulator();
            int[] inputLiftState = { 2, 4, 3 };
            var actual = liftSimulator.FitPeopleOnTheLiftAndGetResult(3, inputLiftState);

            Assert.That(actual, Is.EqualTo("All people placed and the lift if full.\r\n4 4 4"));
        }

        [Test]
        public void Test_FitPeopleOnTheLiftWithZeroPeople()
        {
            var liftSimulator = new LiftSimulator();
            int[] inputLiftState = { 2, 4, 3 };
            var actual = liftSimulator.FitPeopleOnTheLiftAndGetResult(0, inputLiftState);

            Assert.IsTrue\
        }

        

    }
}