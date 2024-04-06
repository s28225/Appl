using System;

namespace LegacyApp.Interface;

public interface ICreditService
{
    int GetCreditLimit(string lastName, DateTime dateOfBirth);
}