using Microsoft.Toolkit.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SFUListParser.Model
{
    public class StudentSource : IIncrementalSource<Student>
    {
        private List<Student> students = new List<Student>();

        public StudentSource()
        {
            for (int i = 1; i <= 200; i++)
            {
                var p = new Student("Person " + i);
                students.Add(p);
            }
        }

        public async Task<IEnumerable<Student>> GetPagedItemsAsync(int pageIndex, int pageSize, CancellationToken cancellationToken = default)
        {
            var result = (from student in students
                          select student).Skip(pageIndex * pageSize).Take(pageSize);

            await Task.Delay(1000);

            return result;
        }
    }
}
