using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

[Route("api/form")]
[ApiController]
public class FormController : ControllerBase
{
    private readonly FormDbContext _context;

    public FormController(FormDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> SubmitForm([FromBody] Dictionary<string, object> formData)
    {
        if (formData == null || formData.Count == 0)
            return BadRequest("Form data cannot be empty.");

        var submission = new FormSubmissionClass
        {
            FormDataJson = JsonSerializer.Serialize(formData), // ✅ Serialize formData
            SubmittedAt = DateTime.UtcNow
        };

        _context.Submissions.Add(submission);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetFormSubmissions), new { id = submission.Id }, submission);

    }

    [HttpGet]
    public async Task<IActionResult> GetFormSubmissions()
    {
        var submissions = await _context.Submissions.ToListAsync();
        return Ok(submissions);
    }
}
