
using System.Threading.Tasks;
using TestApi.Models.StudentModels;
using TestApi.Services.SettingHelpers;

namespace TestApi.Services.StudentRepo
{
    public interface IStudentService<T> : IService<Student>
    {
        Task<Student> authenticateStudent(StudentAuth auth);
    }
}
