using System.Collections.Generic;
using System.Threading.Tasks;

public interface IFormRepository
{
    Task<List<FormSubmissionClass>> GetSubmissionsAsync();
    Task<FormSubmissionClass?> GetSubmissionByIdAsync(int id);
    Task<FormSubmissionClass> CreateSubmissionAsync(FormSubmissionClass form);
}
