using System;
using System.Threading.Tasks;
using TensionDev.Calendar;
using Xunit;

namespace XUnitTestProjectCalendar
{
    public class UnitTestGregorian : IDisposable
    {
        private bool disposedValue;

        [Fact]
        public void TestFirstDayOfTheMonth()
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local);
            DateTime expected = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local);

            DateTime actual = Gregorian.FirstDayOfTheMonth(dateTime);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestFirstDayOfTheMonthUTC()
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime expected = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            DateTime actual = Gregorian.FirstDayOfTheMonthUTC(dateTime);

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void TestLastDayOfTheMonth()
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local);
            DateTime expected = new DateTime(1970, 1, 31, 0, 0, 0, DateTimeKind.Local);

            DateTime actual = Gregorian.LastDayOfTheMonth(dateTime);

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void TestLastDayOfTheMonthUTC()
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime expected = new DateTime(1970, 1, 31, 0, 0, 0, DateTimeKind.Utc);

            DateTime actual = Gregorian.LastDayOfTheMonthUTC(dateTime);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGetDayOfTheMonthJanuary1970()
        {
            int year = 1970;
            int month = 1;

            int[,] expectedDay =
            {
                { 4, 5, 6, 7, 1, 2, 3 },
                { 11, 12, 13, 14, 8, 9, 10 },
                { 18, 19, 20, 21, 15, 16, 17 },
                { 25, 26, 27, 28, 22, 23, 24 },
                { 25, 26, 27, 28, 29, 30, 31 },
            };

            Parallel.ForEach(Enum.GetValues<Gregorian.WeekOfTheMonth>(),
                weekOfTheMonth =>
                {
                    Parallel.ForEach(Enum.GetValues<DayOfWeek>(),
                        dayOfWeek =>
                        {
                            DateTime expected = new DateTime(year, month, expectedDay[((int)weekOfTheMonth), ((int)dayOfWeek)], 0, 0, 0, DateTimeKind.Local);

                            DateTime actual = Gregorian.GetDayOfTheMonth(year, month, weekOfTheMonth, dayOfWeek);

                            Assert.Equal(expected, actual);
                        });
                });
        }

        [Fact]
        public void TestGetDayOfTheMonthFebruary1998()
        {
            int year = 1998;
            int month = 2;

            int[,] expectedDay =
            {
                { 1, 2, 3, 4, 5, 6, 7 },
                { 8, 9, 10, 11, 12, 13, 14 },
                { 15, 16, 17, 18, 19, 20, 21 },
                { 22, 23, 24, 25, 26, 27, 28 },
                { 22, 23, 24, 25, 26, 27, 28 },
            };

            Parallel.ForEach(Enum.GetValues<Gregorian.WeekOfTheMonth>(),
                weekOfTheMonth =>
                {
                    Parallel.ForEach(Enum.GetValues<DayOfWeek>(),
                        dayOfWeek =>
                        {
                            DateTime expected = new DateTime(year, month, expectedDay[((int)weekOfTheMonth), ((int)dayOfWeek)], 0, 0, 0, DateTimeKind.Local);

                            DateTime actual = Gregorian.GetDayOfTheMonth(year, month, weekOfTheMonth, dayOfWeek);

                            Assert.Equal(expected, actual);
                        });
                });
        }

        [Fact]
        public void TestGetDayOfTheMonthDecember1970()
        {
            int year = 1970;
            int month = 12;
            DateTime seed = new DateTime(year, month, 1, 0, 0, 0, DateTimeKind.Local);

            int[,] expectedDay =
            {
                { 6, 7, 1, 2, 3, 4, 5 },
                { 13, 14, 8, 9, 10, 11, 12 },
                { 20, 21, 15, 16, 17, 18, 19 },
                { 27, 28, 22, 23, 24, 25, 26 },
                { 27, 28, 29, 30, 31, 25, 26 },
            };

            Parallel.ForEach(Enum.GetValues<Gregorian.WeekOfTheMonth>(),
                weekOfTheMonth =>
                {
                    Parallel.ForEach(Enum.GetValues<DayOfWeek>(),
                        dayOfWeek =>
                        {
                            DateTime expected = new DateTime(year, month, expectedDay[((int)weekOfTheMonth), ((int)dayOfWeek)], 0, 0, 0, DateTimeKind.Local);

                            DateTime actual = Gregorian.GetDayOfTheMonth(seed, weekOfTheMonth, dayOfWeek);

                            Assert.Equal(expected, actual);
                        });
                });
        }

        [Fact]
        public void TestGetDayOfTheMonthNovember1998()
        {
            int year = 1998;
            int month = 11;
            DateTime seed = new DateTime(year, month, 1, 0, 0, 0, DateTimeKind.Local);

            int[,] expectedDay =
            {
                { 1, 2, 3, 4, 5, 6, 7 },
                { 8, 9, 10, 11, 12, 13, 14 },
                { 15, 16, 17, 18, 19, 20, 21 },
                { 22, 23, 24, 25, 26, 27, 28 },
                { 29, 30, 24, 25, 26, 27, 28 },
            };

            Parallel.ForEach(Enum.GetValues<Gregorian.WeekOfTheMonth>(),
                weekOfTheMonth =>
                {
                    Parallel.ForEach(Enum.GetValues<DayOfWeek>(),
                        dayOfWeek =>
                        {
                            DateTime expected = new DateTime(year, month, expectedDay[((int)weekOfTheMonth), ((int)dayOfWeek)], 0, 0, 0, DateTimeKind.Local);

                            DateTime actual = Gregorian.GetDayOfTheMonth(seed, weekOfTheMonth, dayOfWeek);

                            Assert.Equal(expected, actual);
                        });
                });
        }

        [Fact]
        public void TestGetDayOfTheMonthUTCJanuary1970()
        {
            int year = 1970;
            int month = 1;

            int[,] expectedDay =
            {
                { 4, 5, 6, 7, 1, 2, 3 },
                { 11, 12, 13, 14, 8, 9, 10 },
                { 18, 19, 20, 21, 15, 16, 17 },
                { 25, 26, 27, 28, 22, 23, 24 },
                { 25, 26, 27, 28, 29, 30, 31 },
            };

            Parallel.ForEach(Enum.GetValues<Gregorian.WeekOfTheMonth>(),
                weekOfTheMonth =>
                {
                    Parallel.ForEach(Enum.GetValues<DayOfWeek>(),
                        dayOfWeek =>
                        {
                            DateTime expected = new DateTime(year, month, expectedDay[((int)weekOfTheMonth), ((int)dayOfWeek)], 0, 0, 0, DateTimeKind.Utc);

                            DateTime actual = Gregorian.GetDayOfTheMonthUTC(year, month, weekOfTheMonth, dayOfWeek);

                            Assert.Equal(expected, actual);
                        });
                });
        }

        [Fact]
        public void TestGetDayOfTheMonthUTCFebruary1998()
        {
            int year = 1998;
            int month = 2;

            int[,] expectedDay =
            {
                { 1, 2, 3, 4, 5, 6, 7 },
                { 8, 9, 10, 11, 12, 13, 14 },
                { 15, 16, 17, 18, 19, 20, 21 },
                { 22, 23, 24, 25, 26, 27, 28 },
                { 22, 23, 24, 25, 26, 27, 28 },
            };

            Parallel.ForEach(Enum.GetValues<Gregorian.WeekOfTheMonth>(),
                weekOfTheMonth =>
                {
                    Parallel.ForEach(Enum.GetValues<DayOfWeek>(),
                        dayOfWeek =>
                        {
                            DateTime expected = new DateTime(year, month, expectedDay[((int)weekOfTheMonth), ((int)dayOfWeek)], 0, 0, 0, DateTimeKind.Utc);

                            DateTime actual = Gregorian.GetDayOfTheMonthUTC(year, month, weekOfTheMonth, dayOfWeek);

                            Assert.Equal(expected, actual);
                        });
                });
        }

        [Fact]
        public void TestGetDayOfTheMonthUTCDecember1970()
        {
            int year = 1970;
            int month = 12;
            DateTime seed = new DateTime(year, month, 1, 0, 0, 0, DateTimeKind.Utc);

            int[,] expectedDay =
            {
                { 6, 7, 1, 2, 3, 4, 5 },
                { 13, 14, 8, 9, 10, 11, 12 },
                { 20, 21, 15, 16, 17, 18, 19 },
                { 27, 28, 22, 23, 24, 25, 26 },
                { 27, 28, 29, 30, 31, 25, 26 },
            };

            Parallel.ForEach(Enum.GetValues<Gregorian.WeekOfTheMonth>(),
                weekOfTheMonth =>
                {
                    Parallel.ForEach(Enum.GetValues<DayOfWeek>(),
                        dayOfWeek =>
                        {
                            DateTime expected = new DateTime(year, month, expectedDay[((int)weekOfTheMonth), ((int)dayOfWeek)], 0, 0, 0, DateTimeKind.Utc);

                            DateTime actual = Gregorian.GetDayOfTheMonthUTC(seed, weekOfTheMonth, dayOfWeek);

                            Assert.Equal(expected, actual);
                        });
                });
        }

        [Fact]
        public void TestGetDayOfTheMonthUTCNovember1998()
        {
            int year = 1998;
            int month = 11;
            DateTime seed = new DateTime(year, month, 1, 0, 0, 0, DateTimeKind.Utc);

            int[,] expectedDay =
            {
                { 1, 2, 3, 4, 5, 6, 7 },
                { 8, 9, 10, 11, 12, 13, 14 },
                { 15, 16, 17, 18, 19, 20, 21 },
                { 22, 23, 24, 25, 26, 27, 28 },
                { 29, 30, 24, 25, 26, 27, 28 },
            };

            Parallel.ForEach(Enum.GetValues<Gregorian.WeekOfTheMonth>(),
                weekOfTheMonth =>
                {
                    Parallel.ForEach(Enum.GetValues<DayOfWeek>(),
                        dayOfWeek =>
                        {
                            DateTime expected = new DateTime(year, month, expectedDay[((int)weekOfTheMonth), ((int)dayOfWeek)], 0, 0, 0, DateTimeKind.Utc);

                            DateTime actual = Gregorian.GetDayOfTheMonthUTC(seed, weekOfTheMonth, dayOfWeek);

                            Assert.Equal(expected, actual);
                        });
                });
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UnitTestGregorian()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}