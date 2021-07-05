using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using JSTester.TestEngine.Params;

namespace JSTester.JSCommon
{
    // Основной фаил для запуска скриптов
    // Класс родитель умеющий запускать скрипты
    class JSRunner
    {
        private static readonly Dictionary<ScriptType, string> processNames = new Dictionary<ScriptType, string>
        {
            {ScriptType.JavaScript, "node"},
            {ScriptType.CScript, "cscript"}
        };

        protected JSRunnerArgs Args { get; }

        public JSRunner(JSRunnerArgs args)
        {
            Args = args;
            WriteInFile(args.InputProgram, args.WorkFilePath);
        }


        //Выполняет скрипт на js и возвращает результат
        //line строка записываемая в фаил
        //scriptArguments аргументы передаваемые при запуске js файлу
        //return {строка результа}
        public string GetResultFromFile(string line, string scriptArguments)
        {
            WriteInFile(line, Args.InputFilePath);
            StartScript(Args.ScriptType, Args.WorkFilePath, scriptArguments).WaitForExit();
            return ReadFromFile(Args.OutputFilePath);
        }

        protected Process StartScript(ScriptType type, string pathToScript, string scriptArguments = null)
        {
            var cmdArgs = $"{processNames[type]} {pathToScript} {scriptArguments ?? ""}";
            Process p = new Process();
            p.StartInfo.WorkingDirectory = JSRunnerArgs.WorkFolder + "\\";
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = $"/c {cmdArgs}";
            p.Start();

            return p;


            //Process.Start($"{processNames[type]} );
        }

        #region Read Write Methods

        protected string ReadFromFile(string readPath)
        {
            var result = "";
            try
            {
                using (StreamReader sr = new StreamReader(readPath))
                {
                    result = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return result;
        }

        protected void WriteInFile(string text, string writePath)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.UTF8))
                {
                    sw.WriteAsync(text);
                }
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }
        }

        #endregion
    }
}