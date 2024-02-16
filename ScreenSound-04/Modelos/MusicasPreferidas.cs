using System.Text.Json;

namespace ScreenSound_04.Modelos;

internal class MusicasPreferidas
{
    public MusicasPreferidas(string? nome)
    {
        Nome = nome;
        ListaDeMusicasFavoritas = new List<Musica>();
    }
    public string? Nome {  get; set; }
    public List<Musica> ListaDeMusicasFavoritas { get; }

    public void AdicionasMusicasFavoritas(Musica musica)
    {
        ListaDeMusicasFavoritas.Add(musica);
    }

    public void ExibirMusicasFavoritas()
    {
        Console.WriteLine($"Essas são as musicas favoritas -> {Nome}");
        foreach(var musica in ListaDeMusicasFavoritas)
        {
            Console.WriteLine($"- {musica.Nome} de {musica.Artista}");
        }
        Console.WriteLine("");
    }

    public void GerarArquivoJson()
    {
        string json = JsonSerializer.Serialize(new
        {
            nome = Nome,   
            musicas = ListaDeMusicasFavoritas
        }); //objeto anonimo um new sem um tipo
        string nomeDoArquivo = $"musicas-favoritas-{Nome}.json";

        File.WriteAllText(nomeDoArquivo, json);
        Console.WriteLine($"O arquivo Json foi criado com sucesso! {Path.GetFullPath(nomeDoArquivo)}");
    }

    public void GerarDocumentoTXTComAsMusicasFavoritas()
    {
        string nomeDoArquivo = $"musicas-favoritas-{Nome}.txt";
        using (StreamWriter arquivo = new StreamWriter(nomeDoArquivo))
        {
            arquivo.WriteLine($"Essas são suas músicas favoritas -> {Nome}\n");
            foreach (var musica in ListaDeMusicasFavoritas)
            {
                arquivo.WriteLine($"- {musica.Nome} de {musica.Artista}");
            }
        }
        Console.WriteLine($"txt gerado com sucesso! {Path.GetFullPath(nomeDoArquivo)}");
    }
}
