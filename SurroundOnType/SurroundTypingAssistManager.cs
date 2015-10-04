using JetBrains.DataFlow;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Feature.Services.TypingAssist;
using JetBrains.ReSharper.Psi;
using JetBrains.TextControl;

namespace SurroundOnType
{
    [SolutionComponent]
    public class SurroundTypingAssistManager : ITypingHandler
    {
        public SurroundTypingAssistManager(Lifetime lifetime, ITypingAssistManager typingAssistManager)
        {
            typingAssistManager.AddTypingHandler(lifetime, '{', this, HandleBrace);
            //typingAssistManager.AddActionHandler(lifetime, TextControlActions.ENTER_ACTION_ID, this, HandleEnterPressed);
        }

        private static bool HandleBrace(ITypingContext context)
        {
//            var document = context.TextControl.Document;
//            var line = context.TextControl.Caret.PositionValue.ToDocLineColumn().Line;
            context.TextControl.Document.InsertText(context.TextControl.Caret.Offset(), "{//test");
            return true;
        }

/*        private bool HandleEnterPressed(IActionContext context)
        {
            // See CSharpTypingAssistBase.HandleEnterPressed for more examples of what you can do here
            // e.g. retrieving the text control from context.TextControl, getting a lexer for the contents
            // of the file, inserting text and moving the caret

            var document = context.TextControl.Document;
            var line = context.TextControl.Caret.PositionValue.ToDocLineColumn().Line;
            var text = document.GetLineText(line);

            if (text.Contains("stop"))
            {
                // Return true to say that we've handled it. No other handlers will see this enter keypress
                return true;
            }

            if (text.Contains("after"))
            {
                // Let the other handlers have a go, and do something after they have (e.g. format what they inserted)
                // If we call CallNext, we *must* return true, or the remaining handlers in the chain will get called twice
                context.CallNext();
                context.TextControl.Document.InsertText(context.TextControl.Caret.Offset(), "inserted after");
                return true;
            }

            // Return false. We didn't handle it, let the other handlers have a go
            return false;
        }*/

        public bool QuickCheckAvailability(ITextControl textControl, IPsiSourceFile projectFile)
        {
            throw new System.NotImplementedException();
        }
    }
}