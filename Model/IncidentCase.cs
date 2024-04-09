using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Components.Web;

namespace IncidentReport.Model;

public class IncidentCase{
    [Key]
    [Column("Id")]
    public long Id{get; set;}
    
    [Column("TimeDate")]
    public DateTime TimeDate{get; set;}

    [Column("Title")]
    public required String Title{get; set;}

    [Column("Description")]
    public required String Description{get; set;}
    
    [Column("Quantity")]
    public required Decimal Quantity{get; set;}

    [Column("Price")]
    public decimal? Price{get; set;}

    [Column("Image")]    
    public byte? Image{get; set;}
}