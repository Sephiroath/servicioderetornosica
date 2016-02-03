using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;
using System.Data;
using System.Diagnostics;
using System.Threading;
using System.Configuration;

namespace BussinessLayer
{
    public class ServiceAccess
    {
        public static int intervalo { get; set; }
        public static int tiempoespera { get; set; }
        public static int horainicio { get; set; }
        public static int horafin { get; set; }
        public static string TramaRetorno { get; set; }
        public static string TramaEnvio { get; set; }
        public static DateTime fechainiciotransaccion { get; set; }
        public static void setParametros()
        {
            DataTable dtDatosRetorno = new DataTable();
            int varIntValid;
            try
            {
                #region SetIntervalo
                if (DataLayer.Procesos.TraerParametros(ConfigurationManager.AppSettings["Id_Intervalo"], ConfigurationManager.AppSettings["Centro_Intervalo"], ref dtDatosRetorno,0))
                {
                    foreach (DataRow drFila in dtDatosRetorno.Rows)
                    {
                        bool isNumerical = int.TryParse(drFila[6].ToString(), out varIntValid);
                        if (isNumerical) { intervalo = varIntValid; } else { intervalo = int.Parse(ConfigurationManager.AppSettings["Default_Intervalo"]); }
                    }
                }
                else { intervalo = int.Parse(ConfigurationManager.AppSettings["Default_Intervalo"]); }
                #endregion
                #region SetTimeout
                if (DataLayer.Procesos.TraerParametros(ConfigurationManager.AppSettings["Id_Timeout"], ConfigurationManager.AppSettings["Centro_Timeout"], ref dtDatosRetorno,0))
                {
                    foreach (DataRow drFila in dtDatosRetorno.Rows)
                    {
                        bool isNumerical = int.TryParse(drFila[6].ToString(), out varIntValid);
                        if (isNumerical) { tiempoespera = varIntValid; } else { tiempoespera = int.Parse(ConfigurationManager.AppSettings["Default_Timeout"]); }
                    }
                }
                else { tiempoespera = int.Parse(ConfigurationManager.AppSettings["Default_Timeout"]); }
                #endregion
                #region SetHoraInicio
                if (DataLayer.Procesos.TraerParametros(ConfigurationManager.AppSettings["Id_HoraInicio"], ConfigurationManager.AppSettings["Centro_HoraInicio"], ref dtDatosRetorno,0))
                {
                    foreach (DataRow drFila in dtDatosRetorno.Rows)
                    {
                        bool isNumerical = int.TryParse(drFila[6].ToString(), out varIntValid);
                        if (isNumerical) { horainicio = varIntValid; } else { horainicio = int.Parse(ConfigurationManager.AppSettings["Default_HoraInicio"]); }
                    }
                }
                else { horainicio = int.Parse(ConfigurationManager.AppSettings["Default_HoraInicio"]); }
                #endregion
                #region SetHoraFin
                if (DataLayer.Procesos.TraerParametros(ConfigurationManager.AppSettings["Id_HoraFin"], ConfigurationManager.AppSettings["Centro_HoraFin"], ref dtDatosRetorno,0))
                {
                    foreach (DataRow drFila in dtDatosRetorno.Rows)
                    {
                        bool isNumerical = int.TryParse(drFila[6].ToString(), out varIntValid);
                        if (isNumerical) { horafin = varIntValid; } else { horafin = int.Parse(ConfigurationManager.AppSettings["Default_HoraFin"]); }
                    }
                }
                else { horafin = int.Parse(ConfigurationManager.AppSettings["Default_HoraFin"]); }
                #endregion
                #region ValidarVariables
                if (intervalo <= 0) { intervalo = int.Parse(ConfigurationManager.AppSettings["Default_Intervalo"]); }
                if (tiempoespera <= 25000) { tiempoespera = int.Parse(ConfigurationManager.AppSettings["Default_Timeout"]); }
                if (horainicio <= -1 || horainicio >= 86400) { horainicio = int.Parse(ConfigurationManager.AppSettings["Default_HoraInicio"]); }
                if (horafin <= 0 || horainicio > 86400) { horafin = int.Parse(ConfigurationManager.AppSettings["Default_HoraFin"]); }
                if (horafin <= horainicio) { horainicio = int.Parse(ConfigurationManager.AppSettings["Default_HoraInicio"]); horafin = int.Parse(ConfigurationManager.AppSettings["Default_HoraFin"]); }
                #endregion

            }
            catch (Exception e) { Library.WriteErrorLog(e); }
            finally { dtDatosRetorno = null; }
        }
        private static WR_NoBankOfficeSvr.RetRespuesta rr { get; set; }

