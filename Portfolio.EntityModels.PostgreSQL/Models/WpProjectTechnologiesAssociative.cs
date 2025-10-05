using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Portfolio.EntityModels;

[Table("wp_project_technologies_associative")]
public partial class WpProjectTechnologiesAssociative
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("projectid")]
    public int Projectid { get; set; }

    [Column("technologyid")]
    public int Technologyid { get; set; }

    [ForeignKey("Projectid")]
    [InverseProperty("WpProjectTechnologiesAssociatives")]
    public virtual WpProject Project { get; set; } = null!;

    [ForeignKey("Projectid")]
    [InverseProperty("WpProjectTechnologiesAssociatives")]
    public virtual WpTechnology ProjectNavigation { get; set; } = null!;
}
