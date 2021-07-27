import Vue from 'vue'
import App from './App.vue'
import VueResource from 'vue-resource';
import VueRouter from 'vue-router';
import { routes } from './routes';
import './directives/Transform';
import VeeValidate from 'vee-validate';
import msg from './pt_BR';

Vue.use(VueResource);


Vue.http.interceptors.push((request, next) => {
  const token = localStorage.getItem('Token'); 
  if (token)
  {         
    request.headers.set('Authorization', 'Bearer '+token)
    request.headers.set('Accept', 'application/json')
  }
  next()
})


Vue.http.options.root = 'https://localhost:44374';

Vue.use(VueRouter);

const router = new VueRouter({ 
  routes, 
  mode: 'history'
});

Vue.use(VeeValidate, {
  
  locale: 'pt_BR',
  dictionary: {
    pt_BR: {
      messages: msg
    }
  }
});

new Vue({
  el: '#app',
  router,
  render: h => h(App)
})

