import { useState } from 'react'
import axios from 'axios'
import { Link } from 'react-router-dom'

import BarChart from '../components/Grafico'
import { UserData } from '../teste'

import img_perfil from '../assets/img/profile.svg'
import icone_verde from '../assets/img/icone.svg'
import icone_vermelho from '../assets/img/vermelho.svg'
import icone_amarelo from '../assets/img/amarelo.svg'

import '../assets/css/PainelADM.css'

export default function PainelADM() {
    const [userData, setUserData] = useState({
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
        <div>
            <header className="cabecalho">
                <Link to="/" className="logout">Logout</Link>
                <img src={img_perfil} alt="Imagem de perfil do usuario logado" />
            </header>
            <section className="Background">
                <div className="container_infos">
                    <div className="box_info">
                        <div className="infos">
                            <span className="titulo">Lucros</span>
                            <span className="valor">R$ 12.500,00</span>
                            <span className="complemento">+ 2,2% que na semana passada</span>
                        </div>
                        <div className="logo_box">
                            <img src={icone_verde} alt="Icone referente ao lucro do sistema" />
                        </div>
                    </div>

                    <div className="box_info box_info_vermelho">
                        <div className="infos">
                            <span className="titulo">Custos</span>
                            <span className="valor">R$ 512,50</span>
                            <span className="complemento">+ 5,4% que na semana passada</span>
                        </div>
                        <div className="logo_box">
                            <img src={icone_vermelho} alt="Icone referente aos custos do sistema" />
                        </div>
                    </div>

                    <div className="box_info box_info_amarelo">
                        <div className="infos">
                            <span className="titulo">Usuarios Totais</span>
                            <span className="valor">8.2K</span>
                            <span className="complemento">Taxa de crescimento de 8% ao mês</span>
                        </div>
                        <div className="logo_box">
                            <img src={icone_amarelo} alt="Icone referente a quantidade de usuarios" />
                        </div>
                    </div>
                </div>
                <div className="container_grafico">
                <BarChart chartData={userData} className="teste"/>
                </div>
            </section>
        </div>
    )
}