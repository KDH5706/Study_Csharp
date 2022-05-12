using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;

namespace WithPython
{
    class MainApp
    {
        static void Main(string[] args)
        {
            //ScriptEngine : 언어의 구문을 나타내는 일꾼. 코드를 실행하고, ScriptScope와 ScriptSource를 생성하는 방법을 제공
            ScriptEngine engine = Python.CreateEngine();

            //ScriptScope : 네임스페이스를 나타냄. ScriptScope 객체 안의 동적 언어 코드에서 사용하는 변수에 값을 대입 or 읽음
            ScriptScope scope = engine.CreateScope();

            scope.SetVariable("n", "박상현");
            scope.SetVariable("p", "010-123-4566");

            //ScriptSource : 소스 코드를 읽어들이는 여러 메소드와 읽어들인 소스 코드를 다양한 방법으로 실행하는 메소드를 제공
            ScriptSource source = engine.CreateScriptSourceFromString(
@"
class NameCard:
    name = ''
    phon = ''
    
    def __init__(self, name, phone) :
        self.name = name
        self.phone = phone

    def printNameCard(self) :
        print self.name + ', ' + self.phone

NameCard(n, p)    
"
            );

            dynamic result = source.Execute(scope); //파이썬 코드를 실행하여 결과를 반환, NameCard 객체가 반환됨.
            result.printNameCard(); //반환된 객체의 메소드를 호출할 수 있음.

            Console.WriteLine("{0}, {1}", result.name, result.phone);   //반환된 객체의 필드에 접근이 가능
        }
    }
}
