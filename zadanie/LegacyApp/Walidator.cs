using System;
using System.Data;

namespace LegacyApp;

public static class Walidator
{
    public static bool CheckIsNullOrEmpty(string data)
    {
        return string.IsNullOrEmpty(data);
    }
    public static bool CheckEmail(string data)
    {
        return data.Contains("@") && data.Contains(".");
    }

    public static bool CheckAge(DateTime dateOfBirth)
    {
        var now = DateTime.Now;
        int age = now.Year - dateOfBirth.Year;
        if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;
        return age < 21;
    }

    public static bool CheckCreditLimit(bool hasCreditLimit, int creditLimit)
    {
        return hasCreditLimit && creditLimit < 500;
    }
}