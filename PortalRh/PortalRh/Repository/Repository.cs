using Microsoft.EntityFrameworkCore;

using PortalRh.Data;
using PortalRh.Models;
namespace PortalRh.Repository
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _contexto;

        public Repository(ApplicationDbContext context)
        {
            _contexto = context;
        }
        public async Task<Expediente> ActualizarExpediente(string ExpedienteId, Expediente actualizarExpediente)
        {

            var ExpedienteDesdeDb = await _contexto.Expedientes.FindAsync();
            ExpedienteDesdeDb.ExpedienteID = actualizarExpediente.ExpedienteID;
            ExpedienteDesdeDb.CURP = actualizarExpediente.CURP;
            ExpedienteDesdeDb.RFC = actualizarExpediente.RFC;
            ExpedienteDesdeDb.FechaValidacionRFC = actualizarExpediente.FechaValidacionRFC;
            ExpedienteDesdeDb.PrimerApellido = actualizarExpediente.PrimerApellido;
            ExpedienteDesdeDb.SegundoApellido = actualizarExpediente.SegundoApellido;
            ExpedienteDesdeDb.Edad = actualizarExpediente.Edad;
            ExpedienteDesdeDb.Sexo = actualizarExpediente.Sexo;
            ExpedienteDesdeDb.Estado = actualizarExpediente.Estado;
            ExpedienteDesdeDb.Municipio = actualizarExpediente.Municipio;
            ExpedienteDesdeDb.Localidad = actualizarExpediente.Localidad;
            ExpedienteDesdeDb.Calle = actualizarExpediente.Calle;
            ExpedienteDesdeDb.NumeroExterior = actualizarExpediente.NumeroExterior;
            ExpedienteDesdeDb.NumeroInterior = actualizarExpediente.NumeroInterior;
            ExpedienteDesdeDb.CodigoPostal = actualizarExpediente.CodigoPostal;
            ExpedienteDesdeDb.Telefono = actualizarExpediente.Telefono;
            ExpedienteDesdeDb.Celular = actualizarExpediente.Celular;
            ExpedienteDesdeDb.Correo = actualizarExpediente.Correo;
            ExpedienteDesdeDb.NSS = actualizarExpediente.NSS;
            ExpedienteDesdeDb.GrupoSanguineo = actualizarExpediente.GrupoSanguineo;
            ExpedienteDesdeDb.GradoEstudios = actualizarExpediente.GradoEstudios;
            ExpedienteDesdeDb.OtroEmpleo = actualizarExpediente.OtroEmpleo;

            await _contexto.SaveChangesAsync();
            return ExpedienteDesdeDb;

        }

        public async Task<Expediente> CrearExpediente(Expediente crearExpediente)
        {
            if (CrearExpediente != null)
            {

                await _contexto.Expedientes.AddAsync(crearExpediente);
                await _contexto.SaveChangesAsync();
                return crearExpediente;

            }
            else
            {

                return new Expediente();

            }

        }

        public async Task EliminarExpediente(string ExpedienteId)
        {

            var ExpedienteDesdeDb = await _contexto.Expedientes.FindAsync(ExpedienteId);
            _contexto.Remove(ExpedienteDesdeDb);
            await _contexto.SaveChangesAsync();
        }

        public Task<List<Expediente>> GetExpediente()
        {
            return _contexto.Expedientes.ToListAsync();
        }

        public async Task<Expediente> GetExpedienteId(string ExpedienteId)
        {
            var ExpedienteDesdeDb = await _contexto.Expedientes.FindAsync(ExpedienteId);
            if (ExpedienteDesdeDb == null)
            {

                return new Expediente();

            }
            return ExpedienteDesdeDb;
        }
    }


}
