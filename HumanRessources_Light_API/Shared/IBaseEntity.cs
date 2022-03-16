using System;

namespace HumanRessources_Light_API.Shared
{
    /// <summary>
    ///     Defines properties shared among all sub-classes
    /// </summary>
    public interface IBaseEntity
    {
        public string Id { get; set; }

    }
}
