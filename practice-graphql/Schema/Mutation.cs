using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using practice_graphql.DTOs;
using practice_graphql.Schema.InputType;
using practice_graphql.Services.Students;

namespace practice_graphql.Schema
{
    public class Mutation
    {

        private readonly StudentsRepository _studentsRepository;
        public Mutation(StudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository;
        }
        public async Task<StudentDTO> CreateStudent(StudentInputType student)
        {
            StudentDTO data = new StudentDTO
            {
                Course = student.Course,
                Name = student.Name,
                Year = student.Year
            };
            StudentDTO studentDTO = await _studentsRepository.Create(data);
            return studentDTO;
        }
        public async Task<StudentDTO> UpdateStudent(Guid id, StudentInputType student)
        {
            StudentDTO data = new StudentDTO
            {
                Id = id,
                Course = student.Course,
                Name = student.Name,
                Year = student.Year
            };
            StudentDTO studentDTO = await _studentsRepository.Update(id, data);
            return studentDTO;
        }
        public async Task<bool> DeleteStudent(Guid id)
        {
            return await _studentsRepository.Delete(id);
        }
    }
}