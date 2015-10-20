using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFC.Framework.Data;

namespace FFC.Framework.WebServicesManager
{
    public class ForecastManager
    {
        FFCEntities context = new FFCEntities();

        public List<sp_Forecast_GetDailyAvereageProductTransactions_Result> GetDailyAvereageProductTransactions()
        {
            var result = context.sp_Forecast_GetDailyAvereageProductTransactions();
            return result.ToList();
        }

        public List<sp_Forecast_GetDailyTimeSpecificAvereageProductTransactions_Result> GetDailyTimeSpecificAvereageProductTransactions()
        {
            var result = context.sp_Forecast_GetDailyTimeSpecificAvereageProductTransactions();
            return result.ToList();
        }

        public List<sp_Forecast_GetWeeklyAverageTransactions_Result> GetWeeklyAverageTransactions()
        {
            var result = context.sp_Forecast_GetWeeklyAverageTransactions();
            return result.ToList();
        }

        public List<sp_Forecast_GetWeeklyAvereageProductTransactions_Result> GetWeeklyAvereageProductTransactions()
        {
            var result = context.sp_Forecast_GetWeeklyAvereageProductTransactions();
            return result.ToList();
        }

        public List<sp_Forecast_GetProductCountYearDayByProductId_Result> GetProductCountYearDayByProductId(int productId)
        {
            var result = context.sp_Forecast_GetProductCountYearDayByProductId(productId);
            return result.ToList();
        }

        public List<sp_Forecast_GetProductCountMonthDayByProductId_Result> GetProductCountMonthDayByProductId(int productId)
        {
            var result = context.sp_Forecast_GetProductCountMonthDayByProductId(productId);
            return result.ToList();
        }

        public List<sp_Forecast_GetProductCountDayByProductId_Result> GetProductCountDayByProductId(int productId)
        {
            var result = context.sp_Forecast_GetProductCountDayByProductId(productId);
            return result.ToList();
        }

    }
}
