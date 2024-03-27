namespace StructuralDesignPatterns
{
    public class ItalicDecorator : BaseTextDecorator
    {
        private const string Italic = " -Italic applied- ";

        public ItalicDecorator()
        {           
        }

        public ItalicDecorator(IText text) : base(text)
        {           
        }

        public override string GetText()
        {
            return _text.GetText() + Italic;
        }

        public override string RemoveFormat(IText text)
        {
            return text.GetText().Replace(Italic, "");
        }
    }
}
