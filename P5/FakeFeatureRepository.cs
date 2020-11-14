using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P5;

namespace Builder
{
    class FakeFeatureRepository : IFeatureRepository
    {
        public const string NO_ERROR = "";
        public const string DUPLICATE_TITLE_ERROR = "Title must be unique";
        public const string EMPTY_TITLE_ERROR = "TItle must have a value";
        public const string NOT_FOUND_ERROR = "Feature Not Found";
        public const string INVALID_PROJECT_ID_ERROR = "Invalid Project ID for feature";
        public int _SelectedProjectID;
        private static List<Feature> features = new List<Feature>();

        public FakeFeatureRepository(int selected_project)
        {
            _SelectedProjectID = selected_project;
        }
        public FakeFeatureRepository()
        {

        }
        public string Add(Feature feature)
        {
            string newFeatureTitle = feature.Title.Trim();
            if (IsDuplicateTitle(newFeatureTitle))
            {
                return DUPLICATE_TITLE_ERROR;
            }
            if (newFeatureTitle == "")
            {
                return EMPTY_TITLE_ERROR;
            }
            feature.Id = GetNextID();
            features.Add(feature);
            return NO_ERROR;
        }

        public List<Feature> GetAll(int ProjectID)
        {
            List<Feature> tmp_list = new List<Feature>();

            foreach (Feature f in features)
            {
                if (f.ProjectId == _SelectedProjectID)
                {
                    tmp_list.Add(f);
                }
            }
            return tmp_list;
        }

        public Feature GetFeatureByID(int featureID)
        {
            Feature feature = new Feature();
            foreach (Feature f in features)
            {
                if (f.Id == featureID)
                {
                    feature = f;
                }
            }
            return feature;
        }

        public Feature GetFeatureByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public string Modify(Feature feature)
        {
            Feature feature1 = new Feature();
            feature1 = GetFeatureByID(feature1.Id);
            if (IsDuplicateTitle(feature1.Title) && feature.Title != feature1.Title)
            {
                return DUPLICATE_TITLE_ERROR;
            }
            if (feature.Title == "")
            {
                return EMPTY_TITLE_ERROR;
            }
            int index = 0;
            foreach (Feature f in features)
            {
                if (feature.Id == f.Id)
                {
                    features[index].Title = f.Title;
                    return NO_ERROR;
                }
                index++;
            }
            return NO_ERROR;
        }

        public string Remove(Feature feature)
        {
            int index = 0;
            foreach (Feature f in features)
            {
                if (f.Id == feature.Id)
                {
                    features.RemoveAt(index);
                    return NO_ERROR;
                }
                index++;
            }
            return NOT_FOUND_ERROR;
        }
        public bool IsDuplicateTitle(string featureTitle)
        {
            bool isDuplicate = false;
            foreach (Feature f in features)
            {
                if (featureTitle == f.Title)
                {
                    isDuplicate = true;
                }
            }
            return isDuplicate;
        }
        public int GetNextID()
        {
            int currentMaxID = 0;
            foreach (Feature f in features)
            {
                currentMaxID = f.Id;
            }
            return ++currentMaxID;
        }
    }
}
