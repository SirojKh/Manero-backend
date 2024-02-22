using Manero_Backend.Models.Entities;
using Manero_Backend.Models.Interfaces.Repositories;
using Manero_Backend.Models.Interfaces.Services;

namespace Manero_Backend.Helpers.Services
{
    public class CompanyService : BaseService<CompanyEntity>, ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository) : base(companyRepository)
        {
            _companyRepository = companyRepository;
        }
    }
}
