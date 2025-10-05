using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Portfolio.EntityModels;

[Table("wp_technologies")]
public partial class WpTechnology
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(255)]
    public string Name { get; set; } = null!;

    [Column("categoryid")]
    public int? Categoryid { get; set; }

    [Column("years")]
    public int? Years { get; set; }

    [Column("estimate")]
    [StringLength(30)]
    public string? Estimate { get; set; }

    [Column("level")]
    public int? Level { get; set; }

    [Column("note")]
    public string? Note { get; set; }

    [ForeignKey("Categoryid")]
    [InverseProperty("WpTechnologies")]
    public virtual WpSkillCategory? Category { get; set; }

    [InverseProperty("ProjectNavigation")]
    public virtual ICollection<WpProjectTechnologiesAssociative> WpProjectTechnologiesAssociatives { get; set; } = new List<WpProjectTechnologiesAssociative>();
}
