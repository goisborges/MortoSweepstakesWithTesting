using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MortoSweepstakes.Controllers;
using MortoSweepstakes.Data;
using MortoSweepstakes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortoSweepstakesTests
{
    [TestClass]
    public class TeamsControllerTests
    {
        //installed dependency Microsoft.EntityFrameworkCore.InMemory
        //create a "fake" database for testing - no real connection do db
        private ApplicationDbContext _context;
        TeamsController controller;

        //create a List with teams coming from the db
        List<Team> teams = new List<Team>();
        
        //this runs automatically before each test
        [TestInitialize]
        public void TestInitialize()
        {
            //creat in memory db
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _context = new ApplicationDbContext(options);

            //instantiate controller
            controller = new TeamsController(_context);

            //populate the db with mock data
            //if tables are connected, products.Add(new Product { info here});
            teams.Add(new Team
            {
                TeamId = 300,
                TeamName = "Canada",
                TeamGroup = 'B'
            });

            teams.Add(new Team
            {
                TeamId = 400,
                TeamName = "Brazil",
                TeamGroup = 'A'
            });

            //add to db
            foreach (var team in teams)
            {
                _context.Teams.Add(team);
            }

            //commit to inMemory DB
            _context.SaveChanges();
        }

        #region Index

        //Now the first method checking the Index method of TeamsController
        //checks if it returns a view named "Index"
        [TestMethod]
        public void IndexLoadsIndexView()
        {
            //arrange - now done in TestInitialize instead


            //act
            var result = (ViewResult)controller.Index().Result;


            //assert
            Assert.AreEqual("Index", result.ViewName);
        }


        //second test that will check for teams coming from database
        [TestMethod]
        public void IndexLoadsTeams()
        {
            //arrange - now done in TestInitialize instead


            //act
            var result = (ViewResult)controller.Index().Result;
            List<Team> model = (List<Team>)result.Model;

            //assert
            CollectionAssert.AreEqual(teams, model);

            //if need to order results as the controller class does, the code would be like this
            //CollectionAssert.AreEqual(teams.OrderBy(p => p.TeamName).ToList(), model)
        }
        #endregion

        #region Details

        [TestMethod]
        public void DetailsNullIdLoads404()
        {
            // act
            var result = (ViewResult)controller.Details(null).Result;


            //assert
            Assert.AreEqual("404", result.ViewName);
        }

        [TestMethod]
        public void DetailsInvalidIdLoads404()
        {
            // act
            var result = (ViewResult)controller.Details(1001).Result;


            //assert
            Assert.AreEqual("404", result.ViewName);
        }

        [TestMethod]
        public void DetailsValidIdLoadsTeams()
        {
            // act
            var result = (ViewResult)controller.Details(300).Result;


            //assert
            Assert.AreEqual(teams[0], result.Model);
        }

        [TestMethod]
        public void DetailsValidIdLoadsView()
        {
            // act
            var result = (ViewResult)controller.Details(400).Result;


            //assert
            Assert.AreEqual("Details", result.ViewName);
        }
        #endregion


        #region Create
        [TestMethod]
        public void CreateReturnsView()
        {
            // act
            var result = (ViewResult)controller.Create();


            //assert
            Assert.AreEqual("Create", result.ViewName);
        }
        #endregion
    }
}
