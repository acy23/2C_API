﻿using System.ComponentModel.DataAnnotations;

namespace _2C_API.Data.DTOs
{
    public class EmployeeViewModel : BaseEntityModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string VisaType { get; set; } = string.Empty;
        public string TaskType { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public DateTime AgreementStartDate { get; set; }
        public DateTime AgreementEndDate { get; set; }
        public double YearlySalary { get; set; }
        public string Currency { get; set; } = string.Empty;
        public string? Notes { get; set; } = string.Empty;
    }
}
