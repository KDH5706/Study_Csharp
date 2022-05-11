using System;
using System.Reflection;
using System.Reflection.Emit;

namespace EmitTest
{
    public class MainApp
    {
        public static void Main()
        {
            AssemblyBuilder newAssembly =
                AssemblyBuilder.DefineDynamicAssembly(
                    new AssemblyName("CalculatorAssembly"), AssemblyBuilderAccess.Run); //1. AssemblyBuilder를 이용해서 어셈블리 생성

            ModuleBuilder newModule = newAssembly.DefineDynamicModule("Calculator");    //2. ModuleBuilder를 이용해서 어셈블리(1) 안에 모듈을 생성
            TypeBuilder newType = newModule.DefineType("Sum1To100");                    //3. 2에서 생성한 모듈 안에 클래스 생성

            MethodBuilder newMethod = newType.DefineMethod(
                "Calculate",
                MethodAttributes.Public,
                typeof(int),
                new Type[0]);                                                           //4. 3에서 생성한 클래스에 메서드or 프로퍼티 생성

            ILGenerator generator = newMethod.GetILGenerator();                         //5. 메서드를 생성했기 때문에 ILGenerator를 이용해서 CPU가 실행할 IL 명령을 삽입

            generator.Emit(OpCodes.Ldc_I4, 1);      //32비트 정수(1)를 계산 스택에 넣음.

            for (int i = 2; i <= 100; i++)
            {
                generator.Emit(OpCodes.Ldc_I4, i);  //32비트 정수(i)를 계산 스택에 넣음
                generator.Emit(OpCodes.Add);        //계산 후 계산 스택에 담겨 있는 두 개의 값을 꺼내서 더한 후, 그 결과를 다시 스택에 넣음
            }

            generator.Emit(OpCodes.Ret);            //계산 스택에 담겨 있는 값을 반환
            newType.CreateType();

            object sum1To100 = Activator.CreateInstance(newType);
            MethodInfo Calculate = sum1To100.GetType().GetMethod("Calculate");
            Console.WriteLine(Calculate.Invoke(sum1To100, null));
        }
    }
}
