using TorneosITM.Classes;
using TorneosITM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TorneosITM.Controllers
{
    [RoutePrefix("api/Torneos")]
    public class TorneosController : ApiController
    {
        [HttpGet]
        [Route("ConsultarPorTipoNombreYFecha")]
        public IQueryable ConsultarPorTipoNombreYFecha(string tipo, string nombre, DateTime fecha)
        {
            clsTorneo torneo = new clsTorneo();
            return torneo.ConsultarPorTipoNombreYFecha(tipo, nombre, fecha);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Torneo torneo)
        {
            clsTorneo Torneo = new clsTorneo();
            Torneo.torneo = torneo;
            return Torneo.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Torneo torneo)
        {
            clsTorneo Torneo = new clsTorneo();
            Torneo.torneo = torneo;
            return Torneo.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int idTorneo)
        {
            clsTorneo torneo = new clsTorneo();
            return torneo.Eliminar(idTorneo);
        }
    }
}