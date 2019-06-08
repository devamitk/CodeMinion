// Copyright (c) 2019 by the SciSharp Team
// Code generated by CodeMinion: https://github.com/SciSharp/CodeMinion

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Python.Runtime;
using Numpy.Models;

namespace Numpy
{
    public partial class NumPy
    {
        
        /// <summary>
        /// Convert an array of datetimes into an array of strings.
        /// </summary>
        /// <param name="arr">
        /// The array of UTC timestamps to format.
        /// </param>
        /// <param name="unit">
        /// One of None, ‘auto’, or a datetime unit.
        /// </param>
        /// <param name="timezone">
        /// Timezone information to use when displaying the datetime. If ‘UTC’, end
        /// with a Z to indicate UTC time. If ‘local’, convert to the local timezone
        /// first, and suffix with a +-#### timezone offset. If a tzinfo object,
        /// then do as with ‘local’, but use the specified timezone.
        /// </param>
        /// <param name="casting">
        /// Casting to allow when changing between datetime units.
        /// </param>
        /// <returns>
        /// An array of strings the same shape as arr.
        /// </returns>
        public NDarray datetime_as_string(string[] arr, string unit, string timezone = "naive", string casting = "same_kind")
        {
            //auto-generated code, do not change
            var __self__=self;
            var pyargs=ToTuple(new object[]
            {
                arr,
                unit,
                timezone,
                casting,
            });
            var kwargs=new PyDict();
            dynamic py = __self__.InvokeMethod("datetime_as_string", pyargs, kwargs);
            return ToCsharp<NDarray>(py);
        }
        
        /// <summary>
        /// Get information about the step size of a date or time type.
        /// 
        /// The returned tuple can be passed as the second argument of numpy.datetime64 and
        /// numpy.timedelta64.
        /// </summary>
        /// <param name="dtype">
        /// The dtype object, which must be a datetime64 or timedelta64 type.
        /// </param>
        /// <returns>
        /// A tuple of:
        /// unit
        /// The datetime unit on which this dtype
        /// is based.
        /// count
        /// The number of base units in a step.
        /// </returns>
        public (string, int) datetime_data(Dtype dtype)
        {
            //auto-generated code, do not change
            var __self__=self;
            var pyargs=ToTuple(new object[]
            {
                dtype,
            });
            var kwargs=new PyDict();
            dynamic py = __self__.InvokeMethod("datetime_data", pyargs, kwargs);
            var t = py as PyTuple;
            return (ToCsharp<string>(t[0]), ToCsharp<int>(t[1]));
        }
        
        /*
        /// <summary>
        /// A business day calendar object that efficiently stores information
        /// defining valid days for the busday family of functions.
        /// 
        /// The default valid days are Monday through Friday (“business days”).
        /// A busdaycalendar object can be specified with any set of weekly
        /// valid days, plus an optional “holiday” dates that always will be invalid.
        /// 
        /// Once a busdaycalendar object is created, the weekmask and holidays
        /// cannot be modified.
        /// </summary>
        /// <param name="weekmask">
        /// A seven-element array indicating which of Monday through Sunday are
        /// valid days. May be specified as a length-seven list or array, like
        /// [1,1,1,1,1,0,0]; a length-seven string, like ‘1111100’; or a string
        /// like “Mon Tue Wed Thu Fri”, made up of 3-character abbreviations for
        /// weekdays, optionally separated by white space. Valid abbreviations
        /// are: Mon Tue Wed Thu Fri Sat Sun
        /// </param>
        /// <param name="holidays">
        /// An array of dates to consider as invalid dates, no matter which
        /// weekday they fall upon.  Holiday dates may be specified in any
        /// order, and NaT (not-a-time) dates are ignored.  This list is
        /// saved in a normalized form that is suited for fast calculations
        /// of valid days.
        /// </param>
        /// <returns>
        /// A business day calendar object containing the specified
        /// weekmask and holidays values.
        /// </returns>
        public busdaycalendar busdaycalendar(string weekmask = null, string[] holidays = null)
        {
            //auto-generated code, do not change
            var __self__=self;
            var pyargs=ToTuple(new object[]
            {
            });
            var kwargs=new PyDict();
            if (weekmask!=null) kwargs["weekmask"]=ToPython(weekmask);
            if (holidays!=null) kwargs["holidays"]=ToPython(holidays);
            dynamic py = __self__.InvokeMethod("busdaycalendar", pyargs, kwargs);
            return ToCsharp<busdaycalendar>(py);
        }
        */
        
