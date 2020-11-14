using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class FakeFeatureRepository : IFeatureRepository
    {
        public const string NO_ERROR = "";
        public const string DUPLICATE_TITLE_ERROR = "Title must be unique";
        public const string EMPTY_TITLE_ERROR = "TItle must have a value";
        public const string NOT_FOUND_ERROR = "Feature Not Found";
        public const string INVALID_PROJECT_ID_ERROR = "Invalid Project ID for feature";

        private static List<Feature> features = new List<Feature>();

        public string Add(Feature feature)
        {
            throw new NotImplementedException();
        }

        public List<Feature> GetAll(int ProjectID)
        {
            throw new NotImplementedException();
        }

        public Feature GetFeatureByID(int featureID)
        {
            throw new NotImplementedException();
        }

        public Feature GetFeatureByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public string Modify(Feature feature)
        {
            throw new NotImplementedException();
        }

        public string Remove(Feature feature)
        {
            throw new NotImplementedException();
        }
    }
}
