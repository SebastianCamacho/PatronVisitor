using PatronVisitor.Visitor;

namespace PatronVisitor.Models
{
    // Plan de Jubilación
    public class PlanJubilacion : ISeguro
    {
        public double AporteAnual { get; set; }

        public PlanJubilacion(double aporteAnual)
        {
            AporteAnual = aporteAnual;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
