using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BussinessLayer;
using System.Threading;

namespace ServicioRetornoSicacom
{
    class Program
    {
        private static System.Timers.Timer aTimer;
        static void Main(string[] args)
        {
            ServiceAccess.setParametros();
            ServiceAccess.intervalo = 1000;
            aTimer = new System.Timers.Timer(ServiceAccess.intervalo);
            aTimer.Elapsed += EventoTimer;
            aTimer.AutoReset = true;
            aTimer.Start();
            GC.KeepAlive(aTimer);
            Console.ReadLine();
            //System.Threading.Timer timer;
        }
        private static void EventoTimer(Object source, System.Timers.ElapsedEventArgs e)
        {
            RealizarProcesamientotransaccion();
            Console.ReadLine();
        }
        protected static void RealizarProcesamientotransaccion()
        {
            aTimer.Stop();
            ServiceAccess.setParametros();
            aTimer.Interval = ServiceAccess.intervalo;
            if (DateTime.Now.TimeOfDay.TotalSeconds > ServiceAccess.horainicio && DateTime.Now.TimeOfDay.TotalSeconds <= ServiceAccess.horafin)
            {
                for (int i = 0; i < 3; i++)
                {
                    ServiceAccess.RealizarSolicitudRechazo(i);
                }
            }
            aTimer.Start();
        }
    }
}
