using System;
using System.Globalization;

namespace AutoFrame.AutoImplement.Attribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class AutoImplementDateTimePropertyAttribute : AutoImplementPropertyAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.DateTime"/> structure to a specified number of ticks.
        /// </summary>
        /// <param name="ticks">A date and time expressed in the number of 100-nanosecond intervals that have elapsed since January 1, 0001 at 00:00:00.000 in the Gregorian calendar. </param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="ticks"/> is less than <see cref="F:System.DateTime.MinValue"/> or greater than <see cref="F:System.DateTime.MaxValue"/>. </exception>
        public AutoImplementDateTimePropertyAttribute(long ticks)
            : base(new DateTime(ticks))
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.DateTime"/> structure to a specified number of ticks and to Coordinated Universal Time (UTC) or local time.
        /// </summary>
        /// <param name="ticks">A date and time expressed in the number of 100-nanosecond intervals that have elapsed since January 1, 0001 at 00:00:00.000 in the Gregorian calendar. </param><param name="kind">One of the enumeration values that indicates whether <paramref name="ticks"/> specifies a local time, Coordinated Universal Time (UTC), or neither.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="ticks"/> is less than <see cref="F:System.DateTime.MinValue"/> or greater than <see cref="F:System.DateTime.MaxValue"/>. </exception><exception cref="T:System.ArgumentException"><paramref name="kind"/> is not one of the <see cref="T:System.DateTimeKind"/> values.</exception>
        public AutoImplementDateTimePropertyAttribute(long ticks, DateTimeKind kind)
            : base(new DateTime(ticks, kind))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.DateTime"/> structure to the specified year, month, and day.
        /// </summary>
        /// <param name="year">The year (1 through 9999). </param><param name="month">The month (1 through 12). </param><param name="day">The day (1 through the number of days in <paramref name="month"/>). </param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="year"/> is less than 1 or greater than 9999.-or- <paramref name="month"/> is less than 1 or greater than 12.-or- <paramref name="day"/> is less than 1 or greater than the number of days in <paramref name="month"/>. </exception>
        public AutoImplementDateTimePropertyAttribute(int year, int month, int day)
            : base(new DateTime(year, month, day))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.DateTime"/> structure to the specified year, month, and day for the specified calendar.
        /// </summary>
        /// <param name="year">The year (1 through the number of years in <paramref name="calendar"/>). </param><param name="month">The month (1 through the number of months in <paramref name="calendar"/>). </param><param name="day">The day (1 through the number of days in <paramref name="month"/>). </param><param name="calendar">The calendar that is used to interpret <paramref name="year"/>, <paramref name="month"/>, and <paramref name="day"/>. </param><exception cref="T:System.ArgumentNullException"><paramref name="calendar"/> is null.</exception><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="year"/> is not in the range supported by <paramref name="calendar"/>.-or- <paramref name="month"/> is less than 1 or greater than the number of months in <paramref name="calendar"/>.-or- <paramref name="day"/> is less than 1 or greater than the number of days in <paramref name="month"/>. </exception>
        public AutoImplementDateTimePropertyAttribute(int year, int month, int day, Calendar calendar)
            : base(new DateTime(year, month, day, calendar))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.DateTime"/> structure to the specified year, month, day, hour, minute, and second.
        /// </summary>
        /// <param name="year">The year (1 through 9999). </param><param name="month">The month (1 through 12). </param><param name="day">The day (1 through the number of days in <paramref name="month"/>). </param><param name="hour">The hours (0 through 23). </param><param name="minute">The minutes (0 through 59). </param><param name="second">The seconds (0 through 59). </param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="year"/> is less than 1 or greater than 9999. -or- <paramref name="month"/> is less than 1 or greater than 12. -or- <paramref name="day"/> is less than 1 or greater than the number of days in <paramref name="month"/>.-or- <paramref name="hour"/> is less than 0 or greater than 23. -or- <paramref name="minute"/> is less than 0 or greater than 59. -or- <paramref name="second"/> is less than 0 or greater than 59. </exception>
        public AutoImplementDateTimePropertyAttribute(int year, int month, int day, int hour, int minute, int second)
            : base(new DateTime(year, month, day, hour, minute, second))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.DateTime"/> structure to the specified year, month, day, hour, minute, second, and Coordinated Universal Time (UTC) or local time.
        /// </summary>
        /// <param name="year">The year (1 through 9999). </param><param name="month">The month (1 through 12). </param><param name="day">The day (1 through the number of days in <paramref name="month"/>). </param><param name="hour">The hours (0 through 23). </param><param name="minute">The minutes (0 through 59). </param><param name="second">The seconds (0 through 59). </param><param name="kind">One of the enumeration values that indicates whether <paramref name="year"/>, <paramref name="month"/>, <paramref name="day"/>, <paramref name="hour"/>, <paramref name="minute"/> and <paramref name="second"/> specify a local time, Coordinated Universal Time (UTC), or neither.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="year"/> is less than 1 or greater than 9999. -or- <paramref name="month"/> is less than 1 or greater than 12. -or- <paramref name="day"/> is less than 1 or greater than the number of days in <paramref name="month"/>.-or- <paramref name="hour"/> is less than 0 or greater than 23. -or- <paramref name="minute"/> is less than 0 or greater than 59. -or- <paramref name="second"/> is less than 0 or greater than 59. </exception><exception cref="T:System.ArgumentException"><paramref name="kind"/> is not one of the <see cref="T:System.DateTimeKind"/> values.</exception>
        public AutoImplementDateTimePropertyAttribute(int year, int month, int day, int hour, int minute, int second, DateTimeKind kind)
            : base(new DateTime(year, month, day, hour, minute, second, kind))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.DateTime"/> structure to the specified year, month, day, hour, minute, and second for the specified calendar.
        /// </summary>
        /// <param name="year">The year (1 through the number of years in <paramref name="calendar"/>). </param><param name="month">The month (1 through the number of months in <paramref name="calendar"/>). </param><param name="day">The day (1 through the number of days in <paramref name="month"/>). </param><param name="hour">The hours (0 through 23). </param><param name="minute">The minutes (0 through 59). </param><param name="second">The seconds (0 through 59). </param><param name="calendar">The calendar that is used to interpret <paramref name="year"/>, <paramref name="month"/>, and <paramref name="day"/>. </param><exception cref="T:System.ArgumentNullException"><paramref name="calendar"/> is null. </exception><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="year"/> is not in the range supported by <paramref name="calendar"/>.-or- <paramref name="month"/> is less than 1 or greater than the number of months in <paramref name="calendar"/>.-or- <paramref name="day"/> is less than 1 or greater than the number of days in <paramref name="month"/>.-or- <paramref name="hour"/> is less than 0 or greater than 23 -or- <paramref name="minute"/> is less than 0 or greater than 59. -or- <paramref name="second"/> is less than 0 or greater than 59. </exception>
        public AutoImplementDateTimePropertyAttribute(int year, int month, int day, int hour, int minute, int second, Calendar calendar)
            : base(new DateTime(year, month, day, hour, minute, second, calendar))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.DateTime"/> structure to the specified year, month, day, hour, minute, second, and millisecond.
        /// </summary>
        /// <param name="year">The year (1 through 9999). </param><param name="month">The month (1 through 12). </param><param name="day">The day (1 through the number of days in <paramref name="month"/>). </param><param name="hour">The hours (0 through 23). </param><param name="minute">The minutes (0 through 59). </param><param name="second">The seconds (0 through 59). </param><param name="millisecond">The milliseconds (0 through 999). </param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="year"/> is less than 1 or greater than 9999.-or- <paramref name="month"/> is less than 1 or greater than 12.-or- <paramref name="day"/> is less than 1 or greater than the number of days in <paramref name="month"/>.-or- <paramref name="hour"/> is less than 0 or greater than 23.-or- <paramref name="minute"/> is less than 0 or greater than 59.-or- <paramref name="second"/> is less than 0 or greater than 59.-or- <paramref name="millisecond"/> is less than 0 or greater than 999. </exception>
        public AutoImplementDateTimePropertyAttribute(int year, int month, int day, int hour, int minute, int second, int millisecond)
            : base(new DateTime(year, month, day, hour, minute, second, millisecond))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.DateTime"/> structure to the specified year, month, day, hour, minute, second, millisecond, and Coordinated Universal Time (UTC) or local time.
        /// </summary>
        /// <param name="year">The year (1 through 9999). </param><param name="month">The month (1 through 12). </param><param name="day">The day (1 through the number of days in <paramref name="month"/>). </param><param name="hour">The hours (0 through 23). </param><param name="minute">The minutes (0 through 59). </param><param name="second">The seconds (0 through 59). </param><param name="millisecond">The milliseconds (0 through 999). </param><param name="kind">One of the enumeration values that indicates whether <paramref name="year"/>, <paramref name="month"/>, <paramref name="day"/>, <paramref name="hour"/>, <paramref name="minute"/>, <paramref name="second"/>, and <paramref name="millisecond"/> specify a local time, Coordinated Universal Time (UTC), or neither.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="year"/> is less than 1 or greater than 9999.-or- <paramref name="month"/> is less than 1 or greater than 12.-or- <paramref name="day"/> is less than 1 or greater than the number of days in <paramref name="month"/>.-or- <paramref name="hour"/> is less than 0 or greater than 23.-or- <paramref name="minute"/> is less than 0 or greater than 59.-or- <paramref name="second"/> is less than 0 or greater than 59.-or- <paramref name="millisecond"/> is less than 0 or greater than 999. </exception><exception cref="T:System.ArgumentException"><paramref name="kind"/> is not one of the <see cref="T:System.DateTimeKind"/> values.</exception>
        public AutoImplementDateTimePropertyAttribute(int year, int month, int day, int hour, int minute, int second, int millisecond, DateTimeKind kind)
            : base(new DateTime(year, month, day, hour, minute, second, millisecond, kind))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.DateTime"/> structure to the specified year, month, day, hour, minute, second, and millisecond for the specified calendar.
        /// </summary>
        /// <param name="year">The year (1 through the number of years in <paramref name="calendar"/>). </param><param name="month">The month (1 through the number of months in <paramref name="calendar"/>). </param><param name="day">The day (1 through the number of days in <paramref name="month"/>). </param><param name="hour">The hours (0 through 23). </param><param name="minute">The minutes (0 through 59). </param><param name="second">The seconds (0 through 59). </param><param name="millisecond">The milliseconds (0 through 999). </param><param name="calendar">The calendar that is used to interpret <paramref name="year"/>, <paramref name="month"/>, and <paramref name="day"/>.</param><exception cref="T:System.ArgumentNullException"><paramref name="calendar"/> is null. </exception><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="year"/> is not in the range supported by <paramref name="calendar"/>.-or- <paramref name="month"/> is less than 1 or greater than the number of months in <paramref name="calendar"/>.-or- <paramref name="day"/> is less than 1 or greater than the number of days in <paramref name="month"/>.-or- <paramref name="hour"/> is less than 0 or greater than 23.-or- <paramref name="minute"/> is less than 0 or greater than 59.-or- <paramref name="second"/> is less than 0 or greater than 59.-or- <paramref name="millisecond"/> is less than 0 or greater than 999. </exception>
        public AutoImplementDateTimePropertyAttribute(int year, int month, int day, int hour, int minute, int second, int millisecond, Calendar calendar)
            : base(new DateTime(year, month, day, hour, minute, second, millisecond, calendar))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.DateTime"/> structure to the specified year, month, day, hour, minute, second, millisecond, and Coordinated Universal Time (UTC) or local time for the specified calendar.
        /// </summary>
        /// <param name="year">The year (1 through the number of years in <paramref name="calendar"/>). </param><param name="month">The month (1 through the number of months in <paramref name="calendar"/>). </param><param name="day">The day (1 through the number of days in <paramref name="month"/>). </param><param name="hour">The hours (0 through 23). </param><param name="minute">The minutes (0 through 59). </param><param name="second">The seconds (0 through 59). </param><param name="millisecond">The milliseconds (0 through 999). </param><param name="calendar">The calendar that is used to interpret <paramref name="year"/>, <paramref name="month"/>, and <paramref name="day"/>.</param><param name="kind">One of the enumeration values that indicates whether <paramref name="year"/>, <paramref name="month"/>, <paramref name="day"/>, <paramref name="hour"/>, <paramref name="minute"/>, <paramref name="second"/>, and <paramref name="millisecond"/> specify a local time, Coordinated Universal Time (UTC), or neither.</param><exception cref="T:System.ArgumentNullException"><paramref name="calendar"/> is null. </exception><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="year"/> is not in the range supported by <paramref name="calendar"/>.-or- <paramref name="month"/> is less than 1 or greater than the number of months in <paramref name="calendar"/>.-or- <paramref name="day"/> is less than 1 or greater than the number of days in <paramref name="month"/>.-or- <paramref name="hour"/> is less than 0 or greater than 23.-or- <paramref name="minute"/> is less than 0 or greater than 59.-or- <paramref name="second"/> is less than 0 or greater than 59.-or- <paramref name="millisecond"/> is less than 0 or greater than 999. </exception><exception cref="T:System.ArgumentException"><paramref name="kind"/> is not one of the <see cref="T:System.DateTimeKind"/> values.</exception>
        public AutoImplementDateTimePropertyAttribute(int year, int month, int day, int hour, int minute, int second, int millisecond, Calendar calendar, DateTimeKind kind)
            : base(new DateTime(year, month, day, hour, minute, second, millisecond, calendar, kind))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.DateTime"/> structure to a specified number of ticks.
        /// </summary>
        /// <param name="ticks">A date and time expressed in the number of 100-nanosecond intervals that have elapsed since January 1, 0001 at 00:00:00.000 in the Gregorian calendar. </param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="ticks"/> is less than <see cref="F:System.DateTime.MinValue"/> or greater than <see cref="F:System.DateTime.MaxValue"/>. </exception>
        public AutoImplementDateTimePropertyAttribute(string memberSetKey, long ticks)
            : base(memberSetKey, new DateTime(ticks))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.DateTime"/> structure to a specified number of ticks and to Coordinated Universal Time (UTC) or local time.
        /// </summary>
        /// <param name="ticks">A date and time expressed in the number of 100-nanosecond intervals that have elapsed since January 1, 0001 at 00:00:00.000 in the Gregorian calendar. </param><param name="kind">One of the enumeration values that indicates whether <paramref name="ticks"/> specifies a local time, Coordinated Universal Time (UTC), or neither.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="ticks"/> is less than <see cref="F:System.DateTime.MinValue"/> or greater than <see cref="F:System.DateTime.MaxValue"/>. </exception><exception cref="T:System.ArgumentException"><paramref name="kind"/> is not one of the <see cref="T:System.DateTimeKind"/> values.</exception>
        public AutoImplementDateTimePropertyAttribute(string memberSetKey, long ticks, DateTimeKind kind)
            : base(memberSetKey, new DateTime(ticks, kind))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.DateTime"/> structure to the specified year, month, and day.
        /// </summary>
        /// <param name="year">The year (1 through 9999). </param><param name="month">The month (1 through 12). </param><param name="day">The day (1 through the number of days in <paramref name="month"/>). </param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="year"/> is less than 1 or greater than 9999.-or- <paramref name="month"/> is less than 1 or greater than 12.-or- <paramref name="day"/> is less than 1 or greater than the number of days in <paramref name="month"/>. </exception>
        public AutoImplementDateTimePropertyAttribute(string memberSetKey, int year, int month, int day)
            : base(memberSetKey, new DateTime(year, month, day))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.DateTime"/> structure to the specified year, month, and day for the specified calendar.
        /// </summary>
        /// <param name="year">The year (1 through the number of years in <paramref name="calendar"/>). </param><param name="month">The month (1 through the number of months in <paramref name="calendar"/>). </param><param name="day">The day (1 through the number of days in <paramref name="month"/>). </param><param name="calendar">The calendar that is used to interpret <paramref name="year"/>, <paramref name="month"/>, and <paramref name="day"/>. </param><exception cref="T:System.ArgumentNullException"><paramref name="calendar"/> is null.</exception><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="year"/> is not in the range supported by <paramref name="calendar"/>.-or- <paramref name="month"/> is less than 1 or greater than the number of months in <paramref name="calendar"/>.-or- <paramref name="day"/> is less than 1 or greater than the number of days in <paramref name="month"/>. </exception>
        public AutoImplementDateTimePropertyAttribute(string memberSetKey, int year, int month, int day, Calendar calendar)
            : base(memberSetKey, new DateTime(year, month, day, calendar))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.DateTime"/> structure to the specified year, month, day, hour, minute, and second.
        /// </summary>
        /// <param name="year">The year (1 through 9999). </param><param name="month">The month (1 through 12). </param><param name="day">The day (1 through the number of days in <paramref name="month"/>). </param><param name="hour">The hours (0 through 23). </param><param name="minute">The minutes (0 through 59). </param><param name="second">The seconds (0 through 59). </param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="year"/> is less than 1 or greater than 9999. -or- <paramref name="month"/> is less than 1 or greater than 12. -or- <paramref name="day"/> is less than 1 or greater than the number of days in <paramref name="month"/>.-or- <paramref name="hour"/> is less than 0 or greater than 23. -or- <paramref name="minute"/> is less than 0 or greater than 59. -or- <paramref name="second"/> is less than 0 or greater than 59. </exception>
        public AutoImplementDateTimePropertyAttribute(string memberSetKey, int year, int month, int day, int hour, int minute, int second)
            : base(memberSetKey, new DateTime(year, month, day, hour, minute, second))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.DateTime"/> structure to the specified year, month, day, hour, minute, second, and Coordinated Universal Time (UTC) or local time.
        /// </summary>
        /// <param name="year">The year (1 through 9999). </param><param name="month">The month (1 through 12). </param><param name="day">The day (1 through the number of days in <paramref name="month"/>). </param><param name="hour">The hours (0 through 23). </param><param name="minute">The minutes (0 through 59). </param><param name="second">The seconds (0 through 59). </param><param name="kind">One of the enumeration values that indicates whether <paramref name="year"/>, <paramref name="month"/>, <paramref name="day"/>, <paramref name="hour"/>, <paramref name="minute"/> and <paramref name="second"/> specify a local time, Coordinated Universal Time (UTC), or neither.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="year"/> is less than 1 or greater than 9999. -or- <paramref name="month"/> is less than 1 or greater than 12. -or- <paramref name="day"/> is less than 1 or greater than the number of days in <paramref name="month"/>.-or- <paramref name="hour"/> is less than 0 or greater than 23. -or- <paramref name="minute"/> is less than 0 or greater than 59. -or- <paramref name="second"/> is less than 0 or greater than 59. </exception><exception cref="T:System.ArgumentException"><paramref name="kind"/> is not one of the <see cref="T:System.DateTimeKind"/> values.</exception>
        public AutoImplementDateTimePropertyAttribute(string memberSetKey, int year, int month, int day, int hour, int minute, int second, DateTimeKind kind)
            : base(memberSetKey, new DateTime(year, month, day, hour, minute, second, kind))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.DateTime"/> structure to the specified year, month, day, hour, minute, and second for the specified calendar.
        /// </summary>
        /// <param name="year">The year (1 through the number of years in <paramref name="calendar"/>). </param><param name="month">The month (1 through the number of months in <paramref name="calendar"/>). </param><param name="day">The day (1 through the number of days in <paramref name="month"/>). </param><param name="hour">The hours (0 through 23). </param><param name="minute">The minutes (0 through 59). </param><param name="second">The seconds (0 through 59). </param><param name="calendar">The calendar that is used to interpret <paramref name="year"/>, <paramref name="month"/>, and <paramref name="day"/>. </param><exception cref="T:System.ArgumentNullException"><paramref name="calendar"/> is null. </exception><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="year"/> is not in the range supported by <paramref name="calendar"/>.-or- <paramref name="month"/> is less than 1 or greater than the number of months in <paramref name="calendar"/>.-or- <paramref name="day"/> is less than 1 or greater than the number of days in <paramref name="month"/>.-or- <paramref name="hour"/> is less than 0 or greater than 23 -or- <paramref name="minute"/> is less than 0 or greater than 59. -or- <paramref name="second"/> is less than 0 or greater than 59. </exception>
        public AutoImplementDateTimePropertyAttribute(string memberSetKey, int year, int month, int day, int hour, int minute, int second, Calendar calendar)
            : base(memberSetKey, new DateTime(year, month, day, hour, minute, second, calendar))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.DateTime"/> structure to the specified year, month, day, hour, minute, second, and millisecond.
        /// </summary>
        /// <param name="year">The year (1 through 9999). </param><param name="month">The month (1 through 12). </param><param name="day">The day (1 through the number of days in <paramref name="month"/>). </param><param name="hour">The hours (0 through 23). </param><param name="minute">The minutes (0 through 59). </param><param name="second">The seconds (0 through 59). </param><param name="millisecond">The milliseconds (0 through 999). </param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="year"/> is less than 1 or greater than 9999.-or- <paramref name="month"/> is less than 1 or greater than 12.-or- <paramref name="day"/> is less than 1 or greater than the number of days in <paramref name="month"/>.-or- <paramref name="hour"/> is less than 0 or greater than 23.-or- <paramref name="minute"/> is less than 0 or greater than 59.-or- <paramref name="second"/> is less than 0 or greater than 59.-or- <paramref name="millisecond"/> is less than 0 or greater than 999. </exception>
        public AutoImplementDateTimePropertyAttribute(string memberSetKey, int year, int month, int day, int hour, int minute, int second, int millisecond)
            : base(memberSetKey, new DateTime(year, month, day, hour, minute, second, millisecond))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.DateTime"/> structure to the specified year, month, day, hour, minute, second, millisecond, and Coordinated Universal Time (UTC) or local time.
        /// </summary>
        /// <param name="year">The year (1 through 9999). </param><param name="month">The month (1 through 12). </param><param name="day">The day (1 through the number of days in <paramref name="month"/>). </param><param name="hour">The hours (0 through 23). </param><param name="minute">The minutes (0 through 59). </param><param name="second">The seconds (0 through 59). </param><param name="millisecond">The milliseconds (0 through 999). </param><param name="kind">One of the enumeration values that indicates whether <paramref name="year"/>, <paramref name="month"/>, <paramref name="day"/>, <paramref name="hour"/>, <paramref name="minute"/>, <paramref name="second"/>, and <paramref name="millisecond"/> specify a local time, Coordinated Universal Time (UTC), or neither.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="year"/> is less than 1 or greater than 9999.-or- <paramref name="month"/> is less than 1 or greater than 12.-or- <paramref name="day"/> is less than 1 or greater than the number of days in <paramref name="month"/>.-or- <paramref name="hour"/> is less than 0 or greater than 23.-or- <paramref name="minute"/> is less than 0 or greater than 59.-or- <paramref name="second"/> is less than 0 or greater than 59.-or- <paramref name="millisecond"/> is less than 0 or greater than 999. </exception><exception cref="T:System.ArgumentException"><paramref name="kind"/> is not one of the <see cref="T:System.DateTimeKind"/> values.</exception>
        public AutoImplementDateTimePropertyAttribute(string memberSetKey, int year, int month, int day, int hour, int minute, int second, int millisecond, DateTimeKind kind)
            : base(memberSetKey, new DateTime(year, month, day, hour, minute, second, millisecond, kind))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.DateTime"/> structure to the specified year, month, day, hour, minute, second, and millisecond for the specified calendar.
        /// </summary>
        /// <param name="year">The year (1 through the number of years in <paramref name="calendar"/>). </param><param name="month">The month (1 through the number of months in <paramref name="calendar"/>). </param><param name="day">The day (1 through the number of days in <paramref name="month"/>). </param><param name="hour">The hours (0 through 23). </param><param name="minute">The minutes (0 through 59). </param><param name="second">The seconds (0 through 59). </param><param name="millisecond">The milliseconds (0 through 999). </param><param name="calendar">The calendar that is used to interpret <paramref name="year"/>, <paramref name="month"/>, and <paramref name="day"/>.</param><exception cref="T:System.ArgumentNullException"><paramref name="calendar"/> is null. </exception><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="year"/> is not in the range supported by <paramref name="calendar"/>.-or- <paramref name="month"/> is less than 1 or greater than the number of months in <paramref name="calendar"/>.-or- <paramref name="day"/> is less than 1 or greater than the number of days in <paramref name="month"/>.-or- <paramref name="hour"/> is less than 0 or greater than 23.-or- <paramref name="minute"/> is less than 0 or greater than 59.-or- <paramref name="second"/> is less than 0 or greater than 59.-or- <paramref name="millisecond"/> is less than 0 or greater than 999. </exception>
        public AutoImplementDateTimePropertyAttribute(string memberSetKey, int year, int month, int day, int hour, int minute, int second, int millisecond, Calendar calendar)
            : base(memberSetKey, new DateTime(year, month, day, hour, minute, second, millisecond, calendar))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.DateTime"/> structure to the specified year, month, day, hour, minute, second, millisecond, and Coordinated Universal Time (UTC) or local time for the specified calendar.
        /// </summary>
        /// <param name="year">The year (1 through the number of years in <paramref name="calendar"/>). </param><param name="month">The month (1 through the number of months in <paramref name="calendar"/>). </param><param name="day">The day (1 through the number of days in <paramref name="month"/>). </param><param name="hour">The hours (0 through 23). </param><param name="minute">The minutes (0 through 59). </param><param name="second">The seconds (0 through 59). </param><param name="millisecond">The milliseconds (0 through 999). </param><param name="calendar">The calendar that is used to interpret <paramref name="year"/>, <paramref name="month"/>, and <paramref name="day"/>.</param><param name="kind">One of the enumeration values that indicates whether <paramref name="year"/>, <paramref name="month"/>, <paramref name="day"/>, <paramref name="hour"/>, <paramref name="minute"/>, <paramref name="second"/>, and <paramref name="millisecond"/> specify a local time, Coordinated Universal Time (UTC), or neither.</param><exception cref="T:System.ArgumentNullException"><paramref name="calendar"/> is null. </exception><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="year"/> is not in the range supported by <paramref name="calendar"/>.-or- <paramref name="month"/> is less than 1 or greater than the number of months in <paramref name="calendar"/>.-or- <paramref name="day"/> is less than 1 or greater than the number of days in <paramref name="month"/>.-or- <paramref name="hour"/> is less than 0 or greater than 23.-or- <paramref name="minute"/> is less than 0 or greater than 59.-or- <paramref name="second"/> is less than 0 or greater than 59.-or- <paramref name="millisecond"/> is less than 0 or greater than 999. </exception><exception cref="T:System.ArgumentException"><paramref name="kind"/> is not one of the <see cref="T:System.DateTimeKind"/> values.</exception>
        public AutoImplementDateTimePropertyAttribute(string memberSetKey, int year, int month, int day, int hour, int minute, int second, int millisecond, Calendar calendar, DateTimeKind kind)
            : base(memberSetKey, new DateTime(year, month, day, hour, minute, second, millisecond, calendar, kind))
        {
        }
    }
}
