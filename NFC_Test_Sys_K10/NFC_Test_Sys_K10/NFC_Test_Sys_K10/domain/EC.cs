using System;

namespace NFC_Test_Sys_K10.domain
{
    public class EC
    {
        private int ecCode;
        private String desc;
        private double lLimit;
        private double uLimit;
        private String unit;
        private double value;
        private bool result;
        private int costTime;

        public int EcCode { get => ecCode; set => ecCode = value; }
        public string Desc { get => desc; set => desc = value; }
        public double LLimit { get => lLimit; set => lLimit = value; }
        public double ULimit { get => uLimit; set => uLimit = value; }
        public string Unit { get => unit; set => unit = value; }
        public double Value { get => value; set => this.value = value; }
        public bool Result { get => result; set => result = value; }
        public int CostTime { get => costTime; set => costTime = value; }

        public EC() { }

        public EC(int ecCode, string desc, double lLimit, double uLimit, string unit)
        {
            this.ecCode = ecCode;
            this.desc = desc;
            this.lLimit = lLimit;
            this.uLimit = uLimit;
            this.unit = unit;
        }

        public EC(int ecCode, string desc, double lLimit, double uLimit, string unit, double value, bool result, int costTime)
        {
            this.ecCode = ecCode;
            this.desc = desc;
            this.lLimit = lLimit;
            this.uLimit = uLimit;
            this.unit = unit;
            this.value = value;
            this.result = result;
            this.costTime = costTime;
        }
    }
}
