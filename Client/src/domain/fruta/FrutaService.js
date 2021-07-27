export default class FrutaService {

    constructor(resource) {

        this._resource = resource('https://localhost:44374/api/frutas{/id}');
        
    } 

    lista() {

        return this._resource
            .query()
            .then(res => res.json(), err => {
                console.log(err);
                throw new Error('Não foi possível obter as frutas');
            });
    }  

    cadastra(fruta) {

        if(fruta.id) {

            return this._resource
                .update({ id: fruta.id}, fruta);

        } else {
            return this._resource
                .save(fruta);    
        }

    }
    
    apaga(id) {

        return this._resource
            .delete({ id })
            .then(null, err => {
                console.log(err);
                throw new Error('Não foi possível remover a fruta');
            })
    }

    busca(id) {

        return this._resource
            .get({ id })
            .then(res => res.json());
    }

}