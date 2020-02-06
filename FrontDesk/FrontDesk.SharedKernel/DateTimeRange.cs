using System;
namespace FrontDesk.SharedKernel
{
    public class DateTimeRange : ValueObject<DateTimeRange>
    {
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }

        public DateTimeRange(DateTime start, DateTime end)
        {
            Guard.ForPrecedesDate(start, end, "start");
            Start = start;
            End = end;
        }

        public DateTimeRange(DateTime start, TimeSpan duration) : this(start, start.Add(duration))
        {
        }

        protected DateTimeRange() { }

        public int DurationInMinutes() => (End - Start).Minutes;

        public DateTimeRange NewEnd(DateTime newEnd) => new DateTimeRange(this.Start, newEnd);

        public DateTimeRange NewDuration(TimeSpan newDuration) => new DateTimeRange(Start, newDuration);

        public DateTimeRange NewStart(DateTime newStart) => new DateTimeRange(newStart, this.End);

        public static DateTimeRange CreateOneDayRange(DateTime day) => new DateTimeRange(day, day.AddDays(1));

        public static DateTimeRange CreateOneWeekRange(DateTime startDay) => new DateTimeRange(startDay, startDay.AddDays(7));

        public bool Overlaps(DateTimeRange dateTimeRange) => this.Start < dateTimeRange.End &&
                this.End > dateTimeRange.Start;
    }
}
