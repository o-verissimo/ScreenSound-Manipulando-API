using System.Text.Json.Serialization;

namespace ScreenSound_04.Modelos;
internal class Musica
{
    private string[] notas =
    {
        "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B"
    };
    // [Propriedade(Nome do campo que vamos utilizar)] isso é um atributo que representa um metadado especifico para a propriedade nome.
    // esse atributo em outras linguagens é conhecido como *anotação*
    [JsonPropertyName("song")]  
    public string? Nome { get; set; }
    [JsonPropertyName("artist")]
    public string? Artista { get; set; }
    [JsonPropertyName("duration_ms")]
    public int Duracao { get; set; }
    [JsonPropertyName("genre")]
    public string? Genero { get; set; }
    [JsonPropertyName("key")]
    public int Key { get; set; }
    public string Tom
    {
        get
        {
            return notas[Key];
        }
    }
    public void ExibirDetalhesDaMusica()
    {
        Console.WriteLine($"Artista: {Artista}");
        Console.WriteLine($"Música: {Nome}");
        Console.WriteLine($"Duração: {Duracao/1000} segundos");
        Console.WriteLine($"Genêro Musical: {Genero}");
        Console.WriteLine($"Tonalidade: {Tom}");
    }

}
