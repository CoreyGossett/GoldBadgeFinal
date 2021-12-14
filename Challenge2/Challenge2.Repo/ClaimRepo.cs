using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2.Repo
{
    class ClaimRepo
    {
        public Queue<Claim> _claimQueue = new Queue<Claim>();

        public bool CreateClaim(Claim claim)
        {
            if (claim is null)
            {
                return false;
            }
            _claimQueue.Enqueue(claim);
            return true;
        }

        public Queue<Claim> GetClaims()
        {
            return _claimQueue;
        }

        public bool GetNextClaim()
        {
            _claimQueue.Dequeue();
            return true;
        }
    }
}
