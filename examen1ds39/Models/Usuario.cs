using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace examen1ds39.Models;

[Table("usuarios")]
public partial class Usuario
{
    [Key]
    [Column("cod_user")]
    public int CodUser { get; set; }

    [Column("nombre_usuario")]
    [StringLength(30)]
    [Unicode(false)]
    [Required(ErrorMessage = "El campo es obligatorio")]
    public string? NombreUsuario { get; set; }

    [Column("contra")]
    [StringLength(20)]
    [Unicode(false)]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "El campo es obligatorio")]
    [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$",ErrorMessage ="La contraseña debe contener minimo 8 caracteres, un numero y un caracter especial")]
    public string? Contra { get; set; }

    [Column("nivel_usuario")]
    [StringLength(20)]
    [Unicode(false)]
    [Required(ErrorMessage = "El campo es obligatorio")]
    public string? NivelUsuario { get; set; }
}
