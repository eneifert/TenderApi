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
        private const string _site = "ritter";
        private const string _email = "ericn@ritterim.com";
        private const string _userName = "Ericn";
        private const string _password = "password";
        private const string _apiKey = "4857a21f7f401eedd5a8746a4e61f3ff0fe84a59";

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

            Assert.AreEqual("ericn", u.name);
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

            Assert.Greater(_testApi.GetCategories().Count, 0);
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
    }
}
