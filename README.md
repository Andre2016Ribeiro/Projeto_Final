# Projeto_Final
https://github.com/Andre2016Ribeiro/Projeto_Final

Para este Projecto decidiu-se Criar 3 WebApps: 
Um site publico com login para utilizador.
Uma api para o Site Publico
Um site de gestão de encomendas, com pagina de gestão de desafios e de publicação de imagens. Site com Policy de limitação de acesso ao IP.

O site publico:
-Permite fazer encomendas, verificar apenas os dados e encomendas se o utilizador fizer login, (tem um filtro a base de dados principal para filtrar os dados relativos a esse utilizador).
-Também obriga ao registro na base de dados principal do utilizador Que fez login, para poder fazer encomendas e aceder as suas encomendas.
-Permite publicar e imagens para um blobstorage na Cloud Azure, e visualizar todas as imagens publicadas.
-Permite responder ao desafio que são "mesages queues" enviadas para a "storage accont".
-Permite receber as respostas do desafio quando forem submetidas no site de gestão, filtra as mensagens relativas a esse uttilizador.

Api:
Trata tudo relacionado com a base de dados principal, que vem do site publico.

Site de gestão:
-Ligada a base de dados principal, faz toda a gestão de artigos, encomendas, utilizadores e categorias.
-Permite, fazer upload de imagens para a blobsotorage e apagar imagens da blobstorage.
-Gestão do desafio: receber as respostas, enviar respostas designando se estão certas ou erradas, enviando para outro container nas messages queues, e apagar mensagens.
-Tem um link na pagina de encomendas para exportar as encomendas para json, sendo posterior desenvolvimento enviar para a api da empresa de entregas.

Pipelines:
Faz o deployment na cloud Azure das 3 apps.
A pipeline é toda executada no github, fazendo o deployment atraves de Bicep.
Tem também outra pipeline para fazer o deployment no Docker e criar um ACR.

O esquema de bases de dados consiste em 2 bases de dados locais que posteriormente se criar na cloud azure, 1 para login no site publico
outra para a API e o site MVC de Gestão. Bases de  dados SQL.

Criou-se na cloud Azure um storage container, com um blobstorage container para guardar as imagens publicadas. Neste mesmo storage container criou-se 2 containers de messages queues, 1 para receber as respostas, outro para colocar se as respostas estão certas ou erradas.

Intruções:
Abrir o git hub e importar o repositorio.
Abrir repositorio local com visual studio e compilar
Criar um resource group na cloud Azure com o nome Projeto-Final.
No visual studio publicar as duas bases de dados no azure
Alterar as conections strings nas apps(ficheiro appsetings).
Criar no portal azure uma storage accont com um contentor de blobs e 2 contentores de queues.
Copiar as conections strings para as apps(ficheiro appsetings).
Compilar e fazer commit.
Fazer push para o git.
Na Cli do azure registrar o ressorce group como service principal, usando o seguinte comando
  az ad sp create-for-rbac --name GH-Action-Projecto_Final --role contributor --scopes /subscriptions/<SubscriptionId>/resourceGroups/<Ressorce Group Name> --sdk-auth

Copiar o valor JSON devolvido, para guardar como secret no git
No git criar um secret com o nome AZURE_CREDENTIALS e colar o JSON anterior no valor.
Na pasta .github/Workflows editar o ficheiro dotnet.yml modificar o ID da subscrição.
Correr as actions e as apps serão publicadas na cloud Azure



