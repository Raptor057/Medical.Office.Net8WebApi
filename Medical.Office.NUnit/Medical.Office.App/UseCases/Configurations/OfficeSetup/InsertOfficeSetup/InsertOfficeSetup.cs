using Common.Common;
using Medical.Office.App.Dtos.Configurations;
using Medical.Office.App.UseCases.Configurations.OfficeSetup.InsertOfficeSetup;


namespace Medical.Office.NUnit.Medical.Office.App.UseCases.Configurations.OfficeSetup.InsertOfficeSetup
{
    [TestFixture]
    public class InsertOfficeSetupRequestTests
    {
        [Test]
        public void Create_ValidOfficeSetup_ReturnsInsertOfficeSetupRequest()
        {
            // Arrange
            var officeSetup = new OfficeSetupDto
            {
                NameOfOffice = "Main Office",
                Address = "123 Main St",
                OpeningTime = new TimeSpan(9, 0, 0),
                ClosingTime = new TimeSpan(17, 0, 0)
            };

            // Act
            var request = InsertOfficeSetupRequest.Create(officeSetup);

            // Assert
            Assert.IsNotNull(request);
            Assert.IsTrue(!string.IsNullOrEmpty(request.NameOfOffice));
            Assert.IsTrue(!string.IsNullOrEmpty(request.Address));
            Assert.IsTrue(!string.IsNullOrEmpty(Convert.ToString(request.OpeningTime)));
            Assert.IsTrue(!string.IsNullOrEmpty(Convert.ToString(request.ClosingTime)));
        }

        [Test]
        public void Create_InvalidOfficeSetup_ThrowsException()
        {
            // Arrange
            var officeSetup = new OfficeSetupDto
            {
                NameOfOffice = string.Empty,
                Address = string.Empty,
                OpeningTime = TimeSpan.Zero,
                ClosingTime = TimeSpan.Zero
            };

            // Act & Assert
            var ex = Assert.Throws<BusinessRuleException>(() => InsertOfficeSetupRequest.Create(officeSetup));
            Assert.IsNotNull(ex);
            Console.WriteLine($"Exception message: {ex.Message}");
            Assert.IsTrue(!string.IsNullOrEmpty(ex.Message), "Expected an error message but got none.");
        }

        [Test]
        public void Validations_NullOfficeSetup_AddsError()
        {
            // Arrange
            OfficeSetupDto officeSetup = null;
            var errors = new ErrorList();

            // Act
            InsertOfficeSetupRequest.Validations(officeSetup, errors);

            // Assert
            Assert.IsFalse(errors.IsEmpty);
            Assert.IsTrue(errors.Contains("No se ingreso ningun dato"));
        }
    }
}
