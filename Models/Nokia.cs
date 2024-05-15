using System;
using System.Collections.Generic;

namespace DesafioPOO.Models
{
    public class Nokia : Smartphone
    {
        public List<string> Aplicativos { get; private set; }

        // Construtor da classe Nokia que chama o construtor da classe base (Smartphone)
        public Nokia(string numero, string marca, string modelo, string cor) : base(numero, marca, modelo, cor)
        {
            Aplicativos = new List<string>();
        }

        // Sobrescreve o método "InstalarAplicativo"
        public override void InstalarAplicativo(string nomeApp)
        {
            try
            {
                // Verifica se o celular está ligado
                if (!Ligado)
                {
                    throw new InvalidOperationException("Não é possível instalar aplicativos com o celular desligado. Ligue-o primeiro.");
                }

                // Verifica se o nome do aplicativo é válido
                if (string.IsNullOrWhiteSpace(nomeApp))
                {
                    throw new ArgumentException("Nome do aplicativo inválido. O nome não pode estar vazio.");
                }

                // Verifica se o aplicativo já está instalado
                if (Aplicativos.Contains(nomeApp.ToLower()))
                {
                    throw new InvalidOperationException($"O aplicativo '{nomeApp}' já está instalado.");
                }

                // Instala o aplicativo
                Console.WriteLine($"Instalando {nomeApp} no Nokia...");
                Aplicativos.Add(nomeApp.ToLower());
                Console.WriteLine($"\nO app {nomeApp} foi instalado com sucesso no Nokia.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao instalar o aplicativo: {ex.Message}");
            }
        }

        // Sobrescreve o método "DesinstalarAplicativo"
        public override void DesinstalarAplicativo(string nomeApp)
        {
            try
            {
                // Verifica se o celular está ligado
                if (!Ligado)
                {
                    throw new InvalidOperationException("Não é possível desinstalar aplicativos com o celular desligado. Ligue-o primeiro.");
                }

                // Verifica se o nome do aplicativo é válido
                if (string.IsNullOrWhiteSpace(nomeApp))
                {
                    throw new ArgumentException("Nome do aplicativo inválido. O nome não pode estar vazio.");
                }

                // Verifica se o aplicativo já está instalado
                if (!Aplicativos.Contains(nomeApp.ToLower()))
                {
                    throw new InvalidOperationException($"O aplicativo '{nomeApp}' não está instalado.");
                }

                // Desinstala o aplicativo
                Console.WriteLine($"Desinstalando {nomeApp} no Nokia...");
                Aplicativos.Remove(nomeApp.ToLower());
                Console.WriteLine($"\nO app {nomeApp} foi desinstalado com sucesso no Nokia.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao desinstalar o aplicativo: {ex.Message}");
            }
        }

        // Método para listar aplicativos instalados
        public void ListarAplicativos()
        {
            try
            {
                Console.WriteLine("\nListar Aplicativos:");

                if (Aplicativos.Count == 0)
                {
                    Console.WriteLine("Nenhum aplicativo instalado.");
                }
                else
                {
                    foreach (var app in Aplicativos)
                    {
                        Console.WriteLine(app);
                    }
                }

                Console.WriteLine("...");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao listar os aplicativos: {ex.Message}");
            }
        }
    }
}
