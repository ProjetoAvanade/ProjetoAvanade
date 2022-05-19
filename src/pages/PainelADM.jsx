import { useEffect, useState } from 'react'
import axios from 'axios'
import { Link } from 'react-router-dom'

import { UserData } from '../teste'

import logo_login from '../assets/img/logo-login.svg'
import icon_dashboard from '../assets/img/dashboard.svg'
import icon_perfil from '../assets/img/perfil.svg'
import icon_sair from '../assets/img/sair.svg'
import icon_email from '../assets/img/icon_email.svg'
import icon_bolo from '../assets/img/icon_bolo.svg'
import img_perfil from '../assets/img/img_perfil.png'

import '../assets/css/PainelADM.css'



export default function PainelADM() {
    const [NomeUsuario, setNomeUsuario] = useState("")
    const [cpf, setCpf] = useState("")
    const [Email, setEmail] = useState("")
    const [DataNascimento, setDataNascimento] = useState(Date.now);

    function BuscarUsuario() {
        axios('https://api-avanade.azurewebsites.net/api/Usuario', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        }).then((resposta) => {
            if (resposta.status === 200) {
                console.log(resposta.data)
                setNomeUsuario(resposta.data.NomeUsuario)
                setCpf(resposta.data.Cpf)
                setEmail(resposta.data.Email)
                setDataNascimento(resposta.data.DataNascimento)
            }
        }).catch(erro => console.log(erro))
    }


    function atualizar_conteudo() {
        var conteudo = document.getElementById("teste");
        var conteudo_perfil = document.getElementById("teste_perfil");
        var menu_dash = document.getElementById("menu_dash");
        var menu_perfil = document.getElementById("menu_perfil");
        conteudo.style.display = "block";
        conteudo_perfil.style.display = "none"
        if (conteudo.style.display === "block") {
            menu_dash.style.backgroundColor = "#F8F9FD"
            menu_perfil.style.backgroundColor = "#F2F2F2"
        }
    }

    function atualizar_conteudo_perfil() {
        var conteudo = document.getElementById("teste");
        var conteudo_perfil = document.getElementById("teste_perfil");
        var menu_dash = document.getElementById("menu_dash");
        var menu_perfil = document.getElementById("menu_perfil");
        conteudo.style.display = "none";
        conteudo_perfil.style.display = "block"
        if (conteudo_perfil.style.display === "block") {
            menu_dash.style.backgroundColor = "#F2F2F2"
            menu_perfil.style.backgroundColor = "#F8F9FD"
        }
    }

    useEffect(BuscarUsuario(), []);

    return (
        <div className='Container_tela'>
            <section className='menu_sidebar'>
                <img src={logo_login} alt="Logo do Bikecione" className='logo' />

                <div className='box_secoes'>
                    <div className='box_campo' onClick={() => atualizar_conteudo()} id="menu_dash">
                        <img src={icon_dashboard} alt="Imagem para a tela de dashboard" />
                        <span>Dashboard</span>
                    </div>
                    <div className='box_perfil' onClick={() => atualizar_conteudo_perfil()} id="menu_perfil">
                        <img src={icon_perfil} alt="Imagem para a tela de perfil" />
                        <span>Perfil</span>
                    </div>
                </div>

                <div className='box_link'>
                    <Link to='/' className='box_sair'>
                        <img src={icon_sair} alt="Imagem para sair da aplicação" />
                        <span>Sair</span>
                    </Link>
                </div>
            </section>
            <section className='conteudo' id='teste'>

                <div className='cabecalho'>
                    <h1 className='titulo'>Dashboard</h1>
                </div>

                <section className='container_graficos'>
                    <div className='grafico'></div>
                    <div className='grafico'></div>
                </section>
            </section>

            <section className='conteudo_perfil' id='teste_perfil'>
                <div className='cabecalho'>
                    <h1 className='titulo'>Perfil</h1>
                </div>

                <section className='container_perfil'>
                    <img src={img_perfil} alt="Foto de Perfil do usuario" className='img_user' />
                    <div className='box_info_usuarios'>
                        <span>{NomeUsuario}</span>
                        <span>{cpf}</span>
                        <div className='box_icon'>
                            <img src={icon_email} alt="Icone de Email" />
                            <span>{Email}</span>
                        </div>
                        <div className='box_icon_bolo'>
                            <img src={icon_bolo} alt="Icone de Aniversario" />
                            <span>{DataNascimento}</span>
                        </div>
                    </div>
                </section>
            </section>
        </div>
    )
}