<template>
    <div id="login">
        <div class="login__content card">
            <div class="login__content__wrapper">

                <div>
                    <h3 flex center>Acesso ao sistema</h3>               
                    <form @submit.prevent="efetuarLogin" class="login__content__wrapper">

                        <div class="login__content__row__input card">
                            <input class="login__input" placeholder="Informe o login" type="usuario" v-model="usuario.Username" />
                        </div>

                        <div class="login__content__row__input card">
                            <input class="login__input" placeholder="Digite sua senha" type="password" v-model="usuario.Password" />
                        </div>
                        <div class="login__button_content">
                            <button type="submit">Entrar</button> 
                        </div>       
                    </form>

                    <p v-if="mensagem" flex center>
                        <b class="mensagem">{{mensagem}}</b>
                    </p>
                </div>                 
            </div>  
        </div>
    </div>    
</template>

<script>
import axios from 'axios';

export default {

    data() {

        return {

            usuario: {username:'', password:''},
            id: this.$route.params.id,
            mensagem: ""
        }
    },    
      
    methods: {  
        efetuarLogin() {

            let http = axios.create({
                timeout: 120000,
            });

            http.interceptors.request.use(function (config) {
                const token = localStorage.getItem('Token');
                if (token) {
                    config.headers.Authorization = `Bearer ${token}`;
                    return config;
                }
                else
                    return new Promise(function (resolve, reject) {
                        $router.push({ name: "login" });
                    });    
            }, erro => {       
                localStorage.removeItem('Token');
                $router.push({ name: "login" });
            }    
            );            

            if((this.usuario.Username === undefined)||(this.usuario.Password === undefined)||(this.usuario.Username === "")||(this.usuario.Password===""))
                this.mensagem = "Dados incompletos";
            else
            {
                const http = axios.create({
                    baseURL: "https://localhost:44387/api/auth",
                    headers: {
                        'Accept': 'application/json',
                        'Content': 'application/json',
                        'Access-Control-Allow-Origin':'*',
                        'Access-Control-Allow-Methods':' GET, PUT, POST, DELETE, OPTIONS, post, get',
                        'Access-Control-Max-Age': '3600',
                        'Access-Control-Allow-Headers':'Origin, Content-Type, X-Auth-Token',
                        'Access-Control-Allow-Credentials': 'true'
                    }
                });

                this.mensagem = "";

                http.interceptors.request.use(function (config) {
                    const token = localStorage.getItem('Token');
                    if (token) {
                        config.headers.Authorization = `Bearer ${token}`;
                    }
                    return config;
                }, function (erro) {
                    return Promise.reject(erro);
                });              

                http.post("login", this.usuario)
                    .then(response => {
                        localStorage.setItem("Token", response.data);
                        this.$router.push({ name: "home" });
                    })
                    .catch(erro => this.mensagem = "Dados inválidos "+erro.message);
            }
        }
    }
    
}
</script>

<style>

#login {
    height: 100vh;
    width: 100%;
    padding: 16px;
    text-align: center;
}
.login__button {
    height: 36px;    
}
.login__content {
    height: 100%;
    display: flex;
    align-items: center;
    justify-content: center;
    background-size: cover;
    background-repeat: no-repeat;
}
.login__content__row__input {
    flex: 1;
    height: 100%;
    display: flex;
    align-items: center;
    margin-top: 10px;
    
}
.login__input {
    font-size:14px;
    border: solid;
    border-width: thin;
    width: 100%;
    height: 100%;
    padding: 5px 5px;
	margin: 10px 0px;
    background:none;
    
    border-radius: 6px;
    font-weight: var(--medium);
    text-align: center;
}
.login__input::placeholder {
    font-size: 0.875rem;
    color: var(--light-text);        
    text-align: center;
}
.login__content__wrapper {
    width: 380px;
}

.login__logo {
    height: 90px;
}
.login__button {
    height: 36px;
    opacity: 0;
}

.login__button_content {
    height: 100%;
    display: flex;
    align-items: center;
    justify-content: center;
}

button{
	height:40px;
	padding: 5px 5px;
	margin: 10px 0px;
	font-weight:bold;
	background-color:black;
	border:none;
	color:white;
	cursor:pointer;
	font-size:16px;
    border-radius: 25px;  
    width:100px;  
}
button:hover{
	background-color:#1b1b1b;
}

.mensagem {
    color: var(--error) !important;
}
</style>
