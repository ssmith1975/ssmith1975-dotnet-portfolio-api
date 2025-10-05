using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Portfolio.EntityModels;

[Table("wp_skill_categories")]
public partial class WpSkillCategory
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Column("description")]
    public string? Description { get; set; }

    [Column("slug")]
    [StringLength(255)]
    public string Slug { get; set; } = null!;

    [Column("skillsetid")]
    public int? Skillsetid { get; set; }

    [ForeignKey("Skillsetid")]
    [InverseProperty("WpSkillCategories")]
    public virtual WpSkillset? Skillset { get; set; }

    [InverseProperty("Category")]
    public virtual ICollection<WpTechnology> WpTechnologies { get; set; } = new List<WpTechnology>();
}
