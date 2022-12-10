namespace WMS.Domain.Common.Models;

public interface IAudit
{
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }
}