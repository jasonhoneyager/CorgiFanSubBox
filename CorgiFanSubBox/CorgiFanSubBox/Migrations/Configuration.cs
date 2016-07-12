using CorgiFanSubBox.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CorgiFanSubBox.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;


    internal sealed class Configuration : DbMigrationsConfiguration<CorgiFanSubBox.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CorgiFanSubBox.Models.ApplicationDbContext context)
        {
            if (!context.Users.Any(u => u.UserName == "admin@admin.com"))
            {
                RoleStore<IdentityRole> roleStore = new RoleStore<IdentityRole>(context);
                RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(roleStore);
                UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(context);
                UserManager<ApplicationUser> userManager = new ApplicationUserManager(userStore);
                ApplicationUser admin = new ApplicationUser { UserName = "admin@admin.com", FirstName = "Admin", LastName = "Admin" };

                userManager.Create(admin, password: "adminpass");
                roleManager.Create(new IdentityRole { Name = "admin" });
                userManager.AddToRole(admin.Id, "admin");
            }

            var address = new AddressModel() { ID = 1, Street1 = "1605 Chestnut Ln", Street2 = "", City = "Waukesha", State = "WI", Zip = 53189 };
            context.CustomerModels.AddOrUpdate(c => c.ID,
                new CustomerModel() { ID = 1, FirstName = "Jason", LastName = "Honeyager", Address = address }
                );

            SurveyQuestionsModel q1 = new SurveyQuestionsModel() { ID = 1, Question = "What kinds of treats does your Corgi enjoy most?" };
            SurveyQuestionsModel q2 = new SurveyQuestionsModel() { ID = 2, Question = "How often do you get out on walks with your Corgi?" };
            SurveyQuestionsModel q3 = new SurveyQuestionsModel() { ID = 3, Question = "How often do you groom your Corgi?" };
            SurveyQuestionsModel q4 = new SurveyQuestionsModel() { ID = 4, Question = "Where does your Corgi sleep most frequently?" };
            SurveyQuestionsModel q5 = new SurveyQuestionsModel() { ID = 5, Question = "What is your Corgi's favorite type of toy?" };

            //context.SurveyQuestionModels.AddOrUpdate(q => q.ID,
            //    q1, q2, q3, q4, q5
            //    );

            var item1 = new ItemModel() { ID = 1, ItemName = "Meaty Snacks"};
            var item2 = new ItemModel() { ID = 1, ItemName = "Crunchy Snacks"};
            var item3 = new ItemModel() { ID = 1, ItemName = "Peanut Butter Snacks"};
            var item4 = new ItemModel() { ID = 1, ItemName = "Leash"};
            var item5 = new ItemModel() { ID = 1, ItemName = "Harness"};
            var item6 = new ItemModel() { ID = 1, ItemName = "Harness with reflector"};
            var item7 = new ItemModel() { ID = 1, ItemName = "Soft Bristled Brush"};
            var item8 = new ItemModel() { ID = 1, ItemName = "Undercoat Brush"};
            var item9 = new ItemModel() { ID = 1, ItemName = "Furminator Brush"};
            var item10 = new ItemModel() { ID = 1, ItemName = "Doggy Pillow"};
            var item11 = new ItemModel() { ID = 1, ItemName = "Plush Dog Bed"};
            var item12 = new ItemModel() { ID = 1, ItemName = "Dog Blanket"};
            var item13 = new ItemModel() { ID = 1, ItemName = "Squeeky Pheasant"};
            var item14 = new ItemModel() { ID = 1, ItemName = "Plushy Hedgehog"};
            var item15 = new ItemModel() { ID = 1, ItemName = "Rolling Foxtail Ball"};


            SurveyAnswersModel a1 = new SurveyAnswersModel() { ID = 1, Result = "Chewy, Meat Flavored Treats", Item = item1 };
            SurveyAnswersModel a2 = new SurveyAnswersModel() { ID = 2, Result = "Crunchy Milk Bones", Item = item2 };
            SurveyAnswersModel a3 = new SurveyAnswersModel() { ID = 3, Result = "Peanut Butter Treats", Item = item3 };
            SurveyAnswersModel a4 = new SurveyAnswersModel() { ID = 4, Result = "A few times a week", Item = item4 };
            SurveyAnswersModel a5 = new SurveyAnswersModel() { ID = 5, Result = "Once a day", Item = item5 };
            SurveyAnswersModel a6 = new SurveyAnswersModel() { ID = 6, Result = "Multiple times a day", Item = item6 };
            SurveyAnswersModel a7 = new SurveyAnswersModel() { ID = 7, Result = "Once a week", Item = item7 };
            SurveyAnswersModel a8 = new SurveyAnswersModel() { ID = 8, Result = "A few times a week", Item = item8 };
            SurveyAnswersModel a9 = new SurveyAnswersModel() { ID = 9, Result = "At LEAST daily", Item = item9 };
            SurveyAnswersModel a10 = new SurveyAnswersModel() { ID = 10, Result = "In their crate/kennel", Item = item10 };
            SurveyAnswersModel a11 = new SurveyAnswersModel() { ID = 11, Result = "On the floor", Item = item11 };
            SurveyAnswersModel a12 = new SurveyAnswersModel() { ID = 12, Result = "On the bed/couch", Item = item12 };
            SurveyAnswersModel a13 = new SurveyAnswersModel() { ID = 13, Result = "Squeeky Toys", Item = item13 };
            SurveyAnswersModel a14 = new SurveyAnswersModel() { ID = 14, Result = "Plush Toys", Item = item14 };
            SurveyAnswersModel a15 = new SurveyAnswersModel() { ID = 15, Result = "Interactive Toys", Item = item15 };

            //context.SurveyAnswerModels.AddOrUpdate(a => a.ID,
            //   a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15

            //    );

            context.CombinedQAModels.AddOrUpdate(x => x.ID,
                new CombinedQAModel() { SurveyAnswers = a1, SurveyQuestions = q1 },
                new CombinedQAModel() { SurveyAnswers = a2, SurveyQuestions = q1 },
                new CombinedQAModel() { SurveyAnswers = a3, SurveyQuestions = q1 },
                new CombinedQAModel() { SurveyAnswers = a4, SurveyQuestions = q2 },
                new CombinedQAModel() { SurveyAnswers = a5, SurveyQuestions = q2 },
                new CombinedQAModel() { SurveyAnswers = a6, SurveyQuestions = q2 },
                new CombinedQAModel() { SurveyAnswers = a7, SurveyQuestions = q3 },
                new CombinedQAModel() { SurveyAnswers = a8, SurveyQuestions = q3 },
                new CombinedQAModel() { SurveyAnswers = a9, SurveyQuestions = q3 },
                new CombinedQAModel() { SurveyAnswers = a10, SurveyQuestions = q4 },
                new CombinedQAModel() { SurveyAnswers = a11, SurveyQuestions = q4 },
                new CombinedQAModel() { SurveyAnswers = a12, SurveyQuestions = q4 },
                new CombinedQAModel() { SurveyAnswers = a13, SurveyQuestions = q5 },
                new CombinedQAModel() { SurveyAnswers = a14, SurveyQuestions = q5 },
                new CombinedQAModel() { SurveyAnswers = a15, SurveyQuestions = q5 }

                );



            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
