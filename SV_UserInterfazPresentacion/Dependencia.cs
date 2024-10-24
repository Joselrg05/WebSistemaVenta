using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration; // Permite acceder a la configuración de la aplicación, como cadenas de conexión a bases de datos.
using Microsoft.Extensions.DependencyInjection; // Se usa para la inyección de dependencias en ASP.NET Core.
using SV_DataAccesLayer.ContextoDB; // Importa el contexto de base de datos de la capa de acceso a datos (DAL).
using Microsoft.EntityFrameworkCore; // Proporciona la funcionalidad del ORM Entity Framework Core para trabajar con bases de datos relacionales.
// using SV_DataAccesLayer.Interfaces; // Esta línea está comentada, pero en producción se usaría para inyectar interfaces de la capa DAL.
// using SV_DataAccesLayer.Implementacion; // También comentada, podría incluir la implementación concreta de la capa DAL.
using SV_BussinessLayer.Interfaces; // Importa las interfaces de la capa de negocio (BLL).
using SV_BussinessLayer.Implementacion; // Importa las implementaciones de la capa de negocio (BLL).

namespace SV_UserInterfazPresentacion // Define el espacio de nombres para la capa de presentación (UI/Presentación).
{
    public static class Dependencia // Esta clase es estática y contiene la lógica para registrar dependencias del sistema.
    {
        // Este método extiende el IServiceCollection para registrar los servicios que serán inyectados como dependencias.
        // `services` es una colección de servicios que ASP.NET Core usará para la inyección de dependencias.
        // `configuration` proporciona el acceso a la configuración de la aplicación (appsettings.json, por ejemplo).
        public static void InyectarDependencia(this IServiceCollection services, IConfiguration configuration)
        {
            // Aquí se registra el contexto de base de datos DBVENTAContext, que pertenece a la capa de acceso a datos (DAL).
            services.AddDbContext<DBVENTAContext>(options =>
            {
                // Usa la cadena de conexión configurada en el archivo de configuración (appsettings.json).
                // `UseSqlServer` indica que el proveedor de base de datos es SQL Server.
                options.UseSqlServer(configuration.GetConnectionString("CadenaSql"));
            });

            // Aquí podrías registrar servicios adicionales de otras capas como DAL o BLL, por ejemplo:
            // services.AddScoped<INombreServicioDAL, NombreServicioDAL>();
            // services.AddScoped<INombreServicioBLL, NombreServicioBLL>();
        }
    }
}
