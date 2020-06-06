using System;
using System.Collections.Generic;
using InteractiveLearningFramework.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InteractiveLearningFramework.Controllers
{
    public class QuizController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            return Ok(this.GetQuestion());
        }

        public List<QuestionVM> GetQuestion()
        {

            var questions = new List<QuestionVM>()
            {
                new QuestionVM
                {
                        QuestionID = 1,
                        QuestionText ="Which of the following is not the keyword in C++?",
                        Description="",
                        Choices = new List<ChoiceVM>()
                        {
                            new ChoiceVM()
                            {
                                ChoiceID = 1,
                                ChoiceText = "volatile"
                            },

                            new ChoiceVM()
                            {
                                ChoiceID = 2,
                                ChoiceText = "friend"
                            },
                            new ChoiceVM()
                            {
                                ChoiceID = 3,
                                ChoiceText = "extends"
                            },
                            new ChoiceVM()
                            {
                                ChoiceID = 4,
                                ChoiceText = "this"
                            }
                        }
                },
                 new QuestionVM
                {
                        QuestionID = 2,
                        QuestionText ="Which operator is having the right to left associativity in the following?",
                        Description="",
                        Choices = new List<ChoiceVM>()
                        {
                            new ChoiceVM()
                            {
                                ChoiceID = 1,
                                ChoiceText = "Array subscripting"
                            },

                            new ChoiceVM()
                            {
                                ChoiceID = 2,
                                ChoiceText = "Function call"
                            },
                            new ChoiceVM()
                            {
                                ChoiceID = 3,
                                ChoiceText = "Addition and subtraction"
                            },
                            new ChoiceVM()
                            {
                                ChoiceID = 4,
                                ChoiceText = "Type cast"
                            }
                        }
                },
                  new QuestionVM
                {
                        QuestionID = 3,
                        QuestionText ="Which operator is having the highest precedence??",
                        Description="",
                        Choices = new List<ChoiceVM>()
                        {
                            new ChoiceVM()
                            {
                                ChoiceID = 1,
                                ChoiceText = "postfix"
                            },

                            new ChoiceVM()
                            {
                                ChoiceID = 2,
                                ChoiceText = "unary"
                            },
                            new ChoiceVM()
                            {
                                ChoiceID = 3,
                                ChoiceText = "shift"
                            },
                            new ChoiceVM()
                            {
                                ChoiceID = 4,
                                ChoiceText = "equality"
                            }
                        }
                },
                   new QuestionVM
                {
                        QuestionID = 4,
                        QuestionText ="What is this operator called ?:?",
                        Description="",
                        Choices = new List<ChoiceVM>()
                        {
                            new ChoiceVM()
                            {
                                ChoiceID = 1,
                                ChoiceText = "conditional"
                            },

                            new ChoiceVM()
                            {
                                ChoiceID = 2,
                                ChoiceText = "relational"
                            },
                            new ChoiceVM()
                            {
                                ChoiceID = 3,
                                ChoiceText = "casting operator"
                            },
                            new ChoiceVM()
                            {
                                ChoiceID = 4,
                                ChoiceText = "none of the mentioned"
                            }
                        }
                },
                    new QuestionVM
                {
                        QuestionID = 5,
                        QuestionText ="What is the use of dynamic_cast operator?",
                        Description="",
                        Choices = new List<ChoiceVM>()
                        {
                            new ChoiceVM()
                            {
                                ChoiceID = 1,
                                ChoiceText = "it converts virtual base class to derived class"
                            },

                            new ChoiceVM()
                            {
                                ChoiceID = 2,
                                ChoiceText = "it converts the virtual base object to derived objects"
                            },
                            new ChoiceVM()
                            {
                                ChoiceID = 3,
                                ChoiceText = "it will convert the operator based on precedence"
                            },
                            new ChoiceVM()
                            {
                                ChoiceID = 4,
                                ChoiceText = "none of the mentioned"
                            }
                        }
                }
            };




            return questions;

        }


        public ActionResult GetTime()
        {
            var s = string.Format("{0:MMMM dd, yyyy HH:mm:ss}", DateTime.Now);
            var s1 = string.Format("{0:MMMM dd, yyyy HH:mm:ss}", DateTime.Now.AddMinutes(1));

            var obj = new { StartTime = s, EndDate = s1 };
            return Ok(obj);
        }
    }
}