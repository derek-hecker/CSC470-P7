using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P5;

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
        public int selected_project;
        public FakeRequiremnetRepository(int selected_id)
        {
            selected_project = selected_id;
        }
        public string Add(Requirement requirement)
        {
            string newRequirementTitle = requirement.Statement.Trim();
            if (isDuplicateDescription(newRequirementTitle))
            {
                return DUPLICATE_STATEMENT_ERROR;
            }
            if (newRequirementTitle == "")
            {
                return EMPTY_STATEMENT_ERROR;
            }
            requirement.Id = GetNextID();
            requirement.ProjectId = selected_project;
            requirements.Add(requirement);
            return NO_ERROR;
            
        }

        public int CountByFeatureID(int featureId)
        {
            int count = 0;
            foreach (Requirement r in requirements)
            {
                if (r.FeatureId == featureId)
                {
                    count++;
                }
            }
            return count;
        }

        public List<Requirement> GetAll(int ProjectID)
        {
            List<Requirement> tmp = new List<Requirement>();
            foreach (Requirement r in requirements)
            {
                if (r.ProjectId == selected_project)
                {
                    tmp.Add(r);
                }
            }
            return tmp;
        }

        public Requirement GetRequirementByID(int requirementID)
        {
            Requirement tmp = new Requirement();
            foreach (Requirement r in requirements)
            {
                if (r.Id == requirementID)
                {
                    tmp = r;
                }
            }
            return tmp;
        }

        public string Modify(Requirement requirement)
        {
            Requirement requirement1 = new Requirement();
            requirement1 = GetRequirementByID(requirement.Id);
            if (isDuplicateDescription(requirement.Statement) && requirement.Statement != requirement1.Statement)
            {
                return DUPLICATE_STATEMENT_ERROR;
            }
            if (requirement.Statement == "")
            {
                return EMPTY_STATEMENT_ERROR;
            }
            int index = 0;
            foreach (Requirement r in requirements)
            {
                if (requirement.Id == r.Id)
                {
                    requirements[index].Statement = r.Statement;
                    return NO_ERROR;
                }
                index++;
            }
            return NO_ERROR;
        }

        public string Remove(Requirement requirement)
        {
            int index = 0;
            foreach(Requirement r in requirements)
            {
                if (r.Id == requirement.Id)
                {
                    requirements.RemoveAt(index);
                    return NO_ERROR;
                }
                index++;
            }
            return REQUIREMENT_NOT_FOUND;
        }

        public void RemoveByFeatureID(int featureID)
        {
            int index = 0;
            foreach (Requirement r in requirements)
            {
                if (r.FeatureId == featureID)
                {
                    requirements.RemoveAt(index);
                }
                index++;
            }
        }
        public bool isDuplicateDescription(string desc)
        {
            bool isDuplicate = false;
            foreach (Requirement r in requirements)
            {
                if (r.Statement == desc && r.ProjectId == selected_project)
                {
                    isDuplicate = true;
                }
            }
            return isDuplicate;
        }
        public int GetNextID()
        {
            int currentMaxID = 0;
            foreach (Requirement r in requirements)
            {
                currentMaxID = r.Id;
            }
            return ++currentMaxID;
        }
    }
}
