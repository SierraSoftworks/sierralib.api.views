namespace SierraLib.API.Views
{
    /// <summary>
    /// Extension methods for IRepresenter to simplify common use cases.
    /// </summary>
    public static class IRepresenterExtensions
    {
        /// <summary>
        /// Gets the <typeparamref name="TView"/> corresponding to a <paramref name="model"/> using this <paramref name="representer"/>
        /// or the default (<c>null</c>) if the <paramref name="model"/> is <c>null</c>.
        /// </summary>
        /// <param name="representer">The representer which will be used to convert this <paramref name="model"/> into the <typeparamref name="TView"/>.</param>
        /// <param name="model">The model which should be converted into a <typeparamref name="TView"/>.</param>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <returns>The <typeparamref name="TView"/> which represents the <paramref name="model"/> or <c>null</c> if the model is <c>null</c>.</returns>
        public static TView ToViewOrDefault<TModel, TView>(this IRepresenter<TModel, TView> representer, TModel model)
            where TView : class, IView<TModel>
            where TModel : class
        {
            if (representer is null)
            {
                throw new System.ArgumentNullException(nameof(representer));
            }

            if (model is null)
            {
                return default(TView);
            }

            return representer.ToView(model);
        }

        /// <summary>
        /// Gets the <typeparamref name="TModel"/> corresponding to a <paramref name="view"/> using this <paramref name="representer"/>
        /// or the default (<c>null</c>) if the <paramref name="view"/> is <c>null</c>.
        /// </summary>
        /// <param name="representer">The representer which will be used to convert this <paramref name="view"/> into the <typeparamref name="TModel"/>.</param>
        /// <param name="view">The view which should be converted into a <typeparamref name="TModel"/>.</param>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <returns>The <typeparamref name="TModel"/> which represents the <paramref name="view"/> or <c>null</c> if the view is <c>null</c>.</returns>
        public static TModel ToModelOrDefault<TModel, TView>(this IRepresenter<TModel, TView> representer, TView view)
            where TView : class, IView<TModel>
            where TModel : class
        {
            if (representer is null)
            {
                throw new System.ArgumentNullException(nameof(representer));
            }

            if (view is null)
            {
                return default(TModel);
            }

            return representer.ToModel(view);
        }
    }
}