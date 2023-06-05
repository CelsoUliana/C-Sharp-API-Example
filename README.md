# C-Sharp-API-Example

## Implementação simples de uma API com tema de Pokemon

### Metodologias Utilizadas:
DDD, com duas entidades principais.


CQRS, utilizando comandos para alterar entidades e queries para obter dados.


### TODO/Melhorias:
Testes unitários, testes de controlladores e demais.
Demais lógicas e funcionalidades.

### Como subir:
Ter um SQL Server instalado localmente, ou utilizar uma imagem do docker, por exemplo:

```
docker run -e ACCEPT_EULA=Y -e MSSQL_SA_PASSWORD=Mssql!Passw0rd -e MSSQL_DATA_DIR=/var/opt/mssql/data -e MSSQL -p 1435:1433 --name sql-server-2022 mcr.microsoft.com/mssql/server:2022-latest
```

Após isso, rodar as migrações iniciais com:
```
dotnet ef migrations add init --project C-Sharp-API-Example
```

E por fim atualizar o banco de dados com as migrações:
```
dotnet ef database update --project C-Sharp-API-Example
```
