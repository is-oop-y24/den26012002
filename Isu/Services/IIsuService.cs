﻿using System.Collections.Generic;
using Isu.Entities;

namespace Isu.Services
{
    public interface IIsuService
    {
        public IReadOnlyList<Group> Groups { get; }
        public IReadOnlyList<Faculty> Faculties { get; }
        Group AddGroup(string name);
        Student AddStudent(Group group, string name);
        Faculty AddFaculty(char letter, string name);

        Student GetStudent(int id);
        Student FindStudent(string name);
        List<Student> FindStudents(string groupName);
        List<Student> FindStudents(CourseNumber courseNumber);

        Group FindGroup(string groupName);
        List<Group> FindGroups(CourseNumber courseNumber);

        void ChangeStudentGroup(Student student, Group newGroup);
    }
}