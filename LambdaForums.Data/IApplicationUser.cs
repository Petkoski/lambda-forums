using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LambdaForums.Data.Models;

namespace LambdaForums.Data
{
    public interface IApplicationUser
    {
        ApplicationUser GetById(string id);
        IEnumerable<ApplicationUser> GetAll();
        Task SetProfileImage(string id, Uri uri);
        Task IncrementRating(string id, Type type);
    }
}
