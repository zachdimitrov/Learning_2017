using System;

namespace ProjectManager.Common.Providers
{
    public class EngineProvider
    {
        private Engine engine;

        public EngineProvider(Engine engine)
        {
            this.TheEngine = engine;
        }

        public Engine TheEngine
        {
            get
            {
                return this.engine;
            }

            set
            {
                if (value == null)
                {
                    throw new NullReferenceException();
                }

                this.engine = value;
            }
        }

        public void Startup()
        {
            this.TheEngine.Start();
        }
    }
}
