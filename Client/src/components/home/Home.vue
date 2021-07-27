<template>
  <div>
    <h1 class="centralizado">{{ titulo }}</h1>

    <p v-show="mensagem" class="centralizado">{{ mensagem }}</p>

    <input type="search" class="filtro" @input="filtro = $event.target.value" placeholder="filtre por parte do título">

    <ul class="lista-frutas">
      <li class="lista-frutas-item" v-for="fruta of frutasComFiltro">

        <meu-painel :titulo="fruta.nome">
          
          <imagem-responsiva v-meu-transform:scale.animate="1.2" :url="fruta.foto" :titulo="fruta.descricao"/>
          
          <meu-botao v-show="fruta.quantidade>0" tipo="button" @botaoAtivado="compra(fruta)" rotulo="Comprar"/>
          
          <h2 v-show="fruta.quantidade==0">Esgotado</h2>
          
        </meu-painel>

      </li>
    </ul>
  </div>
</template>

<script>
import Painel from '../shared/painel/Painel.vue';
import ImagemResponsiva from '../shared/imagem-responsiva/ImagemResponsiva.vue';
import Botao from '../shared/botao/Botao.vue';
import FrutaService from '../../domain/fruta/FrutaService';
import CarrinhoService from '../../domain/fruta/CarrinhoService';

export default {

  components: {
    'meu-painel' : Painel, 
    'imagem-responsiva': ImagemResponsiva,
    'meu-botao' : Botao
  },

  data() {

    return {

      titulo: 'Cesta de frutas', 
      frutas: [], 
      filtro: '',
      carrinho: {'frutaId':''},
      mensagem: ''
    }
  },

  computed: {

    frutasComFiltro() {

      if(this.filtro) {
        let exp = new RegExp(this.filtro.trim(), 'i');
        return this.frutas.filter(fruta => exp.test(fruta.nome));
      } else {
        return this.frutas;
      }
    }
  },

  methods: {

    compra(fruta) { 
      this.carrinho.frutaId = fruta.id; 
      this.carrinhoService.cadastra(this.carrinho).finally(function () {
          this.$router.push({ name: "Carrinho" });
      });
    }

  },

  created() {

    this.service = new FrutaService(this.$resource);
    this.carrinhoService = new CarrinhoService(this.$resource);

    this.service
      .lista()
      .then(frutas => this.frutas = frutas, 
      err => {this.mensagem = err.message; this.$router.push({ name: "Login" })});
  }
}

</script>

<style>

  .centralizado {

    text-align: center;
  }

  .lista-frutas {
    list-style: none;
  }

  .lista-frutas .lista-frutas-item {

    display: inline-block;
  }

  .filtro {

    display: block;
    width: 100%;
  }
</style>
