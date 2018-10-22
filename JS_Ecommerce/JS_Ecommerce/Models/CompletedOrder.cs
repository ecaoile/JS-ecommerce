using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JS_Ecommerce.Models
{
    public class CompletedOrder
    {
        public string TransactionId { get; set; }
        public SubmittedOrder SubmittedOrder { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
    }
}
