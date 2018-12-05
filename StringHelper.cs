using System;
using System.Data;
using Sigo.Dapper;
using System.Configuration;
using Newtonsoft.Json.Linq;

namespace Sigo.FIMS.BLL.Helper
{
    public class StringHelper
    {
        /// <summary>
        /// 
        /// </summary>
        private Repository quickRepository;

        /// <summary>
        /// 
        /// </summary>
        public Repository QuickRepository
        {
            get
            {
                if (quickRepository == null) quickRepository = new Repository();
                return quickRepository;
            }
        }

        /// <summary>
        /// (通用)生成单据编号。统一格式：前缀+年月日+4位字符，示例 YT1507010001
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="columnName">列名</param>
        /// <param name="prefix">前缀</param>
        /// <returns>返回单据编号</returns>
        public string GetBatchCodeForCreateTime(string tableName, string columnName, string prefix)
        {
            string batchCode = string.Empty;
            using (IDbConnection conn = SessionFactory.CreateConnection())
            {
                try
                {
                    string sql = string.Format("EXEC UP_GetBatchCodeForCreateTime '{0}', '{1}', '{2}'", tableName, columnName, prefix);
                    object obj = QuickRepository.ExecuteScalar(conn, sql);
                    if (obj != null)
                    {
                        batchCode = obj.ToString();
                    }
                }
                catch (Exception ex)
                {
                }
            }

            return batchCode;
        }


        /// <summary>
        /// (通用)生成单据编号。统一格式：前缀+年月日+4位字符，示例 YT1507010001
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="columnName">列名</param>
        /// <param name="prefix">前缀</param>
        /// <returns>返回单据编号</returns>
        public string GetBatchCode(string tableName, string columnName, string prefix)
        {
            string batchCode = string.Empty;
            using (IDbConnection conn = SessionFactory.CreateConnection())
            {
                try
                {
                    string sql = string.Format("EXEC UP_GetBatchCode '{0}', '{1}', '{2}'", tableName, columnName, prefix);
                    object obj = QuickRepository.ExecuteScalar(conn, sql);
                    if (obj != null)
                    {
                        batchCode = obj.ToString();
                    }
                }
                catch (Exception ex)
                {
                }
            }

            return batchCode;
        }

        /// <summary>
        /// (通用)生成单据编号。统一格式：前缀+年月日+4位字符，示例 YT2017070001
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="columnName">列名</param>
        /// <param name="prefix">前缀</param>
        /// <returns>返回单据编号</returns>
        public string GetMonthBatchCode(string tableName, string columnName, string prefix)
        {
            string batchCode = string.Empty;
            using (IDbConnection conn = SessionFactory.CreateConnection())
            {
                try
                {
                    string sql = string.Format("EXEC UP_GetMonthBatchCode '{0}', '{1}', '{2}'", tableName, columnName, prefix);
                    object obj = QuickRepository.ExecuteScalar(conn, sql);
                    if (obj != null)
                    {
                        batchCode = obj.ToString();
                    }
                }
                catch (Exception ex)
                {
                }
            }

            return batchCode;
        }

        public static string ToString(JToken token)
        {
            if (token != null)
            {
                return token.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        public static DateTime ToDateTime(JToken token)
        {
            if (token != null && token.ToString() != string.Empty)
            {
                return Convert.ToDateTime(token.ToString());
            }
            else
            {
                return Convert.ToDateTime("1900-01-01");
            }
        }

        public static bool ToBoolean(JToken token)
        {
            if (token != null && token.ToString() != string.Empty)
            {
                return Convert.ToBoolean(token.ToString());
            }
            else
            {
                return false;
            }
        }

        public static int ToInt32(JToken token)
        {
            if (token != null && token.ToString() != string.Empty)
            {
                return Convert.ToInt32(token.ToString());
            }
            else
            {
                return 0;
            }
        }

        public static decimal ToDecimal(JToken token)
        {
            if (token != null && token.ToString() != string.Empty)
            {
                return Convert.ToDecimal(token.ToString());
            }
            else
            {
                return 0.00m;
            }
        }

        public static long ToLong(JToken token)
        {
            if (token != null && token.ToString() != string.Empty)
            {
                return long.Parse(token.ToString());
            }
            else
            {
                return 0;
            }
        }
    }
}