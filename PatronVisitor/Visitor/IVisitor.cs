using PatronVisitor.Models;

namespace PatronVisitor.Visitor
{
    // Interfaz del visitante
    public interface IVisitor
    {
        void Visit(SeguroVida vida);
        void Visit(SeguroRobo robo);
        void Visit(PlanJubilacion jubilacion);
    }
}
