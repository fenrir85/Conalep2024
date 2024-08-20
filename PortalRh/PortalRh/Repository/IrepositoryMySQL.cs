using PortalRh.Models;

namespace PortalRh.Repository
{
    public interface IrepositoryMySQL
    {
        //void DoSomething();
        public  Task<List<RegNominasInfo>> GetRegNominasInfoAsync();
        public Task<List<reg_nominas>> GetRegNominasDBTableAsync();
        public Task<List<SericaHeaderModel>> GetHeaderSericaPrestamoAsync(string tabla);
        public Task<List<SericaDetalleReporteModel>> GetSericaPrestamoAsync(string tabla);
        public Task<List<SericaHeaderModel>> GetHeaderSericaSinPrestamo(string tabla);
        public Task<List<SericaDetalleReporteModel>> GetSericaSinPrestamo(string tabla);
        public Task<List<SericaHeaderModel>> GetHeaderSericaIncremento(string tabla);
        public Task<List<SericaDetalleReporteModel>> GetSericaIncremento(string tabla);
        public Task<List<ResumenConceptos>> GetDetalleTerceros(string tabla);



    }
}
