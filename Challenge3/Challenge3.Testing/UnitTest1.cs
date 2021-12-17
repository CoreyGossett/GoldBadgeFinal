using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Challenge3.Repo;
using System.Collections.Generic;

namespace Challenge3.Testing
{
    [TestClass]
    public class UnitTest1
    {
        public List<string> _doorList = new List<string>();
        public BadgeRepo _testRepo = new BadgeRepo();

        [TestMethod]
        public void TestAddBadge()
        {
            AddDoorsToTestList();
            Badge testBadge = new Badge(1, _doorList);

            Assert.IsTrue(_testRepo.AddBadge(testBadge));
        }

        public void AddDoorsToTestList()
        {
            string doorOne = "a1";
            string doorTwo = "a2";
            string doorThree = "a3";
            _doorList.Add(doorOne);
            _doorList.Add(doorTwo);
            _doorList.Add(doorThree);
        }

        [TestMethod]
        public void TestRemoveBadgeFromDictionary()
        {
            AddDoorsToTestList();
            Badge testBadge = new Badge(1, _doorList);
            int testId = 1;

            Assert.IsTrue(_testRepo.RemoveBadgeFromDictionary(testId));
        }

        [TestMethod]
        public void TestGetBadgeById()
        {
            AddDoorsToTestList();
            Badge expected = new Badge(1, _doorList);
            Badge actual = _testRepo.GetBadgeById(1);

            Assert.ReferenceEquals(expected, actual);
        }
    }
}
