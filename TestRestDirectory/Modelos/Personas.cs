using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestRest.Modelos
{
    /// <summary>
    /// Clase Entidad Personas
    /// </summary>
    public class Personas
    {
        /// <summary>
        /// Identificador de Persona
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Nombres
        /// </summary>
        [Required(ErrorMessage = "El campo Nombres es requerido")]
        public string Nombres { get; set; }

        /// <summary>
        /// Apellidos
        /// </summary>
        [Required(ErrorMessage = "El campo Apellidos es requerido")]
        public string Apellidos { get; set; }

        /// <summary>
        /// Correo Electronico
        /// </summary>
        [Required(ErrorMessage = "El campo Correo Electronico es requerido")]
        [EmailAddress]
        public string CorreoE { get; set; }

        /// <summary>
        ///  Numero de telefono Fijo
        /// </summary>
        [Required(ErrorMessage = "El campo Telefono Fijo es requerido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "El campo TelefonoFijo sólo permite números")]
        public string TelefonoFijo { get; set; }

        /// <summary>
        /// Numero de telefono Movil
        /// </summary>
        [Required(ErrorMessage = "El campo Telefono Móvil es requerido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "El campo TelefonoMovil sólo permite números")]
        public string TelefonoMovil { get; set; }
    }
}
