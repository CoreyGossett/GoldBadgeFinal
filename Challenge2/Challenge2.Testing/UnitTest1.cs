using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Challenge2.Repo;
using System.Collections.Generic;

namespace Challenge2.Testing
{
    [TestClass]
    public class UnitTest1
    {
        private static ClaimRepo _claimRepo = new ClaimRepo();


        [TestMethod]
        public void TestCreateClaim()
        {
            Claim newClaim = new Claim();
            bool actual =_claimRepo.CreateClaim(newClaim);

            Assert.IsTrue(actual);

        }

        [TestMethod]
        public void TestGetClaims()
        {
            Claim newClaim = new Claim();
            _claimRepo.CreateClaim(newClaim);

            var expected = _claimRepo.GetClaims();

            Assert.IsNotNull(expected);
        }

        [TestMethod]
        public void TestDequeuClaim()
        {
            Claim newClaim = new Claim();
            _claimRepo.CreateClaim(newClaim);

            bool expected = true;

            bool actual = _claimRepo.DequeueClaim();

            Assert.IsTrue(actual);
            //Assert.AreEqual(expected, actual);
        }
    }
}
