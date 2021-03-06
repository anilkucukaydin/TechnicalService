﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public enum PersonType
    {
        Customer,
        CustomerRepresentative,
        Technician
    }
    public class Person : IdentityUser
    {
        //public string Name { get; set; }
        //public string Surname { get; set; }
        //public string Email { get; set; }   IdentityUserdan geliyor zaten
        //public string Password { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public PersonType PersonType { get; set; }
        public virtual List<LiveMessage> LiveMessages { get; set; }
        public virtual List<Fault> Faults { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Person> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

}
