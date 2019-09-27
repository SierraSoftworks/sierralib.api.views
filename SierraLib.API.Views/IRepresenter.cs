namespace SierraLib.API.Views
{
    /// <summary>
    /// A representer which is responsible for converting a <typeparamref name="TModel"/>
    /// into a <typeparamref name="TView"/> and vice versa.
    /// </summary>
    /// <typeparam name="TModel">The type of the model that the view will represent.</typeparam>
    /// <typeparam name="TView">The specific view type used to represent the model.</typeparam>
    public interface IRepresenter<TModel, TView>
        where TView : IView<TModel>
        where TModel : class
    {
        /// <summary>
        /// Returns a new <typeparamref name="TModel"/> which represents the data provided in the
        /// <paramref name="view"/>.
        /// </summary>
        /// <param name="view">The <typeparamref name="TView"/> which should be converted into the <typeparamref name="TModel"/>.</param>
        /// <returns>A <typeparamref name="TModel"/> representing the <paramref name="view"/>.</returns>
        TModel ToModel(TView view);

        /// <summary>
        /// Returns a new <typeparamref name="TView"/> which represents the data provided in the
        /// <paramref name="model"/>.
        /// </summary>
        /// <param name="model">The <typeparamref name="TModel"/> which should be represented in the <typeparamref name="TView"/>.</param>
        /// <returns>A <typeparamref name="TView"/> representing the <paramref name="model"/>.</returns>
        TView ToView(TModel model);
    }
}