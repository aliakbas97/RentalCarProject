using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Entity
{
   public class OperationClaim :IEntity
    {
        public int OperationClaimId { get; set; }
        public string Name { get; set; }

    }
}
