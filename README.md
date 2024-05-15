# Aplicação de Gerenciamento de Smartphones

## Descrição
Esta aplicação de gerenciamento de smartphones é um projeto que simula as operações básicas de um celular, como ligar, desligar, adicionar contatos, fazer e receber ligações, e instalar/desinstalar aplicativos. O projeto é desenvolvido em C# utilizando o paradigma de Programação Orientada a Objetos (POO).

## Funcionalidades
- **Ligar e Desligar o Smartphone**: Métodos para ligar e desligar o dispositivo com tratamento para impedir operações redundantes.
- **Gerenciamento de Contatos**: Adicionar, listar e remover contatos da agenda telefônica com validações para evitar duplicidades e entradas inválidas.
- **Gerenciamento de Aplicativos**: Instalar e desinstalar aplicativos com validação de estado do dispositivo e nome dos aplicativos.
- **Fazer e Receber Ligações**: Simular fazer e receber ligações, exibindo o nome do contato se presente na agenda.

## Estrutura do Projeto
O projeto está organizado nas seguintes classes:

### `Smartphone`
Classe abstrata que define a estrutura básica de um smartphone.

### `Nokia`
Classe concreta que herda de `Smartphone` e implementa os métodos abstratos para a marca Nokia.

### `Iphone`
Classe concreta que herda de `Smartphone` e implementa os métodos abstratos para a marca iPhone (a ser implementado).

## Pré-requisitos
- .NET SDK

## Executando a Aplicação
1. Clone o repositório para o seu ambiente local:
    ```sh
    git clone https://github.com/seu-usuario/repositorio-smartphones.git
    ```

2. Navegue até o diretório do projeto:
    ```sh
    cd repositorio-smartphones
    ```

3. Execute o projeto:
    ```sh
    dotnet run
    ```

## Exemplo de Uso
Aqui está um exemplo de uso das funcionalidades da aplicação:

```csharp
using DesafioPOO.Models;

class Program
{
    static void Main(string[] args)
    {
        // Instanciando um objeto da classe Nokia
        Nokia nokia = new Nokia("1234567890", "Nokia", "A1", "Preto");

        // Testando métodos de ligar e desligar o smartphone
        nokia.LigarSmartphone();
        nokia.LigarSmartphone(); // Tentativa de ligar novamente
        nokia.DesligarSmartphone();
        nokia.DesligarSmartphone(); // Tentativa de desligar novamente
        nokia.LigarSmartphone();

        // Testando adicionar contatos na agenda
        nokia.AdicionarContatoAgenda("Val", "1234567895");
        nokia.AdicionarContatoAgenda("Avanade", "12345678911");

        // Listando contatos na agenda
        nokia.ListarContatosAgenda();

        // Removendo contato da agenda
        nokia.RemoverContatoAgenda("Val");
        nokia.ListarContatosAgenda();

        // Testando instalação e desinstalação de aplicativos
        nokia.InstalarAplicativo("Zap");
        nokia.ListarAplicativos();
        nokia.DesinstalarAplicativo("Zap");
        nokia.ListarAplicativos();

        // Testando fazer e receber ligações
        nokia.Ligar("12345678911");
        nokia.ReceberLigacao("12345678911");

        // Testando instalação de mais aplicativos
        nokia.InstalarAplicativo("Instagram");
        nokia.InstalarAplicativo("Dio.me");
        nokia.ListarAplicativos();
        nokia.DesinstalarAplicativo("Instagram");
        nokia.ListarAplicativos();
    }
}
