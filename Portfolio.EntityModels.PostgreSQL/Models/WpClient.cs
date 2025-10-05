using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Portfolio.EntityModels;

[Table("wp_clients")]
public partial class WpClient
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(255)]
    public string Name { get; set; } = null!;

    [Column("description")]
    public string? Description { get; set; }

    [Column("url")]
    [StringLength(255)]
    public string? Url { get; set; }

    [Column("location")]
    [StringLength(516)]
    public string Location { get; set; } = null!;

    [Column("logo")]
    [StringLength(100)]
    public string? Logo { get; set; }

    [Column("isactive")]
    public bool? Isactive { get; set; }

    [Column("jobtype")]
    [StringLength(100)]
    public string? Jobtype { get; set; }

    [Column("jobtitle")]
    [StringLength(100)]
    public string? Jobtitle { get; set; }

    [Column("createddate")]
    public DateOnly? Createddate { get; set; }
}
