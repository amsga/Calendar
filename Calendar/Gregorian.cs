// SPDX-License-Identifier: Apache-2.0
//
//   Copyright 2021 TensionDev <TensionDev@outlook.com>
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.

using System;

namespace TensionDev.Calendar
{
    public static class Gregorian
    {
        /// <summary>
        /// Specifies the week of the month. Assumes starting from the first day of the month.
        /// </summary>
        public enum WeekOfTheMonth
        {
            First = 0,
            Second = 1,
            Third = 2,
            Fourth = 3,
            Last = 4,
        }

        /// <summary>
        /// Returns the first day of the month in local time.
        /// </summary>
        /// <param name="date">The month to compute. Assumes local.</param>
        /// <returns>The first day of the month in local time.</returns>
        public static DateTime FirstDayOfTheMonth(DateTime date)
        {
            DateTime local = date.ToLocalTime().Date;
            DateTime firstDay = new DateTime(local.Year, local.Month, local.Day, 0, 0, 0, DateTimeKind.Local);

            return firstDay;
        }

        /// <summary>
        /// Returns the first day of the month in UTC time.
        /// </summary>
        /// <param name="date">The month to compute. Assumes UTC.</param>
        /// <returns>The first day of the month in UTC time.</returns>
        public static DateTime FirstDayOfTheMonthUTC(DateTime date)
        {
            DateTime utc = date.ToUniversalTime().Date;
            DateTime firstDay = new DateTime(utc.Year, utc.Month, utc.Day, 0, 0, 0, DateTimeKind.Utc);

            return firstDay;
        }

        /// <summary>
        /// Returns the last day of the month in local time.
        /// </summary>
        /// <param name="date">The month to compute. Assumes local.</param>
        /// <returns>The last day of the month in local time.</returns>
        public static DateTime LastDayOfTheMonth(DateTime date)
        {
            DateTime local = date.ToLocalTime().Date;
            DateTime lastDay = new DateTime(local.Year, local.Month, DateTime.DaysInMonth(local.Year, local.Month), 0, 0, 0, DateTimeKind.Local);

            return lastDay;
        }

        /// <summary>
        /// Returns the last day of the month in UTC time.
        /// </summary>
        /// <param name="date">The month to compute. Assumes UTC.</param>
        /// <returns>The last day of the month in UTC time.</returns>
        public static DateTime LastDayOfTheMonthUTC(DateTime date)
        {
            DateTime utc = date.ToUniversalTime().Date;
            DateTime lastDay = new DateTime(utc.Year, utc.Month, DateTime.DaysInMonth(utc.Year, utc.Month), 0, 0, 0, DateTimeKind.Utc);

            return lastDay;
        }

        /// <summary>
        /// Returns a particular day of the month in local time.
        /// <br />E.g. First Sunday, Second Tuesday, etc...
        /// </summary>
        /// <param name="date">The month to compute. Assumes local.</param>
        /// <param name="weekOfTheMonth">Which Week of the Month.</param>
        /// <param name="dayOfWeek">Which Day of the Week.</param>
        /// <returns>The day of the month in local time.</returns>
        public static DateTime GetDayOfTheMonth(DateTime date, WeekOfTheMonth weekOfTheMonth, DayOfWeek dayOfWeek)
        {
            DateTime local = date.ToLocalTime();
            return GetDayOfTheMonth(local.Year, local.Month, weekOfTheMonth, dayOfWeek);
        }

        /// <summary>
        /// Returns a particular day of the month in local time.
        /// <br />E.g. First Sunday, Second Tuesday, etc...
        /// </summary>
        /// <param name="year">The year to compute.</param>
        /// <param name="month">The month to compute.</param>
        /// <param name="weekOfTheMonth">Which Week of the Month.</param>
        /// <param name="dayOfWeek">Which Day of the Week.</param>
        /// <returns>The day of the month in local time.</returns>
        public static DateTime GetDayOfTheMonth(int year, int month, WeekOfTheMonth weekOfTheMonth, DayOfWeek dayOfWeek)
        {
            DateTime dateTime = new DateTime(year, month, 1, 0, 0, 0, DateTimeKind.Local);

            switch (weekOfTheMonth)
            {
                case WeekOfTheMonth.First:
                    break;
                case WeekOfTheMonth.Second:
                    dateTime = dateTime.AddDays(7);
                    break;
                case WeekOfTheMonth.Third:
                    dateTime = dateTime.AddDays(14);
                    break;
                case WeekOfTheMonth.Fourth:
                    dateTime = dateTime.AddDays(21);
                    break;
                case WeekOfTheMonth.Last:
                    dateTime = dateTime.AddDays(28);
                    break;
            }

            int difference = (dayOfWeek - dateTime.DayOfWeek + 7) % 7;

            dateTime = dateTime.AddDays(difference);

            if (dateTime.Month != month)
            {
                dateTime = dateTime.AddDays(-7);
            }

            return dateTime;
        }

        /// <summary>
        /// Returns a particular day of the month in UTC time.
        /// <br />E.g. First Sunday, Second Tuesday, etc...
        /// </summary>
        /// <param name="date">The month to compute. Assumes UTC.</param>
        /// <param name="weekOfTheMonth">Which Week of the Month.</param>
        /// <param name="dayOfWeek">Which Day of the Week.</param>
        /// <returns>The day of the month in UTC time.</returns>
        public static DateTime GetDayOfTheMonthUTC(DateTime date, WeekOfTheMonth weekOfTheMonth, DayOfWeek dayOfWeek)
        {
            DateTime utc = date.ToUniversalTime();
            return GetDayOfTheMonthUTC(utc.Year, utc.Month, weekOfTheMonth, dayOfWeek);
        }

        /// <summary>
        /// Returns a particular day of the month in UTC time.
        /// <br />E.g. First Sunday, Second Tuesday, etc...
        /// </summary>
        /// <param name="year">The year to compute.</param>
        /// <param name="month">The month to compute.</param>
        /// <param name="weekOfTheMonth">Which Week of the Month.</param>
        /// <param name="dayOfWeek">Which Day of the Week.</param>
        /// <returns>The day of the month in UTC time.</returns>
        public static DateTime GetDayOfTheMonthUTC(int year, int month, WeekOfTheMonth weekOfTheMonth, DayOfWeek dayOfWeek)
        {
            DateTime dateTime = new DateTime(year, month, 1, 0, 0, 0, DateTimeKind.Utc);

            switch (weekOfTheMonth)
            {
                case WeekOfTheMonth.First:
                    break;
                case WeekOfTheMonth.Second:
                    dateTime = dateTime.AddDays(7);
                    break;
                case WeekOfTheMonth.Third:
                    dateTime = dateTime.AddDays(14);
                    break;
                case WeekOfTheMonth.Fourth:
                    dateTime = dateTime.AddDays(21);
                    break;
                case WeekOfTheMonth.Last:
                    dateTime = dateTime.AddDays(28);
                    break;
            }

            int difference = (dayOfWeek - dateTime.DayOfWeek + 7) % 7;

            dateTime = dateTime.AddDays(difference);

            if (dateTime.Month != month)
            {
                dateTime = dateTime.AddDays(-7);
            }

            return dateTime;
        }
    }
}
