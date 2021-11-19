using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CourseManager.Tests
{
    [TestClass()]
    public class StartUpFormViewModelTests
    {
        Model model;
        StartUpFormViewModel viewModel;

        // unit test case setup
        [TestInitialize]
        public void Initialize()
        {
            model = new Model();
            viewModel = new StartUpFormViewModel(model);
        }

        // test constructor
        [TestMethod()]
        public void StartUpFormViewModelTest()
        {
            Assert.IsTrue(viewModel.CourseSelectingSystemButtonEnabled);
            Assert.IsTrue(viewModel.CourseManagementSystemButtonEnabled);
        }

        // test model property
        [TestMethod()]
        public void GetModelTest()
        {
            Assert.AreEqual(model, viewModel.Model);
        }

        // test properties enabled
        [TestMethod()]
        public void ControlsEnabledTest()
        {
            viewModel.CourseSelectingSystemButtonEnabled = false;
            Assert.IsFalse(viewModel.CourseSelectingSystemButtonEnabled);
            viewModel.CourseManagementSystemButtonEnabled = false;
            Assert.IsFalse(viewModel.CourseManagementSystemButtonEnabled);
        }
    }
}