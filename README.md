# Rota de Viagem

## Descrição

Este projeto é uma API em .NET 6 que permite cadastrar rotas de viagens e consultar a rota mais barata entre duas cidades, independente da quantidade de conexões. Utiliza o algoritmo de Dijkstra para calcular a rota com o menor custo.

## Funcionalidades

- CRUD de rotas
- Consulta da rota mais barata entre duas cidades

## Tecnologias Utilizadas

- .NET 6
- Entity Framework Core
- SQLite
- xUnit (para testes unitários)

## Endpoints

### CRUD de Rotas

- **GET ​/rotas​/obter-rotas**: Retorna todas as rotas cadastradas
- **GET ​/rotas​/obter-rota​/{id}**: Retorna uma rota específica pelo ID
- **POST ​/rotas​/incluir-rota**: Adiciona uma nova rota
- **PUT /rotas/atualizar-rota/{id}**: Atualiza uma rota existente pelo ID
- **DELETE ​/rotas​/excluir-rota​/{id}**: Deleta uma rota pelo ID

### Consulta da Melhor Rota

- **GET /rotas​/obter-melhor-rota**: Calcula a melhor rota entre duas cidades
    - Parâmetros de consulta:
        - `origem`: Código da cidade de origem
        - `destino`: Código da cidade de destino

    Exemplo de consulta:
    ```bash
    GET /rotas/obter-melhor-rota?origem=GRU&destino=CDG
    ```

### Cadastro de Rotas

#### Request
```json
POST /rotas​/incluir-rota
{
    "origem": "GRU",
    "destino": "BRC",
    "custo": 10.00
}
```

#### Licença 
Este projeto é licenciado sob a MIT License
[MIT](https://choosealicense.com/licenses/mit/)
