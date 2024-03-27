namespace StructuralDesignPatterns
{
    //Combination of Decorator and Facade design patterns
    public static class TextFormattingFacade
    {
        public static IText CreateTextObject(string text)
        {
            return new SimpleText(text);
        }

        public static IText ApplyBold(IText text)
        {
            return text = new BoldDecorator(text);
        }

        public static IText ApplyItalic(IText text)
        {
            return text = new ItalicDecorator(text);
        }

        public static IText ApplyUnderline(IText text)
        {
            return text = new UnderlineDecorator(text);
        }

        public static IText ApplyColor(IText text, string color)
        {
            return text = new ColorDecorator(text, color);
        }

        public static IText RemoveBold(IText text)
        {
            IFormatter bold = new BoldDecorator();
            var removedBold = bold.RemoveFormat(text);
            var newText = new SimpleText(removedBold);
            return newText;
        }

        public static IText RemoveItalic(IText text)
        {
            IFormatter italic = new ItalicDecorator();
            var removedItalic = italic.RemoveFormat(text);
            var newText = new SimpleText(removedItalic);
            return newText;
        }

        public static IText RemoveUnderline(IText text)
        {
            IFormatter underline = new UnderlineDecorator();
            var removedUnderline = underline.RemoveFormat(text);
            var newText = new SimpleText(removedUnderline);
            return newText;
        }

        public static IText RemoveColor(IText text)
        {
            IFormatter color = new ColorDecorator();
            var removedColor = color.RemoveFormat(text);
            var newText = new SimpleText(removedColor);
            return newText;
        }
    }
}
