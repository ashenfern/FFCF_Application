using FFC.Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFC.Framework.Data
{
    public class ForecastResult
    {
        public Enums.Methods Method { get; set; }
        public List<double> results { get; set; }
    }
}
