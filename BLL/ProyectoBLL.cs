using Microsoft.EntityFrameworkCore;
using Segundo_Parcial.DAL;
using Segundo_Parcial.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Segundo_Parcial.BLL
{
    class ProyectoBLL
    {
        public static bool Guardar(Proyecto proyecto)
        {
            if (!Existe(proyecto.TipoId))
                return Insertar(proyecto);
            else
                return Modificar(proyecto);
        }

        private static bool Insertar(Proyecto proyecto)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Proyecto.Add(proyecto);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool Modificar(Proyecto proyecto)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete FROM ProyectoDetalle Where TipoId={proyecto.TipoId}");
                foreach (var item in proyecto.DescripcionProyecto)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }
                contexto.Entry(proyecto).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var proyecto = contexto.Proyecto.Find(id);
                if (proyecto != null)
                {
                    contexto.Entry(proyecto).State = EntityState.Deleted;
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static Proyecto Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Proyecto proyecto;
            try
            {
                proyecto = contexto.Proyecto.Include(e => e.DescripcionProyecto).Where(p => p.TipoId == id).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return proyecto;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Proyecto.Any(e => e.TipoId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        public static List<Proyecto> GetList(Expression<Func<Proyecto, bool>> criterio)
        {
            List<Proyecto> lista = new List<Proyecto>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Proyecto.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }

        public static List<Proyecto> GetProyectos()
        {
            List<Proyecto> lista = new List<Proyecto>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Proyecto.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }
    }
}