namespace SierraLib.API.Views.Examples
{
    using System;
    using System.Globalization;

    public partial class UserProfile
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034", Justification = "This represents a versioned view into the model.")]
        public class Version1 : IView<UserProfile>
        {
            public string Id { get; set; }

            public string Fullname { get; set; }

            public DateTime DateOfBirth { get; set; }

            public class Representer : IRepresenter<UserProfile, Version1>
            {
                /// <inheritdoc/>
                public UserProfile ToModel(Version1 view)
                {
                    if (view is null)
                    {
                        throw new ArgumentNullException(nameof(view));
                    }

                    return new UserProfile
                    {
                        Id = view.Id is null ? Guid.NewGuid() : Guid.ParseExact(view.Id, "N"),
                        Fullname = view.Fullname,
                        DateOfBirth = view.DateOfBirth,
                    };
                }

                /// <inheritdoc/>
                public Version1 ToView(UserProfile model)
                {
                    if (model is null)
                    {
                        throw new ArgumentNullException(nameof(model));
                    }

                    return new Version1
                    {
                        Id = model.Id.ToString("N", CultureInfo.InvariantCulture),
                        Fullname = model.Fullname,
                        DateOfBirth = model.DateOfBirth,
                    };
                }
            }
        }
    }
}
