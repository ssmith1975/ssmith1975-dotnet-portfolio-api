using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Portfolio.EntityModels;

[Table("wp_project_screenshots")]
public partial class WpProjectScreenshot
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(255)]
    public string Name { get; set; } = null!;

    [Column("description")]
    public string? Description { get; set; }

    [Column("projectid")]
    public int Projectid { get; set; }

    [Column("image")]
    [StringLength(255)]
    public string Image { get; set; } = null!;

    [Column("width")]
    public int Width { get; set; }

    [Column("height")]
    public int Height { get; set; }

    [Column("thumbnail")]
    [StringLength(255)]
    public string Thumbnail { get; set; } = null!;

    [Column("isactive")]
    public bool? Isactive { get; set; }

    [Column("createddate")]
    public DateOnly? Createddate { get; set; }

    [ForeignKey("Projectid")]
    [InverseProperty("WpProjectScreenshots")]
    public virtual WpProject Project { get; set; } = null!;
}
