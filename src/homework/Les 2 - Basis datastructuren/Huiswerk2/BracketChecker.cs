using System;

namespace AD
{
    public static class BracketChecker
    {
    /// <summary>
        ///    Run over all characters in a string, push all '(' characters
        ///    found on a stack. When ')' is found, it should match a '(' on
        ///    the stack, which is then popped.
        ///
        ///    If ')' is found when no '(' is on the stack, this method will
        ///    terminate prematurely, no further inspection is needed.
        /// </summary>
        /// <param name="s">The string to check</param>
        /// <returns>Returns True if all '(' are matched by ')'.
        /// Returns False otherwise.</returns>
        public static bool CheckBrackets(string s)
        {
			MyStack<char> stack = new MyStack<char>();
	        foreach (char t in s)
	        {
		        switch (t)
		        {
			        case '(':
				        stack.Push(t); // push all opening brackets (only opening brackets will be pushed on the stack)
				        break;
			        case ')' when stack.IsEmpty(): // if a closing bracket occurs when stack is empty there is no matching opening bracket so return false
				        return false;
			        case ')': // if a closing bracket occurs when stack is not empty, remove one opening bracket from the stack
				        stack.Pop();
				        break;
			        default: // if anything else occurs in the string, the string is invalid
				        throw new BracketCheckerInvalidInputException();
		        }
	        }

	        return stack.IsEmpty(); // if the stack ends up empty all opening brackets found a matching closing bracket so the result is true
        }


        /// <summary>
        ///    Run over all characters in a string, when an opening bracket is
		///    found the closing counterpart from closeChar is pushed on a Stack
        ///    When an closing bracket is found, it should match the top character
		///    from this stack.
		///    
        ///    This method will terminate prematurely if a wrong or missmatched
        ///    closing bracket is found and no further inspection is needed.
		/// </summary>
		/// <param name="s">The string to check</param>
		/// <returns>Returns True if all opening brackets are matched by
		/// it's correct counterpart in a correct order.
        /// Returns False otherwise.</returns>
        public static bool CheckBrackets2(string s)
        {
	        MyStack<char> stack = new MyStack<char>();

	        foreach (char t in s)
	        {
		        switch (t)
		        {
			        case '(': // if an opening bracket occurs, push its matching closing bracket
				        stack.Push(')');
				        break;
			        case '[': // if an opening square bracket occurs, push its matching square closing bracket
				        stack.Push(']');
				        break;
			        case '{': // if an opening moustache occurs, push its matching closing moustache
				        stack.Push('}');
				        break;
			        
			        // When a closing character occurs and this closing character is also on top of the stack remove it from the stack
			        case ')' when stack.Top().Equals(')'): 
			        case ']' when stack.Top().Equals(']'):
			        case '}' when stack.Top().Equals('}'):
				        stack.Pop();
				        break;
			        default:
				        return false;
		        }
	        }

	        return stack.IsEmpty();
        }

    }

    class BracketCheckerInvalidInputException : Exception
    {
    }

}
