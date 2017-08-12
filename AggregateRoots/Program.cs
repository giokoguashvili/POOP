using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AggregateRoots;

namespace ConsoleApp1
{
    public interface IEntity { }
    public interface IOpendTab : IEntity { }
    public interface IClosedTab : IEntity { }
    public interface ITabDefault : IEntity
    {
        Tab Opend(int tableNumber, string waiter);
        Tab Closed();
    }

    public class OpendTab : IOpendTab
    {
        private readonly int tableNumber;
        private readonly string waiter;

        public OpendTab(int tableNumber, string waiter)
        {
            this.tableNumber = tableNumber;
            this.waiter = waiter;
        }
    }
    public class ClosedTab : IClosedTab { }

    public class TabDefault : ITabDefault
    {
        public Tab Closed()
        {
            return new Tab(new ClosedTab());
        }
        public Tab Opend(int tableNumber, string waiter)
        {
            return new Tab(new OpendTab(tableNumber, waiter));
        }
    }

    public class TabAggregateRoot
    {
        private readonly int tabId;
        private readonly Tab Tab;

        public TabAggregateRoot(int tabId) : this(new Tab(tabId)) { }
        public TabAggregateRoot(Tab Tab)
        {
            this.Tab = Tab;
        }
        public Tab LastState()
        {
            //var snapshotFromDb = new { State = "Closed" };

            //if (snapshotFromDb.State == "Closed")
            //{
            //    return new Tab(new ClosedTab());
            //}
            //throw new Exception();
            return Tab;
        }

        public TabAggregateRoot Handle(OpenTab command)
        {
            return LastState()
                .Match(
                    (opendTab) => new TabAggregateRoot(
                                    new Tab(
                                        opendTab
                                    )
                             ),
                    (closedTab) => throw new Exception("Tab is closed"),
                    (tab) => new TabAggregateRoot(
                                   tab.Opend(command.TableNumber, command.Waiter)
                             )
                );
        }
    }

    public class Tab : Union<IOpendTab, IClosedTab, ITabDefault>
    {
        public Tab(int tabId) : base((IClosedTab)null)
        {

        }
        public Tab(IOpendTab t1) : base(t1)
        {
        }
        public Tab(IClosedTab t2) : base(t2)
        {
        }

        public Tab(ITabDefault t3) : base(t3)
        {
        }

        public Tab Apply(OpenTab command)
        {
            return this
                .Match(
                    (opendTab) => new Tab(opendTab),
                    (closedTab) => new Tab(closedTab),
                    (tab) => new Tab(tab)
                );
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            new TabAggregateRoot(127)
                .Handle(new OpenTab());

            new TabDefault()
                .Closed();
        }
    }

    public class OpenTab
    {
        public Guid Id;
        public int TableNumber;
        public string Waiter;
    }
}