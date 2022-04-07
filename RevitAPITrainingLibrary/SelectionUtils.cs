using Autodesk.Revit.DB;
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

        public static List<Wall> PickWalls(ExternalCommandData commandData, string message = "Выберите стены")
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            IList<Reference> selectedElementRefList = null;
            try
            {
                selectedElementRefList = uidoc.Selection.PickObjects(Autodesk.Revit.UI.Selection.ObjectType.Element, new WallFilter(), "Выберите стены по грани");
            }
            catch (Autodesk.Revit.Exceptions.OperationCanceledException)
            { }
            catch (System.NullReferenceException)
            { }
            if (selectedElementRefList == null)
            return null;
            else
            {
                var WallList = new List<Wall>();
                foreach (var selectedElement in selectedElementRefList)
                {
                    Wall oWall = doc.GetElement(selectedElement) as Wall;
                    WallList.Add(oWall);
                }
                return WallList;
            }
        }
    }
}
