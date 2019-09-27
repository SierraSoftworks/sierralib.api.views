
namespace SierraLib.API.Views
{
    using System;

    /// <summary>
    /// An interface which is used to mark a type as being a view
    /// for a specific <typeparamref name="TModel"/>.
    /// </summary>
    /// <typeparam name="TModel">The type of the model that this view represents.</typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1040", Justification = "This interface is intentionally empty and is used as a marker.")]
    public interface IView<TModel>
        where TModel : class
    {
    }
}
