using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2.Repo
{
    public class ClaimRepo
    {
        public Queue<Claim> _claimQueue = new Queue<Claim>();

        
        public Claim _claim = new Claim();
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

        public Claim DequeueClaim()
        {
            Claim nextClaim = _claimQueue.Dequeue();
            return nextClaim;
        }
    }
}
