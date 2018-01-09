using AutoMapper;
using Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpensApp.Utilities
{
    public class Business_RepoMapperProfileConfig : Profile
    {
        public Business_RepoMapperProfileConfig()
            :this("Business_Repositories")
        {

        }

        protected Business_RepoMapperProfileConfig(string profileName) : base(profileName)
        {
            CreateMap<Expense, Business.Entities.Expense>().ReverseMap();
        }
    }
}
