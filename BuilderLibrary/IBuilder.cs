using System;

namespace BuilderLibrary
{
    public interface IBuilder {  /* maker to indicate a builder object */ }

    public interface IBuilder<TBuildResult, TBuilder> : IBuilder
        where TBuildResult : class, new()
        where TBuilder : class, IBuilder
    {
        TBuildResult Build();

        /// <summary>
        /// A generic way to set properties
        /// </summary>
        TBuilder With(Action<TBuildResult> setAction);

        TBuilder With<TRequestBuilder>(Action<TBuildResult, TRequestBuilder> setAction) where TRequestBuilder : class, IBuilder, new();
    }
}
