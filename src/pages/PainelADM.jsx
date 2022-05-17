import { useState } from 'react'
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
    const [userData] = useState({
        labels: UserData.map((data) => data.month),
        datasets: [
            {
                label: "Lucros",
                data: UserData.map((data) => data.userGain),
                backgroundColor: [
                    "#90F926",
                ],
            },
            {
                label: "Perdas",
                data: UserData.map((data) => data.userLost),
                backgroundColor: [
                    "#F92626",
                ],
            },
        ],
    });
    return (
        <div className='Container_tela'>
            <section className='menu_sidebar'>
                <img src={logo_login} alt="Logo do Bikecione" className='logo' />

                <div className='box_secoes'>
                    <div className='box_campo'>
                        <img src={icon_dashboard} alt="Imagem para a tela de dashboard" />
                        <span>Dashboard</span>
                    </div>
                    <div className='box_perfil'>
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
            <section className='conteudo'>

                <div className='cabecalho'>
                    <h1 className='titulo'>Dashboard</h1>
                </div>

                <section className='container_graficos'>
                    <div className='grafico'></div>
                    <div className='grafico'></div>
                </section>
            </section>

            <section className='conteudo_perfil'>
                <div className='cabecalho'>
                    <h1 className='titulo'>Perfil</h1>
                </div>
                
                <section className='container_perfil'>
                    <img src={img_perfil} alt="Foto de Perfil do usuario" className='img_user'/>
                    <div className='box_info_usuarios'>
                        <span>Yuri Mitsugui Chiba</span>
                        <span>000.000.000-00</span>
                        <div className='box_icon'>
                            <img src={icon_email} alt="Icone de Email" />
                            <span>yurichiba@gmail.com</span>
                        </div>
                        <div className='box_icon_bolo'>
                            <img src={icon_bolo} alt="Icone de Aniversario" />
                            <span>24/12/2004</span>
                        </div>
                    </div>
                </section>
            </section>
        </div>
    )
}