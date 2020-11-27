using System;
using System.Collections.Generic;
using System.Text;

namespace ParkwayAssessmentTwo
{
    public class Fee
    {
        public int minAmount { get; set; }
        public int maxAmount { get; set; }
        public int feeAmount { get; set; }
    }

    public class Root
    {
        public List<Fee> fees { get; set; }
    }
    public class Response
    {
        public long Amount { get; set; }
        public long TransferAmount { get; set; }
        public long Charge { get; set; }
        public long DebitAmount { get; set; }
    }
}
