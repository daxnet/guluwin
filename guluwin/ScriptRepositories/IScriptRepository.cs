using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace SunnyChen.Gulu.Win.ScriptRepositories
{
    public enum ScriptType
    {
        Simple,
        G
    }

    internal interface IScriptRepository
    {
        void Add(string _name, string _content, ScriptType _type);
        void Remove(string _name, ScriptType _type);
        string GetContent(string _name, ScriptType _type);
        string[] GetNames(ScriptType _type);
        string GetTemplateContent(ScriptType _type);
    }
}
