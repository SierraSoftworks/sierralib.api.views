# SierraLib.API.Views
**A pattern for versioned views into your data model for APIs**

This library provides a pair of interfaces and some extension methods which act as a framework
on which you can build and maintain multiple, versioned, views into your core data models. It
has been designed to work in concert with good API design patterns like versioned endpoints
and semantic versioning to simplify the development of backwards compatible API surfaces as
your services evolve.

## Example

```csharp
namespace Example
{
    using SierraLib.API.Views;

    public class UserProfile
    {
        public Guid Id { get; set; }

        public string Fullname { get; set; }

        public DateTime DateOfBirth { get; set; }

        public class Version1 : IView<UserProfile>
        {
            public string Id { get; set; }

            public string Fullname { get; set; }

            public DateTime DateOfBirth { get; set; }

            public class Representer : IRepresenter<UserProfile, Version1>
            {
                public UserProfile ToModel(Version1 view)
                {
                    return new UserProfile
                    {
                        Id = view.Id is null ? Guid.NewGuid() : Guid.ParseExact(view.Id, "N"),
                        Fullname = view.Fullname,
                        DateOfBirth = view.DateOfBirth,
                    };
                }

                public Version1 ToView(UserProfile model)
                {
                    return new Version1
                    {
                        Id = model.Id.ToString("N"),
                        Fullname = model.Fullname,
                        DateOfBirth = model.DateOfBirth,
                    };
                }
            }
        }
    }
}
```

## Interfaces

### `IView<TModel>`
The `IView` interface is used to mark classes which represent a view into a specific model.

### `IRepresenter<TModel, TView>`
The `IRepresenter` interface provides the `ToModel` and `ToView` methods and is responsible for
working to convert between the `TModel` and the `TView`.