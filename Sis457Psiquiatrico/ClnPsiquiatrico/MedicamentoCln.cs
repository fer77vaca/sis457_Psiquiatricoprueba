using CadPsiquiatrico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnPsiquiatrico
{
    public class MedicamentoCln
    {
        public static int Insertar(Medicamento medicamento)
        {
            using (var context = new LabPsiquiatricoEntities())
            {
                context.Medicamento.Add(medicamento);
                context.SaveChanges();
                return medicamento.id;
            }
        }

        public static int Actualizar(Medicamento medicamento)
        {
            using (var context = new LabPsiquiatricoEntities())
            {
                var existente = context.Medicamento.Find(medicamento.id);
                existente.nombreMedicamento = medicamento.nombreMedicamento;
                existente.dosificacion = medicamento.dosificacion;
                existente.precio = medicamento.precio;
                existente.usuarioRegistro = medicamento.usuarioRegistro;
                return context.SaveChanges();
            }
        }

        public static int Eliminar(int id, string usuarioRegistro)
        {
            using (var context = new LabPsiquiatricoEntities())
            {
                var existente = context.Medicamento.Find(id);
                existente.estado = -1;
                existente.usuarioRegistro = usuarioRegistro;
                return context.SaveChanges();
            }
        }

        public static Medicamento Get(int id)
        {
            using (var context = new LabPsiquiatricoEntities())
            {
                return context.Medicamento.Find(id);
            }
        }

        public static List<Medicamento> Listar()
        {
            using (var context = new LabPsiquiatricoEntities())
            {
                return context.Medicamento.Where(x => x.estado != -1).ToList();
            }
        }

        public static List<paMedicamentoListar_Result> ListarPa(string parametro)
        {
            using (var context = new LabPsiquiatricoEntities())
            {
                return context.paMedicamentoListar(parametro).ToList();
            }
        }
    }
}
