using Microsoft.EntityFrameworkCore;
using SistemaCIA.Models.ContextDb;
using SistemaCIA.Models.Session;
using System.Linq;

namespace SistemaCIA.Models.Login
{
    public class ControlRoles
    {
        private static DbContextOptions<SistemaCIADBContext> options = new DbContextOptions<SistemaCIADBContext>();
        private static SistemaCIADBContext db = new SistemaCIADBContext(options);

        public static bool TienePermiso(RolesPermisos rol)
        {
            var usuario = db.Personasroles.Where(x => x.CodigoPersona == SessionHelper.ObtenerCodigoPersona);
            foreach (var usu in usuario)
            {
                if (usu.CodigoRol == (int)rol)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
