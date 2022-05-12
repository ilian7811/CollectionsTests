using Collections;
using NUnit.Framework;
using System;
using System.Collections;
using System.Linq;

namespace Collection.Test
{
    public class Tests
    {

        //1
        [Test]
        public void Test_EmptyConstructor()
        {
            // Arange
            var nums = new Collection<int>();

            //Act

            //Assert
            Assert.AreEqual(0, nums.Count, "Collection is not empty");
            Assert.AreEqual(16, nums.Capacity, "Capasity is != 16");
        }

        //2
        [Test]
        public void Test_Collection_ConstructorSingleItem()
        {
            // Arange
            var nums = new Collection<int>(5);

            //Act

            //Assert
            Assert.That(nums.ToString(), Is.EqualTo("[5]"));
        }

        //3
        [Test]
        public void Test_Collection_ConstructorMultyItem()
        {
            // Arange
            var nums = new Collection<int>(5, 10, 15);

            //Act

            //Assert
            Assert.That(nums.ToString(), Is.EqualTo("[5, 10, 15]"));
        }

        //4
        [Test]
        public void TestCollectionCapasity()
        {
            //Arange
            var nums = new Collection<int>();

            //Act

            //Assert
            Assert.That(nums.Capacity, Is.EqualTo(16));
        }


        //5
        [Test]
        public void TestCollection_Add()
        {
            //Arange
            var nums = new Collection<int>();

            //Act
            nums.Add(60);

            //Assert
            Assert.That(nums.ToString(), Is.EqualTo("[60]"));
        }

        //6
        [Test]
        public void TestCollection_AddWithGrow()
        {
            //Arange
            var nums = new Collection<int>();
            var elements = nums.Count;
            var newElements = 0;

            //Act
            nums.Add(70);
            newElements = nums.Count;

            //Assert
            Assert.AreEqual(elements + 1, newElements);
        }

        //7
        [Test]
        public void TestCollection_GetByIndex()
        {
            //Arange
            var names = new Collection<string>("iliyan", "viki");


            //Act
            string name1 = names[0];
            string name2 = names[1];

            //Assert
            Assert.AreEqual("iliyan", name1);
            Assert.AreEqual("viki", name2);
        }


        //8
        [Test]
        public void TestCollection_GetByInvalidIndex()
        {
            //Arange
            var names = new Collection<string>("iliyan", "viki");

            //Act

            //Assert
            Assert.That(() => { var name = names[-1]; },
            Throws.InstanceOf<ArgumentOutOfRangeException>());

            Assert.That(() => { var name = names[2]; },
            Throws.InstanceOf<ArgumentOutOfRangeException>());

            Assert.That(() => { var name = names[3]; },
            Throws.InstanceOf<ArgumentOutOfRangeException>());

            Assert.That(() => { var name = names[300]; },
            Throws.InstanceOf<ArgumentOutOfRangeException>());

        }

        //9
        [Test]
        public void TestCollection__1MilionItems()
        {
            //Arange
            const int itemsCount = 1000000;
            var nums = new Collection<int>();

            //Act
            nums.AddRange(Enumerable.Range(1, itemsCount).ToArray());

            //Asert
            Assert.That(nums.Count, Is.EqualTo(itemsCount));
            Assert.That(nums[itemsCount - 2].ToString, Is.EqualTo("999999"));
            Assert.That(nums[0].ToString, Is.EqualTo("1"));
        }

        //10
        [Test]
        public void TestColle2ction__1MilionItems()
        {
            //Arange
            var nums = new Collection<int>();
            var maxNum = 1000;
            var insertedValue = 99;
            var insertedPosition = 10;


            //Act
            nums.AddRange(Enumerable.Range(1, maxNum).ToArray());
            nums.InsertAt(insertedPosition, insertedValue);

            //Asert
            Assert.That(nums[insertedPosition], Is.EqualTo(insertedValue));
        }

        //11
        [Test]
        public void TestCollection_Exchange_Items()
        {
            //Arrange
            var nums = new Collection<int>();
            var firstIndex = 4;
            var secondIndex = 6;
            //Act
            nums.AddRange(Enumerable.Range(1, 10).ToArray());
            nums.Exchange(firstIndex, secondIndex);

            //Assert
            Assert.That(nums[firstIndex], Is.EqualTo(7));
        }

        //12
        [Test]
        public void TestCollection_SetByIndex()
        {
            //Arrange
            var nums = new Collection<int>(2, 3, 4, 5);
            var addIndex = 1;
            var addNumber = 9;
            //Act
            nums.InsertAt(addIndex, addNumber);

            //Assert
            Assert.That(nums[addIndex], Is.EqualTo(addNumber));
        }

        //13
        [Test]
        public void TestCollection_SetByInvalidIndex()
        {
            //Arrange
            var nums = new Collection<int>(2, 3, 4, 5);
            var invalidNegativeIndex = -1;
            var invalidPositivetiveIndex = 4;

            //Act

            //Assert            
            Assert.That(() => { var element = nums[invalidNegativeIndex]; }, Throws.InstanceOf<ArgumentOutOfRangeException>(), "Get from invalid Negative Index exception");
            Assert.That(() => { var element = nums[invalidPositivetiveIndex]; }, Throws.InstanceOf<ArgumentOutOfRangeException>(), "Get from invalid Positivetive Index exception");
        }

        //14
        [Test]
        public void TestCollection_RemoveAtStart()
        {
            //Arrange
            var nums = new Collection<int>(2, 3, 4, 5);
            var firstItemAtPosition = 0;
            //Act
            nums.RemoveAt(firstItemAtPosition);

            //Assert            
            Assert.That(nums[firstItemAtPosition], Is.EqualTo(3));
        }

        //15
        [Test]
        public void TestCollection_RemoveAtEnd()
        {
            //Arrange
            var nums = new Collection<int>(2, 3, 4, 5);
            var lastrItemAtPosition = 3;
            //Act
            nums.RemoveAt(lastrItemAtPosition);

            //Assert            
            Assert.That(nums[lastrItemAtPosition - 1], Is.EqualTo(4));
        }

        //15
        [Test]
        public void TestCollection_RemoveAtMiddle()
        {
            //Arrange
            var nums = new Collection<int>(2, 3, 4, 5, 6);
            var midleItemAtPosition = 2;

            //Act
            nums.RemoveAt(midleItemAtPosition);

            //Assert            
            Assert.That(nums[midleItemAtPosition], Is.EqualTo(5), "Remove Middle position [2]. Expect position [3] shift left with one.");
        }

    }
}