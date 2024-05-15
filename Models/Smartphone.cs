using System;
using System.Collections.Generic;

namespace DesafioPOO.Models
{
    public abstract class Smartphone
    {
        public string Numero { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public int Bateria { get; set; }
        public bool Ligado { get; set; }
        public string[] AppsInstalados { get; set; }
        public Dictionary<string, string> agenda = new Dictionary<string, string>();

        public Smartphone(string numero, string marca, string modelo, string cor)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(numero) || !ValidarNumero(numero))
                {
                    throw new ArgumentException("Número de telefone inválido.");
                }
                Numero = numero;

                if (string.IsNullOrWhiteSpace(marca))
                {
                    throw new ArgumentException("Marca não pode estar vazia.");
                }
                Marca = marca;

                if (string.IsNullOrWhiteSpace(modelo))
                {
                    throw new ArgumentException("Modelo não pode estar vazio.");
                }
                Modelo = modelo;

                if (string.IsNullOrWhiteSpace(cor))
                {
                    throw new ArgumentException("Cor não pode estar vazia.");
                }
                Cor = cor;

                Bateria = 100;
                Ligado = false;
                AppsInstalados = new string[0];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar o smartphone: {ex.Message}");
            }
        }

        public void LigarSmartphone()
        {
            try
            {
                if (!Ligado)
                {
                    Console.WriteLine("Ligando o smartphone...");
                    Ligado = true;
                }
                else
                {
                    Console.WriteLine("O smartphone já está ligado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao ligar o smartphone: {ex.Message}");
            }
        }

        public void DesligarSmartphone()
        {
            try
            {
                if (Ligado)
                {
                    Console.WriteLine("Desligando o smartphone...");
                    Ligado = false;
                }
                else
                {
                    Console.WriteLine("O smartphone já está desligado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao desligar o smartphone: {ex.Message}");
            }
        }

        public void Ligar(string numero)
        {
            try
            {
                string exibeContato = ExibeNomeContatoPorNumero(numero);
                Console.WriteLine($"Ligando para {exibeContato}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao ligar para {numero}: {ex.Message}");
            }
        }

        public void ReceberLigacao(string numero)
        {
            try
            {
                string exibeContato = ExibeNomeContatoPorNumero(numero);
                Console.WriteLine($"Recebendo ligação de {exibeContato}...");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao receber ligação de {numero}: {ex.Message}");
            }
        }

        public string ExibeNomeContatoPorNumero(string numero)
        {
            try
            {
                foreach (var contato in agenda)
                {
                    if (contato.Value == numero)
                    {
                        return contato.Key;
                    }
                }
                return numero; // Retorna o número se não encontrar o contato
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao exibir o nome do contato para o número {numero}: {ex.Message}");
                return numero;
            }
        }

        public abstract void InstalarAplicativo(string nomeApp);
        public abstract void DesinstalarAplicativo(string nomeApp);

        public void AdicionarContatoAgenda(string nome, string numero)
        {
            try
            {
                if (!ValidarNome(nome))
                {
                    throw new ArgumentException("Nome inválido. Deve conter apenas letras e espaços.");
                }

                if (!ValidarNumero(numero))
                {
                    throw new ArgumentException("Número de telefone inválido. Deve conter apenas dígitos e ter 10 ou 11 dígitos.");
                }

                if (agenda.ContainsValue(numero))
                {
                    throw new InvalidOperationException($"O número {numero} já existe na agenda.");
                }

                if (agenda.ContainsKey(nome))
                {
                    throw new InvalidOperationException($"O contato {nome} já existe na agenda com o número {agenda[nome]}.");
                }

                agenda.Add(nome, numero);
                Console.WriteLine($"Contato {nome} adicionado com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar contato: {ex.Message}");
            }
        }

        public void RemoverContatoAgenda(string nome)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nome))
                {
                    throw new ArgumentException("Nome não pode estar vazio.");
                }

                if (!agenda.ContainsKey(nome))
                {
                    throw new KeyNotFoundException("Contato não existe.");
                }

                agenda.Remove(nome);
                Console.WriteLine($"Contato {nome} removido com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao remover contato: {ex.Message}");
            }
        }

        public void ListarContatosAgenda()
        {
            try
            {
                Console.WriteLine("\nListar Contatos:");

                if (agenda.Count == 0)
                {
                    Console.WriteLine("Nenhum contato na agenda.");
                }
                else
                {
                    foreach (var item in agenda)
                    {
                        Console.WriteLine($"{item.Key} {item.Value}");
                    }
                }

                Console.WriteLine("...");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao listar contatos: {ex.Message}");
            }
        }

        // Método para validar o nome do contato
        private bool ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                return false;
            }

            foreach (char c in nome)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    return false;
                }
            }

            return true;
        }

        // Método para validar o número de telefone
        private bool ValidarNumero(string numero)
        {
            if (string.IsNullOrWhiteSpace(numero))
            {
                return false;
            }

            if (numero.Length < 10 || numero.Length > 11)
            {
                return false;
            }

            foreach (char c in numero)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
