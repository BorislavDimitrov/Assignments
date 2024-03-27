namespace StructuralDesignPatterns
{
    public abstract class BaseTextDecorator : IText, IFormatter
    {
        protected IText _text;

        protected BaseTextDecorator()
        {       
        }

        protected BaseTextDecorator(IText text)
        {
            _text = text;
        }

        public abstract string GetText();

        public abstract string RemoveFormat(IText text);
    }
}
