using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OMS.Models
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        public string BuyerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippingDate { get; set; }
        public string TransactionStatus { get; set; }
        public DateTime PaymentDate { get; set; }
        public double TotalAmount { get; set; }
        public string BillingAddress { get; set; }
        public string ShippingAddress { get; set; }
        public long PhoneNumber { get; set; }
        public string EmailId { get; set; }

        [NotMapped]
        public int saveType { get; set; }


    }
}
