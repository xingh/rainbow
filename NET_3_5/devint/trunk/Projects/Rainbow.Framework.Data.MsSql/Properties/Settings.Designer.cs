﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.1433
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rainbow.Framework.Data.MsSql.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=.\\SQLEXPRESS;database=Rainbow;Integrated Security=True;Asynchronous P" +
            "rocessing=True;MultipleActiveResultSets=True;Connect Timeout=30;")]
        public string DatabaseConnectionString {
            get {
                return ((string)(this["DatabaseConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=.\\SQLEXPRESS;database=Rainbow;Integrated Security=True;Asynchronous P" +
            "rocessing=True;MultipleActiveResultSets=True;Connect Timeout=30;")]
        public string DatabaseConnectionString1 {
            get {
                return ((string)(this["DatabaseConnectionString1"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute(@"Data Source=.\SQLExpress;AttachDbFilename=""T:\Users\William Forney\Documents\Visual Studio 2008\Projects\Rainbow\NET_3_5\devint\trunk\WebSites\Rainbow\App_Data\Database.mdf"";Initial Catalog=Rainbow;Integrated Security=True;Asynchronous Processing=True;MultipleActiveResultSets=True")]
        public string RainbowConnectionString {
            get {
                return ((string)(this["RainbowConnectionString"]));
            }
        }
    }
}
