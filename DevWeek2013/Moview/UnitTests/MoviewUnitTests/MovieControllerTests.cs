using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Entities;
using FluentAssertions;
using Moq;
using Moview.Controllers;
using Moview.Models;
using NUnit.Framework;
using Service;

namespace MoviewUnitTests
{
    [TestFixture]
    public class MovieControllerTests
    {
        MovieController _controller;
        private Mock<IMovieService> _movieService;
        [SetUp]
        public void Setup()
        {
            _movieService = new Mock<IMovieService>();
            _movieService.Setup(m => m.GetMovies()).Returns(new List<Movie> {new Movie(), new Movie(), new Movie()});
            _controller = new MovieController(_movieService.Object);

        }

        [Test]
        public void GivenAMovieController_WhenNewIsCalled_ThenTheCorrectViewIsReturned()
        {
            var result = (ViewResult)_controller.New();
            //            result.ViewName.Should().Be("New");
        }

        [Test]
        public void GivenAMovieController_WhenIndexIsCalled_ThenAllMoviesAreSentToTheView()
        {
            var result = (ViewResult)_controller.Index();
            var model = (List<MovieDetails>)result.Model;

            model.Count.Should().Be(3);
        }
    }
}
