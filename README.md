# ConsoleChess

Este repositório contém a implementação de um jogo de xadrez no console utilizando **C#**. O objetivo é simular um jogo de xadrez simples no terminal, com base no padrão de objetos e interatividade em um ambiente de linha de comando.

## Estrutura do Repositório

```
src/
├── Board/: Contém a classe responsável pela criação e manipulação do tabuleiro de xadrez.
├── Chess/: Contém a lógica principal do jogo de xadrez, incluindo regras e movimentação de peças.
├── ChessInConsole.csproj: Arquivo do projeto da aplicação.
├── ChessInConsole.sln: Solução do projeto.
├── Program.cs: Arquivo principal que inicializa o jogo e controla a execução.
└── Screen.cs: Contém a lógica de exibição do tabuleiro no console.
```

## Como Usar

1. Clone este repositório para sua máquina local:
   ```bash
   git clone https://github.com/seu-usuario/ConsoleChess.git
   ```

2. Abra o repositório no seu ambiente de desenvolvimento (Visual Studio ou VS Code).

3. Execute o projeto:
   ```bash
   dotnet run
   ```

4. O jogo será iniciado no console, onde você pode jogar xadrez movimentando as peças no tabuleiro.

## Funcionalidades

- **Movimentação de Peças**: As peças de xadrez podem ser movidas de acordo com as regras do jogo.
- **Exibição do Tabuleiro**: O estado do jogo é exibido no console com as peças no tabuleiro.
- **Jogo Simples**: Permite jogar uma partida simples entre dois jogadores humanos.

## Tecnologias Utilizadas

- **C#**: Linguagem de programação utilizada para a implementação do jogo.
- **.NET Core**: Framework utilizado para o desenvolvimento da aplicação.
- **Console**: Interface de usuário baseada no terminal.

## Tópicos Abordados

- Implementação de um jogo de xadrez no console com **C#**.
- Manipulação de classes e objetos para representar o tabuleiro e as peças.
- Exibição de informações no console.
- Lógica de movimentação e regras do xadrez.
