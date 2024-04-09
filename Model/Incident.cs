using Microsoft.AspNetCore.Components.Web;

namespace IncidentReport.Model;

public class Incident{
    public long Id{get; set;}
    public DateTime TimeDate{get; set;}
    public required String Title{get; set;}
    public required String Description{get; set;}
    public required Decimal Quantity{get; set;}
    public decimal? Price{get; set;}
    public byte? Image{get; set;}
}