using System.Text.Json;
using ScreenSound_04.Modelos;
using ScreenSound_04.Filtros;

using (HttpClient client = new HttpClient()) 
{
    try
    {
        string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!;
        LinqFilter.FiltrarMusicasDeUmArtista(musicas, "T-Pain");
        Console.WriteLine("");
        var musicasPreferidasDoPaulo = new MusicasPreferidas("Paulo");
        musicasPreferidasDoPaulo.AdicionasMusicasFavoritas(musicas[1]);
        musicasPreferidasDoPaulo.AdicionasMusicasFavoritas(musicas[377]);
        musicasPreferidasDoPaulo.AdicionasMusicasFavoritas(musicas[4]);
        musicasPreferidasDoPaulo.AdicionasMusicasFavoritas(musicas[6]);
        musicasPreferidasDoPaulo.AdicionasMusicasFavoritas(musicas[1467]);

        musicasPreferidasDoPaulo.ExibirMusicasFavoritas();
        musicasPreferidasDoPaulo.GerarArquivoJson();
        musicasPreferidasDoPaulo.GerarDocumentoTXTComAsMusicasFavoritas();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Temos um problema: {ex.Message}");
    }
}