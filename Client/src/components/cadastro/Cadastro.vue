<template>

  <div>
    <h1 class="centralizado">Carrinho de frutas</h1>
    
    <form>

      <div class="container" id="app">
        <div class="row">
          <div class="col">
            <table class="table table-bordered table-striped table-hover" style="width:100%">
              <thead class="thead">
                <tr>
                  <th>Produto</th>
                  <th>Preço</th>
                  <th>Quantidade</th>
                  <th>Total</th>
                </tr>
              </thead>
              <tbody>
                <tr v-for="produto in carrinho.itens" v-bind:key="produto.Id">
                  <td>{{ produto.nome }}</td>
                  <td>{{ produto.valor }}</td>
                  <td>{{ produto.quantidade }}</td>
                </tr>
              </tbody>
              <tfoot>
                <tr>
                  <th colspan="3">Total</th>
                  <th>{{ carrinho.totalPedido }}</th>
                </tr>
              </tfoot>
            </table>
          </div>
        </div>
      </div>

      <div class="centralizado">
        <router-link :to="{ name: 'home'}"><meu-botao rotulo="VOLTAR" tipo="button"/></router-link>
      </div>

    </form>
  </div>
</template>

<script>

import ImagemResponsiva from '../shared/imagem-responsiva/ImagemResponsiva.vue'
import Botao from '../shared/botao/Botao.vue';
import Carrinho from '../../domain/fruta/Carrinho';
import CarrinhoService from '../../domain/fruta/CarrinhoService';

export default {

  components: {

    'imagem-responsiva': ImagemResponsiva, 
    'meu-botao': Botao
  },

  data() {

      return {

          carrinho: new Carrinho(),
          id: this.$route.params.id
      }
  },

  methods: {

      removerProduto: function (p) {
        this.carrinho.itens = this.carrinho.itens = this.carrinho.itens.filter(i => i.nome !== p.nome);
      },
      totalItem: function(p){
        return  p.valor * p.quantidade
      },    
      grava() {

         this.$validator
          .validateAll()
          .then(success => {

            if(success) {

              this.service
                .cadastra(this.carrinho)
                .then(() => {
                  if(this.id) this.$router.push({ name: 'home' });
                  this.carrinho = new Carrinho();
                }, err => console.log(err));
            }
          });
      }
  },

  async created() {

      this.service = new CarrinhoService(this.$resource);
             
      await this.service
        .lista()
        .then(carrinho => this.carrinho = carrinho, err => { this.$router.push({ name: "Login" })});        
  },
}

</script>
<style scoped>

  .container {
    margin: 20px;
    margin-top: 80px;    
}

.centralizado
{
    text-align: center;
}

input{
    border-radius: 10px;
    padding: 5px 5px 5px 5px;
    margin-left: 10px;

}

table {
  margin-top:20px;
  border: 2px solid #000000;
  border-radius: 3px;
  background-color: #fff;
  width: 100%;
}

th {
  background-color: #000000c9;
  color: white;
  cursor: pointer;
  -webkit-user-select: none;
  -moz-user-select: none;
  -ms-user-select: none;
  user-select: none;
}

td {
  background-color: #f9f9f9;
}

th,
td {
  min-width: 120px;
  padding: 10px 20px;
}

th.active {
  color: #fff;
}

th.active .arrow {
  opacity: 1;
}

.arrow {
  display: inline-block;
  vertical-align: middle;
  width: 0;
  height: 0;
  margin-left: 5px;
  opacity: 0.66;
}

.arrow.asc {
  border-left: 4px solid transparent;
  border-right: 4px solid transparent;
  border-bottom: 4px solid #fff;
}

.arrow.dsc {
  border-left: 4px solid transparent;
  border-right: 4px solid transparent;
  border-top: 4px solid #fff;
}

.mensagemErro{
    color: brown;
}
</style>