using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    interface IFeatureRepository
    {
        string Add(Feature feature);
        List<Feature> GetAll(int ProjectID);
        string Remove(Feature feature);
        string Modify(Feature feature);
        Feature GetFeatureByID(int featureID);
        Feature GetFeatureByTitle(string title);
    }
}
