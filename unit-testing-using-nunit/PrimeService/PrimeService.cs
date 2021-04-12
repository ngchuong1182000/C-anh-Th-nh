using System;

namespace Prime.Services
{
    public interface IAgeManager
    {
        int GetAgeById(string identity);
    }
    public interface IDrivingLicenseManager
    {
        bool IssueLicense(int age);
        void Test();
    }

    public class AgeManager : IAgeManager
    {
        public virtual int GetAgeById(string identity)
        {
            Random r = new Random();
            // This contains logic to get age based on ID number
            if (identity.StartsWith("00"))
                return r.Next(1, 9);
            else if (identity.StartsWith("01"))
                return r.Next(10, 19);
            else if (identity.StartsWith("02"))
                return r.Next(20, 29);
            else if (identity.StartsWith("03"))
                return r.Next(30, 39);
            else if (identity.StartsWith("04"))
                return r.Next(40, 49);
            else
                return r.Next(50, int.MaxValue);
        }
    }
    public class DrivingLicenseManager : IDrivingLicenseManager
    {
        public bool IssueLicense(int age)
        {
            if (age > 18 && age < 50)
            {
                Console.WriteLine($"Issue Driving License!");
                return true;
            }
            else
            {
                Console.WriteLine($"NOT suitable for driving!");
                return false;
            }
        }

        public void Test() { 
            
        }
    }

    public class PrimeService
    {
        IAgeManager _ageManager;
        IDrivingLicenseManager _drivingManager;

        public PrimeService(IAgeManager ageManager, IDrivingLicenseManager drivingManager)
        {
            _ageManager = ageManager;
            _drivingManager = drivingManager;
        }

        public bool IssueDrivingLicense(string id)
        {
            int age = _ageManager.GetAgeById(id);

            bool isOk = _drivingManager.IssueLicense(age);
            return isOk;
        }
    }
}