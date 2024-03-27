namespace StructuralDesignPatterns
{
    public class BoldDecorator : BaseTextDecorator
    {
        private const string Bold = " -Bold applied- ";

        public BoldDecorator()
        {        
        }

        public BoldDecorator(IText text) : base(text)
        {          
        }

        public override string GetText()
        {
            return _text.GetText() + Bold;
        }

        public override string RemoveFormat(IText text)
        {
            return text.GetText().Replace(Bold, "");
        }
    }
}
