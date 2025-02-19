using MvcNetCoreSession.Extensions;
using MvcNetCoreSession.Models;
using System.Collections.Generic;

namespace MvcNetCoreSession.Helpers
{
    public class HelperSessionContextAccesor
    {
        private IHttpContextAccessor contextAccessor;

        public HelperSessionContextAccesor(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
        }

        public List<Mascota> GetMascotasSession()
        {
            List<Mascota> mascotas = this.contextAccessor.HttpContext.Session.GetObject<List<Mascota>>("Mascotas");
            return mascotas;
        }
    }
}
