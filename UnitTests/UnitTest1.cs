/******************************************************************************
* Filename    = UnitTest1.cs
*
* Author      = Syed Abdul Mateen
*
* Product     = SoftwareDesignPatterns
* 
* Project     = UnitTests
*
* Description = Unit tests for the Template Method demo.
*****************************************************************************/
using Sorter;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void BubbleSortUnitTests()
        {
            // Arrange
            int n = 5;
            string? sortingMethod = "Bubble Sort";

            // Act
            BubbleSort bubbleSort = new( n );
            bubbleSort.TemplateMethod();

            // Assert
            Assert.AreEqual(bubbleSort.sortingMethod, sortingMethod);
        }

        [TestMethod]
        public void MergeSortUnitTests()
        {
            // Arrange
            int n = 5;
            string? sortingMethod = "Merge Sort";

            // Act
            MergeSort mergeSort = new( n );
            mergeSort.TemplateMethod();

            // Assert
            Assert.AreEqual(mergeSort.sortingMethod, sortingMethod);
        }
    }
}
