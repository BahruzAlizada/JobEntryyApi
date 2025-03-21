
namespace JobEntryy.Application.Abstracts.Services.EntityFramework
{
    public interface ICompanyWriteRepository
    {
        Task AssignIndustriesToCompany(Guid companyId, Guid[] industryId);
    }
}
