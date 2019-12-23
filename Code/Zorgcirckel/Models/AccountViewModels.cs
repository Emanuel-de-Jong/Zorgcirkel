using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace Zorgcirckel.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Gebruikers Naam")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Wachtwoord")]
        public string Password { get; set; }

        [Display(Name = "Onthoud My")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [DataType(DataType.Text)]
        [Display(Name = "Gebruikers Naam")]
        public string Username { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Telefoonnummer")]
        public string Telefoonnummer { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Geslacht")]
        public string Geslacht { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Geboortdatum")]
        public string Geboortdatum { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Adres")]
        public string Adres { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Woonplaats")]
        public string Woonplaats { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Gemeente")]

        public string Gemeente { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Geboorteplaats")]
        public string Geboorteplaats { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Nationaliteit")]
        public string Nationaliteit { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "BSN Nummer")]
        public string BSNNummer { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Verzekering")]
        public string Verzekering { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Huisarts")]
        public string Huisarts { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Reanimatiebeleid")]
        public Nullable<bool> Reanimatiebeleid { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Reanimatie Opmerking")]
        public string ReanimatieOpmerking { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Juridische Status")]
        public Nullable<bool> JuridischeStatus { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Burgelijke Status")]
        public string BurgelijkeStatus { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Gezin")]
        public Nullable<bool> Gezin { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Scholing")]
        public string Scholing { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Werk")]
        public string Werk { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Religie")]
        public Nullable<bool> Religie { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Religie Opmerking")]
        public string ReligieOpmerking { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Disabled")]
        public Nullable<bool> Disabled { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Financien")]
        public Nullable<bool> Financien { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Voornaam")]
        public string Voornaam { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Achternaam")]
        public string Achternaam { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Straatnaam")]
        public string Straatnaam { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Huisnunmmer")]
        public int Huisnunmmer { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Postcode")]
        public string Postcode { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
