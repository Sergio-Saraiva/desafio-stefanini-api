## Para rodar as migrações

Caso o comando abaixo resulte em erro

    dotnet ef database update

Tente rodar

    dotnet ef database update --project .\DesafioStafanini.Infra.Data\ --startup-project .\DesafioStefanini.API\

## Sobre o desafio

O que ficou faltando para a API foi apenas a configuração do ambiente docker. Peço para que rodem o projeto web sem docker mesmo.

Além disso, acredito que tive uma interpretação diferente da esperada. Pois levei em conta que a **Pessoa** fosse a entidade central e a **Cidade** dependesse dela.

Fazendo, assim, apenas um CRUD capaz de manipular **Cidade** e **Pessoas** juntos. Contudo, o ideal, era para **Cidade** ser a entidade central, sendo possível manipular **Cidades** independentemente de **Pessoas**.

Entretanto, creio que consegui demonstrar minha habilidade técnica, mesmo interpretando o desafio de forma diferente.
