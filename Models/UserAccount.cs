using Microsoft.AspNetCore.Antiforgery.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace unitee_supplier_backend.Models
{
    public class UserAccount
    {
        public int Id { get; set; }
        public int User_ID { get; set; }
        public int Department_ID { get; set; }
        public string User_FirstName { get; set; }
        public string User_LastName { get; set; }
        public string User_Password { get; set; }
        public string User_Email { get; set; }
        public int User_PhoneNum { get; set; }
        public string User_Gender { get; set; }
        public BinaryBlob User_Image { get; set; }
        public int User_IsActive { get; set; }
        public string User_ShopName { get; set; }
        public int User_Role { get; set; }

    }
}