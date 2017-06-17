namespace Forum.ConsoleApp
{
    using System;
    using System.Collections.Generic;

    public interface IImporter
    {
        string Message { get; }

        int Order { get; }

        void Import();
    }
}