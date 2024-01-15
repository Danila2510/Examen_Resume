using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;
using Resume.Commands;
using Resume.Models;
using Resume.Views;

namespace Resume.ViewModels
{
    public class MainViewModel : ViewModel_Base
    {
        public ObservableCollection<SummaryModel> summaryModels { get; set; }
        private static readonly DependencyProperty SelectedSummaryItemProperty;
        private static readonly DependencyProperty NameProperty;
        private static readonly DependencyProperty AgeProperty;
        private static readonly DependencyProperty EmailProperty;
        private static readonly DependencyProperty AdressProperty;
        private static readonly DependencyProperty LanguageProperty;
        private static readonly DependencyProperty PhoneProperty;
        private static readonly DependencyProperty EducationProperty;
        private static readonly DependencyProperty ExperienceProperty;
        private static readonly DependencyProperty SkillsProperty;

        static MainViewModel()
        {
            NameProperty = DependencyProperty.Register("Name", typeof(string), typeof(MainViewModel));
            AgeProperty = DependencyProperty.Register("Age", typeof(int), typeof(MainViewModel));
            EmailProperty = DependencyProperty.Register("Email", typeof(string), typeof(MainViewModel));
            AdressProperty = DependencyProperty.Register("Adress", typeof(string), typeof(MainViewModel));
            LanguageProperty = DependencyProperty.Register("Language", typeof(string), typeof(MainViewModel));  
            PhoneProperty = DependencyProperty.Register("Phone", typeof(string), typeof(MainViewModel));
            EducationProperty = DependencyProperty.Register("Education", typeof(string), typeof(MainViewModel));
            ExperienceProperty = DependencyProperty.Register("Experience", typeof(string), typeof(MainViewModel));
            SkillsProperty = DependencyProperty.Register("Skills", typeof(string), typeof(MainViewModel));
            SelectedSummaryItemProperty = DependencyProperty.Register("SelectedSummary", typeof(SummaryModel), typeof(MainViewModel));
        }

        public MainViewModel()
        {
            LoadSummary();
        }
        public SummaryModel SelectedSummary
        {
            get { return (SummaryModel)GetValue(SelectedSummaryItemProperty); }
            set { SetValue(SelectedSummaryItemProperty, value); }
        }
        public string Skills
        {
            get
            {
                return (string)GetValue(SkillsProperty);
            }
            set
            {
                SetValue(SkillsProperty, value);
            }
        }
        public int Age
        {
            get { return (int)GetValue(AgeProperty); }
            set { SetValue(AgeProperty, value); }
        }
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
        public string Phone
        {
            get
            {
                return (string)GetValue(PhoneProperty);
            }
            set
            {
                SetValue(PhoneProperty, value);
            }
        }
        public string Email
        {
            get
            {
                return (string)GetValue(EmailProperty);
            }
            set
            {
                SetValue(EmailProperty, value);
            }
        }      
        public string Language
        {
            get
            {
                return (string)GetValue(LanguageProperty);
            }
            set
            {
                SetValue(LanguageProperty, value);
            }
        }
        public string Adress
        {
            get
            {
                return (string)GetValue(AdressProperty);
            }
            set
            {
                SetValue(AdressProperty, value);
            }
        }
        
        public string Experience
        {
            get
            {
                return (string)GetValue(ExperienceProperty);
            }
            set
            {
                SetValue(ExperienceProperty, value);
            }
        }
        public string Education
        {
            get
            {
                return (string)GetValue(EducationProperty);
            }
            set
            {
                SetValue(EducationProperty, value);
            }
        }

        DelegatesCommand showInfo;
        public ICommand ShowInfo
        {
            get
            {
                if (showInfo == null)
                    showInfo = new DelegatesCommand(ShowSummary, CanShowSummary);
                return showInfo;
            }
        }

        private bool CanShowSummary(object obj)
        {
            if (SelectedSummary != null)
            {
                return true;
            }
            return false;
        }

        private void ShowSummary(object obj)
        {
            SummaryView summaryView = new SummaryView();
            SummaryViewModel viewModel = new SummaryViewModel(SelectedSummary);
            summaryView.DataContext = viewModel;
            summaryView.Show();
        }
        DelegatesCommand clearsummary;
        public ICommand Clearsummary
        {
            get
            {
                if (clearsummary == null)
                    clearsummary = new DelegatesCommand(ClearSummary, CanClearSummary);
                return clearsummary;
            }
        } 

        DelegatesCommand closesummary;

        public ICommand Closesummary
        {
            get
            {
                if (closesummary == null)
                    closesummary = new DelegatesCommand(CloseSummary, CanCloseSummary);
                return closesummary;
            }
        }

        DelegatesCommand saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                    saveCommand = new DelegatesCommand(SaveSummary, CanSaveSummary);
                return saveCommand;
            }
        }
        private bool CanClearSummary(object obj)
        {
            return true;
        }
        private bool CanCloseSummary(object obj)
        {
            return true;
        }
        private bool CanSaveSummary(object obj)
        {
            if (Name == null || Name.Length < 2)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        private void CloseSummary(object obj)
        {
            Application.Current.Shutdown();
        }
        private void ClearSummary(object obj)
        {
            Name = string.Empty;
            Age = 0;
            Email = string.Empty;
            Phone = string.Empty;
            Education = string.Empty;
            Experience = string.Empty;
            Skills = string.Empty;
            Adress = string.Empty;
            Language = string.Empty;
        }
        public void LoadSummary()
        {
            XDocument xmlDocument = XDocument.Load("Summary.xml");
            summaryModels = new ObservableCollection<SummaryModel>();
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
        private void SaveSummary(object obj)
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
            summaryModels.Add(new SummaryModel(Name, Age, Email, Adress , Language , Phone, Education, Experience, Skills));
        }
    }
}