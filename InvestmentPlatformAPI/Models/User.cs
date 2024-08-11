using System.ComponentModel.DataAnnotations;

namespace InvestmentPlatform.Domain;

public class User
{
    [Key]
    public int Id { get; set; }
    public string TastytradeEmail { get; set; }
    public string TastytradePassword { get; set; }
    public string TastytradeAccountNumber { get; set; }
    public string AppPassword { get; set; }
    public string AppUsername { get; set; }
    public string AppEmail { get; set; }
    public string AppName { get; set; }
    public string AppLastname { get; set; }
}