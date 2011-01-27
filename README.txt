For the Tests to run you need to have and configure the TenderSettings.cs file in TenderApiTests.

Here is a sample file:

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TenderApiTests
{
    public class TenderSettings
    {
        public const string Site = "my_site";
        public const string Email = "sample@gmail.com";
        public const string UserName = "user_name";
        public const string Password = "password";
        public const string ApiKey = "your_api_key";
    }
}

Constructors:

public TenderApi(string site, string user, string password)
public TenderApi(string site, string apiKey)


Static Methods:

public static string GenerateSsoToken(string email, string site, string apiKey)


Models: Contain most of the basic Get, Create, Do actions you would expect for

Category
Comment
Discussion
FAQ
Queue
Section
Site
User

Other Public Methods

public List<Category> GetCategories()
public List<Comment> GetComments(int discussionID)
public List<Discussion> GetDiscussions()
public List<Discussion> GetDiscussionByState(string state)
public List<Discussion> GetDiscussionsForUser(int userID)
public List<Discussion> GetDiscussionsForEmail(string email
public bool CreateDiscussion(int categoryID, string title, string authorEmail, string authorName, string body, bool? isPublic=true)
public bool ReplyToDiscussion(int discussionID, string authorEmail, string body, bool? skipSpam = true)
public bool DoDiscussionAction(int discussionID, string action)
public List<FAQ> GetFAQs()
public bool CreateFAQ(int sectionID, string title, string[] keywords, string body, DateTime? published)
public bool UpdateFAQ(int faqID, DateTime? published, string title = "", string[] keywords = null, string body = "")
public List<Queue> GetQueues()
public List<Section> GetSections()
public List<User> GetUsers()
public User FindUser(string email)
public bool AuthenticationIsValid()
public User CreateUser(string email, string password, string passwordConfirmation, string name=null, string title=null)