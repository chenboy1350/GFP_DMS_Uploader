﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DMSUpload_Helper.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.6.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("GPFBKK")]
        public string Domain {
            get {
                return ((string)(this["Domain"]));
            }
            set {
                this["Domain"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("dmsdeploy")]
        public string User {
            get {
                return ((string)(this["User"]));
            }
            set {
                this["User"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("P@ss2022")]
        public string Password {
            get {
                return ((string)(this["Password"]));
            }
            set {
                this["Password"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\DMSUploaderLog")]
        public string LogPath {
            get {
                return ((string)(this["LogPath"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("D:\\\\TEST_FILE\\\\")]
        public string FilePath {
            get {
                return ((string)(this["FilePath"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("D:\\\\TEMP_FILE\\\\")]
        public string TempBatchFile {
            get {
                return ((string)(this["TempBatchFile"]));
            }
            set {
                this["TempBatchFile"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("ThePasswordToDecryptAndEncryptTheFile")]
        public string dmsp {
            get {
                return ((string)(this["dmsp"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://mrc-Tdbs-001.gpf.or.th/dmsapi/")]
        public string GPF_API {
            get {
                return ((string)(this["GPF_API"]));
            }
            set {
                this["GPF_API"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("https://mrc-tdbs-001.gpf.or.th/PROD/GPFDBService.asmx")]
        public string DMSUpload_Helper_GPFDBService_GPFDBService {
            get {
                return ((string)(this["DMSUpload_Helper_GPFDBService_GPFDBService"]));
            }
            set {
                this["DMSUpload_Helper_GPFDBService_GPFDBService"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("https://mrc-tdbs-001.gpf.or.th/Prod/GPFMaintenance.asmx")]
        public string DMSUpload_Helper_GPFMaintenance_GPFMaintenance {
            get {
                return ((string)(this["DMSUpload_Helper_GPFMaintenance_GPFMaintenance"]));
            }
            set {
                this["DMSUpload_Helper_GPFMaintenance_GPFMaintenance"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\\\Dms-tfile-001\\temp_file\\")]
        public string DFILEPath {
            get {
                return ((string)(this["DFILEPath"]));
            }
            set {
                this["DFILEPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://dop-tngx-001.gpf.or.th/DMSTestAPI/DMS-API/")]
        public string DMS_API {
            get {
                return ((string)(this["DMS_API"]));
            }
            set {
                this["DMS_API"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://dms-tfile-001.gpf.or.th/DMS-FILESERVER-API/")]
        public string PFILE_API {
            get {
                return ((string)(this["PFILE_API"]));
            }
            set {
                this["PFILE_API"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\\\Dms-tdbs-001\\temp_file\\")]
        public string BDSPath {
            get {
                return ((string)(this["BDSPath"]));
            }
            set {
                this["BDSPath"] = value;
            }
        }
    }
}
