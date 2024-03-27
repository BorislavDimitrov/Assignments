using System.Text.RegularExpressions;

namespace StructuralDesignPatterns
{
    public class ColorDecorator : BaseTextDecorator
    {
        private const string ColorTemplateRegex = @"-Color applied:(?<color>.*?)-";
        private const string ColorTemplate = $" -Color applied:{{0}}- ";
        private string _color;

        public ColorDecorator()
        {           
        }

        public ColorDecorator(IText text, string color) : base(text)
        {
            _color = color;
        }

        public override string GetText()
        {
            return _text.GetText() + string.Format(ColorTemplate, _color);
        }

        public override string RemoveFormat(IText text)
        {
            return Regex.Replace(text.GetText(), ColorTemplateRegex, "");
        }
    }
}
