using System;
using System.ComponentModel.DataAnnotations;

namespace lifesaver_backend.Models;

public class AgentLog
{
    [Key]
    public int Id { get; set; }
    
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    
    [Required]
    public string ActionTaken { get; set; } = string.Empty;
    
    [Required]
    public string Reasoning { get; set; } = string.Empty;
}