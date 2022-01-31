using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace WebApiTiempo.Models
{
    public class Usuario
    {
        [Key]
        public string usuario { get; set; }
        public string contrasena { get; set; }

    }
}
