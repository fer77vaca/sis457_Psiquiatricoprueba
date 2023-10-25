using CadPsiquiatrico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnPsiquiatrico
{
    public class RecetaCln
    {
        public static int Insertar(Receta receta)
        {
            using (var context = new LabPsiquiatricoEntities())
            {
                context.Receta.Add(receta);
                context.SaveChanges();
                return receta.id;
            }
        }

        public static int Actualizar(Receta receta)
        {
            using (var context = new LabPsiquiatricoEntities())
            {
                var existente = context.Receta.Find(receta.id);
                existente.fechaReceta = receta.fechaReceta;
                existente.cantidadPrescrita = receta.cantidadPrescrita;
                existente.InstruccionesUso = receta.InstruccionesUso;
                existente.usuarioRegistro = receta.usuarioRegistro;
                return context.SaveChanges();
            }
        }

        public static int Eliminar(int id, string usuarioRegistro)
        {
            using (var context = new LabPsiquiatricoEntities())
            {
                var existente = context.Receta.Find(id);
                existente.estado = -1;
                existente.usuarioRegistro = usuarioRegistro;
                return context.SaveChanges();
            }
        }

        public static Receta Get(int id)
        {
            using (var context = new LabPsiquiatricoEntities())
            {
                return context.Receta.Find(id);
            }
        }

        public static List<Receta> Listar()
        {
            using (var context = new LabPsiquiatricoEntities())
            {
                return context.Receta.Where(x => x.estado != -1).ToList();
            }
        }

        public static List<paRecetaListar_Result> ListarPa(string parametro)
        {
            using (var context = new LabPsiquiatricoEntities())
            {
                return context.paRecetaListar(parametro).ToList();
            }
        }
    }
}
