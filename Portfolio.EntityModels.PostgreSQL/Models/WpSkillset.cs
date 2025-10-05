using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Portfolio.EntityModels;

[Table("wp_skillsets")]
public partial class WpSkillset
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

    [Column("image")]
    [StringLength(255)]
    public string? Image { get; set; }

    [Column("icon")]
    [StringLength(100)]
    public string? Icon { get; set; }

    [Column("isfeature")]
    public bool? Isfeature { get; set; }

    [Column("orderrank")]
    public int? Orderrank { get; set; }

    [InverseProperty("Skillset")]
    public virtual ICollection<WpSkillCategory> WpSkillCategories { get; set; } = new List<WpSkillCategory>();
}
