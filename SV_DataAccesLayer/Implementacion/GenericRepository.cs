using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SV_DataAccesLayer.ContextoDB;
using SV_DataAccesLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace SV_DataAccesLayer.Implementacion
{
    public class GenericRepository<TEntidad> : IGenericRepository<TEntidad> where TEntidad : class
    {
        private readonly DBVENTAContext context;

        public GenericRepository(DBVENTAContext dBVENTA)
        {
            context = dBVENTA;
        }

        // Método para obtener una entidad que cumpla con un filtro (expresión lambda)
        public async Task<TEntidad> Obtener(Expression<Func<TEntidad, bool>> filtro)
        {
            try
            {
                TEntidad entidad = await context.Set<TEntidad>().FirstOrDefaultAsync(filtro);
                return entidad;
            }
            catch (ArgumentNullException ex)
            {
                // Argumento nulo cuando el filtro es inválido o nulo
                throw new ArgumentException("El filtro proporcionado no es válido.", ex);
            }
            catch (InvalidOperationException ex)
            {
                // Cuando ocurre un error inesperado al ejecutar la consulta
                throw new InvalidOperationException("No se pudo ejecutar la consulta.", ex);
            }
            catch (Exception ex)
            {
                // Captura cualquier otra excepción
                throw new Exception("Ocurrió un error al obtener la entidad.", ex);
            }
        }

        // Método para crear (insertar) una nueva entidad
        public async Task<TEntidad> Crear(TEntidad entidad)
        {
            try
            {
                context.Set<TEntidad>().Add(entidad);
                await context.SaveChangesAsync();
                return entidad;
            }
            catch (DbUpdateException ex)
            {
                // Error al intentar guardar los cambios en la base de datos
                throw new DbUpdateException("Ocurrió un error al intentar crear la entidad en la base de datos.", ex);
            }
            catch (ArgumentNullException ex)
            {
                // Si la entidad es nula
                throw new ArgumentNullException(nameof(entidad), "La entidad no puede ser nula.");
            }
            catch (Exception ex)
            {
                // Captura cualquier otra excepción
                throw new Exception("Ocurrió un error inesperado al crear la entidad.", ex);
            }
        }

        // Método para editar (actualizar) una entidad existente
        public async Task<bool> Editar(TEntidad entidad)
        {
            try
            {
                context.Set<TEntidad>().Update(entidad);
                await context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Error de concurrencia cuando dos usuarios intentan modificar la misma entidad
                throw new DbUpdateConcurrencyException("Ocurrió un conflicto de concurrencia al actualizar la entidad.", ex);
            }
            catch (DbUpdateException ex)
            {
                // Error general al actualizar la base de datos
                throw new DbUpdateException("Ocurrió un error al actualizar la entidad en la base de datos.", ex);
            }
            catch (ArgumentNullException ex)
            {
                // Si la entidad es nula
                throw new ArgumentNullException(nameof(entidad), "La entidad no puede ser nula.");
            }
            catch (Exception ex)
            {
                // Captura cualquier otra excepción
                throw new Exception("Ocurrió un error inesperado al editar la entidad.", ex);
            }
        }

        // Método para eliminar una entidad de la base de datos
        public async Task<bool> Delete(TEntidad entidad)
        {
            try
            {
                context.Set<TEntidad>().Remove(entidad);
                await context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                // Error al eliminar la entidad (por ejemplo, si tiene relaciones dependientes)
                throw new DbUpdateException("Ocurrió un error al eliminar la entidad. Verifique las dependencias.", ex);
            }
            catch (ArgumentNullException ex)
            {
                // Si la entidad es nula
                throw new ArgumentNullException(nameof(entidad), "La entidad no puede ser nula.");
            }
            catch (Exception ex)
            {
                // Captura cualquier otra excepción
                throw new Exception("Ocurrió un error inesperado al eliminar la entidad.", ex);
            }
        }

        // Método para consultar entidades basadas en un filtro opcional
        public async Task<IQueryable<TEntidad>> Consultar(Expression<Func<TEntidad, bool>> filtro = null)
        {
            try
            {
                IQueryable<TEntidad> consulta = filtro == null ? context.Set<TEntidad>() : context.Set<TEntidad>().Where(filtro);
                return consulta;
            }
            catch (ArgumentNullException ex)
            {
                // Si el filtro es nulo
                throw new ArgumentNullException(nameof(filtro), "El filtro no puede ser nulo.");
            }
            catch (InvalidOperationException ex)
            {
                // Si ocurre un error al intentar construir o ejecutar la consulta
                throw new InvalidOperationException("Ocurrió un error al ejecutar la consulta.", ex);
            }
            catch (Exception ex)
            {
                // Captura cualquier otra excepción
                throw new Exception("Ocurrió un error inesperado al consultar las entidades.", ex);
            }
        }
    }
}
