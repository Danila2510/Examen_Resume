using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Resume.Models
{
    public class SummaryModel
    {
        public string Phone { set; get; }
        public string Name { set; get; }
        public int Age { set; get; }
        public string Email { set; get; }
        public string Adress { set; get; }
        public string Language { set; get; }
        public string Experience { set; get; }
        public string Education { set; get; }
        public string Skills { set; get; }

        public SummaryModel() { }
        public SummaryModel(string name, int age, string email, string adress , string language,  string phone, string education, string experience, string skills)
        {
            Skills = skills;
            Phone = phone;
            Education = education;
            Email = email;
            Adress = adress;
            Language = language;
            Experience = experience;
            Name = name;
            Age = age;
        
        }
        public void SummarySave()
        {
            XDocument xmlDocument = XDocument.Load("Summary.xml");
            XElement newPersonElement = new XElement("Person",
                new XElement("Name", Name),
                new XElement("Age", Age),
                new XElement("Email", Email),
                new XElement("Phone", Phone),
                new XElement("Adress", Adress),
                new XElement("Education", Education),
                new XElement("Experience", Experience),
                new XElement("Skills", Skills),
                new XElement("Language", Language)
            );
            xmlDocument.Root?.Add(newPersonElement);
            xmlDocument.Save("Summary.xml");
        }
        public static void SummaryLoad(ObservableCollection<SummaryModel> summaryModels)
        {
            XDocument xmlDocument = XDocument.Load("Summary.xml");   
            foreach (XElement personElement in xmlDocument.Descendants("Person"))
            {
                SummaryModel person = new SummaryModel();
                person.Name = personElement.Element("Name").Value;
                person.Age = int.Parse(personElement.Element("Age").Value);
                person.Email = personElement.Element("Email").Value;
                person.Phone = personElement.Element("Phone").Value;
                person.Adress = personElement.Element("Adress").Value;
                person.Education = personElement.Element("Education").Value;
                person.Experience = personElement.Element("Experience").Value;
                person.Skills = personElement.Element("Skills").Value;
                person.Language = personElement.Element("Language").Value;
                summaryModels.Add(person);
            }
        }
        public override string ToString()
        {
            return $"{Name}";
        }
    }

}
