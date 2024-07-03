using BackLibs.Entities;
using BackLibs.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackLibs.Utils
{
    public class ManejadorBacklog
    {
        public delegate void DelegadoBacklog(Serie ciudadano);
        public event DelegadoBacklog NuevaSerieParaVer;

        public void IniciarManejador(List<Serie> series) {
            Task.Run(() => MoverSeries(series));
        }
        private void MoverSeries(List<Serie> series) {
            int i;
            
            while(series.Count>0) {
                i = series.GenerarRandom();
                Serie serieUpd = series[i];
                
                AccesoDatos.ActualizarSerie(serieUpd);

                Thread.Sleep(1500);
                if (NuevaSerieParaVer is not null) {
                    NuevaSerieParaVer.Invoke(serieUpd);
                }
            }
        }

    }
}
