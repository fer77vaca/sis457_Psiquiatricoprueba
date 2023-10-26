using CadPsiquiatrico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnPsiquiatrico
{
    public class TerapeutaCln
    {
        public static int insertar(Terapeuta terapeuta)
        {
            using (var context = new LabPsiquiatricoEntities())
            {
                context.Terapeuta.Add(terapeuta);
                context.SaveChanges();
                return terapeuta.id;
            }
        }

        public static int actualizar(Terapeuta terapeuta)
        {
            using (var context = new LabPsiquiatricoEntities())
            {
                var existente = context.Terapeuta.Find(terapeuta.id);
                existente.nombre = terapeuta.nombre;
                existente.apellido = terapeuta.apellido;
                existente.especialidad = terapeuta.especialidad;
                existente.telefono = terapeuta.telefono;
                existente.direccionClinica = terapeuta.direccionClinica;
                existente.horarioTrabajo = terapeuta.horarioTrabajo;
                existente.usuarioRegistro = terapeuta.usuarioRegistro;
                return context.SaveChanges();
            }
        }

        public static int eliminar(int id, string usuarioRegistro)
        {
            using (var context = new LabPsiquiatricoEntities())
            {
                var existente = context.Terapeuta.Find(id);
                existente.estado = -1;
                existente.usuarioRegistro = usuarioRegistro;
                return context.SaveChanges();
            }
        }

        public static Terapeuta get(int id)
        {
            using (var context = new LabPsiquiatricoEntities())
            {
                return context.Terapeuta.Find(id);
            }
        }

        public static List<Terapeuta> listar()
        {
            using (var context = new LabPsiquiatricoEntities())
            {
                return context.Terapeuta.Where(x => x.estado != -1).ToList();
            }
        }

        public static List<paTerapeutaListar_Result> listarPa(string parametro)
        {
            using (var context = new LabPsiquiatricoEntities())
            {
                return context.paTerapeutaListar(parametro).ToList();
            }
        }
    }
}
