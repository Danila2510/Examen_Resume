using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Resume.Models;

namespace Resume.ViewModels
{
    public class SummaryViewModel:ViewModel_Base
    {
        private static readonly DependencyProperty NameProperty;
        private static readonly DependencyProperty AgeProperty;
        private static readonly DependencyProperty EmailProperty;
        private static readonly DependencyProperty PhoneProperty;
        private static readonly DependencyProperty AdressProperty;
        private static readonly DependencyProperty EducationProperty;
        private static readonly DependencyProperty ExperienceProperty;
        private static readonly DependencyProperty SkillsProperty;
        private static readonly DependencyProperty LanguageProperty;

        static SummaryViewModel()
        {
            NameProperty = DependencyProperty.Register("NameSummary", typeof(string), typeof(MainViewModel));
            AgeProperty = DependencyProperty.Register("AgeSummary", typeof(string), typeof(MainViewModel));
            EmailProperty = DependencyProperty.Register("EmailSummary", typeof(string), typeof(MainViewModel));
            PhoneProperty = DependencyProperty.Register("PhoneSummary", typeof(string), typeof(MainViewModel));
            AdressProperty = DependencyProperty.Register("AdressSummary", typeof(string), typeof(MainViewModel));
            EducationProperty = DependencyProperty.Register("EducationSummary", typeof(string), typeof(MainViewModel));
            ExperienceProperty = DependencyProperty.Register("ExperienceSummary", typeof(string), typeof(MainViewModel));
            SkillsProperty = DependencyProperty.Register("SkillsSummary", typeof(string), typeof(MainViewModel));
            LanguageProperty = DependencyProperty.Register("LanguageSummary", typeof(string), typeof(MainViewModel));
        }

        public SummaryViewModel(SummaryModel model)
        {
            NameSummary = model.Name;
            AgeSummary = model.Age.ToString();
            EmailSummary = model.Email;
            PhoneSummary = model.Phone;
            AdressSummary = model.Adress;
            EducationSummary = model.Education;
            ExperienceSummary = model.Experience;
            SkillsSummary = model.Skills;
            LanguageSummary = model.Language;
        }
        public string NameSummary
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
        public string AgeSummary
        {
            get { return (string)GetValue(AgeProperty); }
            set { SetValue(AgeProperty, value); }
        }
        public string EmailSummary
        {
            get { return (string)GetValue(EmailProperty); }
            set { SetValue(EmailProperty, value); }
        }
        public string PhoneSummary
        {
            get { return (string)GetValue(PhoneProperty); }
            set { SetValue(PhoneProperty, value); }
        }
        public string AdressSummary
        {
            get { return (string)GetValue(AdressProperty); }
            set { SetValue(AdressProperty, value); }
        }
        public string EducationSummary
        {
            get { return (string)GetValue(EducationProperty); }
            set { SetValue(EducationProperty, value); }
        }
        public string ExperienceSummary
        {
            get { return (string)GetValue(ExperienceProperty); }
            set { SetValue(ExperienceProperty, value); }
        }
        public string SkillsSummary
        {
            get { return (string)GetValue(SkillsProperty); }
            set { SetValue(SkillsProperty, value); }
        }
        public string LanguageSummary
        {
            get { return (string)GetValue(LanguageProperty); }
            set { SetValue(LanguageProperty, value); }
        }
    }
}
