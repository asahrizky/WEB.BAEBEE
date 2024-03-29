﻿using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace WEB.BAEBEE.Data.Model 
{
    public partial class UserRole : IEntity
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public string IdRole { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual Role IdRoleNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
