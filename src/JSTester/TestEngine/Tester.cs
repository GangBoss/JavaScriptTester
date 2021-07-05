using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using JSTester.Extensions;
using JSTester.JSCommon;
using JSTester.TestEngine.Attributes;
using JSTester.TestEngine.Params;

namespace JSTester.TestEngine
{
    internal class Tester
    {
        delegate void Result<T>(T runner);
        //should be generated code
        public static string GetResult<T>(T runner, IJSTest<T> tester)
        {

            var result = new StringBuilder();
            var methods = GetTests(tester);

            foreach (var method in methods)
            {

                try
                {
                    ExecuteTestCaseSources(method, runner, tester, result);
                    ExecuteTestCases(method, runner, result);

                }
                catch (Exception e)
                {
                    //should be logger
                    result.Append(e.Message);

                }

            }

            return result.ToString();

        }

        private static int ExecuteTestCases<T>(MethodInfo method, T runner, StringBuilder stb)
        {
            var testCases = method.GetCustomAttributes(typeof(JSTestCase), false);
            foreach (var testCase in testCases)
            {
                var curCase = (JSTestCase)testCase;
                var result = GetTestResult(method, curCase.Arguments.GetArrayWithElementAtStart(runner));
                stb.Append(result.GetResultInfo(method.Name, curCase.Name));
            }

            return testCases.Length;
        }
        private static int ExecuteTestCaseSources<T>(MethodInfo method, T runner, IJSTest<T> tester, StringBuilder stb)
        {
            var testCaseSources = method.GetCustomAttributes(typeof(JSTestCaseSource), false);
            foreach (var testCaseSource in testCaseSources)
            {
                var source = (JSTestCaseSource)testCaseSource;
                var field = GetParamField(source.ParamName, tester);
                var par = (IEnumerable<object>)field.GetValue(tester);
                foreach (var currentCase in par)
                {
                    object[] testCase;
                    if (typeof(object[]) == currentCase.GetType())
                        testCase = (object[])currentCase;
                    else
                        testCase = new[] { currentCase };
                    {
                        var result = GetTestResult(method, (testCase).GetArrayWithElementAtStart(runner));
                        stb.Append(result.GetResultInfo(method.Name, source.Name));
                    }
                }
            }
            return testCaseSources.Length;
        }

        private static PropertyInfo GetParamField<T>(string sourceName, IJSTest<T> tester)
        {
            return tester.GetType().GetProperty(sourceName);
        }

        public static TestResult GetTestResult(MethodInfo method, object[] parameters)
        {
            try
            {
                method.Invoke(null, parameters);
            }
            catch (Exception ex)
            {
                var e = ex.InnerException;
                return new TestResult(false, e.Message);
            }
            return new TestResult(true);
        }

        public static IEnumerable<MethodInfo> GetTests<T>(IJSTest<T> tester)
        {
            return tester.GetType()
                .GetMethods()
                .Where(m => m.GetCustomAttributes(typeof(JSTest), false).Length > 0);
        }
    }
}
