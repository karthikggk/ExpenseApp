using AutoMapper;
using Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Entities;

namespace ExpensApp.Utilities
{
    public class View_BusinessMapperProfileConfig : Profile
    {

        public View_BusinessMapperProfileConfig() : this("View_Business")
        {

        }
        public View_BusinessMapperProfileConfig(string profileName): base(profileName)
        {
            CreateMap<ExpensesViewModel, Expense>().ReverseMap();
        }
    }
}
