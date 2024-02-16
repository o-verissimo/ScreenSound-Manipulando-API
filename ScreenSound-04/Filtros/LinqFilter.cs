using ScreenSound_04.Modelos;
using System.Linq;

namespace ScreenSound_04.Filtros;
internal class LinqFilter
{
    public static void FiltrarMusicasPorTonalidade(List<Musica> musicas)
    {
        var musicasPorTonalidade = musicas.Where(Tom => Tom.Tom == "C#" ).Select(musica => musica.Nome).ToList();
        Console.WriteLine("Musicas em C#:\n");
        foreach (var musica in  musicasPorTonalidade)
        {
            Console.WriteLine($"- {musica}");
        }
    }
    public static void FiltrarTodosOsGenerosMusicais(List<Musica> musicas)
    {
        var todosOsGenerosMusicais = musicas.Select(generos => generos.Genero).Distinct().ToList();
        foreach (var genero in todosOsGenerosMusicais)
        {
            Console.WriteLine($"- {genero}");
        }
    }

    public static void FiltrarArtistasPorGeneroMusical(List<Musica> musicas, string genero)
    {
        var ArtistasPorGeneroMusical = musicas.Where(musica => musica.Genero!.Contains(genero)).OrderBy(musica => musica.Artista).Select(musica => musica.Artista).Distinct().ToList();
        Console.WriteLine($"Exibindo os artistas por gênero musical >>> {genero}");
        foreach (var artista in ArtistasPorGeneroMusical)
        {
            Console.WriteLine($"- {artista}");
        }
    }

    public static void FiltrarMusicasDeUmArtista(List<Musica> musicas, string nomeDoArtista)
    {
        var musicasDoArtista = musicas.Where(musica => musica.Artista!.Equals(nomeDoArtista)).ToList();
        Console.WriteLine(nomeDoArtista);
        foreach (var musica in musicasDoArtista)
        {
            Console.WriteLine($"- {musica.Nome}");
        }
    }

}
