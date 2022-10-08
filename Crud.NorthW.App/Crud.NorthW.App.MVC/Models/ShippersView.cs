using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Crud.NorthW.App.MVC.Models
{
    public class ShippersView
    {
        [Key]
        public int ShipperID { get; set; }

        [Required(ErrorMessage = "Ingresar nombre del shipper")]
        [RegularExpression(@"^[\ a-zA-Z]+$", ErrorMessage = "Ingrese un nombre válido (sin números ni caracteres especiales)")]
        [StringLength(40, ErrorMessage = "Ingrese máximo 40 caracteres por favor.")]
        [DisplayName("Nombre")]
        public string CompanyName { get; set; }

        [RegularExpression(@"^[0-9]", ErrorMessage = "Ingrese solo números por favor.")]
        [StringLength(24, ErrorMessage = "Ingrese máximo 24 números por favor")]
        [DisplayName("Teléfono")]
        public string Phone { get; set; }
    }
}