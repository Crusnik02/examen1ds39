using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace examen1ds39.Models;

[Table("clientes")]
public partial class Cliente
{
    [Key]
    [Column("cod_cliente")]
    public int CodCliente { get; set; }

    [Column("nombres")]
    [StringLength(30)]
    [Unicode(false)]
    [Required]
    public string? Nombres { get; set; }

    [Column("apellidos")]
    [StringLength(30)]
    [Unicode(false)]
    [Required(ErrorMessage ="El campo es obligatorio")]
    public string? Apellidos { get; set; }

    [Column("dui")]
    [StringLength(10)]
    [Unicode(false)]
    [Required(ErrorMessage = "El campo es obligatorio")]
    [RegularExpression(@"^\d{8}-\d{1}$",ErrorMessage ="Ingrese dui con el formato correcto")]
    public string? Dui { get; set; }

    [Column("direccion")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Direccion { get; set; }

    [Column("nit")]
    [StringLength(17)]
    [Unicode(false)]
    [Required(ErrorMessage = "El campo es obligatorio")]
    [RegularExpression(@"^\d{4}-\d{6}-\d{3}-\d{1}$", ErrorMessage = "Ingrese nit con el formato correcto")]
    public string? Nit { get; set; }
}
