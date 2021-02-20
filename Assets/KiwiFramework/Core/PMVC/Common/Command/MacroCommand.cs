using System.Collections;
using KiwiFramework.Core.Interface;

namespace KiwiFramework.Core
{
    /************************************************
     ***************** Example: *********************
     ************************************************
        public class LoginCommand : MacroCommand
        {
            protected override IEnumerator SubCommands()
            {
                yield return new Command2();
                yield return new Command1();
            }
        }
    */

    /// <summary>
    /// 多重指令
    /// </summary>
    public abstract class MacroCommand : Command
    {
        public override void Execute(INotice note)
        {
            var commands = SubCommands();

            while (commands.MoveNext())
            {
                if (commands.Current is ICommand current)
                {
                    current.Execute(note);
                }
            }
        }

        protected abstract IEnumerator SubCommands();
    }
}