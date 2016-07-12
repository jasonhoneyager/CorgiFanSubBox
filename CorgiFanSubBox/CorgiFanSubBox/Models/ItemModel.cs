﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CorgiFanSubBox.Models
{
    public class ItemModel
    {
        [Key]
        public int ID { get; set; }
        public string ItemName { get; set; }
        public virtual SubscriptionModel Subscription { get; set; }
        public virtual ResponsesModel Responses { get; set; }
    }
}