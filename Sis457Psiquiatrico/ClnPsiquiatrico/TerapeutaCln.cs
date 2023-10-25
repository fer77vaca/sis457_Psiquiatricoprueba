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
        public static int Insertar(Terapeuta terapeuta)
        {
            using (var context = new LabPsiquiatricoEntities())
            {
                context.Terapeuta.Add(terapeuta);
                context.SaveChanges();
                return terapeuta.id;
            }
        }

        public static int Actualizar(Terapeuta terapeuta)
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

        public static int Eliminar(int id, string usuarioRegistro)
        {
            using (var context = new LabPsiquiatricoEntities())
            {
                var existente = context.Terapeuta.Find(id);
                existente.estado = -1;
                existente.usuarioRegistro = usuarioRegistro;
                return context.SaveChanges();
            }
        }

        public static Terapeuta Get(int id)
        {
            using (var context = new LabPsiquiatricoEntities())
            {
                return context.Terapeuta.Find(id);
            }
        }

        public static List<Terapeuta> Listar()
        {
            using (var context = new LabPsiquiatricoEntities())
            {
                return context.Terapeuta.Where(x => x.estado != -1).ToList();
            }
        }

        public static List<paTerapeutaListar_Result> ListarPa(string parametro)
        {
            using (var context = new LabPsiquiatricoEntities())
            {
                return context.paTerapeutaListar(parametro).ToList();
            }
        }
    }
}
