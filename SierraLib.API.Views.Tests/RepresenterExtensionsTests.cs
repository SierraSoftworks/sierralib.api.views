namespace SierraLib.API.Views.Tests
{
    using System;
    using FluentAssertions;
    using NUnit.Framework;
    using SierraLib.API.Views.Examples;

    public class RepresenterExtensionsTests
    {
        private readonly IRepresenter<UserProfile, UserProfile.Version1> representer = new UserProfile.Version1.Representer();

        [Test]
        public void TestToViewOrDefault()
        {
            var model = this.CreateUserProfile();

            this.representer.ToViewOrDefault(null).Should().BeNull("when we pass a null value it should return null");
            this.representer.ToViewOrDefault(model).Should().NotBeNull("when we pass a non-null value we should return the view");
        }

        [Test]
        public void TestToModelOrDefault()
        {
            var model = this.CreateUserProfile();
            var view = this.representer.ToView(model);
            view.Should().NotBeNull("the view should not be null");

            this.representer.ToModelOrDefault(null).Should().BeNull("when we pass a null value it should return null");
            this.representer.ToModelOrDefault(view).Should().NotBeNull("when we pass a non-null value we should return the model");
            this.representer.ToModelOrDefault(view).Should().BeEquivalentTo(model, "the model should be equivalent");

            this.representer.ToViewOrDefault(null).Should().BeNull("when we pass a null value it should return null");
            this.representer.ToViewOrDefault(model).Should().NotBeNull("when we pass a non-null value we should return the view");
        }

        private UserProfile CreateUserProfile()
        {
            return new UserProfile
            {
                Id = Guid.NewGuid(),
                Fullname = "Example User",
                DateOfBirth = new DateTime(1973, 09, 18),
            };
        }
    }
}