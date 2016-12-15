﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18033
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.18033.
// 
#pragma warning disable 1591

namespace Hardware_Hub_Serial_Port_Client.DynamicsHub {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="HubSoap", Namespace="http://www.dynamics.is/")]
    public partial class Hub : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback SendCommandOperationCompleted;
        
        private System.Threading.SendOrPostCallback ReceiveCommandOperationCompleted;
        
        private System.Threading.SendOrPostCallback SendBarcodeOperationCompleted;
        
        private System.Threading.SendOrPostCallback ReceiveBarcodeOperationCompleted;
        
        private System.Threading.SendOrPostCallback SendImageOperationCompleted;
        
        private System.Threading.SendOrPostCallback ReceiveImageOperationCompleted;
        
        private System.Threading.SendOrPostCallback SendXmlOperationCompleted;
        
        private System.Threading.SendOrPostCallback ReceiveXmlOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Hub() {
            this.Url = global::Hardware_Hub_Serial_Port_Client.Properties.Settings.Default.Hardware_Hub_Serial_Port_Client_DynamicsHub_Hub;
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
        public event SendCommandCompletedEventHandler SendCommandCompleted;
        
        /// <remarks/>
        public event ReceiveCommandCompletedEventHandler ReceiveCommandCompleted;
        
        /// <remarks/>
        public event SendBarcodeCompletedEventHandler SendBarcodeCompleted;
        
        /// <remarks/>
        public event ReceiveBarcodeCompletedEventHandler ReceiveBarcodeCompleted;
        
        /// <remarks/>
        public event SendImageCompletedEventHandler SendImageCompleted;
        
        /// <remarks/>
        public event ReceiveImageCompletedEventHandler ReceiveImageCompleted;
        
        /// <remarks/>
        public event SendXmlCompletedEventHandler SendXmlCompleted;
        
        /// <remarks/>
        public event ReceiveXmlCompletedEventHandler ReceiveXmlCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.dynamics.is/SendCommand", RequestNamespace="http://www.dynamics.is/", ResponseNamespace="http://www.dynamics.is/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool SendCommand(string guid, string command, string parameter1, string parameter2, string parameter3, string parameter4) {
            object[] results = this.Invoke("SendCommand", new object[] {
                        guid,
                        command,
                        parameter1,
                        parameter2,
                        parameter3,
                        parameter4});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void SendCommandAsync(string guid, string command, string parameter1, string parameter2, string parameter3, string parameter4) {
            this.SendCommandAsync(guid, command, parameter1, parameter2, parameter3, parameter4, null);
        }
        
        /// <remarks/>
        public void SendCommandAsync(string guid, string command, string parameter1, string parameter2, string parameter3, string parameter4, object userState) {
            if ((this.SendCommandOperationCompleted == null)) {
                this.SendCommandOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSendCommandOperationCompleted);
            }
            this.InvokeAsync("SendCommand", new object[] {
                        guid,
                        command,
                        parameter1,
                        parameter2,
                        parameter3,
                        parameter4}, this.SendCommandOperationCompleted, userState);
        }
        
        private void OnSendCommandOperationCompleted(object arg) {
            if ((this.SendCommandCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SendCommandCompleted(this, new SendCommandCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.dynamics.is/ReceiveCommand", RequestNamespace="http://www.dynamics.is/", ResponseNamespace="http://www.dynamics.is/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ReceiveCommand(string guid, ref string parameter1, ref string parameter2, ref string parameter3, ref string parameter4) {
            object[] results = this.Invoke("ReceiveCommand", new object[] {
                        guid,
                        parameter1,
                        parameter2,
                        parameter3,
                        parameter4});
            parameter1 = ((string)(results[1]));
            parameter2 = ((string)(results[2]));
            parameter3 = ((string)(results[3]));
            parameter4 = ((string)(results[4]));
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ReceiveCommandAsync(string guid, string parameter1, string parameter2, string parameter3, string parameter4) {
            this.ReceiveCommandAsync(guid, parameter1, parameter2, parameter3, parameter4, null);
        }
        
        /// <remarks/>
        public void ReceiveCommandAsync(string guid, string parameter1, string parameter2, string parameter3, string parameter4, object userState) {
            if ((this.ReceiveCommandOperationCompleted == null)) {
                this.ReceiveCommandOperationCompleted = new System.Threading.SendOrPostCallback(this.OnReceiveCommandOperationCompleted);
            }
            this.InvokeAsync("ReceiveCommand", new object[] {
                        guid,
                        parameter1,
                        parameter2,
                        parameter3,
                        parameter4}, this.ReceiveCommandOperationCompleted, userState);
        }
        
        private void OnReceiveCommandOperationCompleted(object arg) {
            if ((this.ReceiveCommandCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ReceiveCommandCompleted(this, new ReceiveCommandCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.dynamics.is/SendBarcode", RequestNamespace="http://www.dynamics.is/", ResponseNamespace="http://www.dynamics.is/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool SendBarcode(string guid, string barcode) {
            object[] results = this.Invoke("SendBarcode", new object[] {
                        guid,
                        barcode});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void SendBarcodeAsync(string guid, string barcode) {
            this.SendBarcodeAsync(guid, barcode, null);
        }
        
        /// <remarks/>
        public void SendBarcodeAsync(string guid, string barcode, object userState) {
            if ((this.SendBarcodeOperationCompleted == null)) {
                this.SendBarcodeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSendBarcodeOperationCompleted);
            }
            this.InvokeAsync("SendBarcode", new object[] {
                        guid,
                        barcode}, this.SendBarcodeOperationCompleted, userState);
        }
        
        private void OnSendBarcodeOperationCompleted(object arg) {
            if ((this.SendBarcodeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SendBarcodeCompleted(this, new SendBarcodeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.dynamics.is/ReceiveBarcode", RequestNamespace="http://www.dynamics.is/", ResponseNamespace="http://www.dynamics.is/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ReceiveBarcode(string guid) {
            object[] results = this.Invoke("ReceiveBarcode", new object[] {
                        guid});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ReceiveBarcodeAsync(string guid) {
            this.ReceiveBarcodeAsync(guid, null);
        }
        
        /// <remarks/>
        public void ReceiveBarcodeAsync(string guid, object userState) {
            if ((this.ReceiveBarcodeOperationCompleted == null)) {
                this.ReceiveBarcodeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnReceiveBarcodeOperationCompleted);
            }
            this.InvokeAsync("ReceiveBarcode", new object[] {
                        guid}, this.ReceiveBarcodeOperationCompleted, userState);
        }
        
        private void OnReceiveBarcodeOperationCompleted(object arg) {
            if ((this.ReceiveBarcodeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ReceiveBarcodeCompleted(this, new ReceiveBarcodeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.dynamics.is/SendImage", RequestNamespace="http://www.dynamics.is/", ResponseNamespace="http://www.dynamics.is/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool SendImage(string guid, [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")] byte[] image) {
            object[] results = this.Invoke("SendImage", new object[] {
                        guid,
                        image});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void SendImageAsync(string guid, byte[] image) {
            this.SendImageAsync(guid, image, null);
        }
        
        /// <remarks/>
        public void SendImageAsync(string guid, byte[] image, object userState) {
            if ((this.SendImageOperationCompleted == null)) {
                this.SendImageOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSendImageOperationCompleted);
            }
            this.InvokeAsync("SendImage", new object[] {
                        guid,
                        image}, this.SendImageOperationCompleted, userState);
        }
        
        private void OnSendImageOperationCompleted(object arg) {
            if ((this.SendImageCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SendImageCompleted(this, new SendImageCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.dynamics.is/ReceiveImage", RequestNamespace="http://www.dynamics.is/", ResponseNamespace="http://www.dynamics.is/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")]
        public byte[] ReceiveImage(string guid) {
            object[] results = this.Invoke("ReceiveImage", new object[] {
                        guid});
            return ((byte[])(results[0]));
        }
        
        /// <remarks/>
        public void ReceiveImageAsync(string guid) {
            this.ReceiveImageAsync(guid, null);
        }
        
        /// <remarks/>
        public void ReceiveImageAsync(string guid, object userState) {
            if ((this.ReceiveImageOperationCompleted == null)) {
                this.ReceiveImageOperationCompleted = new System.Threading.SendOrPostCallback(this.OnReceiveImageOperationCompleted);
            }
            this.InvokeAsync("ReceiveImage", new object[] {
                        guid}, this.ReceiveImageOperationCompleted, userState);
        }
        
        private void OnReceiveImageOperationCompleted(object arg) {
            if ((this.ReceiveImageCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ReceiveImageCompleted(this, new ReceiveImageCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.dynamics.is/SendXml", RequestNamespace="http://www.dynamics.is/", ResponseNamespace="http://www.dynamics.is/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool SendXml(string guid, System.Xml.XmlNode xmlDoc) {
            object[] results = this.Invoke("SendXml", new object[] {
                        guid,
                        xmlDoc});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void SendXmlAsync(string guid, System.Xml.XmlNode xmlDoc) {
            this.SendXmlAsync(guid, xmlDoc, null);
        }
        
        /// <remarks/>
        public void SendXmlAsync(string guid, System.Xml.XmlNode xmlDoc, object userState) {
            if ((this.SendXmlOperationCompleted == null)) {
                this.SendXmlOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSendXmlOperationCompleted);
            }
            this.InvokeAsync("SendXml", new object[] {
                        guid,
                        xmlDoc}, this.SendXmlOperationCompleted, userState);
        }
        
        private void OnSendXmlOperationCompleted(object arg) {
            if ((this.SendXmlCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SendXmlCompleted(this, new SendXmlCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.dynamics.is/ReceiveXml", RequestNamespace="http://www.dynamics.is/", ResponseNamespace="http://www.dynamics.is/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Xml.XmlNode ReceiveXml(string guid) {
            object[] results = this.Invoke("ReceiveXml", new object[] {
                        guid});
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        public void ReceiveXmlAsync(string guid) {
            this.ReceiveXmlAsync(guid, null);
        }
        
        /// <remarks/>
        public void ReceiveXmlAsync(string guid, object userState) {
            if ((this.ReceiveXmlOperationCompleted == null)) {
                this.ReceiveXmlOperationCompleted = new System.Threading.SendOrPostCallback(this.OnReceiveXmlOperationCompleted);
            }
            this.InvokeAsync("ReceiveXml", new object[] {
                        guid}, this.ReceiveXmlOperationCompleted, userState);
        }
        
        private void OnReceiveXmlOperationCompleted(object arg) {
            if ((this.ReceiveXmlCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ReceiveXmlCompleted(this, new ReceiveXmlCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void SendCommandCompletedEventHandler(object sender, SendCommandCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SendCommandCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SendCommandCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void ReceiveCommandCompletedEventHandler(object sender, ReceiveCommandCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ReceiveCommandCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ReceiveCommandCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
        
        /// <remarks/>
        public string parameter1 {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[1]));
            }
        }
        
        /// <remarks/>
        public string parameter2 {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[2]));
            }
        }
        
        /// <remarks/>
        public string parameter3 {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[3]));
            }
        }
        
        /// <remarks/>
        public string parameter4 {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[4]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void SendBarcodeCompletedEventHandler(object sender, SendBarcodeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SendBarcodeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SendBarcodeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void ReceiveBarcodeCompletedEventHandler(object sender, ReceiveBarcodeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ReceiveBarcodeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ReceiveBarcodeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void SendImageCompletedEventHandler(object sender, SendImageCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SendImageCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SendImageCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void ReceiveImageCompletedEventHandler(object sender, ReceiveImageCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ReceiveImageCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ReceiveImageCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public byte[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((byte[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void SendXmlCompletedEventHandler(object sender, SendXmlCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SendXmlCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SendXmlCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void ReceiveXmlCompletedEventHandler(object sender, ReceiveXmlCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ReceiveXmlCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ReceiveXmlCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Xml.XmlNode Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Xml.XmlNode)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591