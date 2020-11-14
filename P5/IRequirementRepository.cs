using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    interface IRequirementRepository
    {
        string Add(Requirement requirement);
        List<Requirement> GetAll(int ProjectID);
        string Remove(Requirement requirement);
        string Modify(Requirement requirement);
        Requirement GetRequirementByID(int requirementID);
        int CountByFeatureID(int featureId);
        void RemoveByFeatureID(int featureID);
    }
}
