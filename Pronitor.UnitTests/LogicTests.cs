using NUnit.Framework;
using System;
using Pronitor.Logic;
using System.Linq;

namespace Pronitor.UnitTests
{
    [TestFixture]
    public class ManagerTests
    {
        [TestCase("chromeBrowser", 2, 3)]
        [TestCase("TaskManagerWindow", 2, 4)]
        [TestCase("Name4", 6, 3)]
        [TestCase("Anything But Name|Name2|Name3", 2, 9)]
        public void Validator_UniqueNameWithNoLessThanZeroIntegers_ReturnsTrue(string name, int lifeTime, int frequency)
        {

            //Arange
            Manager.AddMonitor("Name", 1, 1, 'Q');
            Manager.AddMonitor("Name2", 1, 1, 'Q');
            Manager.AddMonitor("Name3", 1, 1, 'Q');
            Assert.IsTrue(Manager.Validator(name, frequency, lifeTime));
            Manager.DeleteMonitor();
        }


        [TestCase("Name", 2, 3)]
        [TestCase("Name2", 311, 2)]
        [TestCase("Name3", 32, 1)]
        public void Validator_NotUniqueName_ArgumentException(string name, int lifeTime, int frequency)
        {
            Manager.AddMonitor("Name", 1, 1, 'Q');
            Manager.AddMonitor("Name2", 1, 1, 'Q');
            Manager.AddMonitor("Name3", 1, 1, 'Q');
            Assert.Throws<ArgumentException>(() => Manager.Validator(name, lifeTime, frequency));
            Manager.DeleteMonitor();
        }


        [TestCase("chromeBrowser", -2, -3)]
        [TestCase("TaskManagerWindow", -6, 4)]
        [TestCase("Name4", 6, -3)]
        [TestCase("Anything But Name|Name2|Name3", 0, 0)]
        public void Validator_UniqueNameWithLessThanOrEqualZeroIntegers_ArgumentException(string name, int lifeTime, int frequency)
        {
            Assert.Throws<ArgumentException>(() => Manager.Validator(name, lifeTime, frequency));
            Manager.DeleteMonitor();
        }


        [TestCase("chromeBrowser", 2, 3, 'S')]
        [TestCase("TaskManagerWindow", 2, 4, 'F')]
        [TestCase("Name4", 6, 3, 'D')]
        [TestCase("Anything But Name|Name2|Name3", 2, 9, 'C')]
        public void AddMonitor_TryingToAddAMonitor_AddToMonitorList(string name, int lifeTime, int frequency, char killKey)
        {
            Manager.AddMonitor(name, lifeTime, frequency, killKey);
            Assert.IsTrue(Manager.monitoringList.Any(x => (x.Name.Equals(name) && x.LifeTime == lifeTime && x.Frequency == frequency && x.KillKey == killKey)));
            Manager.DeleteMonitor();
        }


        // No arguments passed, means clear all monitors
        [Test]
        public void DeleteMonitor_PassingNoArgument_ClearsAllMonitorsInList()
        {
            Manager.AddMonitor("TaskManagerWindow", 2, 4, 'F');
            Manager.DeleteMonitor();
            Assert.IsTrue(Manager.monitoringList.Count == 0);
        }


        [TestCase("chromeBrowser", 2, 3, 'S')]
        [TestCase("TaskManagerWindow", 2, 4, 'F')]
        [TestCase("Name4", 6, 3, 'D')]
        [TestCase("Anything But Name|Name2|Name3", 2, 9, 'C')]
        public void DeleteMonitor_DeletingAPassedMonitor_RemovePassedMonitor(string name, int lifeTime, int frequency, char killKey)
        {
            Manager.AddMonitor("Name", 1, 1, 'Q');
            Manager.AddMonitor(name, lifeTime, frequency, killKey);
            Manager.AddMonitor("Name2", 1, 1, 'Q');
            Manager.DeleteMonitor(name);
            Assert.IsFalse(Manager.monitoringList.Any(x => x.Name == name));
            Manager.DeleteMonitor();
        }


        [TestCase("chromeBrowser", 2, 3, 'S')]
        [TestCase("TaskManagerWindow", 2, 4, 'F')]
        [TestCase("Name4", 6, 3, 'D')]
        public void DeleteMonitor_DeletingAMonitorThatDoesntExist_Ignore(string name, int lifeTime, int frequency, char killKey)
        {
            Manager.DeleteMonitor(name);
            Assert.IsFalse(Manager.monitoringList.Any(x => x.Name == name));
            Manager.DeleteMonitor();
        }


        [TestCase("chromeBrowser", 2, 3, 'S')]
        [TestCase("TaskManagerWindow", 2, 4, 'F')]
        [TestCase("Name4", 6, 3, 'D')]
        public void KillTask_PassingNoArgument_ClearsAllTasksInMonitorList(string name, int lifeTime, int frequency, char killKey)
        {
            //case there is no tasks:
            Manager.AddMonitor(name, lifeTime, frequency, killKey);
            Manager.KillTask();
            var firstAnswer = Manager.monitoringList[0].tasks.Count == 0;

            //case there are tasks:
            Monitor newMonitor = new Monitor(name, lifeTime, frequency, killKey);
            newMonitor.tasks.Add(new Task(newMonitor, 1324));
            newMonitor.tasks.Add(new Task(newMonitor, 1325));
            newMonitor.tasks.Add(new Task(newMonitor, 1326));
            newMonitor.tasks.Add(new Task(newMonitor, 1329));
            Manager.KillTask();
            var secondAnswer = Manager.monitoringList[0].tasks.Count == 0;
            Assert.IsTrue(firstAnswer && secondAnswer);
            Manager.DeleteMonitor();
        }


        [TestCase("chromeBrowser", 2, 3, 'S')]
        [TestCase("TaskManagerWindow", 2, 4, 'F')]
        [TestCase("Name4", 6, 3, 'D')]
        public void DeleteMonitor_KillingAPassedTask_RemovePassedTaskInTheMonitor(string name, int lifeTime, int frequency, char killKey)
        {
            Monitor newMonitor = new Monitor(name, lifeTime, frequency, killKey);
            newMonitor.tasks.Add(new Task(newMonitor, 0));
            newMonitor.tasks.Add(new Task(newMonitor, 1));
            newMonitor.tasks.Add(new Task(newMonitor, 2));
            newMonitor.tasks.Add(new Task(newMonitor, 3));
            Manager.monitoringList.Add(newMonitor);
            Manager.KillTask(name);
            Assert.IsTrue(Manager.monitoringList[0].tasks.Count == 3);
            Manager.DeleteMonitor();
        }


        [TestCase("chromeBrowser", 2, 3, 'S')]
        [TestCase("TaskManagerWindow", 2, 4, 'F')]
        [TestCase("Name4", 6, 3, 'D')]
        public void KillTask_KillingATaskThatDoesntExist_Ignore(string name, int lifeTime, int frequency, char killKey)
        {
            Monitor newMonitor = new Monitor(name, lifeTime, frequency, killKey);
            Manager.monitoringList.Add(newMonitor);
            Manager.KillTask(name);
            Assert.IsTrue(Manager.monitoringList[0].tasks.Count == 0);
            Manager.DeleteMonitor();
        }
    }
}