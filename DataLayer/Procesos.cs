using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;
using System.Diagnostics;

namespace DataLayer
{
    public class Procesos
    {
        public static bool TraerParametros(string varidparam, string varcentro, ref DataTable dtDatosRetorno, int tipoconexion)
        {
            bool varTraerParametros = false;
            BD bddatos = new BD(tipoconexion);
            DataTable dtDatos = new DataTable();
            OracleCommand ocComando = new OracleCommand("SELECT * FROM SYSCOMCEL.PARAMETRO WHERE ID_CENTRO = " + varcentro + " AND ID_PARAM = '" + varidparam + "'", bddatos.conexionOracle);
            OracleDataAdapter odaAdaptador;
            ocComando.CommandType = CommandType.Text;
            bddatos.abrirConexion(bddatos.conexionOracle);
            try
            {
                odaAdaptador = new OracleDataAdapter(ocComando);
                odaAdaptador.Fill(dtDatos);
                if (dtDatos != null)
                {
                    if (dtDatos.Rows.Count > 0)
                    {
                        dtDatosRetorno = dtDatos;
                        varTraerParametros = true;
                    }
                    else { varTraerParametros = false; }
                }
                else { varTraerParametros = false; }
            }
            catch (Exception e)
            {
                AgregarLogErrores(e);
            }
            finally
            {
                bddatos.cerrarConexion(bddatos.conexionOracle);
                bddatos = null;
                odaAdaptador = null;
            }
            return varTraerParametros;
        }
        public static DataTable TraerTransferenciaRetorno(int tipoconexion)
        {
            BD bdBaseDatos = new BD(tipoconexion);
            DataTable dtDatos = new DataTable();
            OracleCommand ocComando = new OracleCommand("SYSCOMCEL.PKG_REPROCESOS_CNB_REV.SP_REPROCESO_CNB_REV", bdBaseDatos.conexionOracle);
            OracleDataAdapter odaAdaptador;
            OracleParameter opParametro;

            ocComando.CommandType = CommandType.StoredProcedure;

            bdBaseDatos.abrirConexion(bdBaseDatos.conexionOracle);

            try
            {
                odaAdaptador = new OracleDataAdapter(ocComando);

                opParametro = new OracleParameter();
                opParametro.Direction = ParameterDirection.Output;
                opParametro.OracleDbType = OracleDbType.RefCursor;
                opParametro.ParameterName = "REP_CNB_R";
                ocComando.Parameters.Add(opParametro);

                opParametro = new OracleParameter();
                opParametro.Direction = ParameterDirection.Output;
                opParametro.OracleDbType = OracleDbType.Int32;
                opParametro.ParameterName = "RES";
                ocComando.Parameters.Add(opParametro);

                odaAdaptador.Fill(dtDatos);
                Int32 varRes = Int32.Parse(ocComando.Parameters[1].Value.ToString());
            }
            catch (Exception e) { AgregarLogErrores(e); }
            finally
            {
                bdBaseDatos.cerrarConexion(bdBaseDatos.conexionOracle);
                bdBaseDatos = null;
                opParametro = null;
                odaAdaptador = null;
            }

            return (dtDatos);
        }
        public static DataTable ActualizarCodigoRetorno(String idtransferencia, string indicadorreverso, int tipoconexion)
        {
            BD bdBaseDatos = new BD(tipoconexion);
            DataTable dtDatos = new DataTable();
            OracleCommand ocComando = new OracleCommand("SYSCOMCEL.PKG_REPROCESOS_CNB_REV.Sp_Upd_Reproceso_cnb_rev", bdBaseDatos.conexionOracle);
            OracleDataAdapter odaAdaptador;
            OracleParameter opParametro;

            ocComando.CommandType = CommandType.StoredProcedure;

            bdBaseDatos.abrirConexion(bdBaseDatos.conexionOracle);

            try
            {
                odaAdaptador = new OracleDataAdapter(ocComando);

                opParametro = new OracleParameter();
                opParametro.Direction = ParameterDirection.Input;
                opParametro.OracleDbType = OracleDbType.Int32;
                opParametro.ParameterName = "pi_nm_Id_Secuencia";
                opParametro.Size = 30;
                opParametro.Value = idtransferencia;
                ocComando.Parameters.Add(opParametro);

                opParametro = new OracleParameter();
                opParametro.Direction = ParameterDirection.Input;
                opParametro.OracleDbType = OracleDbType.Varchar2;
                opParametro.ParameterName = "pi_vc_estado";
                opParametro.Size = 2;
                opParametro.Value = indicadorreverso;
                ocComando.Parameters.Add(opParametro);

                opParametro = new OracleParameter();
                opParametro.Direction = ParameterDirection.Output;
                opParametro.OracleDbType = OracleDbType.Int32;
                opParametro.ParameterName = "po_nmres";
                ocComando.Parameters.Add(opParametro);

                ocComando.ExecuteNonQuery();

                Int32 varRes = Int32.Parse(ocComando.Parameters[2].Value.ToString());
                if (varRes == 1) { /*No realizado*/}
            }
            catch (Exception e) { AgregarLogErrores(e); }
            finally
            {
                bdBaseDatos.cerrarConexion(bdBaseDatos.conexionOracle);
                bdBaseDatos = null;
                opParametro = null;
                odaAdaptador = null;
            }

            return (dtDatos);
        }
        public static DataTable AgregarEventoLog(DataRow drEventoLog, DateTime fechainiciotransaccion, string tramaretorno, int cod_respuesta, string Adic1, String Adic2, int tipoconexion)
        {
            BD bdBaseDatos = new BD(tipoconexion);
            DataTable dtDatos = new DataTable();
            OracleCommand ocComando = new OracleCommand("SYSCOMCEL.PKG_REPROCESOS_CNB_REV.Sp_Reg_Log_cnb_rev", bdBaseDatos.conexionOracle);
            OracleDataAdapter odaAdaptador;
            OracleParameter opParametro;
            #region Declaracion Variables LOG
            int varRegion, varCentro, varCodrespuesta;
            string varId_usuario, varTramaenvio, varTramaretorno, varAdic1, varAdic2;
            DateTime fechafintrasaccion = DateTime.Now;

            varRegion = int.Parse(drEventoLog[1].ToString());
            varCentro = int.Parse(drEventoLog[2].ToString());
            varId_usuario = drEventoLog[3].ToString();
            varTramaenvio = drEventoLog[30].ToString();
            varTramaretorno = tramaretorno;
            varCodrespuesta = cod_respuesta;
            varAdic1 = Adic1;
            varAdic2 = Adic2;
            #endregion
            ocComando.CommandType = CommandType.StoredProcedure;

            bdBaseDatos.abrirConexion(bdBaseDatos.conexionOracle);

            try
            {
                odaAdaptador = new OracleDataAdapter(ocComando);
                #region ParametrosProcedimientoLog
                opParametro = new OracleParameter();
                opParametro.Direction = ParameterDirection.Input;
                opParametro.OracleDbType = OracleDbType.Int32;
                opParametro.ParameterName = "pi_nm_id_region";
                opParametro.Value = varRegion;
                ocComando.Parameters.Add(opParametro);

                opParametro = new OracleParameter();
                opParametro.Direction = ParameterDirection.Input;
                opParametro.OracleDbType = OracleDbType.Int32;
                opParametro.ParameterName = "pi_nm_id_centro";
                opParametro.Value = varCentro;
                ocComando.Parameters.Add(opParametro);

                opParametro = new OracleParameter();
                opParametro.Direction = ParameterDirection.Input;
                opParametro.OracleDbType = OracleDbType.Varchar2;
                opParametro.ParameterName = "pi_vc_id_usuario";
                opParametro.Size = 30;
                opParametro.Value = varId_usuario;
                ocComando.Parameters.Add(opParametro);

                opParametro = new OracleParameter();
                opParametro.Direction = ParameterDirection.Input;
                opParametro.OracleDbType = OracleDbType.Date;
                opParametro.ParameterName = "pi_dt_fecha_hora_ini";
                opParametro.Value = fechainiciotransaccion;
                ocComando.Parameters.Add(opParametro);

                opParametro = new OracleParameter();
                opParametro.Direction = ParameterDirection.Input;
                opParametro.OracleDbType = OracleDbType.Date;
                opParametro.ParameterName = "pi_dt_fecha_hora_fin";
                opParametro.Value = fechafintrasaccion;
                ocComando.Parameters.Add(opParametro);

                opParametro = new OracleParameter();
                opParametro.Direction = ParameterDirection.Input;
                opParametro.OracleDbType = OracleDbType.Varchar2;
                opParametro.ParameterName = "pi_vc_trama_enviada";
                opParametro.Size = 2500;
                opParametro.Value = varTramaenvio;
                ocComando.Parameters.Add(opParametro);

                opParametro = new OracleParameter();
                opParametro.Direction = ParameterDirection.Input;
                opParametro.OracleDbType = OracleDbType.Varchar2;
                opParametro.ParameterName = "pi_vc_trama_recibida";
                opParametro.Size = 2500;
                opParametro.Value = varTramaretorno;
                ocComando.Parameters.Add(opParametro);

                opParametro = new OracleParameter();
                opParametro.Direction = ParameterDirection.Input;
                opParametro.OracleDbType = OracleDbType.Int32;
                opParametro.ParameterName = "pi_nm_cod_respuesta";
                opParametro.Value = varCodrespuesta;
                ocComando.Parameters.Add(opParametro);

                opParametro = new OracleParameter();
                opParametro.Direction = ParameterDirection.Input;
                opParametro.OracleDbType = OracleDbType.Varchar2;
                opParametro.ParameterName = "pi_vc_adic1";
                opParametro.Size = 30;
                opParametro.Value = varAdic1;
                ocComando.Parameters.Add(opParametro);

                opParametro = new OracleParameter();
                opParametro.Direction = ParameterDirection.Input;
                opParametro.OracleDbType = OracleDbType.Varchar2;
                opParametro.ParameterName = "pi_vc_adic2";
                opParametro.Size = 30;
                opParametro.Value = varAdic2;
                ocComando.Parameters.Add(opParametro);

                opParametro = new OracleParameter();
                opParametro.Direction = ParameterDirection.Output;
                opParametro.OracleDbType = OracleDbType.Int32;
                opParametro.ParameterName = "po_nmres";
                ocComando.Parameters.Add(opParametro);
                #endregion
                ocComando.ExecuteNonQuery();
                Int32 varRes = Int32.Parse(ocComando.Parameters[10].Value.ToString());

            }
            catch (Exception e) { AgregarLogErrores(e); }
            finally
            {
                bdBaseDatos.cerrarConexion(bdBaseDatos.conexionOracle);
                bdBaseDatos = null;
                opParametro = null;
                odaAdaptador = null;
            }

            return (dtDatos);

        }
        public static DataTable AgregarEventoLog2(DateTime fechainiciotransaccion, string tramaenvio, string tramaretorno, int cod_respuesta, string Adic1, String Adic2, int tipoconexion)
        {
            BD bdBaseDatos = new BD(tipoconexion);
            DataTable dtDatos = new DataTable();
            OracleCommand ocComando = new OracleCommand("SYSCOMCEL.PKG_REPROCESOS_CNB_REV.Sp_Reg_Log_cnb_rev", bdBaseDatos.conexionOracle);
            OracleDataAdapter odaAdaptador;
            OracleParameter opParametro;
            #region Declaracion Variables LOG
            int varRegion, varCentro, varCodrespuesta;
            string varId_usuario, varTramaenvio, varTramaretorno, varAdic1, varAdic2;
            DateTime fechafintrasaccion = DateTime.Now;

            varRegion = 999;
            varCentro = 999;
            varId_usuario = "9999";
            if (tramaenvio != "") { varTramaenvio = tramaenvio; } else { varTramaenvio = "999999"; }
            varTramaretorno = tramaretorno;
            varCodrespuesta = cod_respuesta;
            varAdic1 = Adic1;
            varAdic2 = Adic2;
            #endregion
            ocComando.CommandType = CommandType.StoredProcedure;

            bdBaseDatos.abrirConexion(bdBaseDatos.conexionOracle);

            try
            {
                odaAdaptador = new OracleDataAdapter(ocComando);
                #region ParametrosProcedimientoLog
                opParametro = new OracleParameter();
                opParametro.Direction = ParameterDirection.Input;
                opParametro.OracleDbType = OracleDbType.Int32;
                opParametro.ParameterName = "pi_nm_id_region";
                opParametro.Value = varRegion;
                ocComando.Parameters.Add(opParametro);

                opParametro = new OracleParameter();
                opParametro.Direction = ParameterDirection.Input;
                opParametro.OracleDbType = OracleDbType.Int32;
                opParametro.ParameterName = "pi_nm_id_centro";
                opParametro.Value = varCentro;
                ocComando.Parameters.Add(opParametro);

                opParametro = new OracleParameter();
                opParametro.Direction = ParameterDirection.Input;
                opParametro.OracleDbType = OracleDbType.Varchar2;
                opParametro.ParameterName = "pi_vc_id_usuario";
                opParametro.Size = 30;
                opParametro.Value = varId_usuario;
                ocComando.Parameters.Add(opParametro);

                opParametro = new OracleParameter();
                opParametro.Direction = ParameterDirection.Input;
                opParametro.OracleDbType = OracleDbType.Date;
                opParametro.ParameterName = "pi_dt_fecha_hora_ini";
                opParametro.Value = fechainiciotransaccion;
                ocComando.Parameters.Add(opParametro);

                opParametro = new OracleParameter();
                opParametro.Direction = ParameterDirection.Input;
                opParametro.OracleDbType = OracleDbType.Date;
                opParametro.ParameterName = "pi_dt_fecha_hora_fin";
                opParametro.Value = fechafintrasaccion;
                ocComando.Parameters.Add(opParametro);

                opParametro = new OracleParameter();
                opParametro.Direction = ParameterDirection.Input;
                opParametro.OracleDbType = OracleDbType.Varchar2;
                opParametro.ParameterName = "pi_vc_trama_enviada";
                opParametro.Size = 2500;
                opParametro.Value = varTramaenvio;
                ocComando.Parameters.Add(opParametro);

                opParametro = new OracleParameter();
                opParametro.Direction = ParameterDirection.Input;
                opParametro.OracleDbType = OracleDbType.Varchar2;
                opParametro.ParameterName = "pi_vc_trama_recibida";
                opParametro.Size = 2500;
                opParametro.Value = varTramaretorno;
                ocComando.Parameters.Add(opParametro);

                opParametro = new OracleParameter();
                opParametro.Direction = ParameterDirection.Input;
                opParametro.OracleDbType = OracleDbType.Int32;
                opParametro.ParameterName = "pi_nm_cod_respuesta";
                opParametro.Value = varCodrespuesta;
                ocComando.Parameters.Add(opParametro);

                opParametro = new OracleParameter();
                opParametro.Direction = ParameterDirection.Input;
                opParametro.OracleDbType = OracleDbType.Varchar2;
                opParametro.ParameterName = "pi_vc_adic1";
                opParametro.Size = 30;
                opParametro.Value = varAdic1;
                ocComando.Parameters.Add(opParametro);

                opParametro = new OracleParameter();
                opParametro.Direction = ParameterDirection.Input;
                opParametro.OracleDbType = OracleDbType.Varchar2;
                opParametro.ParameterName = "pi_vc_adic2";
                opParametro.Size = 30;
                opParametro.Value = varAdic2;
                ocComando.Parameters.Add(opParametro);

                opParametro = new OracleParameter();
                opParametro.Direction = ParameterDirection.Output;
                opParametro.OracleDbType = OracleDbType.Int32;
                opParametro.ParameterName = "po_nmres";
                ocComando.Parameters.Add(opParametro);
                #endregion
                ocComando.ExecuteNonQuery();
                Int32 varRes = Int32.Parse(ocComando.Parameters[10].Value.ToString());

            }
            catch (Exception e) { AgregarLogErrores(e); }
            finally
            {
                bdBaseDatos.cerrarConexion(bdBaseDatos.conexionOracle);
                bdBaseDatos = null;
                opParametro = null;
                odaAdaptador = null;
            }

            return (dtDatos);

        }
        public static DataTable AgregarLogErrores(Exception ex)
        {
            return null;
        }
        public static DataTable AgregarLogErrores(DataRow DRError)
        {
            return null;
        }
    }
}
