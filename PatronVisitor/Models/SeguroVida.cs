using PatronVisitor.Visitor;

namespace PatronVisitor.Models
{
    // Seguro de Vida
    public class SeguroVida : ISeguro
    {
        public double PrimaAnual { get; set; }

        public SeguroVida(double primaAnual)
        {
            PrimaAnual = primaAnual;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