        ~ServiceAccess() { rr = null; }

        public static void RealizarSolicitudRechazo(int tipoconexion)
        {
            DataTable dtRetirosRetorno = new DataTable();
            TramaEnvio = "";
            string[] SepararTrama;
            fechainiciotransaccion = DateTime.Now;
            System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
            dtRetirosRetorno = DataLayer.Procesos.TraerTransferenciaRetorno(tipoconexion);
            try
            {
                WR_NoBankOfficeSvr.RetSolicitud rs = new WR_NoBankOfficeSvr.RetSolicitud();
                foreach (DataRow drFila in dtRetirosRetorno.Rows)
                {
                    #region fill RetSolicitud
                    fechainiciotransaccion = DateTime.Now;
                    SepararTrama = drFila[30].ToString().Split('|');
                    TramaEnvio = drFila[30].ToString();
                    if (SepararTrama.Length == 20)
                    {
                        rs.CanalOrigen = SepararTrama[0].ToString();
                        rs.IdentificacionDispositivo = SepararTrama[1].ToString();
                        rs.LocalizacionDispositivo = SepararTrama[2].ToString();
                        rs.FechaTransaccion = int.Parse(SepararTrama[3].ToString());
                        rs.HoraTransaccion = int.Parse(SepararTrama[4].ToString());
                        rs.NumeroSecuencia = int.Parse(SepararTrama[5].ToString());
                        rs.IdentificacionUsuario = SepararTrama[6].ToString();
                        rs.ClaveUsuario = SepararTrama[7].ToString();
                        rs.ClaveOTP = SepararTrama[8].ToString();
                        rs.CodigoTransaccion = int.Parse(SepararTrama[9].ToString());
                        rs.NumeroTerminal = SepararTrama[10].ToString();
                        rs.EntidadOrigen = short.Parse(SepararTrama[11].ToString());
                        rs.TipoProductoOrigen = short.Parse(SepararTrama[12].ToString());
                        rs.NumeroProductoOrigen = int.Parse(SepararTrama[13].ToString());
                        rs.EntidadDestino = short.Parse(SepararTrama[14].ToString());
                        rs.TipoProductoDestino = short.Parse(SepararTrama[15].ToString());
                        rs.NumeroProductoDestino = int.Parse(SepararTrama[16].ToString());
                        rs.ValorRetiro = int.Parse(SepararTrama[17].ToString());
                        rs.NumeroCelular = long.Parse(SepararTrama[18].ToString());
                        rs.IndicadorReverso = SepararTrama[18].ToString();
                    }
                    else
                    {
                        DataLayer.Procesos.AgregarLogErrores(drFila);
                        continue;
                    }
                    #endregion
                    //Thread t = new Thread(metodo);
                    //t.Start(rs);
                    int var1 = LlamadoServicioRetiro(rs, tipoconexion);
                    //if (t.Join(tiempoespera))
                    //{

                    if (var1 == -1)
                    {
                        #region ActualizacionBDfallida
                        DataLayer.Procesos.ActualizarCodigoRetorno(drFila[0].ToString(), "PP",tipoconexion);
                        DataLayer.Procesos.AgregarEventoLog(drFila, fechainiciotransaccion, TramaRetorno, rr.CodigoRespuesta, rr.MensajeRespuesta, "",tipoconexion);
                        #endregion                        
                    }
                    else
                    {
                        #region ActualizacionBDExitosa
                        DataLayer.Procesos.ActualizarCodigoRetorno(drFila[0].ToString(), "P",tipoconexion);
                        DataLayer.Procesos.AgregarEventoLog(drFila, fechainiciotransaccion, TramaRetorno, rr.CodigoRespuesta, "", "",tipoconexion);
                        #endregion
                    }

                    //}
                    //else { DataLayer.Procesos.AgregarEventoLog(drFila, fechainiciotransaccion, "Timeout en llamado de servicio",1, "",""); }

                    //t = null;
                }

                //NBOfficeSvr.Dispose();
                rs = null;
                //rr = null;
            }
            catch (Exception e)
            {
                //dtRetirosRetorno.Rows
                DataLayer.Procesos.AgregarEventoLog2(fechainiciotransaccion, TramaEnvio, "error durante llamado al servicio: " + e.Message, 1, "", "", tipoconexion);
            }
            finally
            {
                dtRetirosRetorno.Dispose();
                dtRetirosRetorno = null;
            }
        }

