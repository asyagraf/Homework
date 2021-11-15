using HometaskService.DBModels;
using HometaskService.Models;
using HometaskService.Repositories;
using HometaskService.Repositories.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HometaskService.UnitTests.Repositories
{
    class CarRepositoryTests
    {
        private IRepository<Car, string> repository;

        [SetUp]
        public void SetUp()
        {
            //repository = new CarRepository(IMemoryCache cache, List<string> keys);
        }

        [TearDown]
        public void TearDown()
        {
        }

        //#region Get
        //[Test]
        //public void ShouldGet()
        //{
        //}
        //#endregion

        //#region Delete
        //[Test]
        //public void ShouldDelete()
        //{
        //}
        //#endregion

        //#region Create
        //[Test]
        //public void ShouldCreate()
        //{
        //}
        //#endregion

        //#region Update
        //[Test]
        //public void ShouldUpdate()
        //{
        //}
        //#endregion

        //#region GetAll
        //[Test]
        //public void ShouldGetAll()
        //{
        //}
        //#endregion
    }
}
