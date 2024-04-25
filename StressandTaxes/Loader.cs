using HarmonyLib;
using System.Reflection;

namespace StressandTaxes
{
    public class Loader
    {
        /// <summary>
        /// This method is run by Winch to initialize your mod
        /// </summary>
        public static void Initialize()
        {
            new Harmony("com.Johncook.StressandTaxes").PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}