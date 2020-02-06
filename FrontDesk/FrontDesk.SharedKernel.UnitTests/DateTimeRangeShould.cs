using System;
using FluentAssertions;
using Xunit;

namespace FrontDesk.SharedKernel.UnitTests
{
    public class DateTimeRangeShould
    {
        private DateTime _testStartDate = new DateTime(2014, 1, 1, 9, 0, 0);

        [Fact]
        public void ThrowExceptionIfStartDateEqualsEndDate() =>
            new Action(() => new DateTimeRange(_testStartDate, _testStartDate))
                .Should().Throw<ArgumentException>();


    }
}
