using System;
using System.Threading.Tasks;

public interface ITextGenerator
{
    Task<string> FetchTextAsync();
    // sau daca vrei fara async, despre care o sa vorbim maine string FetchText();
}
