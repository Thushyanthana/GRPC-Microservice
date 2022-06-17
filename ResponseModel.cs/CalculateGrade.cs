using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace userGRPC.ResponseModel.cs
{
    public class CalculateGrade
    {
        public int Id { get; set; }
        public bool isValid { get; set; }
        public string NameWithInitail { get; set; }
        public double Total { get; set; }
        public string Grade { get; set; }

    }
}
