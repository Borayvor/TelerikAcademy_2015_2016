namespace UserVoiceSystem.Data.Seeders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    internal static class StaticDataSeeder
    {
        private const string Alphabet = "abcdefghijklmnopqrstuvwxyz";

        private static readonly Random Random = new Random();

        private static List<int> ideasId = new List<int>();

        internal static void SeedUsers(ApplicationDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            const string UserNameEmail = "user1@site.com";
            const string UserPassword = "user111";
            const string UserIp = "127.0.100.42";

            // Create user
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var user = new ApplicationUser
            {
                Ip = UserIp,
                UserName = UserNameEmail,
                Email = UserNameEmail,
                VotePoints = 10
            };

            userManager.Create(user, UserPassword);

            context.SaveChanges();
        }

        internal static void SeedData(ApplicationDbContext context)
        {
            SeedIdeas(context);

            foreach (var item in context.Ideas)
            {
                ideasId.Add(item.Id);
            }

            SeedComments(context);
            SeedVotes(context);
        }

        private static void SeedIdeas(ApplicationDbContext context)
        {
            if (context.Ideas.Any())
            {
                return;
            }

            var idea1 = new Idea
            {
                Title = "XNA 5",
                Description = @"Please continue to work on XNA. It's a great way for indie game developers like myself to make games and give them to the world. XNA gave us the ability to put our games, easily, on the most popular platforms, and to just dump XNA would be therefor heartbreaking... I implore you to keep working on XNA so we C# developers can still make amazing games!",
                AuthorId = context.Users.FirstOrDefault().Id
            };

            context.Ideas.Add(idea1);

            var idea2 = new Idea
            {
                Title = "Allow .NET games on Xbox One",
                Description = @"Lots of indie developers and small game company are using .NET to develop games. Today, we are able to easily target several Windows platforms (Windows Desktop, Windows RT and Windows Phone 8) as well as other platforms thanks to Mono from Xamarin.

As we don't know yet the details about this indie developer program for Xbox One, we would love to use .NET on this platform - with everything accessible, from latest 4.5 with async, to unsafe code and native code access through DLLImport (and not only through WinRT components)

Please make.NET a compelling game development alternative on Xbox One!",
                AuthorId = context.Users.FirstOrDefault().Id
            };

            context.Ideas.Add(idea2);

            var idea3 = new Idea
            {
                Title = "Support web.config style Transforms on any file in any project type",
                Description = @"Web.config Transforms offer a great way to handle environment-specific settings. XML and other files frequently warrant similar changes when building for development (Debug), SIT, UAT, and production (Release). It is easy to create additional build configurations to support multiple environments via transforms. Unfortunately, not everything can be handled in web.config files many settings need to be changed in xml or other ""config"" files.",
                AuthorId = context.Users.FirstOrDefault().Id
            };

            context.Ideas.Add(idea3);

            var idea4 = new Idea
            {
                Title = "Open source Silverlight",
                Description = @"Blog post at http://davidburela.wordpress.com/2013/11/22/is-it-time-to-open-source-silverlight/

For all intents and purposes Microsoft now views Silverlight as “Done”. While it is no longer in active development it is still being “supported” through to 2021 (source).

However there is still a section of the .Net community that would like to see further development done on the Silverlight framework. A quick look at some common request lists brings up the following stats:

* 5,720+ votes to release Silverlight 6 https://visualstudio.uservoice.com/forums/121579-visual-studio/suggestions/3556619-silverlight-6 
* Feature requests for Silverlight http://dotnet.uservoice.com/forums/4325-silverlight-feature-suggestions 
* Microsoft connect list of active Silverlight feature requests: http://connect.microsoft.com/VisualStudio/SearchResults.aspx?KeywordSearchIn=2&SearchQuery=%22silverlight%22&FeedbackType=2&Status=1&Scope=0&SortOrder=10&TabView=1 
Rather than letting Silverlight decay in a locked up source control in the Microsoft vaults, I call on them to instead release it into the hands of the community to see what they can build with it. Microsoft may no longer have a long term vision for it, but the community itself may find ways to extend it in ways Microsoft didn’t envision. 
Earlier this year Microsoft open sourced RIA Services on Outer Curve http://www.outercurve.org/Galleries/ASPNETOpenSourceGallery/OpenRIAServices, it would be great to see this extended to the entire Silverlight framework.",
                AuthorId = context.Users.FirstOrDefault().Id
            };

            context.Ideas.Add(idea4);

            var idea5 = new Idea
            {
                Title = "Make WPF open-source and accept pull-requests from the community",
                Description = @"Please follow the footsteps of the ASP .NET team and make WPF open-source with the source code on GitHub, and accept pull-requests from the community.",
                AuthorId = context.Users.FirstOrDefault().Id
            };

            context.Ideas.Add(idea5);

            var idea6 = new Idea
            {
                Title = "Native DirectX 11 support for WPF",
                Description = @"in 2013 WPF still work on DX9, and this have a lot of inconvenience. First of all it is almost impossible to make interaction with native DX11 C++ and WPF. Axisting D3DImage class support only DX 9, but not higher and for now it is a lot of pain to attach DX 11 engine to WPF.

Please, make nativa support for DX 11 in WOF by default and update D3DImage class to have possibility to work with nativa C++ DX 11 engine and make render directly to WPF control (controls) without pain with C++ dll.",
                AuthorId = context.Users.FirstOrDefault().Id
            };

            context.Ideas.Add(idea6);

            var idea7 = new Idea
            {
                Title = "Fix 260 character file name length limitation",
                Description = @"Same description as here:

http://visualstudio.uservoice.com/forums/121579-visual-studio/suggestions/2156195-fix-260-character-file-name-length-limitation",
                AuthorId = context.Users.FirstOrDefault().Id
            };

            context.Ideas.Add(idea7);

            var idea8 = new Idea
            {
                Title = "Support for ES6 modules",
                Description = @"Add support for the new JavaScript ES6 module syntax, including module definition and imports.",
                AuthorId = context.Users.FirstOrDefault().Id
            };

            context.Ideas.Add(idea8);

            var idea9 = new Idea
            {
                Title = "Create a \"remove all remnants of Visual Studio from your system\" program.",
                Description = @"I'm writing this on behalf of the thousands of other Visual Studio users out there who have had nightmares trying to uninstall previous versions of VS. Thus cumulatively losing hundreds of thousands of productive work hours.

During this year, I had installed the following programs/components on my system: 
* Visual Studio 2012 Express for Desktop 
* Visual Studio 2012 Express for Web 
* Team Foundation Server Express 
* SQL Server Express 
* SQL Server Data Tools 
* LightSwitch 2011 trial (which created a VS 2010 installation) 
* Visual Studio 2010 Tools for SQL Server Compact 3.5 SP2 
* Entity Framework Designer for Visual Studio 2012 
* Visual Studio Tools for Applications 
* Visual Studio Tools for Office 
* F# Tools for Visual Studio Express 2012 for Web

Two weeks ago I discovered that third-party controls can't be added to the Express versions of VS. I'm disabled and live on a fixed income, so spending $500 for the Professional version, in order to continue my hobby programming with a third-party control, was a tough decision. But I bought it.

When it arrived, I figured it would take an hour or two to remove the above programs and then I could install the Pro version. I wanted to have a clean file system and Registry for the new install of VS Pro.

It's now SIX DAYS later, and my spending 12-14 hours a day working on this alone. Removing these programs was the biggest nightmare I have ever faced with Microsoft products in my 30 years of being a Microsoft customer. Each one of these products automatically installed 5, 10 or more additional components, along with many thousands of files and individual Registry entries.

It took me four days alone, just to successfully remove the LightSwitch 2011 trial, and the entire VS 2010 product it installed. Restoring a 600 GB disk drive (5 hours) from backup after every removal attempt failed miserably. I finally gave up, spent 6 hours downloading the entire VS 2010 ISO and installed it. Only then, was I able to successfully uninstall LightSwitch 2011 and VS 2010.

As for the remaining products listed above, the uninstall programs do NOT UNinstall everything that they automatically INstall. Every single, automatically INstalled component, had to be removed manually, one at a time. Along with manually creating a System Restore point before each removal attempt, in case it failed. In total, I spent 12 hours uninstalling the remaining products.

I have a Registry search program where I can enter a search string and it will list ALL occurrences it finds in the Registry. I checked ""visual studio"", ""visualstudio"", ""vbexpress"", ""vcexpress"", ""SQL Server"", etc. I never finished searching for all the possible Visual Studio and SQL Server strings because the results being returned were eye-popping. Each search was returning 1,000, 3,000, even 7,000 individual Registry entries that had NOT been removed by the individual uninstall processes. This is TENS of THOUSANDS of never to be used again Registry entries that these programs simply left behind. The size of my Registry file is now a stunning 691 MB!

All of this frustration and wasted time is completely avoidable!And my case is not ""isolated"".There are hundreds of thousands of hits on Google regarding this problem,
                that point to Microsoft forums,
                MS Blog sites,
                and many independent Windows developer support forums on the web.

Microsoft really should provide an uninstall program that actually works,
                by UNinstalling everything it INstalls-- for each product it sells-- including Visual Studio.The downloadable(from Microsoft) uninstall program for VS 2010 does not work correctly and does not remove everything that VS 2010 installs.

When a program installs multiple individual components, tens of thousands of files and Registry entries, it SHOULD have an uninstaller that removes ALL of this, automatically, just like the install program.The OS and Registry keep track of dependencies and you folks know what the removal order should be for all of these products.So the team that creates the INstall program for each product, should also create the UNinstall program.And, the product should NOT ship until this program works correctly and fully.

You have ONE install program for each version of Visual Studio, that asks the user what they want to install and then does it ALL automatically.You should also have ONE uninstall program that does the same thing in reverse...
* Collect info on all the VS - related products and components currently installed
* Ask the user what they want to remove
* Determine if their selections make sense
* Check for dependencies by using your knowledge and experience, along with the computer's stored information, and warn the user as needed 
* Decide on the removal order
*Then do it ALL automatically-- removing ALL files and ALL Registry entries

When you release a new product version, ADD the new version and additional decision logic to this existing program, do NOT create a new uninstall program.This way, the user can also remove previous version products, components, etc.ONE uninstall program* should be* able to uninstall every version of Visual Studio released in the past 10 years, along with every single component that was available with it, AND all of the associated files and Registry entries.

Please don't tell us why it CAN'T be done.Rather, figure out a way to do it, and then make it happen, just like every other software company out there has already done for their products. Even FREEware providers have better uninstall processes than Microsoft.This is a sad state for Microsoft and it should be rectified SOON.

Thank you.",
                AuthorId = context.Users.FirstOrDefault().Id
            };

            context.Ideas.Add(idea9);

            var idea10 = new Idea
            {
                Title = "Support .NET Builds without requiring Visual Studio on the server",
                Description = @"To build certain PCL libraries and libraries for Windows 8 RT requires having Visual Studio on the server.

Nick Berardi writes about a workaround that allows running a build server without VS, but it's really just a workaround for functionality that should be easy.

Not to mention there's probably licensing considerations we're just ignoring by doing that.

http://nickberardi.com/a-net-build-server-without-visual-studio/

Please make it easy (and legal) to build .NET projects on a server without requiring a Visual Studio installation (or license) on that server.",
                AuthorId = context.Users.FirstOrDefault().Id
            };

            context.Ideas.Add(idea10);

            var idea11 = new Idea
            {
                Title = "VS IDE should support file patterns in project files",
                Description = @"Patterns should be preserved and unmodified when working with *proj files. If I specify a pattern with something like **/*.cs for my code files. If I add a new .cs file that fits that pattern the .csproj file should not be modified.

MSBuild already respects this, but the IDE will always modify the project file.

For numerous scenarios this could simplify the diff / merge process.",
                AuthorId = context.Users.FirstOrDefault().Id
            };

            context.Ideas.Add(idea11);

            var idea12 = new Idea
            {
                Title = "Resolve Airspace iusse to full integrate OpenGL inside WPF",
                Description = @"There are many programmers and company that develop applications based on geometrical kernels that use OpenGL for drawing (like CAD/CAM applications) often they have an old MFC application, and to pass to a modern view for their applications and give a new user experience for the user they could make new WPF interfaces very quickly but they can't rewrite an entire kernel to pass from OpenGL to DirectX, so often they prefer to remain with MFC without pass to WPF. This could be a very special thing to have the possibility to use OpenGL fully supported by WPF, without airspace iusse. 
Now it's possible the integration using HwndHost or WindowsFormsHost but it's not possible to have other WPF control over this, and it's impossible to apply effects and transitions.",
                AuthorId = context.Users.FirstOrDefault().Id
            };

            context.Ideas.Add(idea12);

            var idea13 = new Idea
            {
                Title = "Improve WPF performance",
                Description = @"I have a high end PC and still WPF is not always fluent. Just compare it with QT 4.6 QML (Declarative UI) it is sooo FAST!",
                AuthorId = context.Users.FirstOrDefault().Id
            };

            context.Ideas.Add(idea13);

            var idea14 = new Idea
            {
                Title = "Create a Ubiquitous .NET Client Application Development Model",
                Description = @"This vote is for developers who wish to see the idea of a ubiquitous .NET client application development model created by Microsoft and the Visual Studio team.

A ubiquitous .NET client application development model is a model that is defined in .NET-based technologies and is able to run in a multitude of runtime environments -- both native-compiled (store-hosted) and web-hosted.

A *very* rough image of the vision can be found here: 
http://i0.wp.com/blog.developers.win/wp-content/uploads/2015/09/Vision.png

The goal is to enable *one* .NET Client Application Project to build deliverables for the following platforms: 
1) Windows 10 
2) Legacy Windows 
3) *nix (Unix/Linux) 
4) Droid 
5) iOS 
6) Macintosh 
7) HTML5 
8) ??? (Extendible to different, future platforms)

