﻿using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace WEB.BAEBEE.Data.Model 
{
    public partial class Role : IEntity
    {
        public Role()
        {
            UserRole = new HashSet<UserRole>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
