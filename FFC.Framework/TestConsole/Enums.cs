﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    public class Enums
    {
        public enum Methods
        {
            meanf, //Mean
            rwf,   //Naive
            MovingAverage, //Moving Average
            ets,
            HoltWinters,
            Arima
        }

        public enum Data
        {
            Daily,          //Every day
            Day,            //All given day (sunday data)
            MonthDay,       //All Month day (April sunday)
            MonthWeedDay,   //All Month Weed day (April 1st Week monday)
            MonthDate,      //All month date data (April 8th)
        }
    }
}