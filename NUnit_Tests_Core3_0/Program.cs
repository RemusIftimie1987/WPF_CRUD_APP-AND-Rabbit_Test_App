using System;
using NUnit.Framework;
//using Lab_08_TDD_Collections;
using Lab_09_Rabbit_Test;


namespace NUnit_Tests_Core3_0
{

    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RunThisTest()
        {
            // Arrange (data)
            // Act (run test)

            // Assert (true/false ie pass/fail)
            Assert.AreEqual(true, true);
        }

        #region Rabbit GrowthTest
        [TestCase(3, 7, 8)]
        [TestCase(2, 3, 4)]
        public void RabbitGrowthTest(int totalYears, int expectedRabbitAge, int expectedRabbitCount)
        {
            //Arrange

            //Act
            // Tuple (int NAME,int NAME)
            (int actualCumulativeAge, int actualRabbitCount) = Rabbit_Collection.MultiplyRabbits(totalYears);

           Assert.AreEqual(expectedRabbitAge, actualCumulativeAge);
           Assert.AreEqual(expectedRabbitCount, actualRabbitCount);
        }
        [TestCase(4,4,2)]
        [TestCase(6,9,4)]
        [TestCase(8,18,7)]
        [TestCase(2,2,1)]
        #endregion
        public void RabbitGrowthAfterThreeYears
            (int totalYears, int expectedRabbitAge, int expectedRabbitCount)
        {
            // Tuple (int NAME,int NAME)
            (int actualCumulativeAge, int actualRabbitCount) = Rabbit_Collection.MultiplyRabbitsAfterAgeThree(totalYears);

            // Assert
            Assert.AreEqual(expectedRabbitAge, actualCumulativeAge);
            Assert.AreEqual(expectedRabbitCount, actualRabbitCount);
        }

        
    }



}
