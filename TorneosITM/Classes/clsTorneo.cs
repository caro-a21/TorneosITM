using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using TorneosITM.Models;

namespace TorneosITM.Classes
{
    public class clsTorneo
    {
            private DBTorneosITMEntities dbTorneosITM = new DBTorneosITMEntities();

            public Torneo torneo = new Torneo();

            public string Insertar()
            {
            try
            {
               dbTorneosITM.Torneos.Add(torneo);
               dbTorneosITM.SaveChanges();
                return "Torneo ingresado correctamente";
            }

                catch (Exception ex)
                {
                    return "Error al ingresar el torneo: " + ex.Message;

                }
            }

            public IQueryable ConsultarPorTipoNombreYFecha(string tipo, string nombre, DateTime fecha)
            {
                return from t in dbTorneosITM.Set<Torneo>()
                       where t.TipoTorneo == tipo && t.NombreTorneo == nombre && t.FechaTorneo == fecha
                       select new
                       {
                           idTorneos = t.idTorneos,
                           tipoTorneo = t.TipoTorneo,
                           nombreTorneo = t.NombreTorneo,
                           nombreEquipo = t.NombreEquipo,
                           valorInscripcion = t.ValorInscripcion,
                           fechaTorneo = t.FechaTorneo,
                           integrantes = t.Integrantes
                       };
            }

            public string Actualizar()
            {
                try
                {
                    var torneoExistente = dbTorneosITM.Torneos.FirstOrDefault(t => t.idTorneos == torneo.idTorneos);
                    if (torneoExistente == null)
                    {
                        return $"Error, el torneo con id {torneo.idTorneos} no se encuentra registrado en la base de datos.";
                    }
                    else
                    {
                        dbTorneosITM.Torneos.AddOrUpdate(torneo);
                        dbTorneosITM.SaveChanges();
                        return $"Se ha actualizado el torneo con id {torneo.idTorneos} en la base de datos.";
                    }
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

            }

            public string Eliminar(int idTorneos)
            {
                try
                {
                    var torneoExistente = dbTorneosITM.Torneos.FirstOrDefault(m => m.idTorneos == idTorneos);
                    if (torneoExistente == null)
                    {
                        return $"Error, el torneo con id {torneo.idTorneos} no se encuentra registraoa en la base de datos.";
                    }
                    else
                    {
                        dbTorneosITM.Torneos.Remove(torneoExistente);
                        dbTorneosITM.SaveChanges();
                        return $"Se ha eliminado el torneo con id {torneoExistente.idTorneos} en la base de datos.";
                    }
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }
    }