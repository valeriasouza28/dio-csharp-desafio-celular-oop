using System;
using DesafioPOO.Models;

namespace DesafioPOO
{
  class Program
  {
    static void Main(string[] args)
    {
      // Instanciando um objeto da classe Nokia
      Nokia nokia = new Nokia("1234567890", "Nokia", "A1", "Preto");

      // Testando métodos de ligar e desligar o smartphone
      Console.WriteLine("Testando ligar e desligar o smartphone:");
      nokia.LigarSmartphone();
      nokia.LigarSmartphone(); // Tentativa de ligar novamente
      nokia.DesligarSmartphone();
      nokia.DesligarSmartphone(); // Tentativa de desligar novamente
      nokia.LigarSmartphone();
      Console.WriteLine();

      // Testando adicionar contatos na agenda
      Console.WriteLine("Testando adicionar contatos na agenda:");
      nokia.AdicionarContatoAgenda("Val", "1234567895");
      nokia.AdicionarContatoAgenda("Avanade", "12345678911");
      nokia.AdicionarContatoAgenda("Val", "1234567896"); // Tentativa de adicionar um nome duplicado
      nokia.AdicionarContatoAgenda("Novo", "1234567895"); // Tentativa de adicionar um número duplicado
      Console.WriteLine();

      // Listando contatos na agenda
      Console.WriteLine("Listando contatos na agenda:");
      nokia.ListarContatosAgenda();
      Console.WriteLine();

      // Removendo contato da agenda
      Console.WriteLine("Removendo contato da agenda:");
      nokia.RemoverContatoAgenda("Val");
      nokia.ListarContatosAgenda();
      Console.WriteLine();

      // Testando instalação e desinstalação de aplicativos
      Console.WriteLine("Testando instalação e desinstalação de aplicativos:");
      nokia.InstalarAplicativo("Zap"); // Instalação de aplicativo
      nokia.ListarAplicativos();
      nokia.DesinstalarAplicativo("Zap"); // Desinstalação de aplicativo
      nokia.ListarAplicativos();
      Console.WriteLine();

      // Testando fazer e receber ligações
      Console.WriteLine("Testando fazer e receber ligações:");
      nokia.Ligar("12345678911");
      nokia.ReceberLigacao("12345678911");
      Console.WriteLine();

      // Testando instalação de mais aplicativos
      Console.WriteLine("Testando instalação de mais aplicativos:");
      nokia.InstalarAplicativo("Instagram");
      nokia.InstalarAplicativo("Dio.me");
      nokia.ListarAplicativos();
      nokia.DesinstalarAplicativo("Instagram");
      nokia.ListarAplicativos();
    }
  }
}
