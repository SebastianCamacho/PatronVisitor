using PatronVisitor.Visitor;

namespace PatronVisitor.Models
{
    public interface ISeguro
    {
        void Accept(IVisitor visitor);
    }
}
