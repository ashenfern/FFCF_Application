using RDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    public class RTest
    {
        public static void HelloR()
        {
            REngine.SetEnvironmentVariables();
            // There are several options to initialize the engine, but by default the following suffice:
            REngine engine = REngine.GetInstance();

            // .NET Framework array to R vector.
            NumericVector group1 = engine.CreateNumericVector(new double[] { 30.02, 29.99, 30.11, 29.97, 30.01, 29.99 });
            engine.SetSymbol("group1", group1);
            // Direct parsing from R script.
            NumericVector group2 = engine.Evaluate("group2 <- c(29.89, 29.93, 29.72, 29.98, 30.02, 29.98)").AsNumeric();

            // Test difference of mean and get the P-value.
            GenericVector testResult = engine.Evaluate("t.test(group1, group2)").AsList();
            double p = testResult["p.value"].AsNumeric().First();

            Console.WriteLine("Group1: [{0}]", string.Join(", ", group1));
            Console.WriteLine("Group2: [{0}]", string.Join(", ", group2));
            Console.WriteLine("P-value = {0:0.000}", p);

            // you should always dispose of the REngine properly.
            // After disposing of the engine, you cannot reinitialize nor reuse it
            engine.Dispose();
        }

        public static void TestMethod()
        {
            REngine.SetEnvironmentVariables();
            // There are several options to initialize the engine, but by default the following suffice:
            REngine engine = REngine.GetInstance();

            // .NET Framework array to R vector.
            NumericVector testTs = engine.CreateNumericVector(new double[] { 30.02, 29.99, 30.11, 29.97, 30.01, 29.99 });
            
            engine.SetSymbol("testTs", testTs);
            
            // Direct parsing from R script.
            //NumericVector group2 = engine.Evaluate("group2 <- c(29.89, 29.93, 29.72, 29.98, 30.02, 29.98)").AsNumeric();

            //auto arima for monthly
            engine.Evaluate("tsValue <- ts(testTs, frequency=1, start=c(2010, 1, 1))");
            engine.Evaluate("library(forecast)");
            engine.Evaluate("arimaFit <- auto.arima(tsValue)");
            engine.Evaluate("fcast <- forecast(tsValue, h=5)");

            var a = engine.Evaluate("fcast <- forecast(tsValue, h=5)").AsCharacter();
            NumericVector forecasts = engine.Evaluate("fcast$mean").AsNumeric();

            foreach (var item in forecasts)
            {
                Console.WriteLine(item);
            }

            engine.Dispose();
        }

        public static void TestMethod2()
        {

            FFCEntities db = new FFCEntities();
            var list = db.sp_Forecast_GetProductCountYearDayByProductId(1).ToList();

            List<double> values = list.Select(r => Double.Parse(r.Count.ToString())).ToList();

            REngine.SetEnvironmentVariables();
            // There are several options to initialize the engine, but by default the following suffice:
            REngine engine = REngine.GetInstance();

            // .NET Framework array to R vector.
            //NumericVector testTs = engine.CreateNumericVector(new double[] { 30.02, 29.99, 30.11, 29.97, 30.01, 29.99 });
            NumericVector testTs = engine.CreateNumericVector(values);

            //DataFrame datafrate = engine.CreateDataFrame(new List<string> { },);

            engine.SetSymbol("testTs", testTs);

            // Direct parsing from R script.
            //NumericVector group2 = engine.Evaluate("group2 <- c(29.89, 29.93, 29.72, 29.98, 30.02, 29.98)").AsNumeric();

            //auto arima for monthly
            engine.Evaluate("tsValue <- ts(testTs, frequency=1, start=c(2010, 1, 1))");
            engine.Evaluate("library(forecast)");
            engine.Evaluate("arimaFit <- Ho(tsValue)");
            engine.Evaluate("fcast <- forecast(tsValue, h=5)");

            var a = engine.Evaluate("fcast <- forecast(tsValue, h=5)").AsCharacter();
            NumericVector forecasts = engine.Evaluate("fcast$mean").AsNumeric();

            foreach (var item in forecasts)
            {
                Console.WriteLine(item);
            }


            engine.Dispose();
        }
    }
}
