using System.ComponentModel.DataAnnotations;

namespace IS.Models
{
    public class SubscriptionViewModel
    {
        [Required]
        [Display(Name = "Adresse mail")]
        public string Email { get; set; }

        [Display(Name = "Nom de famille")]
        public string FirstName { get; set; }

        [Display(Name = "Prénom")]
        public string LastName { get; set; }

        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


    }
}
