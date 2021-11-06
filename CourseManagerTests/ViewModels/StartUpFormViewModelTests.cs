using Microsoft.VisualStudio.TestTools.UnitTesting;
using CourseManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Tests
{
    [TestClass()]
    public class StartUpFormViewModelTests
    {
        Model model;
        StartUpFormViewModel viewModel;
        [TestInitialize]
        public void Setup()
        {
            model = new Model();
            viewModel = new StartUpFormViewModel(model);
        }

        [TestMethod()]
        public void StartUpFormViewModelTest()
        {
            Assert.IsTrue(viewModel.CourseSelectingSystemButtonEnabled);
            Assert.IsTrue(viewModel.CourseManagementSystemButtonEnabled);
        }

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