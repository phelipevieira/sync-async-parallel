using System.Diagnostics;


var formigasDoFormigueiro = new List<int>();


for (int i = 0; i < 10; i++)
{
    formigasDoFormigueiro.Add(i);
}
var watcher = new Stopwatch();
var resultados = new List<(long ElapsedMilisenconds, string Cenario)>();


#region Execução sequencial e síncrona
watcher.Start();
foreach (var formiga in formigasDoFormigueiro)
{
    BuscarAcucarDeFormaProceduralSincrona(formiga);
}
watcher.Stop();
resultados.Add((watcher.ElapsedMilliseconds, "Execução procedural e síncrona"));
watcher.Reset();
#endregion


#region Execução paralela e síncrona
watcher.Start();
Parallel.ForEach(formigasDoFormigueiro, x => BuscarAcucarDeFormaParalelizadaSincrona(x));
watcher.Stop();
resultados.Add((watcher.ElapsedMilliseconds, "Execução paralela e síncrona"));
watcher.Reset();
#endregion


#region Execução procedural e assíncrona
watcher.Start();
var atividadesFormigasProceduralAssincrona = new List<Task>();
foreach (var formiga in formigasDoFormigueiro)
{
    atividadesFormigasProceduralAssincrona.Add(BuscarAcucarDeFormaProceduralAssincrona(formiga));
}
await Task.WhenAll(atividadesFormigasProceduralAssincrona);
watcher.Stop();
resultados.Add((watcher.ElapsedMilliseconds, "Execução procedural e assíncrona"));
watcher.Reset();
#endregion


#region Execução paralela e assíncrona
watcher.Start();
var atividadesFormigasParalelizadaAssincrona = new List<Task>();
Parallel.ForEach(formigasDoFormigueiro, x => atividadesFormigasParalelizadaAssincrona.Add(BuscarAcucarDeFormaParalelizadaAssincrona(x)));
await Task.WhenAll(atividadesFormigasParalelizadaAssincrona);
watcher.Stop();
resultados.Add((watcher.ElapsedMilliseconds, "Execução paralela e assíncrona"));
watcher.Reset();
#endregion


foreach (var resultado in resultados)
{
    Console.WriteLine($"Tempo decorrido em milisegundos: {resultado.ElapsedMilisenconds} | Cenário: {resultado.Cenario}");
}


Console.ReadKey();


#region Comandos
void BuscarAcucarDeFormaProceduralSincrona(int formiga)
{
    Thread.Sleep(537);
    Console.WriteLine(" Executando de forma procedural síncrona");
}

void BuscarAcucarDeFormaParalelizadaSincrona(int formiga)
{
    Thread.Sleep(537);
    Console.WriteLine(" Executando de forma paralelizada e síncrona");
}

async Task BuscarAcucarDeFormaProceduralAssincrona(int formiga)
{
    Thread.Sleep(537);
    Console.WriteLine(" Executando de forma procedural e assíncrona");
}

async Task BuscarAcucarDeFormaParalelizadaAssincrona(int formiga)
{
    Thread.Sleep(537);
    Console.WriteLine(" Executando de forma paralela e assíncrona");
}
#endregion;