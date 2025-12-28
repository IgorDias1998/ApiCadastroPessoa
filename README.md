# ApiCadastroPessoa

Este projeto consiste em uma API REST em .NET para cadastro de pessoas, executando operações de CRUD (Create, Read, Update e Delete).

A aplicação foi estruturada de forma inspirada na Arquitetura Hexagonal (Ports and Adapters).

O objetivo não foi criar uma arquitetura complexa, mas sim aplicar os conceitos essenciais, foi de grande aprendizado o primeiro código escrito com esse padrão.

- Domain

  Contém o coração da aplicação:
  
  Entidade Pessoa
  
  Value Object Endereco
  
  Regras de negócio e validações
  
  Exceções de domínio
  
  O domínio não depende de banco de dados, framework ou infraestrutura.

- Application

  Responsável por administrar os casos de uso:
  
  Criação, atualização, listagem e exclusão de pessoas
  
  Comunicação entre domínio e infraestrutura
  
  Uso de DTOs para entrada e saída de dados

- Infrastructure

  Camada responsável por detalhes técnicos:
  
  Persistência com Entity Framework Core
  
  Implementação de repositórios
  
  Integração com API externa de CEP (ViaCEP)

- API

  Camada de exposição da aplicação:
  
  Controllers REST
  
  Mapeamento de rotas
  
  Delegação das ações para a camada de Application

# Testes

  Foram implementados testes unitários focados no domínio, validando as principais regras de negócio da aplicação.
  
  Os testes estão localizados em um projeto separado, garantindo que o domínio permaneça isolado de dependências externas.
  
  dotnet test

# Persistência

A persistência de dados foi implementada utilizando:

  Entity Framework Core
  
  MySQL

# Front-End

Foi desenvolvido um front-end em Angular, utilizando:

  Angular moderno (Standalone Components)
  
  Lazy Loading
  
  Comunicação com a API REST
  
  O front-end consome a API exibindo mensagens claras de sucesso e erro para o usuário.
Repositório: https://github.com/IgorDias1998/cadastro-pessoa-frontend



