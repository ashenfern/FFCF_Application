using FFC.Framework.Data;
using RDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFC.Framework.Common;

namespace FFC.Framework.WebServicesManager
{
    public class RManager
    {
        FFCEntities db = new FFCEntities();

        public static ForecastResult Fcast1()
        {
            ForecastResult fcastResult = new ForecastResult();

            int productId = 1;
            Enums.Methods method = Enums.Methods.rwf; //meanf(YYMMDD,MMDD,MMWWDD,DD), rtw, rtw(with Drift), Moving AVG,ets, Arima, HoltWinters, msts
            Enums.Data dataType = Enums.Data.Daily;
            int periods = 50;

            var values = GetCorrespondingData(dataType, productId);
            //FFCEntities db = new FFCEntities();
            //var list = db.sp_Forecast_GetProductCountYearDayByProductId(productId).ToList();
            //List<double> values = list.Select(r => Double.Parse(r.Count.ToString())).ToList();
            //REngine.SetEnvironmentVariables(@"C:\Program Files\R\R-2.13.1\bin\i386");
            REngine.SetEnvironmentVariables();

            // There are several options to initialize the engine, but by default the following suffice:
            REngine engine = REngine.GetInstance();

            // .NET Framework array to R vector.
            //NumericVector testTs = engine.CreateNumericVector(new double[] { 30.02, 29.99, 30.11, 29.97, 30.01, 29.99, 1000 });
            NumericVector testTs = engine.CreateNumericVector(new double[] { 6, 5, 6, 5, 6, 5 });
            //NumericVector testTs = engine.CreateNumericVector(values);
            
            engine.SetSymbol("testTs", testTs);
            engine.Evaluate("n <- c(1,2,3)");
            //auto arima for monthly
            engine.Evaluate("tsValue <- ts(testTs, frequency=1, start=c(2010, 1, 1))");
            engine.Evaluate("library(forecast)");
            //engine.Evaluate(String.Format("Fit <- {0}(tsValue)", method)); // Fit <- Arima(tsValue)
            MethodManipulation(engine, method);
            engine.Evaluate(String.Format("fcast <- forecast(Fit, h={0})", periods));

            Plot(engine);

            //var a = engine.Evaluate("fcast <- forecast(tsValue, h=5)").AsCharacter();
            NumericVector forecasts = engine.Evaluate("fcast$mean").AsNumeric();

            fcastResult.results = forecasts.ToList();

            //foreach (var item in forecasts)
            //{
            //    Console.WriteLine(item);
            //}

            engine.Dispose();

            return fcastResult;
        }

        public static void Plot(REngine engine)
        {
            engine.Evaluate(@"png(filename='C:\\Users\\ashfernando\\Documents\\RFiles\\Images\\Test2.png')");
            engine.Evaluate("plot(fcast)");
            engine.Evaluate("dev.off()");
        }

        public static void MethodManipulation(REngine engine, Enums.Methods method)
        {
            engine.Evaluate(String.Format("Fit <- {0}(tsValue)", method.ToString())); // Fit <- Arima(tsValue)
        }

        public static List<double> GetCorrespondingData(Enums.Data data, int productId)
        {
            FFCEntities db = new FFCEntities();
            List<double> values = new List<double>();

            if (data == Enums.Data.Daily)
            {
                var list = db.sp_Forecast_GetProductCountYearDayByProductId(productId).ToList();
                values = list.Select(r => Double.Parse(r.Count.ToString())).ToList();
            }
            else if (data == Enums.Data.Day)
            {
                var list = db.sp_Forecast_GetProductCountDayByProductId(productId).ToList();
                values = list.Select(r => Double.Parse(r.Count.ToString())).ToList();
            }

            return values;
        }
    }
}
