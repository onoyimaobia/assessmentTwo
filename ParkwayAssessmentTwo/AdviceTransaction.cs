using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ParkwayAssessmentTwo
{
    public class AdviceTransaction
    {
        public Response ComputeAdvice(long amount)
        {
            string datafile = File.ReadAllText(@"..\..\..\fees.config.json");
            Root fees = JsonConvert.DeserializeObject<Root>(datafile);
            //var fees = JsonConvert.DeserializeObject<Fees>(datafile);
            //const fee = null
            int maxi = 0;
            int feeAmount = 0;
           
            foreach (var fee in fees.fees)
            {
                if (maxi < fee.maxAmount)
                {
                    maxi = fee.maxAmount;
                    feeAmount = fee.feeAmount;
                }
                if (amount >= fee.minAmount && amount <= fee.maxAmount)
                {
                    var res = new Response
                    {
                        Charge = fee.feeAmount,
                        TransferAmount = amount - fee.feeAmount,
                        DebitAmount = (amount - fee.feeAmount) + fee.feeAmount,
                        Amount = amount
                    };
                    return res;
                }
            }
            if (amount > maxi) return new Response { Amount = amount, DebitAmount = (amount -feeAmount) + feeAmount, TransferAmount = amount - feeAmount, Charge = feeAmount } ;
            return new Response { Amount = amount, DebitAmount = amount, TransferAmount = amount, Charge = 0};
        }
    }
}
