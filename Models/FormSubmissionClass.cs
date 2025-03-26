using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

public class FormSubmissionClass
{
    [Key]
    public int Id { get; set; }

    public string FormDataJson { get; set; }

    public DateTime SubmittedAt { get; set; }

    [NotMapped]
    public Dictionary<string, object> FormData
    {
        get => JsonSerializer.Deserialize<Dictionary<string, object>>(FormDataJson ?? "{}");
        set => FormDataJson = JsonSerializer.Serialize(value);
    }
}
