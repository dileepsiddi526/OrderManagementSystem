using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OMS.Models
{
    public class BuyerViewModel
    {
        [Key]
        public int? buyerId { get; set; }

    }
}
