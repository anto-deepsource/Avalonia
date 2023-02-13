using System;
using Avalonia.Media.TextFormatting;
using Avalonia.VisualTree;

namespace Avalonia.Input.TextInput
{
    public interface ITextInputMethodClient
    {
        /// <summary>
        /// The cursor rectangle relative to the TextViewVisual
        /// </summary>
        Rect CursorRectangle { get; }
        /// <summary>
        /// Should be fired when cursor rectangle is changed inside the TextViewVisual
        /// </summary>
        event EventHandler? CursorRectangleChanged;
        /// <summary>
        /// The visual that's showing the text
        /// </summary>
        Visual TextViewVisual { get; }
        /// <summary>
        /// Should be fired when text-hosting visual is changed
        /// </summary>
        event EventHandler? TextViewVisualChanged;
        /// <summary>
        /// Indicates if TextViewVisual is capable of displaying non-committed input on the cursor position
        /// </summary>
        bool SupportsPreedit { get; }
        /// <summary>
        /// Sets the non-committed input string
        /// </summary>
        void SetPreeditText(string? text);

        /// <summary>
        /// Sets the current composing region. This doesn't remove the composing text from the commited text.
        /// </summary>
        void SetComposingRegion(TextRange? region);

        /// <summary>
        /// Indicates if text input client is capable of providing the text around the cursor
        /// </summary>
        bool SupportsSurroundingText { get; }
        /// <summary>
        /// Returns the text around the cursor, usually the current paragraph, the cursor position inside that text and selection start position
        /// </summary>
        TextInputMethodSurroundingText SurroundingText { get; }
        /// <summary>
        /// Should be fired when surrounding text changed
        /// </summary>
        event EventHandler? SurroundingTextChanged;

        /// <summary>
        /// Gets or sets a platform editable. Text and selection changes made in the editable are forwarded to the IM client.
        /// </summary>
        ITextEditable? TextEditable { get; set; }

        void SelectInSurroundingText(int start, int end);
    }

    public record struct TextInputMethodSurroundingText
    {
        public string Text { get; set; }
        public int CursorOffset { get; set; }
        public int AnchorOffset { get; set; }
    }
}