        /*
        /// <summary>
        /// Calculates which of the given dates are valid days, and which are not.
        /// </summary>
        /// <param name="dates">
        /// The array of dates to process.
        /// </param>
        /// <param name="weekmask">
        /// A seven-element array indicating which of Monday through Sunday are
        /// valid days. May be specified as a length-seven list or array, like
        /// [1,1,1,1,1,0,0]; a length-seven string, like ‘1111100’; or a string
        /// like “Mon Tue Wed Thu Fri”, made up of 3-character abbreviations for
        /// weekdays, optionally separated by white space. Valid abbreviations
        /// are: Mon Tue Wed Thu Fri Sat Sun
        /// </param>
        /// <param name="holidays">
        /// An array of dates to consider as invalid dates.  They may be
        /// specified in any order, and NaT (not-a-time) dates are ignored.
        /// This list is saved in a normalized form that is suited for
        /// fast calculations of valid days.
        /// </param>
        /// <param name="busdaycal">
        /// A busdaycalendar object which specifies the valid days. If this
        /// parameter is provided, neither weekmask nor holidays may be
        /// provided.
        /// </param>
        /// <param name="@out">
        /// If provided, this array is filled with the result.
        /// </param>
        /// <returns>
        /// An array with the same shape as dates, containing True for
        /// each valid day, and False for each invalid day.
        /// </returns>
        public NDarray<bool> is_busday(string[] dates, string weekmask = "1111100", string[] holidays = null, busdaycalendar busdaycal = null, NDarray<bool> @out = null)
        {
            //auto-generated code, do not change
            var __self__=self;
            var pyargs=ToTuple(new object[]
            {
                dates,
            });
            var kwargs=new PyDict();
            if (weekmask!="1111100") kwargs["weekmask"]=ToPython(weekmask);
            if (holidays!=null) kwargs["holidays"]=ToPython(holidays);
            if (busdaycal!=null) kwargs["busdaycal"]=ToPython(busdaycal);
            if (@out!=null) kwargs["out"]=ToPython(@out);
            dynamic py = __self__.InvokeMethod("is_busday", pyargs, kwargs);
            return ToCsharp<NDarray<bool>>(py);
        }
        */
        
