import React from 'react'
import { Bar } from 'react-chartjs-2'
import { Chart as ChartJS } from "chart.js/auto";

export const options = {
    responsive: true,
    plugins: {
      legend: {
        position: 'right',
      },
      title: {
        display: true,
        text: 'Exemplo Gráfico',
      },
    },
  };

function BarChart({ chartData }) {
    return <Bar options={options} data={chartData} className="grafico"/>;
}

export default BarChart