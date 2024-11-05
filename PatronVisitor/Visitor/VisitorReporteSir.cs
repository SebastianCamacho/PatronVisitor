using PatronVisitor.Models;
using System.Text;

namespace PatronVisitor.Visitor
{
    // Implementación del Visitor que genera el reporte SIRIA
    public class VisitorReporteSir : IVisitor
    {
        private StringBuilder _reporte = new StringBuilder();
        private double _costoTotal = 0;

        public void Visit(SeguroVida vida)
        {
            _reporte.AppendLine("Seguro de Vida:");
            _reporte.AppendLine($"\tPrima Anual: {vida.PrimaAnual:C}");
            _costoTotal += vida.PrimaAnual;
        }

        public void Visit(SeguroRobo robo)
        {
            double costoAnual = robo.PrimaMensual * 12;
            _reporte.AppendLine("Seguro contra Robo:");
            _reporte.AppendLine($"\tPrima Mensual: {robo.PrimaMensual:C}");
            _reporte.AppendLine($"\tCosto Anual: {costoAnual:C}");
            _costoTotal += costoAnual;
        }

        public void Visit(PlanJubilacion jubilacion)
        {
            _reporte.AppendLine("Plan de Jubilación:");
            _reporte.AppendLine($"\tAporte Anual: {jubilacion.AporteAnual:C}");
            _costoTotal += jubilacion.AporteAnual;
        }

        public string GetReporte()
        {
            _reporte.AppendLine($"\nCosto Total de los Seguros: {_costoTotal:C}");
            return _reporte.ToString();
        }
    }
}
