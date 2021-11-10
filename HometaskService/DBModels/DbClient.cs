using System;
using System.Collections.Generic;

namespace HometaskService.DBModels
{
    internal class DbClient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int Experience { get; set; }
        public ICollection<DbRentalCar> RentalCars { get; set; }
    }
}
