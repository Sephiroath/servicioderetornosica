using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using BussinessLayer;
using System.Threading;

namespace WS_ServicioRetornoSicacom
{
    public partial class WS_ReversoRetiro : ServiceBase
    {
        private static System.Timers.Timer aTimer;
        public WS_ReversoRetiro()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                ServiceAccess.setParametros();
                aTimer = new System.Timers.Timer(ServiceAccess.intervalo);
                aTimer.Elapsed += EventoTimer;
                aTimer.AutoReset = true;
                aTimer.Start();
            }
            catch (Exception e)
            {
                Library.WriteErrorLog(e);
            }
        }
        private static void EventoTimer(Object source, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                RealizarProcesamientotransaccion();
            }
            catch (Exception ex)
            {
                Library.WriteErrorLog(ex);
            }
        }
        protected static void RealizarProcesamientotransaccion()
        {
            try
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
            catch (Exception e)
            {
                Library.WriteErrorLog(e);
            }
        }

        protected override void OnStop()
        {
            aTimer.Stop();
            aTimer = null;
        }
    }
}
