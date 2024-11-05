using PatronVisitor.Visitor;

namespace PatronVisitor.Models
{
    // Seguro contra Robo
    public class SeguroRobo : ISeguro
    {
        public double PrimaMensual { get; set; }

        public SeguroRobo(double primaMensual)
        {
            PrimaMensual = primaMensual;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
