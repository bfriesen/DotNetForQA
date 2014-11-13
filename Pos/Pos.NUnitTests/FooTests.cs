using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pos.NUnitTests
{
    public class FooTests
    {
        [TestCaseSource("GetQuxTestCases")]
        public void QuxReturnsBarColonBaz(Foo foo, string expectedQux)
        {
            var qux = foo.Qux;

            Assert.That(qux, Is.EqualTo(expectedQux));
        }

        private IEnumerable<TestCaseData> GetQuxTestCases()
        {
            return new TestCaseData[]
            {
                new TestCaseData(new Foo { Bar = "abc", Baz = 123 }, "abc:123"),
                new TestCaseData(new Foo { Bar = "xyz", Baz = 789 }, "xyz:789")
            };
        }
    }

    public class Foo
    {
        public string Bar { get; set; }
        public int Baz { get; set; }

        public string Qux { get { return Bar + ":" + Baz; } }

        public override string ToString()
        {
            return "[Foo{Bar:" + Bar + ",Baz:" + Baz + "}]";
        }
    }
}
