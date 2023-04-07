using System;
using System.Text;

class InterText : ITextGenerator 
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
        string text2 = gen50Thus().ToString();

        text2 += "b";
        text2 += gen50Thus();
        return;
    } 
}
