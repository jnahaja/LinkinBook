using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LinkinBook.Tests.Infrastructure
{
    public class RequirementAttribute : CategoryAttribute
    {
        public string RequirementId { get; private set; }

        public RequirementAttribute(string id): base("Requirement" + id){
            this.RequirementId = id;
           
        }
    }
}
