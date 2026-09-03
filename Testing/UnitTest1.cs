using DAO;
using Models;
using NUnit.Framework;


//tester direkte mot databasen,
//dårlig idee,
//Kunne brukt dependecy injection 
//for mocking, og genrell bedre struktur
namespace Testing
{
    public class Tests
    {
        List<AppUser> users;
        List<Trip> trips;
        List<Scooter> scooters;
        RuterELPgSql dao;

        [SetUp]
        public void Setup()
        {
            using RuterEL db = new();
            dao = new RuterELPgSql();

            users = new List<AppUser> {
                new AppUser { Name = "Ali", PhoneNumber = 70122301 },
                new AppUser { Name = "Eric", PhoneNumber = 23456782 },
                new AppUser { Name = "Rashford", PhoneNumber = 34298111 }
            };
            db.AppUser.AddRange(users);

            scooters = new List<Scooter> {
                new Scooter { Brand = "VOY", BatteryCapacity = 100f, Status = StatusType.Available },
                new Scooter { Brand = "RYDE", BatteryCapacity = 45f, Status = StatusType.InUse },
                new Scooter { Brand = "RYDE", BatteryCapacity = 12f, Status = StatusType.OutOfOrder }
            };
            db.Scooter.AddRange(scooters);
            db.SaveChanges();

            //fikk exption med DateTime.now så fant at jeg måtte endre til UtcNow 
            trips = new List<Trip> {
                new Trip { StartTime = DateTime.UtcNow.AddDays(-2).AddHours(-1), EndTime = DateTime.UtcNow.AddDays(-2),
                Km = 4.2, Cost = 85.50, AppUserId = users[0].Id, ScooterId = scooters[0].Id },
                new Trip { StartTime = DateTime.UtcNow.AddDays(-1).AddMinutes(-30), EndTime = DateTime.UtcNow.AddDays(-1),
                Km = 1.8, Cost = 42.00, AppUserId = users[1].Id, ScooterId = scooters[0].Id },
                new Trip { StartTime = DateTime.UtcNow.AddMinutes(-15), EndTime = null,
               Km = 0.0, Cost = 0.0, AppUserId = users[2].Id, ScooterId = scooters[1].Id }
};
            db.Trip.AddRange(trips);
            db.SaveChanges();
        }

        [TearDown]
        public void Cleanup()
        {
            using RuterEL db = new();
            db.Trip.RemoveRange(db.Trip);
            db.Scooter.RemoveRange(db.Scooter);
            db.AppUser.RemoveRange(db.AppUser);
            db.SaveChanges();
        }

        [Test]
        public void FindAllTripsForUserSorted_CorrectInput_True()
        {
            var result = dao.FindAllTripsForUserSortedByStart(users[0].Id);

            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result[0].AppUserId, Is.EqualTo(users[0].Id));
        }

        [Test]
        public void FindAllTripsNotFinished_NullEndTime()
        {
            var result = dao.FindAllTripsNotFinished();

            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result[0].EndTime, Is.Null);
        }

        [Test]
        public void FindAvailableScootersOver20_AvailableScooters_BatteryOver20()
        {
            var result = dao.FindAvailableScootersOver20();

            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result[0].Brand, Is.EqualTo("VOY"));
        }

        [Test]
        public void FindAveragePricePerKm_FinishedTripsAverage_True()
        {
            double expected = new[] { 85.50 / 4.2, 42.00 / 1.8 }.Average();

            double result = dao.FindAveragePricePerKmFinishedTrips();

            Assert.That(result, Is.EqualTo(expected).Within(0.0001));
        }

        [Test]
        public void FindUserWithMostTrips_UserWithOneTrip_Null()
        {
            var result = dao.FindUserWithMostTrips();

            Assert.That(result, Is.Not.Null);
        }
    }
}