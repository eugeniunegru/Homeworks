using System;
using System.Text;

class SimpleText : ITextGenerator 
{
    StringBuilder gen50Thus()
    {

        StringBuilder text = new StringBuilder("");
        for (int i = 1; i <= 50000; i++)
            text.Append('a');

        return text;

    }
    string generateText()
    {
        string text1 = "";

        return text1 = gen50Thus().Append('b').ToString();
        
    }
}
