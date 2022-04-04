﻿using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITrainingLibrary
{
    public class SelectionUtils
    {
        public static Element PickObject(ExternalCommandData commandData, string message = "Выберите объект")
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            var selectedObject = uidoc.Selection.PickObject(ObjectType.Element, message);
            var oElement = doc.GetElement(selectedObject);
            return oElement;
        }

        public static List<Element> PickObjects(ExternalCommandData commandData, string message = "Выберите объект")
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;
            List<Element> elementList = new List<Element>();
            
            var selectedObjects = uidoc.Selection.PickObjects(ObjectType.Element, message);
            elementList = selectedObjects.Select(selectedObject => doc.GetElement(selectedObject)).ToList();

            return elementList;


        }
    }
}
