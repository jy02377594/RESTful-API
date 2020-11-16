using LXP.api.Entities;
using LXP.api.Services;
using System;
using Xunit;

namespace lxpTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var employee = new Employee { 
               FirstName = "XiaoPeng"
            };
            Assert.Equal("XiaoPeng",employee.FirstName);
            Assert.Contains("A", employee.FirstName);
        }
    }
}
