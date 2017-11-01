using System;
using System.Web.Mvc;

namespace ExampleProject
{
    internal class ViewEngineConfig
    {
        internal static void RemoveUnusedViewEngines()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}