In order to achieve the above, a ubiquitous .NET client application development model should strive to possess the following qualities: 
1) Native Cross-Platform Capable - For native-compiled/store-hosted scenarios (iOS/Droid/Windows Store) 
2) HTML5-Compliant - For web-hosted scenarios, via .NET-to-JavaScript transpilation 
3) Consistent User Experience - For brand recognition, reinforcement, and optimal usability across all known scenarios 
4) Cross-Boundary Accessibility - For shared code/assemblies between server and client boundaries 
5) Xaml-Powered - Harnessing one of the greatest inventions in Microsoft's great history 
6) Object Serialization Congruence - Markup used to describe serialized objects is what is created in memory 
7) Holistic Development Consistency - The same guidelines and conventions are used in both client and server scenarios

For more information around this idea and the qualities above, a series of articles has been created to discuss the notion of a ubiquitous .NET client application development model at length. You can view that series here: 
http://blog.developers.win/series/bridge-to-dotnet-ubiquity/

Finally, this is intended to be a starting point for discussion, and not a final solution. THAT is meant for the experts there at Microsoft. :) Thank you for any support, dialogue, and feedback around this idea!",
                AuthorId = context.Users.FirstOrDefault().Id
            };

            context.Ideas.Add(idea14);

            var idea15 = new Idea
            {
                Title = "C++ CLI support for optional parameters for using in C#",
                Description = @"in C++ CLI is possible to define an optional parameter like

public void ProvaDefaults([Optional, DefaultParameterValue(true)] bool value)

but in this way the compiler don't use the DefaultParameterValue for setting the correct default value in the metadata (II.15.4.1.4 The .para m directive) that is visible in C#

so in C# the deault parameter is visible but only with the system default value (in the sample reported it is false instead of the wanted true)",
                AuthorId = context.Users.FirstOrDefault().Id
            };

            context.Ideas.Add(idea15);

            context.SaveChanges();
        }

        private static void SeedComments(ApplicationDbContext context)
        {
            if (context.Comments.Any())
            {
                return;
            }

            foreach (var ideaId in ideasId)
            {
                var comments = AddComments(context.Users.FirstOrDefault().Id, ideaId);

                foreach (var comment in comments)
                {
                    context.Comments.Add(comment);
                }

                context.SaveChanges();
            }
        }

        private static void SeedVotes(ApplicationDbContext context)
        {
            if (context.Votes.Any())
            {
                return;
            }

            foreach (var ideaId in ideasId)
            {
                var votes = AddVotes(ideaId);

                foreach (var vote in votes)
                {
                    context.Votes.Add(vote);
                }

                context.SaveChanges();
            }
        }

        private static ICollection<Comment> AddComments(string userId, int ideaId)
        {
            var comments = new List<Comment>();

            for (int i = 0; i < 10; i++)
            {
                comments.Add(new Comment
                {
                    IdeaId = ideaId,
                    Content = GetText(),
                    AuthorId = userId
                });
            }

            return comments;
        }

        private static ICollection<Vote> AddVotes(int ideaId)
        {
            var votes = new List<Vote>();

            for (int i = 0; i < 100; i++)
            {
                votes.Add(new Vote
                {
                    IdeaId = ideaId,
                    Points = Random.Next(1, 4),
                    Ip = Random.Next(0, 256) + "." + Random.Next(0, 256) + "." + Random.Next(0, 256) + "." + Random.Next(0, 256),
                });
            }

            return votes;
        }

        private static string GetText()
        {
            StringBuilder sb = new StringBuilder();

            var textLength = Random.Next(1, 20);

            sb.Append(GetSentence());

            for (int i = 1; i < textLength; i++)
            {
                sb.Append(" ");
                sb.Append(GetSentence());
            }

            return sb.ToString().Trim();
        }

        private static string GetSentence()
        {
            StringBuilder sb = new StringBuilder();

            var firstWord = GetWord(true);
            var sentenceLength = Random.Next(3, 15);

            sb.Append(firstWord);

            for (int i = 1; i < sentenceLength; i++)
            {
                sb.Append(" ");
                sb.Append(GetWord());
            }

            sb.Append(".");

            return sb.ToString().Trim();
        }

        private static string GetWord(bool isFirst = false)
        {
            StringBuilder sb = new StringBuilder();

            var wordLength = Random.Next(2, 12);

            for (int i = 0; i < wordLength; i++)
            {
                if (isFirst)
                {
                    sb.Append(GetLetter().ToString().ToUpper());
                    isFirst = false;
                }
                else
                {
                    sb.Append(GetLetter());
                }
            }

            return sb.ToString();
        }

        private static char GetLetter()
        {
            var position = Random.Next(0, Alphabet.Length);

            return Alphabet[position];
        }
    }
}
