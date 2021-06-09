﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace teachme.Models
{
    public class PaymentDetail
    {
        public int PaymentId { get; set; }
        [Required]
        public Nullable<int> MemberId { get; set; }
        [Required]
        public Nullable<int> InstructorId { get; set; }
        [Required]
        public Nullable<int> OrderId { get; set; }
        [Required]
        public Nullable<decimal> AmountPaid { get; set; }
        [Required]
        public string PaymentType { get; set; }
    }
}