using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CorgiFanSubBox.Models
{
    public class OrderModel
    {
        [Key]
        public int ID { get; set; }
        public virtual CustomerModel Customer { get; set; }
        public virtual BoxModel Box { get; set; }
    }
}