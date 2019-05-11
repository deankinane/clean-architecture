using CleanArchitecture.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Activities.Commands.CreateActivity
{
    public class CreateActivityCommand : IRequest<int>
    {
        public string Notes { get; set; }
        public int ContactId { get; set; }
    }
}
