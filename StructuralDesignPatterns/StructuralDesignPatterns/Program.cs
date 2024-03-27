using StructuralDesignPatterns;

var text = TextFormattingFacade.CreateTextObject("Some random text");

text = TextFormattingFacade.ApplyBold(text);
Console.WriteLine(text.GetText());

text = TextFormattingFacade.ApplyItalic(text);
Console.WriteLine(text.GetText());

text = TextFormattingFacade.ApplyUnderline(text);
Console.WriteLine(text.GetText());

text = TextFormattingFacade.ApplyColor(text, "Blue");
Console.WriteLine(text.GetText());

text = TextFormattingFacade.RemoveBold(text);
Console.WriteLine(text.GetText());

text = TextFormattingFacade.RemoveItalic(text);
Console.WriteLine(text.GetText());

text = TextFormattingFacade.RemoveUnderline(text);
Console.WriteLine(text.GetText());

text = TextFormattingFacade.RemoveColor(text);
Console.WriteLine(text.GetText());