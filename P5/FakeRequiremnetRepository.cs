using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class FakeRequiremnetRepository : IRequirementRepository
    {
        public const string NO_ERROR = "";
        public const string DUPLICATE_STATEMENT_ERROR = "Statements must be unique";
        public const string EMPTY_STATEMENT_ERROR = "Statements must have a value";
        public const string REQUIREMENT_NOT_FOUND = "Requiremnet does not exists";
        public const string MISSING_FEATUREID_ERROR = "Must select a feature for this requiremnet";
        public const string MISSING_PROJECTID_ERROR = "Must select a project for this requirement";

        private static List<Requirement> requirements = new List<Requirement>();

        public string Add(Requirement requirement)
        {
            throw new NotImplementedException();
        }

        public int CountByFeatureID(int featureId)
        {
            throw new NotImplementedException();
        }

        public List<Requirement> GetAll(int ProjectID)
        {
            throw new NotImplementedException();
        }

        public Requirement GetRequirementByID(int requirementID)
        {
            throw new NotImplementedException();
        }

        public string Modify(Requirement requirement)
        {
            throw new NotImplementedException();
        }

        public string Remove(Requirement requirement)
        {
            throw new NotImplementedException();
        }

        public void RemoveByFeatureID(int featureID)
        {
            throw new NotImplementedException();
        }
    }
}
