using System.Diagnostics;

var ciclos = new List<int>();
for (int i = 0; i < 10; i++)
{
    ciclos.Add(i);
}
var watcher = new Stopwatch();
var resultados = new List<(long ElapsedMilisenconds, string Cenario)>();

#region Execução sequencial e síncrona
watcher.Start();
foreach (var ciclo in ciclos)
{
    ExecutarDeFormaSincrona(ciclo);
}
watcher.Stop();
resultados.Add((watcher.ElapsedMilliseconds,"Execução sequencial e síncrona"));
watcher.Reset();
#endregion

#region Execução paralela e síncrona
watcher.Start();
Parallel.ForEach(ciclos, x => ExecutarDeFormaSincronaParallel(x));
watcher.Stop();
resultados.Add((watcher.ElapsedMilliseconds, "Execução paralela e síncrona"));
watcher.Reset();
#endregion

#region Execução sequencial e assíncrona
watcher.Start();
var tasks = new List<Task>();
foreach (var ciclo in ciclos)
{
    tasks.Add(ExecutarDeFormaAsincrona(ciclo));
}
await Task.WhenAll(tasks);
watcher.Stop();
resultados.Add((watcher.ElapsedMilliseconds, "Execução sequencial e assíncrona"));
watcher.Reset();
#endregion

#region Execução paralela e assíncrona
watcher.Start();
var tasks2 = new List<Task>();
Parallel.ForEach(ciclos, x => tasks2.Add(ExecutarDeFormaAsincronaParallel(x)));
await Task.WhenAll(tasks2);
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
void ExecutarDeFormaSincrona(int ciclo)
{
    Thread.Sleep(537);
    Console.WriteLine(" Executando de forma sincrona sequencial");
}
void ExecutarDeFormaSincronaParallel(int ciclo)
{
    Thread.Sleep(537);
    Console.WriteLine(" Executando de forma sincrona com Parallel.ForEach");
}
// Desabilitei os warnings, pois o await é feito no Task.WhenAll() e o VS não reconhece, segue leitura para melhor esclarecimento: https://nelsonparente.medium.com/task-whenall-in-a-nutshell-1379428a1a53
#pragma warning disable CS1998 
async Task ExecutarDeFormaAsincrona(int ciclo)
{
    Thread.Sleep(537);
    Console.WriteLine(" Executando de forma assincrona pilha de tasks");
}
#pragma warning restore CS1998 

#pragma warning disable CS1998 
async Task ExecutarDeFormaAsincronaParallel(int ciclo)
{
    Thread.Sleep(537);
    Console.WriteLine(" Executando de forma assincrona paralela");
}
#pragma warning restore CS1998 
#endregion