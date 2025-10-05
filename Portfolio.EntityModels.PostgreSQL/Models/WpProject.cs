using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Portfolio.EntityModels;

[Table("wp_projects")]
public partial class WpProject
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(255)]
    public string Name { get; set; } = null!;

    [Column("description")]
    public string? Description { get; set; }

    [Column("slug")]
    [StringLength(255)]
    public string Slug { get; set; } = null!;

    [Column("thumbnail")]
    [StringLength(255)]
    public string? Thumbnail { get; set; }

    [Column("coverimage")]
    [StringLength(255)]
    public string? Coverimage { get; set; }

    [Column("isfeature")]
    public bool? Isfeature { get; set; }

    [Column("isactive")]
    public bool? Isactive { get; set; }

    [Column("createddate")]
    public DateOnly? Createddate { get; set; }

    [Column("projecttype")]
    [StringLength(60)]
    public string? Projecttype { get; set; }

    [InverseProperty("Project")]
    public virtual ICollection<WpProjectScreenshot> WpProjectScreenshots { get; set; } = new List<WpProjectScreenshot>();

    [InverseProperty("Project")]
    public virtual ICollection<WpProjectTechnologiesAssociative> WpProjectTechnologiesAssociatives { get; set; } = new List<WpProjectTechnologiesAssociative>();
}
