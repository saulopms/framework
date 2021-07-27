import Home from './components/home/Home.vue';
import Login from './components/login/Login.vue';
import Cadastro from './components/cadastro/Cadastro.vue';

export const routes = [
    { path: '', name: 'home', component: Home, titulo: 'Home', menu: true},
    { path: '/cadastro', name: 'Carrinho', component: Cadastro, titulo: 'Meu carrinho', menu: true},
    { path: '/cadastro/:id', name: 'altera', component: Cadastro, titulo: 'Meu carrinho', menu: false},
    { path: '/login', name: 'Login', component: Login, titulo: 'Login', menu: false},    
    { path: '*', component: Home, menu: false}
];