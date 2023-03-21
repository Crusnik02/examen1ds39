using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace examen1ds39.Models;

[Table("productos")]
public partial class Producto
{
    [Key]
    [Column("cod_prod")]
    public int CodProd { get; set; }

    [Column("nombre")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Nombre { get; set; }

    [Column("descripcion")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Descripcion { get; set; }

    [Column("precio_unit", TypeName = "money")]
    public decimal? PrecioUnit { get; set; }

    [Column("existencia")]
    public int? Existencia { get; set; }

    [Column("garantia")]
    public int? Garantia { get; set; }
}
