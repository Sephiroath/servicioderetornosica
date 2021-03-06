﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.18444.
// 
#pragma warning disable 1591

namespace BussinessLayer.WR_NoBankOfficeSvr {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="NoBankOfficeSvrSoap", Namespace="http://tempuri.org/")]
    public partial class NoBankOfficeSvr : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback solicitudDepositoOperationCompleted;
        
        private System.Threading.SendOrPostCallback solicitudRetiroOperationCompleted;
        
        private System.Threading.SendOrPostCallback getParameterOperationCompleted;
        
        private System.Threading.SendOrPostCallback ReprocesoOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public NoBankOfficeSvr() {
            this.Url = global::BussinessLayer.Properties.Settings.Default.BussinessLayer_WR_NoBankOfficeSvr_NoBankOfficeSvr;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event solicitudDepositoCompletedEventHandler solicitudDepositoCompleted;
        
        /// <remarks/>
        public event solicitudRetiroCompletedEventHandler solicitudRetiroCompleted;
        
        /// <remarks/>
        public event getParameterCompletedEventHandler getParameterCompleted;
        
        /// <remarks/>
        public event ReprocesoCompletedEventHandler ReprocesoCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/solicitudDeposito", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public DepRespuesta solicitudDeposito([System.Xml.Serialization.XmlElementAttribute("solicitudDeposito")] DepSolicitud solicitudDeposito1) {
            object[] results = this.Invoke("solicitudDeposito", new object[] {
                        solicitudDeposito1});
            return ((DepRespuesta)(results[0]));
        }
        
        /// <remarks/>
        public void solicitudDepositoAsync(DepSolicitud solicitudDeposito1) {
            this.solicitudDepositoAsync(solicitudDeposito1, null);
        }
        
        /// <remarks/>
        public void solicitudDepositoAsync(DepSolicitud solicitudDeposito1, object userState) {
            if ((this.solicitudDepositoOperationCompleted == null)) {
                this.solicitudDepositoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnsolicitudDepositoOperationCompleted);
            }
            this.InvokeAsync("solicitudDeposito", new object[] {
                        solicitudDeposito1}, this.solicitudDepositoOperationCompleted, userState);
        }
        
        private void OnsolicitudDepositoOperationCompleted(object arg) {
            if ((this.solicitudDepositoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.solicitudDepositoCompleted(this, new solicitudDepositoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/solicitudRetiro", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public RetRespuesta solicitudRetiro([System.Xml.Serialization.XmlElementAttribute("solicitudRetiro")] RetSolicitud solicitudRetiro1) {
            object[] results = this.Invoke("solicitudRetiro", new object[] {
                        solicitudRetiro1});
            return ((RetRespuesta)(results[0]));
        }
        
        /// <remarks/>
        public void solicitudRetiroAsync(RetSolicitud solicitudRetiro1) {
            this.solicitudRetiroAsync(solicitudRetiro1, null);
        }
        
        /// <remarks/>
        public void solicitudRetiroAsync(RetSolicitud solicitudRetiro1, object userState) {
            if ((this.solicitudRetiroOperationCompleted == null)) {
                this.solicitudRetiroOperationCompleted = new System.Threading.SendOrPostCallback(this.OnsolicitudRetiroOperationCompleted);
            }
            this.InvokeAsync("solicitudRetiro", new object[] {
                        solicitudRetiro1}, this.solicitudRetiroOperationCompleted, userState);
        }
        
        private void OnsolicitudRetiroOperationCompleted(object arg) {
            if ((this.solicitudRetiroCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.solicitudRetiroCompleted(this, new solicitudRetiroCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/getParameter", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string getParameter(string idParametros) {
            object[] results = this.Invoke("getParameter", new object[] {
                        idParametros});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void getParameterAsync(string idParametros) {
            this.getParameterAsync(idParametros, null);
        }
        
        /// <remarks/>
        public void getParameterAsync(string idParametros, object userState) {
            if ((this.getParameterOperationCompleted == null)) {
                this.getParameterOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetParameterOperationCompleted);
            }
            this.InvokeAsync("getParameter", new object[] {
                        idParametros}, this.getParameterOperationCompleted, userState);
        }
        
        private void OngetParameterOperationCompleted(object arg) {
            if ((this.getParameterCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getParameterCompleted(this, new getParameterCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Reproceso", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string Reproceso(string Region) {
            object[] results = this.Invoke("Reproceso", new object[] {
                        Region});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ReprocesoAsync(string Region) {
            this.ReprocesoAsync(Region, null);
        }
        
        /// <remarks/>
        public void ReprocesoAsync(string Region, object userState) {
            if ((this.ReprocesoOperationCompleted == null)) {
                this.ReprocesoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnReprocesoOperationCompleted);
            }
            this.InvokeAsync("Reproceso", new object[] {
                        Region}, this.ReprocesoOperationCompleted, userState);
        }
        
        private void OnReprocesoOperationCompleted(object arg) {
            if ((this.ReprocesoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ReprocesoCompleted(this, new ReprocesoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class DepSolicitud {
        
        private string canalOrigenField;
        
        private string identificacionDispositivoField;
        
        private string localizacionDispositivoField;
        
        private int fechaTransaccionField;
        
        private int horaTransaccionField;
        
        private int numeroSecuenciaField;
        
        private string identificacionUsuarioField;
        
        private string claveUsuarioField;
        
        private string claveOTPField;
        
        private int codigoTransaccionField;
        
        private string numeroTerminalField;
        
        private short entidadOrigenField;
        
        private short tipoProductoOrigenField;
        
        private long numeroProductoOrigenField;
        
        private short entidadDestinoField;
        
        private short tipoProductoDestinoField;
        
        private long numeroProductoDestinoField;
        
        private decimal valorDepositoField;
        
        private long numeroCelularField;
        
        private string indicadorReversoField;
        
        /// <remarks/>
        public string CanalOrigen {
            get {
                return this.canalOrigenField;
            }
            set {
                this.canalOrigenField = value;
            }
        }
        
        /// <remarks/>
        public string IdentificacionDispositivo {
            get {
                return this.identificacionDispositivoField;
            }
            set {
                this.identificacionDispositivoField = value;
            }
        }
        
        /// <remarks/>
        public string LocalizacionDispositivo {
            get {
                return this.localizacionDispositivoField;
            }
            set {
                this.localizacionDispositivoField = value;
            }
        }
        
        /// <remarks/>
        public int FechaTransaccion {
            get {
                return this.fechaTransaccionField;
            }
            set {
                this.fechaTransaccionField = value;
            }
        }
        
        /// <remarks/>
        public int HoraTransaccion {
            get {
                return this.horaTransaccionField;
            }
            set {
                this.horaTransaccionField = value;
            }
        }
        
        /// <remarks/>
        public int NumeroSecuencia {
            get {
                return this.numeroSecuenciaField;
            }
            set {
                this.numeroSecuenciaField = value;
            }
        }
        
        /// <remarks/>
        public string IdentificacionUsuario {
            get {
                return this.identificacionUsuarioField;
            }
            set {
                this.identificacionUsuarioField = value;
            }
        }
        
        /// <remarks/>
        public string ClaveUsuario {
            get {
                return this.claveUsuarioField;
            }
            set {
                this.claveUsuarioField = value;
            }
        }
        
        /// <remarks/>
        public string ClaveOTP {
            get {
                return this.claveOTPField;
            }
            set {
                this.claveOTPField = value;
            }
        }
        
        /// <remarks/>
        public int CodigoTransaccion {
            get {
                return this.codigoTransaccionField;
            }
            set {
                this.codigoTransaccionField = value;
            }
        }
        
        /// <remarks/>
        public string NumeroTerminal {
            get {
                return this.numeroTerminalField;
            }
            set {
                this.numeroTerminalField = value;
            }
        }
        
        /// <remarks/>
        public short EntidadOrigen {
            get {
                return this.entidadOrigenField;
            }
            set {
                this.entidadOrigenField = value;
            }
        }
        
        /// <remarks/>
        public short TipoProductoOrigen {
            get {
                return this.tipoProductoOrigenField;
            }
            set {
                this.tipoProductoOrigenField = value;
            }
        }
        
        /// <remarks/>
        public long NumeroProductoOrigen {
            get {
                return this.numeroProductoOrigenField;
            }
            set {
                this.numeroProductoOrigenField = value;
            }
        }
        
        /// <remarks/>
        public short EntidadDestino {
            get {
                return this.entidadDestinoField;
            }
            set {
                this.entidadDestinoField = value;
            }
        }
        
        /// <remarks/>
        public short TipoProductoDestino {
            get {
                return this.tipoProductoDestinoField;
            }
            set {
                this.tipoProductoDestinoField = value;
            }
        }
        
        /// <remarks/>
        public long NumeroProductoDestino {
            get {
                return this.numeroProductoDestinoField;
            }
            set {
                this.numeroProductoDestinoField = value;
            }
        }
        
        /// <remarks/>
        public decimal ValorDeposito {
            get {
                return this.valorDepositoField;
            }
            set {
                this.valorDepositoField = value;
            }
        }
        
        /// <remarks/>
        public long NumeroCelular {
            get {
                return this.numeroCelularField;
            }
            set {
                this.numeroCelularField = value;
            }
        }
        
        /// <remarks/>
        public string IndicadorReverso {
            get {
                return this.indicadorReversoField;
            }
            set {
                this.indicadorReversoField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class RetRespuesta {
        
        private string canalOrigenField;
        
        private string identificacionDispositivoField;
        
        private string localizacionDispositivoField;
        
        private int fechaTransaccionField;
        
        private int horaTransaccionField;
        
        private int numeroSecuenciaField;
        
        private int codigoRespuestaField;
        
        private string mensajeRespuestaField;
        
        private short tipoErrorField;
        
        private int numeroAutorizacionField;
        
        private decimal costoTransaccionField;
        
        private int fechaCompensacionField;
        
        /// <remarks/>
        public string CanalOrigen {
            get {
                return this.canalOrigenField;
            }
            set {
                this.canalOrigenField = value;
            }
        }
        
        /// <remarks/>
        public string IdentificacionDispositivo {
            get {
                return this.identificacionDispositivoField;
            }
            set {
                this.identificacionDispositivoField = value;
            }
        }
        
        /// <remarks/>
        public string LocalizacionDispositivo {
            get {
                return this.localizacionDispositivoField;
            }
            set {
                this.localizacionDispositivoField = value;
            }
        }
        
        /// <remarks/>
        public int FechaTransaccion {
            get {
                return this.fechaTransaccionField;
            }
            set {
                this.fechaTransaccionField = value;
            }
        }
        
        /// <remarks/>
        public int HoraTransaccion {
            get {
                return this.horaTransaccionField;
            }
            set {
                this.horaTransaccionField = value;
            }
        }
        
        /// <remarks/>
        public int NumeroSecuencia {
            get {
                return this.numeroSecuenciaField;
            }
            set {
                this.numeroSecuenciaField = value;
            }
        }
        
        /// <remarks/>
        public int CodigoRespuesta {
            get {
                return this.codigoRespuestaField;
            }
            set {
                this.codigoRespuestaField = value;
            }
        }
        
        /// <remarks/>
        public string MensajeRespuesta {
            get {
                return this.mensajeRespuestaField;
            }
            set {
                this.mensajeRespuestaField = value;
            }
        }
        
        /// <remarks/>
        public short TipoError {
            get {
                return this.tipoErrorField;
            }
            set {
                this.tipoErrorField = value;
            }
        }
        
        /// <remarks/>
        public int NumeroAutorizacion {
            get {
                return this.numeroAutorizacionField;
            }
            set {
                this.numeroAutorizacionField = value;
            }
        }
        
        /// <remarks/>
        public decimal CostoTransaccion {
            get {
                return this.costoTransaccionField;
            }
            set {
                this.costoTransaccionField = value;
            }
        }
        
        /// <remarks/>
        public int FechaCompensacion {
            get {
                return this.fechaCompensacionField;
            }
            set {
                this.fechaCompensacionField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class RetSolicitud {
        
        private string canalOrigenField;
        
        private string identificacionDispositivoField;
        
        private string localizacionDispositivoField;
        
        private int fechaTransaccionField;
        
        private int horaTransaccionField;
        
        private int numeroSecuenciaField;
        
        private string identificacionUsuarioField;
        
        private string claveUsuarioField;
        
        private string claveOTPField;
        
        private int codigoTransaccionField;
        
        private string numeroTerminalField;
        
        private short entidadOrigenField;
        
        private short tipoProductoOrigenField;
        
        private long numeroProductoOrigenField;
        
        private short entidadDestinoField;
        
        private short tipoProductoDestinoField;
        
        private long numeroProductoDestinoField;
        
        private decimal valorRetiroField;
        
        private long numeroCelularField;
        
        private string indicadorReversoField;
        
        /// <remarks/>
        public string CanalOrigen {
            get {
                return this.canalOrigenField;
            }
            set {
                this.canalOrigenField = value;
            }
        }
        
        /// <remarks/>
        public string IdentificacionDispositivo {
            get {
                return this.identificacionDispositivoField;
            }
            set {
                this.identificacionDispositivoField = value;
            }
        }
        
        /// <remarks/>
        public string LocalizacionDispositivo {
            get {
                return this.localizacionDispositivoField;
            }
            set {
                this.localizacionDispositivoField = value;
            }
        }
        
        /// <remarks/>
        public int FechaTransaccion {
            get {
                return this.fechaTransaccionField;
            }
            set {
                this.fechaTransaccionField = value;
            }
        }
        
        /// <remarks/>
        public int HoraTransaccion {
            get {
                return this.horaTransaccionField;
            }
            set {
                this.horaTransaccionField = value;
            }
        }
        
        /// <remarks/>
        public int NumeroSecuencia {
            get {
                return this.numeroSecuenciaField;
            }
            set {
                this.numeroSecuenciaField = value;
            }
        }
        
        /// <remarks/>
        public string IdentificacionUsuario {
            get {
                return this.identificacionUsuarioField;
            }
            set {
                this.identificacionUsuarioField = value;
            }
        }
        
        /// <remarks/>
        public string ClaveUsuario {
            get {
                return this.claveUsuarioField;
            }
            set {
                this.claveUsuarioField = value;
            }
        }
        
        /// <remarks/>
        public string ClaveOTP {
            get {
                return this.claveOTPField;
            }
            set {
                this.claveOTPField = value;
            }
        }
        
        /// <remarks/>
        public int CodigoTransaccion {
            get {
                return this.codigoTransaccionField;
            }
            set {
                this.codigoTransaccionField = value;
            }
        }
        
        /// <remarks/>
        public string NumeroTerminal {
            get {
                return this.numeroTerminalField;
            }
            set {
                this.numeroTerminalField = value;
            }
        }
        
        /// <remarks/>
        public short EntidadOrigen {
            get {
                return this.entidadOrigenField;
            }
            set {
                this.entidadOrigenField = value;
            }
        }
        
        /// <remarks/>
        public short TipoProductoOrigen {
            get {
                return this.tipoProductoOrigenField;
            }
            set {
                this.tipoProductoOrigenField = value;
            }
        }
        
        /// <remarks/>
        public long NumeroProductoOrigen {
            get {
                return this.numeroProductoOrigenField;
            }
            set {
                this.numeroProductoOrigenField = value;
            }
        }
        
        /// <remarks/>
        public short EntidadDestino {
            get {
                return this.entidadDestinoField;
            }
            set {
                this.entidadDestinoField = value;
            }
        }
        
        /// <remarks/>
        public short TipoProductoDestino {
            get {
                return this.tipoProductoDestinoField;
            }
            set {
                this.tipoProductoDestinoField = value;
            }
        }
        
        /// <remarks/>
        public long NumeroProductoDestino {
            get {
                return this.numeroProductoDestinoField;
            }
            set {
                this.numeroProductoDestinoField = value;
            }
        }
        
        /// <remarks/>
        public decimal ValorRetiro {
            get {
                return this.valorRetiroField;
            }
            set {
                this.valorRetiroField = value;
            }
        }
        
        /// <remarks/>
        public long NumeroCelular {
            get {
                return this.numeroCelularField;
            }
            set {
                this.numeroCelularField = value;
            }
        }
        
        /// <remarks/>
        public string IndicadorReverso {
            get {
                return this.indicadorReversoField;
            }
            set {
                this.indicadorReversoField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class DepRespuesta {
        
        private string canalOrigenField;
        
        private string identificacionDispositivoField;
        
        private string localizacionDispositivoField;
        
        private int fechaTransaccionField;
        
        private int horaTransaccionField;
        
        private int numeroSecuenciaField;
        
        private int codigoRespuestaField;
        
        private string mensajeRespuestaField;
        
        private short tipoErrorField;
        
        private int numeroAutorizacionField;
        
        private decimal costoTransaccionField;
        
        private int fechaCompensacionField;
        
        /// <remarks/>
        public string CanalOrigen {
            get {
                return this.canalOrigenField;
            }
            set {
                this.canalOrigenField = value;
            }
        }
        
        /// <remarks/>
        public string IdentificacionDispositivo {
            get {
                return this.identificacionDispositivoField;
            }
            set {
                this.identificacionDispositivoField = value;
            }
        }
        
        /// <remarks/>
        public string LocalizacionDispositivo {
            get {
                return this.localizacionDispositivoField;
            }
            set {
                this.localizacionDispositivoField = value;
            }
        }
        
        /// <remarks/>
        public int FechaTransaccion {
            get {
                return this.fechaTransaccionField;
            }
            set {
                this.fechaTransaccionField = value;
            }
        }
        
        /// <remarks/>
        public int HoraTransaccion {
            get {
                return this.horaTransaccionField;
            }
            set {
                this.horaTransaccionField = value;
            }
        }
        
        /// <remarks/>
        public int NumeroSecuencia {
            get {
                return this.numeroSecuenciaField;
            }
            set {
                this.numeroSecuenciaField = value;
            }
        }
        
        /// <remarks/>
        public int CodigoRespuesta {
            get {
                return this.codigoRespuestaField;
            }
            set {
                this.codigoRespuestaField = value;
            }
        }
        
        /// <remarks/>
        public string MensajeRespuesta {
            get {
                return this.mensajeRespuestaField;
            }
            set {
                this.mensajeRespuestaField = value;
            }
        }
        
        /// <remarks/>
        public short TipoError {
            get {
                return this.tipoErrorField;
            }
            set {
                this.tipoErrorField = value;
            }
        }
        
        /// <remarks/>
        public int NumeroAutorizacion {
            get {
                return this.numeroAutorizacionField;
            }
            set {
                this.numeroAutorizacionField = value;
            }
        }
        
        /// <remarks/>
        public decimal CostoTransaccion {
            get {
                return this.costoTransaccionField;
            }
            set {
                this.costoTransaccionField = value;
            }
        }
        
        /// <remarks/>
        public int FechaCompensacion {
            get {
                return this.fechaCompensacionField;
            }
            set {
                this.fechaCompensacionField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void solicitudDepositoCompletedEventHandler(object sender, solicitudDepositoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class solicitudDepositoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal solicitudDepositoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public DepRespuesta Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((DepRespuesta)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void solicitudRetiroCompletedEventHandler(object sender, solicitudRetiroCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class solicitudRetiroCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal solicitudRetiroCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public RetRespuesta Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((RetRespuesta)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void getParameterCompletedEventHandler(object sender, getParameterCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getParameterCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getParameterCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void ReprocesoCompletedEventHandler(object sender, ReprocesoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ReprocesoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ReprocesoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591