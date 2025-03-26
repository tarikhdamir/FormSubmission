using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class FormRepository : IFormRepository
{
    private readonly FormDbContext _context;

    public FormRepository(FormDbContext context)
    {
        _context = context;
    }

    public async Task<List<FormSubmissionClass>> GetSubmissionsAsync()
    {
        return await _context.Submissions.ToListAsync();
    }

    public async Task<FormSubmissionClass?> GetSubmissionByIdAsync(int id)
    {
        return await _context.Submissions.FindAsync(id);
    }

    public async Task<FormSubmissionClass> CreateSubmissionAsync(FormSubmissionClass form)
    {
        _context.Submissions.Add(form);
        await _context.SaveChangesAsync();
        return form;
    }
}