        public static void metodo(object rs, int tipoconexion)
        {
            WR_NoBankOfficeSvr.RetSolicitud rs2 = (WR_NoBankOfficeSvr.RetSolicitud)rs;
            WR_NoBankOfficeSvr.NoBankOfficeSvr NBOfficeSvr = new WR_NoBankOfficeSvr.NoBankOfficeSvr();
            try
            {
                rr = new WR_NoBankOfficeSvr.RetRespuesta();
                rr = NBOfficeSvr.solicitudRetiro(rs2);
                TramaRetorno = rr.CanalOrigen + "|" + rr.IdentificacionDispositivo + "|" + rr.LocalizacionDispositivo + "|" + rr.FechaCompensacion.ToString() + "|" + rr.HoraTransaccion.ToString() + "|" + rr.NumeroSecuencia.ToString() + "|" + rr.CodigoRespuesta.ToString() + "|" + rr.MensajeRespuesta.ToString() + "|" + rr.TipoError.ToString() + "|" + rr.NumeroAutorizacion.ToString() + "|" + rr.CostoTransaccion.ToString() + "|" + rr.FechaCompensacion.ToString();
            }
            catch (Exception e)
            {
                DataLayer.Procesos.AgregarEventoLog2(fechainiciotransaccion, TramaEnvio, "Error en llamado de servicio: " + e.Message, 1, "", "", tipoconexion);
            }
        }

        public static int LlamadoServicioRetiro(WR_NoBankOfficeSvr.RetSolicitud varrs, int tipoconexion)
        {
            WR_NoBankOfficeSvr.NoBankOfficeSvr NBOfficeSvr = new WR_NoBankOfficeSvr.NoBankOfficeSvr();
            NBOfficeSvr.Timeout = tiempoespera;
            int codrespuesta = -1;
            try
            {
                rr = new WR_NoBankOfficeSvr.RetRespuesta();
                rr = NBOfficeSvr.solicitudRetiro(varrs);
                TramaRetorno = rr.CanalOrigen + "|" + rr.IdentificacionDispositivo + "|" + rr.LocalizacionDispositivo + "|" + rr.FechaCompensacion.ToString() + "|" + rr.HoraTransaccion.ToString() + "|" + rr.NumeroSecuencia.ToString() + "|" + rr.CodigoRespuesta.ToString() + "|" + rr.MensajeRespuesta.ToString() + "|" + rr.TipoError.ToString() + "|" + rr.NumeroAutorizacion.ToString() + "|" + rr.CostoTransaccion.ToString() + "|" + rr.FechaCompensacion.ToString();
                codrespuesta = rr.CodigoRespuesta;
            }
            catch (Exception e)
            {
                DataLayer.Procesos.AgregarEventoLog2(fechainiciotransaccion, TramaEnvio, "Error en llamado de servicio: " + e.Message, 1, "", "", tipoconexion);
            }
            finally
            {
                NBOfficeSvr = null;
            }
            return codrespuesta;
        }

        private Boolean ValidarCertificado(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

    }
}
