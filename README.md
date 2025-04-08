<h1 align="center"> Clean Architecture  </h1>

O projeto feito com ASP.NET Core MVC e usa uma arquitetura limpa em camadas para manter tudo organizado.

> Camada de Apresentação (MVC): é onde fica a interface com o usuário. login e registros.

> Camada de Aplicação: ficam os serviços da aplicação, os DTOs(que ajudam a trocar dados entre camadas) e os mapeamentos. 

> Camada de Domínio: Contem as regras de negócio, as entidades principais e as interfaces (contratos) da aplicação.

> Camada de Infraestrutura: cuida do acesso ao banco de dados e implementa os repositórios com base nas interfaces do domínio.
