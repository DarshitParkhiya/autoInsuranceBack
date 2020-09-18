using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestApi.Models.StudentModels;
using TestApi.Models.RequestModels;
using TestApi.Services.Common;

namespace TestApi.Services.StudentRepo
{
    public class StudentService : CommonService<Student>, IStudentService<Student>
    {

        private readonly IStudentRepository _studentRepository;

        public StudentService(ICommonRepository<Student> commonRepository, IStudentRepository studentRepository) : base(commonRepository)
        {
            _studentRepository = studentRepository;
        }

    }
}
