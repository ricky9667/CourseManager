using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Threading;
using System.Windows.Automation;
using System.Windows;
using System.Collections.Generic;
using OpenQA.Selenium;
using System.Windows.Input;
using System.Windows.Forms;
using OpenQA.Selenium.Interactions;

namespace CourseManager.Tests
{
    public class Robot
    {
        private WindowsDriver<WindowsElement> _driver;
        private Dictionary<string, string> _windowHandles;
        private string _root;
        private const string CONTROL_NOT_FOUND_EXCEPTION = "The specific control is not found!!";
        private const string WIN_APP_DRIVER_URI = "http://127.0.0.1:4723";

        // constructor
        public Robot(string targetAppPath, string root)
        {
            this.Initialize(targetAppPath, root);
        }

        // initialize
        public void Initialize(string targetAppPath, string root)
        {
            _root = root;
            var options = new AppiumOptions();
            options.AddAdditionalCapability("app", targetAppPath);
            options.AddAdditionalCapability("deviceName", "WindowsPC");

            _driver = new WindowsDriver<WindowsElement>(new Uri(WIN_APP_DRIVER_URI), options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _windowHandles = new Dictionary<string, string>
            {
                { _root, _driver.CurrentWindowHandle }
            };
        }

        // clean up
        public void CleanUp()
        {
            SwitchTo(_root);
            _driver.CloseApp();
            _driver.Dispose();
        }

        // test
        public void SwitchTo(string formName)
        {
            if (_windowHandles.ContainsKey(formName))
            {
                _driver.SwitchTo().Window(_windowHandles[formName]);
            }
            else
            {
                foreach (var windowHandle in _driver.WindowHandles)
                {
                    _driver.SwitchTo().Window(windowHandle);
                    try
                    {
                        _driver.FindElementByAccessibilityId(formName);
                        _windowHandles.Add(formName, windowHandle);
                        return;
                    }
                    catch
                    {

                    }
                }
            }
        }

        // test
        public void Sleep(Double time)
        {
            Thread.Sleep(TimeSpan.FromSeconds(time));
        }

        // test
        public void ClickById(string id)
        {
            _driver.FindElementByAccessibilityId(id).Click();
        }

        // test
        public void ClickByName(string name)
        {
            _driver.FindElementByName(name).Click();
        }

        // test
        public void ClickTabControl(string name)
        {
            var elements = _driver.FindElementsByName(name);
            foreach (var element in elements)
            {
                if ("ControlType.TabItem" == element.TagName)
                    element.Click();
            }
        }

        // test
        public void CloseWindow()
        {
            SendKeys.SendWait("%{F4}");
        }

        // test
        public void CloseMessageBox()
        {
            _driver.FindElementByName("確定").Click();
        }

        // test
        public void ClickDataGridViewCellBy(string id, int rowIndex, string columnName)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(id);
            _driver.FindElementByName($"{columnName} 資料列 {rowIndex}").Click();
        }

        // test
        public void ClickListBoxItemBy(string id, string itemName)
        {
            var listBox = _driver.FindElementByAccessibilityId(id);
            _driver.FindElementByName(itemName).Click();
        }

        // test
        public string GetMessageBoxText()
        {
            var element = _driver.FindElementByClassName("Static");
            return element.Text;
        }

        // test
        public string[] GetDataGridViewRowDataStrings(string id, int rowIndex)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(id);
            var rowDatas = dataGridView.FindElementByName($"資料列 {rowIndex}").FindElementsByXPath("//*");
            List<string> stringsList = new List<string>();

            // FindElementsByXPath("//*") 會把 "row" node 也抓出來，因此 i 要從 1 開始以跳過 "row" node
            for (int i = 1; i < rowDatas.Count; i++)
            {
                stringsList.Add(rowDatas[i].Text.Replace("(null)", ""));
            }

            return stringsList.ToArray();
        }

        // test
        public void InputValueToTextBox(string id, string text)
        {
            var element = _driver.FindElementByAccessibilityId(id);
            element.Clear();
            element.SendKeys(text);
        }

        // test
        public void ScrollUpListBox(int times)
        {
            var element = _driver.FindElementByAccessibilityId("UpButton");
            for (int i = 0; i < times; i++)
            {
                element.Click();
            }
        }

        // test
        public void ScrollDownListBox(int times)
        {
            var element = _driver.FindElementByAccessibilityId("DownButton");
            for (int i = 0; i < times; i++)
            {
                element.Click();
            }
        }

        // test
        public void ScrollUpDataGridView(int times)
        {
            var element = _driver.FindElementByName("上移一行");
            for (int i = 0; i < times; i++)
            {
                element.Click();
            }
        }

        // test
        public void ScrollDownDataGridView(int times)
        {
            var element = _driver.FindElementByName("下移一行");
            for (int i = 0; i < times; i++)
            {
                element.Click();
            }
        }

        // test
        public void AssertEnable(string name, bool state)
        {
            WindowsElement element = _driver.FindElementByName(name);
            Assert.AreEqual(state, element.Enabled);
        }

        // test
        public void AssertText(string id, string text)
        {
            WindowsElement element = _driver.FindElementByAccessibilityId(id);
            Assert.AreEqual(text, element.Text);
        }

        // test
        public void AssertDataGridViewRowDataBy(string id, int rowIndex, string[] data)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(id);
            var rowDatas = dataGridView.FindElementByName($"資料列 {rowIndex}").FindElementsByXPath("//*");

            // FindElementsByXPath("//*") 會把 "row" node 也抓出來，因此 i 要從 1 開始以跳過 "row" node
            for (int i = 1; i < rowDatas.Count; i++)
            {
                Assert.AreEqual(data[i - 1], rowDatas[i].Text.Replace("(null)", ""));
            }
        }

        // test
        public void AssertDataGridViewRowCountBy(string id, int rowCount)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(id);
            Point point = new Point(dataGridView.Location.X, dataGridView.Location.Y);
            AutomationElement element = AutomationElement.FromPoint(point);

            while (element != null && element.Current.LocalizedControlType.Contains("datagrid") == false)
            {
                element = TreeWalker.RawViewWalker.GetParent(element);
            }

            if (element != null)
            {
                GridPattern gridPattern = element.GetCurrentPattern(GridPattern.Pattern) as GridPattern;

                if (gridPattern != null)
                {
                    Assert.AreEqual(rowCount, gridPattern.Current.RowCount);
                }
            }
        }
    }
}
