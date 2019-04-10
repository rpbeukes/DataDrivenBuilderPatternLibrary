using System;

namespace BuilderLibrary
{
    public interface IBuilder {  /* maker to indicate a builder object */ }

    public interface IBuilder<TBuildResult, TBuilder> : IBuilder
        where TBuildResult : class, new()
        where TBuilder : class, IBuilder
    {
        /// <summary>
        /// A generic way to set properties
        /// </summary>
        TBuilder With(Action<TBuildResult> setAction); TBuildResult Build();
    }
}
