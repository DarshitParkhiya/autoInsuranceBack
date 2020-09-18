
using TestApi.Models.StudentModels;
using TestApi.Models.Settings;
using TestApi.Services.SettingHelpers;


namespace TestApi.Services.StudentRepo
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(IApiConnectionStrings apiConnectionStrings) : base(apiConnectionStrings)
        { }
    }
}
