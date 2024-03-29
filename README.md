# boilerplate-netcore
Creation of a boilerplate to many projects utilizando Clean Arch
### https://github.com/iuricode/padroes-de-commits
### https://github.com/Fernando-Gouvea/CustomerAccount
### https://github.com/markgossa/Reference-Event-Driven-Architecture
### https://github.com/PacktPublishing/Clean-Architecture-with-.NET
### https://github.com/adamsitnik/awesome-dot-net-performance
### https://henriquemauri.net/category/elasticsearch/
### https://gist.github.com/muratbaseren/07ac745863bcf76e4a2617eadbf60688
### https://gist.github.com/nelson1987/c4b45e199a9b157fc79493bdd8db3815/edit
### http://portalabbc.org.br/images/content/ICF%20-%20Cap%C3%ADtulo%203%20-%20Circular%203_978(1).pdf

# Create Endpoints
### [POST] api/movements
```json
{
    Valor: 0.01, //Maior que 0
    Conta: "0000012345"
}
```
#### Será validado:
    * se a conta da transferência não está nulo;
    * se o valor da transferencia não está nulo;
    * se o valor da transferência é maior que zero;
- Caso validado:
    > Será feito uma requisição para um site autorizador de transferencia
    - Caso não autorizado: 
        > Receberemos uma mensagem de erro na aplicação
    - Caso Autorizado:
        > Será criado uma movimentação na base de dados com os seguintes valores:
            ```sh
            Conta = Conta contida na requisição
            Valor = Valor contido na requisição
            Status = Pendente
            ```
        - Caso não criado:
            > Será iniciada uma re-tentativa de criação
        - Caso criado:
            > Será publicado o evento: "MovementCreated"
            - Caso não publicado:
                > Será iniciada uma re-tentativa de publicação
            - Caso publicado:
                > Receberemos um mensagem de conclusão do fluxo
### Consumir evento: "MovementCreated"
```json
{
    Id: "",
    Valor: 0.01, #Maior que 0
    Conta: "0000012345",
    Status: Pending
}
```
#### Será validado:
    * se o id da transferência não está nulo;
    * se a conta da transferência não está nulo;
    * se a status da transferência não está nulo;
    * se a status da transferência é um enum;
    * se o valor da transferencia não está nulo;
    * se o valor da transferência é maior que zero;
Caso validado:
    Será buscada a transferencia pelo id do evento
        Caso não encontrada
            Receberemos uma mensagem de erro na aplicação
        Caso encontrada
            Será alterada a movimentação encontrada na base de dados com os seguintes valores:
                Conta = Conta contida no evento
                Valor = Valor contido no evento
                Status = Created
            Caso não alterada:
                Será iniciada uma re-tentativa de alteração
            Caso alterada:
                Receberemos um mensagem de conclusão do fluxo



### [GET] api/users
### [GET] api/users/id=1

# Create Roles
* Admin
* Manager
* Basic
