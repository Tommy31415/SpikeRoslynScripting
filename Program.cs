using System;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace SpikeRoslynScripting
{

    public class ScriptHost
    {
        public ScriptHost(int number)
        {
            this.Number = number;

        }
        public int Number { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            var scriptText = @"int Square(int number) {
                return number*number;
                }
                Square(Number)";


            var script = CSharpScript.Create<int>(scriptText, globalsType: typeof(ScriptHost));
            ScriptRunner<int> runner = script.CreateDelegate();

            var watch = System.Diagnostics.Stopwatch.StartNew();    
            var val = runner( new ScriptHost(5)).Result;
            watch.Stop();

            Console.WriteLine(val);
            Console.WriteLine($"Elapsed {watch.ElapsedMilliseconds} miliseconds");
        }
    }
}
