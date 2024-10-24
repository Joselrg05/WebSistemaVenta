using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace SV_DataAccesLayer.Interfaces
{
    /// <summary>
    /// Interfaz genérica que define las operaciones CRUD básicas y de consulta
    /// para una entidad de tipo TEntidad. 
    /// Esta interfaz es útil para implementar un patrón de repositorio genérico.
    /// </summary>
    /// <typeparam name="TEntidad">El tipo de entidad que debe ser una clase.</typeparam>
    public interface IGenericRepository<TEntidad> where TEntidad : class
    {
        /// <summary>
        /// Obtiene una entidad que cumpla con la condición especificada en el filtro.
        /// </summary>
        /// <param name="filtro">Expresión lambda que define la condición para obtener la entidad.</param>
        /// <returns>Tarea que devuelve la entidad que cumple con el filtro, o null si no se encuentra.</returns>
        Task<TEntidad> Obtener(Expression<Func<TEntidad, bool>> filtro);

        /// <summary>
        /// Crea una nueva entidad en el repositorio.
        /// </summary>
        /// <param name="entidad">La entidad que se va a agregar al repositorio.</param>
        /// <returns>Tarea que devuelve la entidad creada después de ser persistida.</returns>
        Task<TEntidad> Crear(TEntidad entidad);

        /// <summary>
        /// Edita una entidad existente en el repositorio.
        /// </summary>
        /// <param name="entidad">La entidad con los nuevos valores a actualizar.</param>
        /// <returns>Tarea que devuelve true si la operación de edición fue exitosa; false en caso contrario.</returns>
        Task<bool> Editar(TEntidad entidad);

        /// <summary>
        /// Elimina una entidad del repositorio.
        /// </summary>
        /// <param name="entidad">La entidad que se va a eliminar.</param>
        /// <returns>Tarea que devuelve true si la operación de eliminación fue exitosa; false en caso contrario.</returns>
        Task<bool> Delete(TEntidad entidad);

        /// <summary>
        /// Consulta un conjunto de entidades en el repositorio que cumplan con el filtro proporcionado.
        /// Si no se proporciona un filtro, devuelve todas las entidades.
        /// </summary>
        /// <param name="filtro">
        /// Expresión lambda opcional que define las condiciones de filtrado.
        /// Si es null, se devuelven todas las entidades.
        /// </param>
        /// <returns>Tarea que devuelve un IQueryable con las entidades filtradas o todas las entidades si no hay filtro.</returns>
        Task<IQueryable<TEntidad>> Consultar(Expression<Func<TEntidad, bool>> filtro = null);
    }
}
