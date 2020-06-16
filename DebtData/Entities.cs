using System;
using System.Collections.Generic;
using System.Text;
using PetaPoco.NetCore;

namespace DebtData
{
    class Entities
    {
    }

    public class Debt
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public decimal Interest { get; set; }
        public decimal MinPayment { get; set; }
        public int DueDay { get; set; }
    }
}
