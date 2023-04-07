using System;
using System.CodeDom.Compiler;
using System.Text;
using System.Threading.Tasks;

public interface ITextGenerator
{
    string generateText();
    StringBuilder gen50Thus();
    Task<string> FetchTextAsync();
    // sau daca vrei fara async, despre care o sa vorbim maine string FetchText();
}
