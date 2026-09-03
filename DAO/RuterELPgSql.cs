using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAO
{
    public class RuterELPgSql : RuterELDao
    {
        public List<Trip> FindAllTripsForUserSortedByStart(int userId)
        {
            throw new NotImplementedException();
        }

        public List<Trip> FindAllTripsNotFinished()
        {
            throw new NotImplementedException();
        }

        public List<Scooter> FindAvailableScootersOver20()
        {
            throw new NotImplementedException();
        }

        public double FindAveragePricePerKmFinishedTrips()
        {
            throw new NotImplementedException();
        }

        public AppUser? FindUserWithMostTrips()
        {
            throw new NotImplementedException();
        }
    }
}
