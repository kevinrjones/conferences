using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAutomation.Interfaces;
using TechTalk.SpecFlow;

namespace TodoScenarios.Steps
{
    [Binding]
    public class TodoSteps : StepsBase
    {
        private void Login()
        {
            Func<IElement> elem = I.Find("a[href=signin]");
            IElement result = null;
            try
            {
                result = elem();
            }
            catch
            {
            }
            if (result != null)
            {
                I.Click(elem);
                I.WaitUntil(() => I.Expect.Exists("input#signin"));
            }
            //I.Enter("user").In("input#UserName");
            //I.Enter("password").In("input#Password");
            //I.Click("input[type='submit']");

        }

        [Given(@"I am authenticated")]
        public void GivenIAmAuthenticated()
        {
            I.Open("http://test.todo.com");
            Login();
        }


        [Given(@"I have entered a title")]
        public void GivenIHaveEnteredATitle()
        {
            I.Enter("Some Todo").In("form input[name='todoText']");
        }

        [Given(@"I have entered a date")]
        public void GivenIHaveEnteredADate()
        {
            DateTime today = DateTime.Now;
            I.Enter(today.ToShortDateString()).In("form input[name='todoDate']");
        }

        [When(@"I add the todo")]
        public void WhenIAddTheTodo()
        {
            I.Click("form input[name='todoAdd']");
        }

        [Then(@"the todo should be added to the list displayed")]
        public void ThenTheTodoShouldBeAddedToTheListDisplayed()
        {
            I.Expect.Count(1).Of("ul#todoList li");
        }

        [Then(@"the todo should be added to the list in the correct place")]
        public void ThenTheTodoShouldBeAddedToTheListInTheCorrectPlace()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I have a todo")]
        public void GivenIHaveATodo()
        {
            I.Open("http://test.todo.com");
            Login();
            GivenIHaveEnteredATitle();
            WhenIAddTheTodo();
        }

        [When(@"I remove the todo")]
        public void WhenIRemoveTheTodo()
        {
            I.WaitUntil(() => I.Find("div.todolist ul li:first button") != null);
            I.Wait(TimeSpan.FromMilliseconds(250));    
            I.Click(() => I.Find("div.todolist ul li:first button")());
        }

        [Then(@"the todo should be removed from the list displayed")]
        public void ThenTheTodoShouldBeRemovedFromTheListDisplayed()
        {
            I.Expect.Count(0).Of("ul#todoList li");
        }
    }
}

