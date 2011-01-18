using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TenderApi;
using TenderApi.Model;

namespace TenderApiTests
{
    [TestFixture]
    public class TenderApiTests
    {
        private const string _site = TenderSettings.Site;
        private const string _email = TenderSettings.Email;
        private const string _userName = TenderSettings.UserName;
        private const string _password = TenderSettings.Password;
        private const string _apiKey = TenderSettings.ApiKey;

        TenderApi.TenderApi _testApi = new TenderApi.TenderApi(_site, _apiKey);

        #region User Tests
        [Test]
        public void Api_Key_Is_Valid()
        {
            bool result = _testApi.AuthenticationIsValid();

            Assert.IsTrue(result);
        }

        [Test]
        public void Invalid_Api_Fails()
        {
            TenderApi.TenderApi tapi = new TenderApi.TenderApi(_site, "ifthisworkssomethingiswrong");
            bool result = tapi.AuthenticationIsValid();

            Assert.IsFalse(result);
        }

        [Test]
        public void User_And_Password_Are_Valid()
        {

            TenderApi.TenderApi tapi = new TenderApi.TenderApi(_site, _email, _password);
            bool result = tapi.AuthenticationIsValid();

            Assert.IsTrue(result);
        }

        [Test]
        public void Invalid_Password_Fails()
        {
            TenderApi.TenderApi tapi = new TenderApi.TenderApi(_site, _email, "*3jfdsa#");
            bool result = tapi.AuthenticationIsValid();

            Assert.IsFalse(result);
        }

        [Test]
        public void Can_Get_Some_Users()
        {
            Assert.Greater(_testApi.GetUsers().Count, 0);
        }

        [Test]
        public void Can_Find_User()
        {
            User u = _testApi.FindUser(_email);

            Assert.AreEqual(_userName, u.name);
        }

        [Test]
        public void Can_Create_User()
        {
            User u = _testApi.CreateUser("test@test.com", "testtest", "testtest", name: "test", title: "that's right Test");
            Assert.AreEqual("test", u.name);
        }

        #endregion

        #region Category Tests

        [Test]
        public void Can_Get_Categories()
        {

            var cats = _testApi.GetCategories();
            Assert.Greater(cats.Count, 0);
        }

        #endregion

        #region Discussion Tests

        [Test]
        public void Can_Get_Discussions()
        {
            List<Discussion> discs = _testApi.GetDiscussions();
            Assert.Greater(discs.Count, 0);
        }

        [Test]
        public void Can_Get_Discussions_By_State()
        {
            Assert.Greater(_testApi.GetDiscussionByState(DiscussionState.Open).Count, 0);
        }

        [Test]
        public void Can_Get_Discussions_By_User_If_Discussion_Exists_For_That_User()
        {
            User u = _testApi.FindUser(_email);

            List<Discussion> discussions = _testApi.GetDiscussionsForUser(u.GetUserID());

            Assert.Greater(discussions.Count, 0);
        }

        [Test]
        public void Can_Get_Discussions_By_Email_If_Discussion_Exists_For_That_Email()
        {
            List<Discussion> discussions = _testApi.GetDiscussionsForEmail(_email);

            Assert.Greater(discussions.Count, 0);
        }

        private string discussion_title = "Api meet Create Discussion";
        [Test]
        public void Can_Create_Discussion()
        {
            List<Category> cats = _testApi.GetCategories();
            Category cat = cats.Find(c => c.name.ToUpper() == "Problems".ToUpper());

            bool r = _testApi.CreateDiscussion(cat.GetCategoryID(), discussion_title, _email, _userName, "Hi discussion, nice to meet you");

            Assert.True(r);
        }

        [Test]
        public void Can_Reply_To_Discussion()
        {
            Discussion discussion = _testApi.GetDiscussions().Find(d => d.title == discussion_title);           

            bool r = _testApi.ReplyToDiscussion(discussion.GetDiscussionID(), _userName, "This is a reply from the test api.");

            Assert.True(r);
        }

        [Test]
        public void Discussion_Actions_Work()
        {
            int id = _testApi.GetDiscussions().Find(d => d.title == discussion_title).GetDiscussionID();

            Assert.True(_testApi.DoDiscussionAction(id, DiscussionAction.Acknowledge));
            Assert.True(_testApi.DoDiscussionAction(id, DiscussionAction.Resolve));
            Assert.True(_testApi.DoDiscussionAction(id, DiscussionAction.Toggle));
            Assert.True(_testApi.DoDiscussionAction(id, DiscussionAction.Unresolve));
            Assert.False(_testApi.DoDiscussionAction(id, "thisisaninvalidaction"));
        }


        #endregion

        #region Queue Tests

        [Test]
        public void Can_Get_Queues()
        {
            List<Queue> q = _testApi.GetQueues();
            Assert.Greater(q.Count, 0);
        }

        #endregion

        #region Section Tests

        [Test]
        public void Can_Get_Sections()
        {
            List<Section> s = _testApi.GetSections();
            Assert.Greater(s.Count, 0);
        }

        #endregion

        #region FAQ Tests

        [Test]
        public void Can_Get_FAQs()
        {
            List<FAQ> faqs = _testApi.GetFAQs();
            Assert.Greater(faqs.Count, 0);
        }

        private string faq_title = "Faq test title";
        
        [Test]
        public void Can_Create_FAQ()
        {
            int sectionID = _testApi.GetSections()[0].GetSectionID();
            Assert.True(_testApi.CreateFAQ(sectionID, faq_title, new string[] { "abc", "body" },
                               "This is the test body to FAQ.", DateTime.Now));   
        }

        [Test]
        public void Update_FAQ()
        {

            List<FAQ> fs = _testApi.GetFAQs();
            int faqID = fs.FirstOrDefault().GetFAQID();

            string newTitle = string.Format("This new title was created at: {0}", DateTime.Now.ToUniversalTime());

            bool res = _testApi.UpdateFAQ(faqID, null, newTitle, new[]{"word"}, "a new body");

            FAQ newF = _testApi.GetFAQs().Find(f => f.GetFAQID() == faqID);

            Assert.True(res);
            Assert.AreEqual(newTitle, newF.title);

        }
        #endregion

        #region Comments Tests

        [Test]
        public void Can_Get_Comments()
        {
            List<Discussion> ds = _testApi.GetDiscussions();
            int dID = ds.FirstOrDefault().GetDiscussionID();

            List<Comment> c = _testApi.GetComments(dID);
            Assert.Greater(c.Count, 0);
        }
        #endregion
    }
}
