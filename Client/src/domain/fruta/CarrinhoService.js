export default class CarrinhoService {

    constructor(resource) {

        this._resource = resource('https://localhost:44374/api/carrinho');
    } 

    async lista() {

        return this._resource
            .query()
            .then(res => res.json(), err => {
                console.log(err);
                throw new Error('Não foi possível obter as carrinhos');
            });
    }  

    cadastra(carrinho) {

        return this._resource
                .save(carrinho);
    }
    
    apaga(id) {

        return this._resource
            .delete({ id })
            .then(null, err => {
                console.log(err);
                throw new Error('Não foi possível remover a carrinho');
            })
    }

    busca(id) {

        return this._resource
            .get({ id })
            .then(res => res.json());
    }

}