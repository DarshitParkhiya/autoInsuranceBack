using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestApi.Models.StudentModels;
using TestApi.Models.AdminModels;
using TestApi.Services.Common;

namespace TestApi.Services.AdminRepo
{
    public class AdminService : CommonService<Admin>, IAdminService<Admin>
    {

        private readonly IAdminRepository _adminRepository;

        public AdminService(ICommonRepository<Admin> commonRepository, IAdminRepository adminRepository) : base(commonRepository)
        {
            _adminRepository = adminRepository;
        }

    }
}
