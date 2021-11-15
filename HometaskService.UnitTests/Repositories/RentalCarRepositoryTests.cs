using HometaskService.Database;
using HometaskService.DBModels;
using HometaskService.Models;
using HometaskService.Repositories;
using HometaskService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HometaskService.UnitTests.Repositories
{
    class RentalCarRepositoryTests
    {
        private HometaskServiceDbContext dbContext;
        private IRentalRepository<DbRentalCar> repository;
        private DbRentalCar carToAdd;
        private DbRentalCar carToUpdate;

        [SetUp]
        public void SetUp()
        {
            dbContext = new HometaskServiceDbContext();
            repository = new RentalCarRepository();
        }

        [TearDown]
        public void TearDown()
        {
        }

        //#region Get
        //[Test]
        //public void ShouldGet()
        //{
        //    if (dbContext.RentalCars.Find(1) is null)
        //    {
        //        Assert.IsNull(repository.GetById(1));
        //    }
        //    else
        //    {
        //        Assert.IsInstanceOf<DbRentalCar>(repository.GetById(1));
        //    }
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
