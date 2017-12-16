﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeWatch.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]                // Over-writing default table column conventions with annotations
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }
        public byte  MembershipTypeId { get; set; }
    }
}