﻿using System;
using ConsoleProject.Core.Interfaces;

public class Employee:IEntity
{
    private static int _id;
    public int Id { get;  }
    public string Name { get; set; }
    public string Surname { get; set; }
    public decimal Salary { get; set; }
    public int DepartmentId { get; set; }

    public Employee()
    {
        Id = _id;
        _id++;
    }

    public Employee(string name,string surname,decimal salary):this()
    {
        Name = name;
        Surname = surname;
        Salary = salary;
    }

    public override string ToString()
    {
        return $"Id: {Id} Name: {Name}  Surname: {Surname}";
    }
}

