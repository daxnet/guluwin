using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using SunnyChen.Gulu.Environment;
using SunnyChen.Gulu.Win.Configuration;

namespace SunnyChen.Gulu.Win.ScriptRepositories
{
    internal class FileSystemScriptRepository : IScriptRepository
    {
        private static readonly string path_Script__;
        private static readonly string path_gScript__;
        private static readonly string path_simpleScript__;
        private ConfigReader configReader__ = new ConfigReader();

        static FileSystemScriptRepository()
        {
            path_Script__ = Directories.ScriptsPath;
            path_gScript__ = Directories.GScriptPath;
            path_simpleScript__ = Directories.SimpleScriptPath;

            if (!Directory.Exists(path_Script__))
            {
                Directory.CreateDirectory(path_Script__);
            }
            if (!Directory.Exists(path_gScript__))
            {
                Directory.CreateDirectory(path_gScript__);
            }
            if (!Directory.Exists(path_simpleScript__))
            {
                Directory.CreateDirectory(path_simpleScript__);
            }
        }

        public static string GetScriptFileName(string _name, ScriptType _type)
        {
            string extension = Path.GetExtension(_name);
            string fileName = _name;

            if (!extension.Trim().ToUpper().Equals(".GS"))
                fileName = _name + ".gs";

            switch (_type)
            {
                case ScriptType.G:
                    fileName = Path.Combine(path_gScript__, fileName);
                    break;
                case ScriptType.Simple:
                    fileName = Path.Combine(path_simpleScript__, fileName);
                    break;
                default:
                    throw new Exception();
            }
            return fileName;
        }

        public static string GetScriptPath(ScriptType _type)
        {
            switch (_type)
            {
                case ScriptType.G:
                    return path_gScript__;
                case ScriptType.Simple:
                    return path_simpleScript__;
                default:
                    throw new Exception();
            }
        }

        #region IScriptRepository Members

        public virtual void Add(string _name, string _content, ScriptType _type)
        {
            try
            {
                string fileName = GetScriptFileName(_name, _type);
                TextWriter writer = File.CreateText(fileName);
                writer.Write(_content);
                writer.Flush();
                writer.Close();
            }
            catch
            {
                throw;
            }
        }

        

        public virtual void Remove(string _name, ScriptType _type)
        {
            try
            {
                string fileName = GetScriptFileName(_name, _type);
                if (fileName != null && File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
            }
            catch
            {
                throw;
            }
        }

        public virtual string GetContent(string _name, ScriptType _type)
        {
            try
            {
                string fileName = GetScriptFileName(_name, _type);
                if (fileName != null && File.Exists(fileName))
                {
                    TextReader reader = File.OpenText(fileName);
                    string ret = reader.ReadToEnd();
                    reader.Close();
                    return ret;
                }
                else
                    return null;
            }
            catch
            {
                throw;
            }
        }

        public virtual string[] GetNames(ScriptType _type)
        {
            string path = GetScriptPath(_type);

            string[] files = Directory.GetFiles(path, "*.gs");

            return files;

        }

        public virtual string GetTemplateContent(ScriptType _type)
        {
            string path = path_Script__;
            switch (_type)
            {
                case ScriptType.G:
                    path = Path.Combine(path, configReader__.GTemplateFileName);
                    break;
                case ScriptType.Simple:
                    path = Path.Combine(path, configReader__.SimpleTemplateFileName);
                    break;
                default:
                    return string.Empty;
            }
            if (File.Exists(path))
            {
                TextReader reader = File.OpenText(path);
                string ret = reader.ReadToEnd();
                reader.Close();
                return ret;
            }
            return string.Empty;
        }

        #endregion

        internal string ScriptPath
        {
            get { return path_Script__; }
        }

        internal string GScriptPath
        {
            get { return path_gScript__; }
        }

        internal string SimpleScriptPath
        {
            get { return path_simpleScript__; }
        }

        
    }
}
