using Microsoft.EntityFrameworkCore;
using SegundoParcial.DAL;
using SegundoParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SegundoParcial.BLL
{
    public class LlamadaBLL
    {

        public static bool Guardar(Llamada llamada)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.llamada.Add(llamada) != null)
                    paso = db.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static bool Modificar(Llamada llamada)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Database.ExecuteSqlRaw($" Delete FROM LLamadaDetalle where LLamadaId = { llamada.LlamadaId}");
                foreach (var item in llamada.Detalles)
                {
                    db.Entry(item).State = EntityState.Added;

                }

                db.Entry(llamada).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static Llamada Buscar(int id)
        {
            Llamada llamada = new Llamada();
            Contexto db = new Contexto();

            try
            {
                llamada = db.llamada .Where(o => o.LlamadaId == id).Include(o => o.Detalles).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return llamada;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var eliminar = db.llamada .Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }
    }
}
