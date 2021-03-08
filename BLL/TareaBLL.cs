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
    class TareaBLL
    { 
        public static Tarea Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Tarea tarea;
            try
            {
                tarea = contexto.Tarea.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return tarea;
        }

        public static List<Tarea> GetList(Expression<Func<Tarea, bool>> criterio)
        {
            List<Tarea> lista = new List<Tarea>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Tarea.Where(criterio).ToList();
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

        public static List<Tarea> GetTarea()
        {
            List<Tarea> lista = new List<Tarea>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Tarea.ToList();
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
