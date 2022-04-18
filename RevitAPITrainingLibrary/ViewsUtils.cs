﻿using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITrainingLibrary
{
    public class ViewsUtils
    {
        public static List<ViewPlan> GetViews(Document doc)
        {


            var views = new FilteredElementCollector(doc)
                .OfClass(typeof(ViewPlan))
                .WhereElementIsNotElementType()
                .Cast<ViewPlan>()
                .ToList();

            return views;
        }
    }
}
