namespace StructuralDesignPatterns
{
    public class SimpleText : IText
    {
        private string _text;
        public SimpleText(string text)
        {
            _text = text;
        }

        public string Text
        {
            set { _text = value; }
        }

        public string GetText()
        {
            return _text;
        }
    }
}
