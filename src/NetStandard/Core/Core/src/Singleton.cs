﻿namespace Teronis
{
    public sealed class Singleton
    {
        public static readonly Singleton Default = new Singleton();

        private Singleton() { }
    }
}
