using PortalRh.Models;

namespace PortalRh.Repository
{
    public interface IrepositoryMySQL
    {
        void DoSomething();
        public  Task<List<RegNominasInfo>> GetRegNominasInfoAsync();
        public Task<List<reg_nominas>> GetRegNominasDBTableAsync();
        public Task<List<SericaReporteModel>> GetReportSericaAsync(string tabla);
    }
}
