using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization; // Required for JSON mapping

namespace lifesaver_backend.Models;

public class TaskItem
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;
    
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
    
    [Required]
    [JsonPropertyName("deadline")]
    public DateTime Deadline { get; set; }
    
    [JsonPropertyName("priority")]
    public string Priority { get; set; } = "Medium"; 
    
    [JsonPropertyName("status")]
    public string Status { get; set; } = "Pending";
    
    [JsonPropertyName("estimatedMinutes")]
    public int EstimatedMinutes { get; set; }
    
    [JsonPropertyName("isAtRisk")]
    public bool IsAtRisk { get; set; } = false;
}