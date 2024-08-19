using Microsoft.EntityFrameworkCore;
using BlogApp.Entity;

namespace BlogApp.Data.Concrete.EfCore
{
    public static class SeedData
    {
        public static void TestVerileriniDoldur(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();
            if (context != null)
            {
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

                if (!context.Tags.Any())
                {
                    context.Tags.AddRange(
                        new Tag { Text = "web programlama",Url="web-programlama ",Color=TagColors.primary},
                        new Tag { Text = "backend programlama",Url="backend programlama" ,Color=TagColors.danger},
                        new Tag { Text = "php programlama",Url="php programlama",Color=TagColors.warning},
                        new Tag { Text = "frontend programlama" ,Url="frontend programlama",Color=TagColors.success},
                        new Tag { Text = "full-stack programlama",Url="full-stack programlama" ,Color=TagColors.secondary}
                    );
                    context.SaveChanges();
                }

                if (!context.Users.Any())
                {
                    var user1 = new User { UserName = "beyzadgn", Name="Beyza Doğan" , Email="info@beyzadgn.com",Password="beyza123",Image ="p1.jpg" };
                    var user2 = new User { UserName = "kullanici1", Name="Kullanıcı Kullanıcı" , Email="info@kullanici.com",Password="kullanıcı123",Image ="p2.jpg" };

                    context.Users.AddRange(user1, user2);
                    context.SaveChanges();

                   
                    if (!context.Posts.Any())
                    {
                        context.Posts.AddRange(
                            new Post
                            {
                                Title = "Asp.net",
                                Description = "Asp.net Core Dersleri",
                                Content = "Asp.net Core Dersleri",
                                Url ="asp-net-core",
                                IsActive = true,
                                PublishedOn = DateTime.Now.AddDays(-10),
                                Tags = context.Tags.Take(3).ToList(),
                                Image ="1.jpg",
                                UserId = user1.UserId,
                                Comments= new List<Comment>
                                {
                                 new Comment {Text ="iyi bir kurs",PublishedOn =  DateTime.Now.AddDays(-20),UserId=user1.UserId},
                                 new Comment {Text ="çok faydalı bir kurs",PublishedOn = DateTime.Now.AddDays(-10),UserId=user2.UserId}
                                }
                            },
                            new Post
                            {
                                Title = "Php",
                                Description = "Php Dersleri",
                                Content = "Php Dersleri",
                                Url ="php-dersleri",
                                IsActive = true,
                                PublishedOn = DateTime.Now.AddDays(-20),
                                Tags = context.Tags.Take(2).ToList(),
                                Image ="2.jpg",
                                UserId = user2.UserId
                            },
                            new Post {
                            Title = "Django",
                            Description = "Django Dersleri",
                            Content = "Django dersleri",
                            Url ="django",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-30),
                            Tags = context.Tags.Take(4).ToList(),
                            Image ="3.jpg",
                            UserId = user2.UserId
                        },
                        new Post {
                            Title = "Django",
                            Content = "Django dersleri",
                            Url ="django",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-15),
                            Tags = context.Tags.Take(4).ToList(),
                            Image ="3.jpg",
                            UserId = user2.UserId
                        },
                        new Post {
                            Title = "React",
                            Content = "React dersleri",
                            Url ="react",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-20),
                            Tags = context.Tags.Take(4).ToList(),
                            Image ="1.jpg",
                            UserId = user2.UserId
                        },
                        new Post {
                            Title = "Java",
                            Content = "Java dersleri",
                            Url ="java",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-50),
                            Tags = context.Tags.Take(4).ToList(),
                            Image ="2.jpg",
                            UserId = user2.UserId
                        },
                        new Post {
                            Title = "C++",
                            Content = "C++ dersleri",
                            Url ="c++",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-40),
                            Tags = context.Tags.Take(4).ToList(),
                            Image ="3.jpg",
                            UserId = user2.UserId
                        }
                            
                        );
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
