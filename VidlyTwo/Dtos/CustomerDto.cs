﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyTwo.Models;

namespace VidlyTwo.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Customer's Name")]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        
        public byte MembershipTypeId { get; set; }
        [Min18IfAMember]
        public Nullable<DateTime> BDate { get; set; }
    }
}