using Roomy.Utils.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Roomy.Models
{
    public class User : BaseModel
    {
        [Required(ErrorMessage = "Le champ {0} est requis.")]
        [Display(Name = "Nom")]
        [StringLength(50, MinimumLength = 2,
            ErrorMessage = "Le champ {0} doit contenir entre {2} et {1} caractères.")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Le champ {0} est requis.")]
        [Display(Name = "Prénom")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Le champ {0} est requis.")]
        [Display(Name = "Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                           @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                           @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
            ErrorMessage = "L'adresse mail n'est pas au bon format.")]
        [ExistingMailUser(ErrorMessage = "Le mail existe déjà.")]
        public string Mail { get; set; }

        [Display(Name = "Date de naissance")]
        [DataType(DataType.Date)]
        [Major (18, ErrorMessage = "Vous devez être majeur !")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Le champ {0} est requis.")]
        [Display(Name = "Mot de passe")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,}$",
            ErrorMessage = "{0} incorrect.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "La confirmation du mot de passe est requise.")]
        [Display(Name = "Confirmer le mot de passe")]
        [Compare("Password", ErrorMessage = "Erreur sur la confirmation du mot de passe.")]
        [NotMapped]
        [DataType(DataType.Password)]
        public string ConfirmedPassword { get; set; }

        [Required(ErrorMessage = "Civilité obligatoire")]
        [Display(Name = "Civilité")]
        public int CivilityID { get; set; }

        [ForeignKey("CivilityID")]
        [Display(Name = "Civilité")]
        public Civility Civility { get; set; }
    }
}