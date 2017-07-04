
using Mono.Cecil;

namespace InjectWebSocketDll
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var distDllPath = "/Users/yi/source/InjectWebSocketDll/app/EmptyUnity.app/Contents/Resources/Data/Managed/Assembly-CSharp.dll";
            var pluginDllPath = "/Users/yi/source/InjectWebSocketDll/app/EmptyUnity.app/Contents/Resources/Data/Managed/OpenSocketServerDll.dll";

            var distAssembly = AssemblyDefinition.ReadAssembly(distDllPath);

            var pluginAssembly = AssemblyDefinition.ReadAssembly(pluginDllPath);

            var startMethod = distAssembly.GetMethod("MainScript", "Start");

            var helloMethod = pluginAssembly.GetMethod("InjectMananger", "startSocket");

            distAssembly.InjectMethod(startMethod, helloMethod);
            
            distAssembly.Write(distDllPath);
        }
    }
}