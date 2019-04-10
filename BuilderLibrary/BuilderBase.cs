using System;

namespace BuilderLibrary
{
    public class BuilderBase<TBuildResult, TBuilder> : IBuilder<TBuildResult, TBuilder>
        where TBuildResult : class, new()
        where TBuilder : class, IBuilder
    {
        protected TBuildResult _concreteObject = new TBuildResult();

        public TBuildResult Build()
        {
            return _concreteObject;
        }

        public TBuilder With(Action<TBuildResult> setAction)
        {
            setAction?.Invoke(_concreteObject);
            return this as TBuilder;
        }
    }
}
