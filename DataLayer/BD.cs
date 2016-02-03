using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Configuration;

namespace DataLayer
{
    class BD
    {
        // declara propiedades
        public OracleConnection conexionOracle { get; set; }
        public string cadenaConexion { get; set; }

        // constructor de la clase con parámetros
        public BD(int tipoconexion)
        {
            switch (tipoconexion) { 
                case 0:
                    conexionOracle = new OracleConnection(ConfigurationManager.AppSettings["cadenaConexionCAJAS"]);
                    break;
                case 1:
                    conexionOracle = new OracleConnection(ConfigurationManager.AppSettings["cadenaConexionCAJASOCC"]);
                    break;
                case 2:
                    conexionOracle = new OracleConnection(ConfigurationManager.AppSettings["cadenaConexionCAJASCELC"]);
                    break;
            }
        }

        public void abrirConexion(OracleConnection ocConexion) { ocConexion.Open(); }

        public void cerrarConexion(OracleConnection ocConexion) { ocConexion.Close(); }
    }
}
