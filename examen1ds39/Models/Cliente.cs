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
    public string? Nombres { get; set; }

    [Column("apellidos")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Apellidos { get; set; }

    [Column("dui")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Dui { get; set; }

    [Column("direccion")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Direccion { get; set; }

    [Column("nit")]
    [StringLength(17)]
    [Unicode(false)]
    public string? Nit { get; set; }
}
