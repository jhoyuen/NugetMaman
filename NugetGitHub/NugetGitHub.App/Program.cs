// See https://aka.ms/new-console-template for more information

using NugetGitHub.Common.Extensions;

string validEmail = "nugettester@test.com";
Console.WriteLine(validEmail);
Console.WriteLine($"Email is valid? - {validEmail.IsValidEmail()}");
Console.WriteLine("---");
string invalidEmail = "nugettester@";
Console.WriteLine(invalidEmail);
Console.WriteLine($"Email is valid? - {invalidEmail.IsValidEmail()}");

Console.ReadKey();