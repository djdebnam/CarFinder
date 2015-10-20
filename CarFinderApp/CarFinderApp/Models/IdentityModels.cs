using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CarFinderApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Car> Cars{get;set;}
        
        public async Task<List<string>> GetYears()
        {
            return await Database.SqlQuery<string>("GetYears").ToListAsync();
        }
        public async Task<List<string>> GetMakes(int year)
        {
            var yearParam = new SqlParameter("@year", year);

            return await Database.SqlQuery<string>("GetMakes @year", yearParam).ToListAsync();
        }
        public async Task<List<string>> GetModels(int year, string make)
        {
            var yearParm = new SqlParameter("@year", year);
            var makeParam = new SqlParameter("@make", make);

            return await Database.SqlQuery<string>("GetModels @year, @make", yearParm, makeParam).ToListAsync();
        }
        public async Task<List<string>> GetTrims(int year, string make, string model)
        {
            var yearParam = new SqlParameter("@year", year);
            var makeParam = new SqlParameter("@make", make);
            var modelParam = new SqlParameter("@model_name", model);

            return await Database.SqlQuery<string>("GetTrims @year, @make, @model_name", yearParam, makeParam, modelParam).ToListAsync();
        }
        public async Task<List<Car>> GetCars(int year, string make = null, string model = null, string trim = null,string filter = null,
            bool? paging = false, int? page = null, int? perPage = null)
        {
            var yearParam = new SqlParameter("@year", year);
            var makeParam = new SqlParameter("@make", make);
            var modelParam = new SqlParameter("@model", model);
            var trimParam = new SqlParameter("@trim", trim);
            var filterParam = new SqlParameter("@filter", filter);
            
            var query = "GetCars @year, @make, @model, @trim, @filter";

            if (page != null && paging.Value == true)
            {
                var pagingParam = new SqlParameter("@paging", paging);
                var pageParam = new SqlParameter("@page", page);
                var perPageParam = new SqlParameter("perPage", perPage);
                query += ",@paging,@page,@perPage";
                var result = await this.Database.SqlQuery<Car>(query, yearParam, makeParam,modelParam,trimParam,filterParam,pagingParam,pageParam,perPageParam).ToListAsync();
                return result;
            }
            else
            {
                var result = await this.Database.SqlQuery<Car>(query, yearParam, makeParam, modelParam, trimParam, filterParam).ToListAsync();
                return result;
            }

                     


        }
    }
}