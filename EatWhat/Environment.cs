using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml;

namespace EatWhat
{
    public static class Environment
    {
        public static List<string> Menu { get; set; }

        public const string MenuPath = "menu.xml";

        public static void ReloadMenu()
        {
            Menu = new List<string>();
            var doc = new XmlDocument();
            doc.Load(MenuPath);

            var root = doc.SelectSingleNode("Menu");
            var foods = root.ChildNodes;

            foreach (var fraw in foods)
            {
                var felem = (XmlElement)fraw;
                Menu.Add(felem.GetAttribute("Name"));
            }
        }

        public static void RefreshMenu(ObservableCollection<string> menu)
        {
            var doc = new XmlDocument();
            doc.Load(MenuPath);

            var root = doc.DocumentElement;
            root.RemoveAll();

            foreach (var f in menu)
            {
                var food = doc.CreateNode(XmlNodeType.Element, "Food", "");
                var foodElem = (XmlElement)food;
                foodElem.SetAttribute("Name", f);
                root.AppendChild(foodElem);
            }

            doc.Save(MenuPath);
        }

    }
}
