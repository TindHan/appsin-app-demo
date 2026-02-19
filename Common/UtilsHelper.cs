using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace app_act.Common
{
    public class UtilsHelper
    {
        public async static Task<bool> resetToken(string aukey, string uid) //uid===psnPK
        {
            string res = await requestHelper.postRequest
            (
                    "/api/Appserv/resetToken",
                    "{\"aukey\":\"" + requestHelper.genAukey() + "\",\"args\":\"" + uid + "\"}"
                    );
            var resObj = JObject.Parse(res);
            if (resObj["status"].ToString().ToLower() == "success")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool checkUser(string uid)
        {
            if (uid != null || uid != "")
            {
                Bizcs.Model.act_psnmain psnModel = new Bizcs.BLL.act_psnmain().GetModel(uid);
                if (psnModel != null)
                {
                    if (psnModel.updateTime.AddHours(1) >= DateTime.Now)//one hour valid,timeout will be log out
                    {
                        psnModel.updateTime = DateTime.Now;
                        new Bizcs.BLL.act_psnmain().Update(psnModel);

                        //create new thread to reset platform token
                        Thread thread = new Thread(() => resetToken(uid));
                        thread.Start();
                        //end new thread

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            { return false; }

        }
        public static async void resetToken(string uid)
        {
           await requestHelper.postRequest(
                        "/api/Appserv/resetToken",
                        "{\"aukey\":\"" + requestHelper.genAukey() + "\",\"args\":\"" + uid + "\"}"
                        );
        }

        public static bool IsInteger(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;
            string trimmedInput = input.Trim();
            return int.TryParse(trimmedInput, out _);
        }

        #region safty detection
        // Regular expression patterns for SQL injection detection
        /* 1. Union-based injection */
        private static readonly Regex Union = new Regex(@"\bunion\s+(all\s+)?select\b", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        /* 2. DDL whole-word match */
        private static readonly Regex DDL = new Regex(
            @"\b(drop|alter|truncate|create)\s+(table|database|view|index|proc|procedure|function|trigger|schema)\b",
            RegexOptions.IgnoreCase | RegexOptions.Compiled);

        /* 3. DML matches only “keyword + space + table name (non-adjective)” */
        private static readonly Regex DML = new Regex(
            @"\b(delete|insert|update|grant|revoke)\s+[a-z][a-z0-9_]*\b(?!['""])",
            RegexOptions.IgnoreCase | RegexOptions.Compiled);

        /* 4. Dangerous extended stored procedure names */
        private static readonly Regex Xp = new Regex(
            @"\bxp_(cmdshell|regread|regwrite|loginconfig|enumgroups|fileexist|fixeddrives|dirtree|enumerrorlogs|getfiledetails|makecab|readerrorlog|sprintf|sqlmaint|sscanf|regdeletekey|regdeletevalue|regenumkeys|regenumvalues|servicecontrol|terminate_process)\b",
            RegexOptions.IgnoreCase | RegexOptions.Compiled);

        public static bool IsDangerous(string input) =>
            !string.IsNullOrWhiteSpace(input) &&
            (Union.IsMatch(input) || DDL.IsMatch(input) || DML.IsMatch(input) || Xp.IsMatch(input));

        // Regular expression pattern for XSS attack detection
        private static readonly Regex XssPattern = new Regex(
            @"<script\b[^>]*>.*?</script\s*>|" +
            @"<\s*(iframe|object|embed|form|input|button|svg|math)\b[^>]*>.*?</\s*\1\s*>|" +
            @"<\s*[^>]*?\b(" +
            @"javascript:|on\w+\s*=|data:\s*text/html|style\s*=\s*[^'""]*expression\(" +
            @")\b[^>]*>",
            RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline
        );

        /// <summary>
        /// Checks whether the input string contains dangerous characters indicative of SQL injection
        /// </summary>
        /// <param name="input">The string to be inspected</param>
        /// <returns>true if dangerous characters are detected; otherwise, false</returns>
        public static bool ContainsSqlInjectionRisk(string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;

            return IsDangerous(input);
        }

        /// <summary>
        /// Checks whether the input string contains XSS attack scripts
        /// </summary>
        /// <param name="input">The string to be inspected</param>
        /// <returns>true if attack scripts are detected; otherwise, false</returns>
        public static bool ContainsXssRisk(string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;

            return XssPattern.IsMatch(input);
        }

        /// <summary>
        /// Determines whether the input string is free of both SQL-injection and XSS risks
        /// </summary>
        /// <param name="input">The string to be inspected</param>
        /// <returns>true if the input is safe; false if any risk is found</returns>
        public static bool isSafe(string input)
        {
            return !(ContainsSqlInjectionRisk(input) || ContainsXssRisk(input));
        }

        /// <summary>
        /// Inspects the input string and returns the specific type of security risk detected
        /// </summary>
        /// <param name="input">The string to be inspected</param>
        /// <returns>A description of the risk type, or an empty string if no risk is found</returns>
        public static string GetSecurityRiskType(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            bool hasSqlRisk = ContainsSqlInjectionRisk(input);
            bool hasXssRisk = ContainsXssRisk(input);

            if (hasSqlRisk && hasXssRisk)
                return "Contains both SQL-injection and XSS risks";
            if (hasSqlRisk)
                return "Contains SQL-injection risk";
            if (hasXssRisk)
                return "Contains XSS risk";

            return string.Empty;
        }

        #endregion
    }
}
