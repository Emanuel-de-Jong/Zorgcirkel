using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Zorgcirckel.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        
        public string Geslacht { get; set; }
        public string Geboortdatum { get; set; }
        public string Adres { get; set; }
        public string Woonplaats { get; set; }

        public string Gemeente { get; set; }
        public string Geboorteplaats { get; set; }
        public string Nationaliteit { get; set; }
        public string BSNNummer { get; set; }
        public string Verzekering { get; set; }
        public string Huisarts { get; set; }
        public Nullable<bool> Reanimatiebeleid { get; set; }
        public string ReanimatieOpmerking { get; set; }
        public Nullable<bool> JuridischeStatus { get; set; }
        public string BurgelijkeStatus { get; set; }
        public Nullable<bool> Gezin { get; set; }
        public string Scholing { get; set; }
        public string Werk { get; set; }
        public Nullable<bool> Religie { get; set; }
        public string ReligieOpmerking { get; set; }
        public Nullable<bool> Disabled { get; set; }
        public Nullable<bool> Financien { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Straatnaam { get; set; }
        public int Huisnunmmer { get; set; }
        public string Postcode { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}