import Item from './ItemCarrinho';
export default class Carrinho {

    constructor(TotalPedido=0.00, Finalizado=false, Itens = []) {

        this.totalPedido = TotalPedido;
        this.finalizado = Finalizado;
        this.Itens = Itens;
    }
}