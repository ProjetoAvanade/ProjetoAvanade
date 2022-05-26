import axios from 'axios';
import React, { Component } from 'react';
import { parsejwt } from '../services/Auth';
import banner_login from '../assets/img/banner_login.svg'
import logo_login from '../assets/img/logo-login.svg'

import '../assets/css/login.css'


export default class Login extends Component {

    constructor(props) {
        super(props)
        this.state = {
            email: '',
            senha: '',
            isLoading: false,
            MensagemErro: '',
        }
    }

    efetuarlogin = (evento) => {
        evento.preventDefault();
        this.setState({ mensagemErro: '', isLoading: true });
        axios.post('https://api-avanade.azurewebsites.net/api/login', {
            email: this.state.email,
            senha: this.state.senha
        }).then(resposta => {
            if (resposta.status === 201) {
                localStorage.setItem('usuario-login', resposta.data.token);
                this.setState({ isLoading: false })
                switch (parsejwt().role) {
                    case '1':
                        window.location.href = "../painelADM"
                        break;
                    default:
                        console.log('nn vai')
                        break;
                }
            }

        }).catch(() => {
            this.setState({
                MensagemErro: 'Email ou senha invalido',
                isLoading: false,
                email: '',
                senha: ''
            }, console.log('deu errado'))
        })
    }

    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name]: campo.target.value });
    }

    render() {
        return (
            <div className="container_tela">
                <div className="banner_login">
                    <div className='box_banner'>
                        <img className='logo' src={logo_login} alt="A logo do nosso site" />
                        <div className="box_img">
                            <img src={banner_login} alt="Pessoa andando de bicicleta" />
                        </div>
                        <span>© 2022 Avanade</span>
                    </div>
                </div>

                <section className='container_login'>
                    <div className='box_login'>
                        <div className='box_titulo'>
                            <h1 className='Titulo'>Login</h1>
                            <h2 className='Sub-titulo'>Acesse sua conta e veja a dashboard</h2>
                        </div>
                        <form onSubmit={this.efetuarlogin} className="box_form">

                            <div className="box_inputs">

                                <input name="email" type="text" placeholder="Email" className="input_login" value={this.state.email} onChange={this.atualizaStateCampo} />

                                <input name="senha" type="password" placeholder="Senha" className="input_login" value={this.state.senha} onChange={this.atualizaStateCampo} />

                                <span className="Mensagem_erro">{this.state.MensagemErro}</span>
                                {
                                    this.state.isLoading === true ? <button disabled className="btn_login">Entrando ...</button> : <button type='submit' className="btn_login">Login</button>
                                }
                            </div>
                        </form>
                    </div>
                </section>
            </div>
        )
    }
}