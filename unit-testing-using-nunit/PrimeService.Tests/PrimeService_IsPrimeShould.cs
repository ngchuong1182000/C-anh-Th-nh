using System;
using Moq;
using NUnit.Framework;
using Prime.Services;

namespace Prime.UnitTests.Services
{
    [TestFixture]
    public class StubAgeManager : IAgeManager
    {
        public int GetAgeById(string identity)
        {
            return 19;
        }
    }
    public class StubDrivingLicenseManager : IDrivingLicenseManager
    {
        public bool IssueLicense(int age)
        {
            if (age >= 18)
            {
                throw new Exception("Success");
            }
            throw new Exception("Failed");
        }

        public void Test()
        {
            throw new System.NotImplementedException();
        }
    }
    public class PrimeService_IsPrimeShould
    {
        private PrimeService _primeService;
        private Mock<IAgeManager> mock;

        [Test]
        public void IssueDrivingLicenseMock_InputValidNumber_ReturnTrue()
        {
            var mock = new Mock<IAgeManager>();
            mock.Setup(p => p.GetAgeById(It.IsAny<string>())).Returns(19);

            DrivingLicenseManager _primeService = new DrivingLicenseManager();

            var result = _primeService.IssueLicense(mock.Object.GetAgeById("12"));
            Assert.IsTrue(result, "Issue Driving License!");
        }
        [Test]
        public void IssueDrivingLicenseStub_InputValidNumber_ReturnTrue()
        {
            StubAgeManager ageManager = new StubAgeManager();
            DrivingLicenseManager driverLicenseManager = new DrivingLicenseManager();
            PrimeService _primeService = new PrimeService(ageManager, driverLicenseManager);
            var result = _primeService.IssueDrivingLicense("194512132");
            Assert.IsTrue(result, "Issue Driving License!");
        }
        [Test]
        public void IssueDrivingLicenseFake_InputValidNumber_ReturnTrue()
        {
            StubAgeManager ageManager = new StubAgeManager();
            StubDrivingLicenseManager driverLicenseManager = new StubDrivingLicenseManager();

            PrimeService _primeService = new PrimeService(ageManager, driverLicenseManager);


            var ex = Assert.Throws<Exception>(() => _primeService.IssueDrivingLicense("194512132"));
            Assert.That(ex.Message, Is.EqualTo("Success"));
        }

        [Test]
        public void IssueDrivingLicense_InputValidNumber_ReturnTrue()
        {
            Mock<IDrivingLicenseManager> mockDrivingLicenseManager = new Mock<IDrivingLicenseManager>();
            StubAgeManager ageManager = new StubAgeManager();
            StubDrivingLicenseManager driverLicenseManager = new StubDrivingLicenseManager();

            PrimeService _primeService = new PrimeService(ageManager, driverLicenseManager);
            _primeService.IssueDrivingLicense("20312");

            mockDrivingLicenseManager.Verify(mock => mock.IssueLicense(19), Times.Once());

        }
    }
}