        /*
        /// <summary>
        /// First adjusts the date to fall on a valid day according to
        /// the roll rule, then applies offsets to the given dates
        /// counted in valid days.
        /// </summary>
        /// <param name="dates">
        /// The array of dates to process.
        /// </param>
        /// <param name="offsets">
        /// The array of offsets, which is broadcast with dates.
        /// </param>
        /// <param name="roll">
        /// How to treat dates that do not fall on a valid day. The default
        /// is ‘raise’.
        /// </param>
        /// <param name="weekmask">
        /// A seven-element array indicating which of Monday through Sunday are
        /// valid days. May be specified as a length-seven list or array, like
        /// [1,1,1,1,1,0,0]; a length-seven string, like ‘1111100’; or a string
        /// like “Mon Tue Wed Thu Fri”, made up of 3-character abbreviations for
        /// weekdays, optionally separated by white space. Valid abbreviations
        /// are: Mon Tue Wed Thu Fri Sat Sun
        /// </param>
        /// <param name="holidays">
        /// An array of dates to consider as invalid dates.  They may be
        /// specified in any order, and NaT (not-a-time) dates are ignored.
        /// This list is saved in a normalized form that is suited for
        /// fast calculations of valid days.
        /// </param>
        /// <param name="busdaycal">
        /// A busdaycalendar object which specifies the valid days. If this
        /// parameter is provided, neither weekmask nor holidays may be
        /// provided.
        /// </param>
        /// <param name="@out">
        /// If provided, this array is filled with the result.
        /// </param>
        /// <returns>
        /// An array with a shape from broadcasting dates and offsets
        /// together, containing the dates with offsets applied.
        /// </returns>
        public array of datetime64[D] busday_offset(string[] dates, array_like of int offsets, string roll = "raise", string weekmask = "1111100", string[] holidays = null, busdaycalendar busdaycal = null, array of datetime64[D] @out = null)
        {
            //auto-generated code, do not change
            var __self__=self;
            var pyargs=ToTuple(new object[]
            {
                dates,
                offsets,
            });
            var kwargs=new PyDict();
            if (roll!="raise") kwargs["roll"]=ToPython(roll);
            if (weekmask!="1111100") kwargs["weekmask"]=ToPython(weekmask);
            if (holidays!=null) kwargs["holidays"]=ToPython(holidays);
            if (busdaycal!=null) kwargs["busdaycal"]=ToPython(busdaycal);
            if (@out!=null) kwargs["out"]=ToPython(@out);
            dynamic py = __self__.InvokeMethod("busday_offset", pyargs, kwargs);
            return ToCsharp<array of datetime64[D]>(py);
        }
        */
        
        /*
        /// <summary>
        /// Counts the number of valid days between begindates and
        /// enddates, not including the day of enddates.
        /// 
        /// If enddates specifies a date value that is earlier than the
        /// corresponding begindates date value, the count will be negative.
        /// </summary>
        /// <param name="begindates">
        /// The array of the first dates for counting.
        /// </param>
        /// <param name="enddates">
        /// The array of the end dates for counting, which are excluded
        /// from the count themselves.
        /// </param>
        /// <param name="weekmask">
        /// A seven-element array indicating which of Monday through Sunday are
        /// valid days. May be specified as a length-seven list or array, like
        /// [1,1,1,1,1,0,0]; a length-seven string, like ‘1111100’; or a string
        /// like “Mon Tue Wed Thu Fri”, made up of 3-character abbreviations for
        /// weekdays, optionally separated by white space. Valid abbreviations
        /// are: Mon Tue Wed Thu Fri Sat Sun
        /// </param>
        /// <param name="holidays">
        /// An array of dates to consider as invalid dates.  They may be
        /// specified in any order, and NaT (not-a-time) dates are ignored.
        /// This list is saved in a normalized form that is suited for
        /// fast calculations of valid days.
        /// </param>
        /// <param name="busdaycal">
        /// A busdaycalendar object which specifies the valid days. If this
        /// parameter is provided, neither weekmask nor holidays may be
        /// provided.
        /// </param>
        /// <param name="@out">
        /// If provided, this array is filled with the result.
        /// </param>
        /// <returns>
        /// An array with a shape from broadcasting begindates and enddates
        /// together, containing the number of valid days between
        /// the begin and end dates.
        /// </returns>
        public array of int busday_count(string[] begindates, string[] enddates, string weekmask = "1111100", string[] holidays = [], busdaycalendar busdaycal = null, array of int @out = null)
        {
            //auto-generated code, do not change
            var __self__=self;
            var pyargs=ToTuple(new object[]
            {
                begindates,
                enddates,
            });
            var kwargs=new PyDict();
            if (weekmask!="1111100") kwargs["weekmask"]=ToPython(weekmask);
            if (holidays!=[]) kwargs["holidays"]=ToPython(holidays);
            if (busdaycal!=null) kwargs["busdaycal"]=ToPython(busdaycal);
            if (@out!=null) kwargs["out"]=ToPython(@out);
            dynamic py = __self__.InvokeMethod("busday_count", pyargs, kwargs);
            return ToCsharp<array of int>(py);
        }
        */
        
    }
}
