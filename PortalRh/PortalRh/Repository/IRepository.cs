using PortalRh.Models;


namespace PortalRh.Repository
{
    public interface IRepository
    {
        Task<Expediente> GetExpedienteByCURP(string curp);
        public Task<List<Expediente>> GetExpediente();
        public Task<Expediente> GetExpedienteId(string ExpedienteId);
        public Task<Expediente> CrearExpediente(Expediente crearExpediente);
        public Task<Expediente> ActualizarExpediente(string ExpedienteId, Expediente actualizarExpediente);
        public Task EliminarExpediente(string ExpedienteId);

    }
}
