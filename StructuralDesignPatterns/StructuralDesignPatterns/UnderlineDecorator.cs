namespace StructuralDesignPatterns
{
    public class UnderlineDecorator : BaseTextDecorator
    {
        private const string Underline = " -Underline applied- ";

        public UnderlineDecorator()
        {          
        }

        public UnderlineDecorator(IText text) : base(text)
        {
        }

        public override string GetText()
        {
            return _text.GetText() + Underline;
        }

        public override string RemoveFormat(IText text)
        {
            return text.GetText().Replace(Underline, "");
        }
    }
}
