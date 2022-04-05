import { useState, useEffect } from 'react'
import axios from 'axios'
import { Link } from 'react-router-dom'

import BarChart from '../components/Grafico'
import { UserData } from '../teste'

import img_perfil from '../assets/img/profile.svg'
import icone_verde from '../assets/img/icone.svg'

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
                            <span>Lucros</span>
                            <span>R$ 12.500,00</span>
                            <span>+ 2,2% que na semana passada</span>
                        </div>
                        <div className="logo_box">
                            <img src={icone_verde} alt="Icone referente ao lucro do sistema" />
                        </div>
                    </div>

                    <div className="box_info box_info_vermelho">
                        <div className="infos">
                            <span>Custos</span>
                            <span>R$ 512,50</span>
                            <span>+ 5,4% que na semana passada</span>
                        </div>
                        <div className="logo_box">
                            <img src={icone_verde} alt="Icone referente ao lucro do sistema" />
                        </div>
                    </div>

                    <div className="box_info box_info_amarelo">
                        <div className="infos">
                            <span>Usuarios Totais</span>
                            <span>8.2K</span>
                            <span>Taxa de crescimento de 8% ao mês</span>
                        </div>
                        <div className="logo_box">
                            <img src={icone_verde} alt="Icone referente ao lucro do sistema" />
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