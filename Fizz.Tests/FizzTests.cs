using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fizz.Business;
using Moq;
using NUnit.Framework;

namespace Fizz.Tests
{

    public class FizzTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void should_check_for_null_writemaps()
        {
            var fizz = new Business.Fizz(null);

            var generic = new Mock<IWriteMap>().Object;

            fizz.WriteFizz(0, null, generic);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void should_check_for_empty_writemaps()
        {
            var fizz = new Business.Fizz(null);

            var generic = new Mock<IWriteMap>().Object;

            fizz.WriteFizz(0, new List<IWriteMap>(), generic);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void should_check_for_null_generic()
        {
            var fizz = new Business.Fizz(null);

            var map = new Mock<IWriteMap>().Object;

            fizz.WriteFizz(0, new List<IWriteMap> { map }, null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void should_check_for_invalid_range()
        {
            var fizz = new Business.Fizz(null);

            var generic = new Mock<IWriteMap>().Object;

            fizz.WriteFizz(-1, new List<IWriteMap> { generic }, generic);
        }

        [TestCase(5)]
        public void should_iterate_correct_number_of_times(int count)
        {

            var fizz = new Business.Fizz(new Mock<IFizzWriter>().Object);

            var generic = new Mock<IWriteMap>().Object;

            var countMap = new Mock<IWriteMap>();

            var actualCount = 0;

            //Ensure it gets called every time.
            countMap.Setup(m => m.Write(It.IsAny<int>(), It.IsAny<IFizzWriter>())).Returns(false).Callback(() => actualCount++);

            fizz.WriteFizz(count, new List<IWriteMap> { countMap.Object }, generic);

            Assert.AreEqual(count, actualCount);
        }

        [TestCase(5)]
        public void should_call_generic_if_not_handled(int count)
        {

            var fizz = new Business.Fizz(new Mock<IFizzWriter>().Object);

            var generic = new Mock<IWriteMap>();

            int genericCount = 0;

            generic.Setup(m => m.Write(It.IsAny<int>(), It.IsAny<IFizzWriter>())).Callback(() => genericCount++);
            var countMap = new Mock<IWriteMap>();

            countMap.Setup(m => m.Write(It.IsAny<int>(), It.IsAny<IFizzWriter>())).Returns(false);

            fizz.WriteFizz(count, new List<IWriteMap> { countMap.Object }, generic.Object);

            Assert.AreEqual(count, genericCount);
        }
    }
}
