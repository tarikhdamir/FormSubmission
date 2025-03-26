using System.Collections.Generic;
using System.Threading.Tasks;

public class FormService
{
    private readonly IFormRepository _repository;

    public FormService(IFormRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<FormSubmissionClass>> GetAllSubmissionsAsync()
    {
        return await _repository.GetSubmissionsAsync();
    }

    public async Task<FormSubmissionClass?> GetSubmissionByIdAsync(int id)
    {
        return await _repository.GetSubmissionByIdAsync(id);
    }

    public async Task<FormSubmissionClass> CreateSubmissionAsync(FormSubmissionDto dto)
    {
        var newSubmission = new FormSubmissionClass
        {
            FormData = dto.FormData
        };
        return await _repository.CreateSubmissionAsync(newSubmission);
    }
}
