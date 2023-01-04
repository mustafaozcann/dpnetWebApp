using System;
namespace dpNetWebApp.Models
{
	public class PatternModel
	{
        public PatternModel(string patternName, string whichProblemSolution, string content, byte[] codeExample, byte[] umlDiagram)
        {
            PatternName = patternName;
            WhichProblemSolution = whichProblemSolution;
            Content = content;
            CodeExample = codeExample;
            UmlDiagram = umlDiagram;
        }

        public string PatternName { get;}
        public string WhichProblemSolution { get; }
        public string Content { get;}
        public byte[] CodeExample { get;}
        public byte[] UmlDiagram { get;}


    }
}

